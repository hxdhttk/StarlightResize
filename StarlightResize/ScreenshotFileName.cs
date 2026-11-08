using System;
using System.IO;

namespace StarlightResize;

internal static class ScreenshotFileName
{
    internal static string GetAvailablePath(string directory, string extension, DateTime timestamp)
    {
        string prefix = timestamp.ToString("yyyyMMdd_HHmmss");
        for (int index = 0; ; index++)
        {
            string stem = Path.Combine(directory, index == 0 ? prefix : $"{prefix}_{index}");
            // Keep HDR pairs together and avoid reusing the name of an existing screenshot.
            if (!File.Exists(stem + ".exr") && !File.Exists(stem + ".avif") && !File.Exists(stem + ".png"))
                return stem + extension;
        }
    }
}
