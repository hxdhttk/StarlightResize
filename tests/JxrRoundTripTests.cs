using System;
using System.IO;
using System.Reflection;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Imaging;
using Windows.Win32.System.Com;

internal static unsafe class JxrRoundTripTests
{
    internal static void Run()
    {
        var write = typeof(PInvoke).Assembly.GetType("StarlightResize.JxrWriter", true)
            .GetMethod("Write", BindingFlags.NonPublic | BindingFlags.Static);
        var init = PInvoke.CoInitializeEx(COINIT.COINIT_APARTMENTTHREADED);
        init.ThrowOnFailure();
        string directory = Path.Combine(Path.GetTempPath(), "StarlightResize-jxr-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            foreach (var size in new[] { (1, 1), (3, 5), (4, 4) })
            {
                byte[] rgba = new byte[size.Item1 * size.Item2 * 8];
                float[] values = { -.25f, .18f, 1f, 6f, 12.5f };
                for (int pixel = 0; pixel < size.Item1 * size.Item2; pixel++)
                    for (int channel = 0; channel < 4; channel++)
                        BitConverter.GetBytes(BitConverter.HalfToUInt16Bits((Half)(channel == 3 ? 1f : values[(pixel + channel) % values.Length]))).CopyTo(rgba, pixel * 8 + channel * 2);
                string path = Path.Combine(directory, $"HDR テスト {size.Item1}x{size.Item2}.jxr");
                write.Invoke(null, new object[] { path, size.Item1, size.Item2, rgba });
                IWICImagingFactory* factory = null;
                IWICBitmapDecoder* decoder = null;
                IWICBitmapFrameDecode* frame = null;
                try
                {
                    PInvoke.CoCreateInstance(PInvoke.CLSID_WICImagingFactory, null, CLSCTX.CLSCTX_INPROC_SERVER,
                        IWICImagingFactory.IID_Guid, out void* pointer).ThrowOnFailure();
                    factory = (IWICImagingFactory*)pointer;
                    decoder = factory->CreateDecoderFromFilename(path, null, GENERIC_ACCESS_RIGHTS.GENERIC_READ, WICDecodeOptions.WICDecodeMetadataCacheOnLoad);
                    decoder->GetFrame(0, &frame);
                    frame->GetSize(out uint width, out uint height);
                    frame->GetPixelFormat(out var format);
                    if (width != size.Item1 || height != size.Item2 || format != PInvoke.GUID_WICPixelFormat64bppRGBAHalf)
                        throw new Exception("JXR dimensions or floating-point pixel format changed.");
                    byte[] decoded = new byte[rgba.Length];
                    frame->CopyPixels(null, (uint)size.Item1 * 8, decoded);
                    if (!rgba.AsSpan().SequenceEqual(decoded))
                        throw new Exception("JXR lossless pixel roundtrip failed.");
                }
                finally
                {
                    if (frame != null) frame->Release();
                    if (decoder != null) decoder->Release();
                    if (factory != null) factory->Release();
                }
                byte[] original = File.ReadAllBytes(path);
                try { write.Invoke(null, new object[] { path, size.Item1, size.Item2, rgba }); throw new Exception("Existing image overwritten."); }
                catch (TargetInvocationException ex) when (ex.InnerException is IOException) { }
                if (!original.AsSpan().SequenceEqual(File.ReadAllBytes(path))) throw new Exception("Existing JXR changed.");
                if (Directory.GetFiles(directory, ".*.jxr").Length != 0) throw new Exception("Temporary JXR leaked.");
            }
            Console.WriteLine("Native WIC JXR tests passed: exact HALF pixel roundtrip, negative colors, HDR highlights, odd dimensions, Unicode paths and existing-file protection.");
        }
        finally
        {
            foreach (string file in Directory.GetFiles(directory)) File.Delete(file);
            Directory.Delete(directory);
            PInvoke.CoUninitialize();
        }
    }
}
