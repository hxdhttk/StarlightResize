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

string namingDirectory = Path.Combine(Path.GetTempPath(), "StarlightResize-names-" + Guid.NewGuid().ToString("N"));
Directory.CreateDirectory(namingDirectory);
try
{
    var timestamp = new DateTime(2026, 11, 8, 19, 20, 30);
    string first = ScreenshotFileName.GetAvailablePath(namingDirectory, ".exr", timestamp);
    Check(Path.GetFileName(first) == "20261108_192030.exr");
    File.WriteAllText(first, "reserved");
    for (int index = 1; index <= 12; index++)
    {
        string next = ScreenshotFileName.GetAvailablePath(namingDirectory, ".png", timestamp);
        Check(Path.GetFileName(next) == $"20261108_192030_{index}.png");
        File.WriteAllText(next, "reserved");
    }
    File.WriteAllText(Path.Combine(namingDirectory, "20261108_192030_13.jxr"), "reserved");
    Check(Path.GetFileName(ScreenshotFileName.GetAvailablePath(namingDirectory, ".exr", timestamp)) == "20261108_192030_14.exr");
    Console.WriteLine("Short filename validation passed: timestamp, mixed formats and more than ten collisions.");
}
finally
{
    foreach (string file in Directory.GetFiles(namingDirectory)) File.Delete(file);
    Directory.Delete(namingDirectory);
}
