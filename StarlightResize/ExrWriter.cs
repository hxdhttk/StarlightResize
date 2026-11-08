using System;
using System.IO;
using System.Text;

namespace StarlightResize;

// Uncompressed scanline OpenEXR, linear scRGB HALF channels. No GDI+ conversion.
internal static class ExrWriter
{
    internal static void Write(Stream stream, int width, int height, byte[] rgba)
    {
        if (width <= 0 || height <= 0 || rgba.Length != checked(width * height * 8))
            throw new ArgumentException("Invalid HDR image dimensions.");
        using var writer = new BinaryWriter(stream, Encoding.ASCII, true);
        writer.Write(20000630);
        writer.Write(2);
        void Text(string value) { writer.Write(Encoding.ASCII.GetBytes(value)); writer.Write((byte)0); }
        void Attribute(string name, string type, Action<BinaryWriter> write)
        {
            using var data = new MemoryStream();
            using (var value = new BinaryWriter(data, Encoding.ASCII, true)) write(value);
            Text(name); Text(type); writer.Write((int)data.Length); writer.Write(data.ToArray());
        }
        Attribute("channels", "chlist", w => {
            foreach (var channel in new[] { "A", "B", "G", "R" }) {
                w.Write(Encoding.ASCII.GetBytes(channel)); w.Write((byte)0);
                w.Write(1); w.Write(0); w.Write(1); w.Write(1);
            }
            w.Write((byte)0);
        });
        Attribute("compression", "compression", w => w.Write((byte)0));
        void Window(BinaryWriter w) { w.Write(0); w.Write(0); w.Write(width - 1); w.Write(height - 1); }
        Attribute("dataWindow", "box2i", Window);
        Attribute("displayWindow", "box2i", Window);
        Attribute("lineOrder", "lineOrder", w => w.Write((byte)0));
        Attribute("pixelAspectRatio", "float", w => w.Write(1f));
        Attribute("screenWindowCenter", "v2f", w => { w.Write(0f); w.Write(0f); });
        Attribute("screenWindowWidth", "float", w => w.Write(1f));
        Attribute("chromaticities", "chromaticities", w => {
            foreach (float v in new[] { .64f, .33f, .30f, .60f, .15f, .06f, .3127f, .3290f }) w.Write(v);
        });
        // Windows scRGB defines 1.0 as 80 cd/m².
        Attribute("whiteLuminance", "float", w => w.Write(80f));
        writer.Write((byte)0);
        long start = stream.Position + height * 8L;
        for (int y = 0; y < height; y++) writer.Write(start + y * (8L + width * 8L));
        for (int y = 0; y < height; y++) {
            writer.Write(y); writer.Write(width * 8);
            foreach (int channel in new[] { 3, 2, 1, 0 })
                for (int x = 0; x < width; x++) {
                    int i = (y * width + x) * 8 + channel * 2;
                    writer.Write(rgba[i]); writer.Write(rgba[i + 1]);
                }
        }
    }
}
