using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;

internal static class GpuCaptureTests
{
    [STAThread]
    private static void Main(string[] arguments)
    {
        JxrRoundTripTests.Run();
        if (Array.IndexOf(arguments, "--gpu") < 0) return;
        var assembly = typeof(PInvoke).Assembly;
        var capture = assembly.GetType("StarlightResize.HdrCapture", true)
            .GetMethod("Capture", BindingFlags.NonPublic | BindingFlags.Static);
        var writer = assembly.GetType("StarlightResize.ExrWriter", true)
            .GetMethod("Write", BindingFlags.NonPublic | BindingFlags.Static);
        using var form = new Form
        {
            ClientSize = new Size(320, 200), TopMost = true,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Left + 40, Screen.PrimaryScreen.WorkingArea.Top + 40),
            Text = "HDR capture pixel validation"
        };
        form.Show();
        var hdr = assembly.GetType("StarlightResize.HdrHelper", true)
            .GetMethod("IsHdrEnabledForWindow", BindingFlags.Public | BindingFlags.Static);
        bool found = false;
        foreach (var screen in Screen.AllScreens)
        {
            form.Location = new Point(screen.WorkingArea.Left + 40, screen.WorkingArea.Top + 40);
            Application.DoEvents();
            if ((bool)hdr.Invoke(null, new object[] { new HWND(form.Handle) })) { found = true; break; }
        }
        if (!found) throw new Exception("Enable HDR on at least one monitor to run this GPU test.");
        foreach (var sample in new[] { (Color.Red, 0), (Color.Lime, 1), (Color.Blue, 2) })
        {
            form.BackColor = sample.Item1;
            form.Refresh();
            Application.DoEvents();
            Thread.Sleep(150);
            object[] args = { new HWND(form.Handle), 0, 0 };
            byte[] pixels;
            try { pixels = (byte[])capture.Invoke(null, args); }
            catch (TargetInvocationException ex) { throw new Exception("HDR GPU capture requires an accessible HDR desktop.", ex.InnerException); }
            if ((int)args[1] != 320 || (int)args[2] != 200) throw new Exception("Wrong capture dimensions.");
            int center = (100 * 320 + 160) * 8;
            float Channel(int c) => (float)BitConverter.UInt16BitsToHalf(BitConverter.ToUInt16(pixels, center + c * 2));
            float primary = Channel(sample.Item2);
            if (!float.IsFinite(primary) || primary < .1f ||
                primary < Channel((sample.Item2 + 1) % 3) * 4 ||
                primary < Channel((sample.Item2 + 2) % 3) * 4 || Channel(3) < .9f)
                throw new Exception($"Wrong {sample.Item1} pixel: {Channel(0)}, {Channel(1)}, {Channel(2)}, {Channel(3)}");
            using var exr = new MemoryStream();
            writer.Invoke(null, new object[] { exr, 320, 200, pixels });
            Console.WriteLine($"{sample.Item1}: center RGBA = {Channel(0)}, {Channel(1)}, {Channel(2)}, {Channel(3)}; EXR serialized.");
        }
        Console.WriteLine("HDR capture pixel validation passed.");
    }
}
