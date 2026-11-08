using System;
using System.IO;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Imaging;
using Windows.Win32.System.Com;
using Windows.Win32.System.Com.StructuredStorage;
using Windows.Win32.System.Variant;

namespace StarlightResize;

// WIC's floating-point JPEG XR format is linear scRGB, matching DXGI capture.
internal static unsafe class JxrWriter
{
    internal static void Write(string path, int width, int height, byte[] rgba)
    {
        if (width <= 0 || height <= 0 || rgba.Length != checked(width * height * 8))
            throw new ArgumentException("Invalid HDR image dimensions.");
        string temporary = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(path))!, $".{Guid.NewGuid():N}.jxr");
        try
        {
            using (new FileStream(temporary, FileMode.CreateNew)) { }
            Encode(temporary, width, height, rgba);
            File.Move(temporary, path); // Never overwrite an existing screenshot.
        }
        finally
        {
            if (File.Exists(temporary)) File.Delete(temporary);
        }
    }

    private static void Encode(string path, int width, int height, byte[] rgba)
    {
        var initialized = PInvoke.CoInitializeEx(COINIT.COINIT_MULTITHREADED);
        // An existing STA apartment can also use WIC; do not uninitialize it.
        if (initialized.Failed && initialized.Value != unchecked((int)0x80010106)) initialized.ThrowOnFailure();
        IWICImagingFactory* factory = null;
        IWICStream* stream = null;
        IWICBitmapEncoder* encoder = null;
        IWICBitmapFrameEncode* frame = null;
        IPropertyBag2* options = null;
        try
        {
            PInvoke.CoCreateInstance(PInvoke.CLSID_WICImagingFactory, null, CLSCTX.CLSCTX_INPROC_SERVER,
                IWICImagingFactory.IID_Guid, out void* pointer).ThrowOnFailure();
            factory = (IWICImagingFactory*)pointer;
            factory->CreateStream(&stream);
            stream->InitializeFromFilename(path, (uint)GENERIC_ACCESS_RIGHTS.GENERIC_WRITE);
            var container = PInvoke.GUID_ContainerFormatWmp;
            encoder = factory->CreateEncoder(&container, null);
            encoder->Initialize((IStream*)stream, WICBitmapEncoderCacheOption.WICBitmapEncoderNoCache);
            encoder->CreateNewFrame(&frame, &options);
            // ImageQuality=1 requests mathematically lossless JPEG XR encoding.
            fixed (char* name = "ImageQuality")
            {
                var property = new PROPBAG2 { pstrName = new PWSTR(name) };
                var value = new VARIANT();
                value.Anonymous.Anonymous.vt = VARENUM.VT_R4;
                value.Anonymous.Anonymous.Anonymous.fltVal = 1f;
                options->Write(1, &property, &value);
            }
            frame->Initialize(options);
            frame->SetSize((uint)width, (uint)height);
            frame->SetResolution(96, 96);
            var format = PInvoke.GUID_WICPixelFormat64bppRGBAHalf;
            frame->SetPixelFormat(ref format);
            if (format != PInvoke.GUID_WICPixelFormat64bppRGBAHalf)
                throw new InvalidOperationException("JPEG XR エンコーダーが HDR 浮動小数点形式をサポートしていません。");
            frame->WritePixels((uint)height, checked((uint)width * 8), rgba);
            frame->Commit();
            encoder->Commit();
        }
        finally
        {
            if (options != null) options->Release();
            if (frame != null) frame->Release();
            if (encoder != null) encoder->Release();
            if (stream != null) stream->Release();
            if (factory != null) factory->Release();
            if (initialized.Succeeded) PInvoke.CoUninitialize();
        }
    }
}
