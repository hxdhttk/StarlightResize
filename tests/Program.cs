using System;
using System.IO;
using System.Text;
using StarlightResize;

// Independent readback verifies the serialized header, channel order and scanline offsets.
float[] samples = { 4f, -.25f, 1.5f, 1f, 0f, .5f, 10f, 1f, -2f, 3f, 8f, 1f, .1f, .2f, .3f, 1f };
byte[] pixels = new byte[samples.Length * 2];
for (int i = 0; i < samples.Length; i++)
    BitConverter.GetBytes(BitConverter.HalfToUInt16Bits((Half)samples[i])).CopyTo(pixels, i * 2);
using var stream = new MemoryStream();
ExrWriter.Write(stream, 2, 2, pixels);
stream.Position = 0;
using var reader = new BinaryReader(stream);
void Check(bool condition) { if (!condition) throw new Exception("EXR validation failed at " + stream.Position); }
string Text() { var value = new StringBuilder(); byte b; while ((b = reader.ReadByte()) != 0) value.Append((char)b); return value.ToString(); }
Check(reader.ReadInt32() == 20000630 && reader.ReadInt32() == 2);
string name;
bool channels = false, luminance = false;
while ((name = Text()) != "") {
    string type = Text(); int size = reader.ReadInt32(); long end = stream.Position + size;
    if (name == "channels") {
        Check(type == "chlist");
        foreach (string channel in new[] { "A", "B", "G", "R" }) {
            Check(Text() == channel && reader.ReadInt32() == 1);
            reader.ReadInt32(); Check(reader.ReadInt32() == 1 && reader.ReadInt32() == 1);
        }
        Check(reader.ReadByte() == 0); channels = true;
    }
    if (name == "whiteLuminance") { Check(reader.ReadSingle() == 80f); luminance = true; }
    stream.Position = end;
}
Check(channels && luminance);
long[] offsets = { reader.ReadInt64(), reader.ReadInt64() };
for (int y = 0; y < 2; y++) {
    Check(stream.Position == offsets[y]);
    Check(reader.ReadInt32() == y && reader.ReadInt32() == 16);
    foreach (int channel in new[] { 3, 2, 1, 0 })
        for (int x = 0; x < 2; x++)
            Check(reader.ReadUInt16() == BitConverter.HalfToUInt16Bits((Half)samples[(y * 2 + x) * 4 + channel]));
}
Check(stream.Position == stream.Length);
try { ExrWriter.Write(new MemoryStream(), 0, 1, Array.Empty<byte>()); throw new Exception("Invalid dimensions accepted"); }
catch (ArgumentException) { }
Console.WriteLine("EXR readback passed: negative values, highlights, channel order, offsets and invalid dimensions.");

if (Array.IndexOf(args, "--ffmpeg") >= 0)
{
    string directory = Path.Combine(Path.GetTempPath(), "StarlightResize-test-" + Guid.NewGuid().ToString("N"));
    Directory.CreateDirectory(directory);
    try
    {
        string input = Path.Combine(directory, "HDR スクリーンショット test.exr");
        File.WriteAllBytes(input, stream.ToArray());
        try
        {
            await HdrAvifConverter.ConvertAsync(input, Path.Combine(directory, "missing-ffmpeg.exe"));
            throw new Exception("Missing executable was accepted");
        }
        catch (System.ComponentModel.Win32Exception) { }
        string output = await HdrAvifConverter.ConvertAsync(input);
        Check(File.Exists(input) && new FileInfo(output).Length > 0);
        byte[] original = File.ReadAllBytes(output);
        try
        {
            await HdrAvifConverter.ConvertAsync(input);
            throw new Exception("Existing output was overwritten");
        }
        catch (IOException) { }
        Check(Convert.ToHexString(File.ReadAllBytes(output)) == Convert.ToHexString(original));

        var probe = new System.Diagnostics.ProcessStartInfo("ffprobe")
        {
            UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true
        };
        foreach (string argument in new[] { "-v", "error", "-show_entries", "stream=pix_fmt,color_primaries,color_transfer,color_space", "-of", "json", output })
            probe.ArgumentList.Add(argument);
        using var process = System.Diagnostics.Process.Start(probe)!;
        string metadata = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();
        Check(process.ExitCode == 0 && metadata.Contains("yuv420p10le") && metadata.Contains("bt2020") && metadata.Contains("smpte2084"));

        string invalid = Path.Combine(directory, "invalid.exr");
        File.WriteAllText(invalid, "not an EXR");
        try
        {
            await HdrAvifConverter.ConvertAsync(invalid);
            throw new Exception("Invalid input was accepted");
        }
        catch (IOException) { }
        Check(File.Exists(invalid) && !File.Exists(Path.ChangeExtension(invalid, ".avif")));
        Check(Directory.GetFiles(directory, ".*.avif").Length == 0);
        Console.WriteLine("FFmpeg integration passed: HDR metadata, Unicode paths, missing FFmpeg, existing output and conversion failure cleanup.");
    }
    finally
    {
        foreach (string file in Directory.GetFiles(directory)) File.Delete(file);
        Directory.Delete(directory);
    }
}
