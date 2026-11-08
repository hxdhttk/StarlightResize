using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;
using Windows.Win32.Graphics.Dxgi.Common;
using Windows.Win32.Graphics.Direct3D;
using Windows.Win32.Graphics.Direct3D11;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.System.Com;

namespace StarlightResize;

[SupportedOSPlatform("windows10.0.17134")]
internal static unsafe class HdrCapture
{
    internal static byte[] Capture(HWND window, out int width, out int height)
    {
        if (PInvoke.IsIconic(window)) throw new InvalidOperationException("ウィンドウを最小化解除してください。");
        if (!PInvoke.GetClientRect(window, out var rect)) throw new InvalidOperationException("ウィンドウを取得できません。");
        var origin = new System.Drawing.Point(0, 0);
        if (!PInvoke.ClientToScreen(window, ref origin)) throw new InvalidOperationException("ウィンドウ位置を取得できません。");
        width = rect.right; height = rect.bottom;
        if (width <= 0 || height <= 0) throw new InvalidOperationException("ウィンドウのサイズが無効です。");
        var monitor = PInvoke.MonitorFromWindow(window, MONITOR_FROM_FLAGS.MONITOR_DEFAULTTONEAREST);
        PInvoke.CreateDXGIFactory1(IDXGIFactory1.IID_Guid, out void* pointer).ThrowOnFailure();
        var factory = (IDXGIFactory1*)pointer;
        try {
            for (uint a = 0; ; a++) {
                IDXGIAdapter1* adapter;
                if (factory->EnumAdapters1(a, &adapter).Failed) break;
                try {
                    for (uint o = 0; ; o++) {
                        IDXGIOutput* output;
                        if (adapter->EnumOutputs(o, &output).Failed) break;
                        try {
                            var desc = output->GetDesc();
                            if (desc.Monitor != monitor) continue;
                            if (desc.Rotation != DXGI_MODE_ROTATION.DXGI_MODE_ROTATION_IDENTITY)
                                throw new InvalidOperationException("HDR キャプチャは回転したディスプレイに未対応です。");
                            int x = origin.X - desc.DesktopCoordinates.left, y = origin.Y - desc.DesktopCoordinates.top;
                            if (x < 0 || y < 0 || (long)x + width > desc.DesktopCoordinates.right - desc.DesktopCoordinates.left ||
                                (long)y + height > desc.DesktopCoordinates.bottom - desc.DesktopCoordinates.top)
                                throw new InvalidOperationException("ウィンドウ全体を一つのディスプレイ内に移動してください。");
                            return CaptureOutput(adapter, output, x, y, width, height);
                        } finally { output->Release(); }
                    }
                } finally { adapter->Release(); }
            }
        } finally { factory->Release(); }
        throw new InvalidOperationException("ディスプレイが見つかりません。");
    }

    private static byte[] CaptureOutput(IDXGIAdapter1* adapter, IDXGIOutput* output, int x, int y, int width, int height)
    {
        ID3D11Device* device = null;
        ID3D11DeviceContext* context = null;
        IDXGIOutput6* output6 = null;
        IDXGIOutputDuplication* duplication = null;
        IDXGIResource* resource = null;
        ID3D11Texture2D* texture = null;
        ID3D11Texture2D* staging = null;
        bool acquired = false, mapped = false;
        try {
            PInvoke.D3D11CreateDevice((IDXGIAdapter*)adapter, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_UNKNOWN, default,
                0, null, 0, PInvoke.D3D11_SDK_VERSION, &device, null, &context).ThrowOnFailure();
            output->QueryInterface(out output6).ThrowOnFailure();
            try
            {
                output6->DuplicateOutput1((IUnknown*)device, 0,
                    new[] { DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT, DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM }, &duplication);
            }
            catch (COMException ex) when (ex.HResult == unchecked((int)0x887A0004))
            {
                // Older drivers can expose FP16 desktop frames through the original API.
                // The format check below still rejects any SDR conversion.
                output6->DuplicateOutput((IUnknown*)device, &duplication);
            }
            var deadline = Environment.TickCount64 + 3000;
            do
            {
                DXGI_OUTDUPL_FRAME_INFO info;
                try
                {
                    duplication->AcquireNextFrame(500, out info, &resource);
                }
                catch (COMException ex) when (ex.HResult == unchecked((int)0x887A0027))
                {
                    if (Environment.TickCount64 >= deadline)
                        throw new TimeoutException("デスクトップ画像を取得できませんでした。再試行してください。", ex);
                    continue;
                }
                acquired = true;
                // A successful AcquireNextFrame may report only a mouse update.
                // The initial resource can then be completely empty; wait for desktop pixels.
                if (info.LastPresentTime != 0) break;
                resource->Release(); resource = null;
                duplication->ReleaseFrame(); acquired = false;
                if (Environment.TickCount64 >= deadline)
                    throw new TimeoutException("デスクトップ画像を取得できませんでした。再試行してください。");
            } while (true);
            resource->QueryInterface(out texture).ThrowOnFailure();
            texture->GetDesc(out var desc);
            if (desc.Format != DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT)
                throw new InvalidOperationException("HDR 浮動小数点画像を取得できませんでした。HDR 設定を確認してください。");
            if ((long)x + width > desc.Width || (long)y + height > desc.Height)
                throw new InvalidOperationException("キャプチャ中に画面構成が変更されました。再試行してください。");
            desc.Width = (uint)width; desc.Height = (uint)height;
            desc.Usage = D3D11_USAGE.D3D11_USAGE_STAGING;
            desc.BindFlags = 0; desc.MiscFlags = 0;
            desc.CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_READ;
            device->CreateTexture2D(&desc, null, &staging);
            var box = new D3D11_BOX { left = (uint)x, top = (uint)y, right = (uint)(x + width), bottom = (uint)(y + height), front = 0, back = 1 };
            context->CopySubresourceRegion((ID3D11Resource*)staging, 0, 0, 0, 0, (ID3D11Resource*)texture, 0, &box);
            context->Map((ID3D11Resource*)staging, 0, D3D11_MAP.D3D11_MAP_READ, 0, out var data);
            mapped = true;
            var pixels = new byte[checked(width * height * 8)];
            for (int row = 0; row < height; row++)
                Marshal.Copy((IntPtr)((byte*)data.pData + row * (long)data.RowPitch), pixels, row * width * 8, width * 8);
            return pixels;
        } finally {
            if (mapped) context->Unmap((ID3D11Resource*)staging, 0);
            if (staging != null) staging->Release();
            if (texture != null) texture->Release();
            if (resource != null) resource->Release();
            if (acquired) duplication->ReleaseFrame();
            if (duplication != null) duplication->Release();
            if (output6 != null) output6->Release();
            if (context != null) context->Release();
            if (device != null) device->Release();
        }
    }
}
