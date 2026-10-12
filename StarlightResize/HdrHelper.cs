using System;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;
using Windows.Win32.Graphics.Dxgi.Common;
using Windows.Win32.Graphics.Gdi;

namespace StarlightResize
{
    internal static class HdrHelper
    {
        /// <summary>
        /// Checks the current output color space of the monitor containing the window.
        /// Returns false when DXGI cannot report HDR status.
        /// </summary>
        public static unsafe bool IsHdrEnabledForWindow(HWND hWnd)
        {
            if (!OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17134))
                return false;

            var monitor = PInvoke.MonitorFromWindow(hWnd, MONITOR_FROM_FLAGS.MONITOR_DEFAULTTONEAREST);
            if (monitor == IntPtr.Zero)
                return false;

            try
            {
                // Use native COM pointers so detection also works with NativeAOT.
                if (PInvoke.CreateDXGIFactory1(IDXGIFactory1.IID_Guid, out void* factoryPointer).Failed)
                    return false;

                var factory = (IDXGIFactory1*)factoryPointer;
                try
                {
                    for (uint adapterIndex = 0; ; adapterIndex++)
                    {
                        IDXGIAdapter1* adapter;
                        if (factory->EnumAdapters1(adapterIndex, &adapter).Failed)
                            break;

                        try
                        {
                            for (uint outputIndex = 0; ; outputIndex++)
                            {
                                IDXGIOutput* output;
                                if (adapter->EnumOutputs(outputIndex, &output).Failed)
                                    break;

                                try
                                {
                                    if (output->GetDesc().Monitor != monitor)
                                        continue;

                                    if (output->QueryInterface(out IDXGIOutput6* output6).Failed)
                                        return false;

                                    try
                                    {
                                        // Bit depth alone does not distinguish HDR from SDR.
                                        return output6->GetDesc1().ColorSpace ==
                                            DXGI_COLOR_SPACE_TYPE.DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020;
                                    }
                                    finally
                                    {
                                        output6->Release();
                                    }
                                }
                                finally
                                {
                                    output->Release();
                                }
                            }
                        }
                        finally
                        {
                            adapter->Release();
                        }
                    }
                }
                finally
                {
                    factory->Release();
                }
            }
            catch (Exception ex) when (ex is COMException || ex is DllNotFoundException || ex is EntryPointNotFoundException)
            {
                // Detection is optional; unavailable DXGI must not prevent an SDR screenshot.
            }

            return false;
        }
    }
}
