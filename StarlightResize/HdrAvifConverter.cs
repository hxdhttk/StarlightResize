using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace StarlightResize;

internal static class HdrAvifConverter
{
    // The input is this application's linear scRGB EXR: 1.0 = 80 cd/m².
    internal static async Task<string> ConvertAsync(string exrPath, string? executable = null)
    {
        string output = Path.ChangeExtension(exrPath, ".avif");
        if (File.Exists(output))
            throw new IOException("AVIF ファイルは既に存在します。");

        string bundled = Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe");
        executable ??= File.Exists(bundled) ? bundled : "ffmpeg.exe";
        string temporary = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(output))!,
            $".{Guid.NewGuid():N}.avif");
        var start = new ProcessStartInfo(executable)
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardError = true
        };
        foreach (string argument in new[]
        {
            "-hide_banner", "-loglevel", "error", "-nostdin", "-n", "-i", Path.GetFullPath(exrPath),
            // Convert at full chroma resolution before padding; 4:2:0 needs even dimensions.
            // Preserve every original pixel and add at most one black row/column.
            "-vf", "format=gbrpf32le,zscale=pin=bt709:tin=linear:min=gbr:rin=full:p=bt2020:t=smpte2084:m=bt2020nc:r=limited:npl=80,format=yuv444p10le,pad=ceil(iw/2)*2:ceil(ih/2)*2:0:0:color=black,format=yuv420p10le",
            "-frames:v", "1", "-c:v", "libaom-av1", "-still-picture", "1", "-crf", "12", "-cpu-used", "6",
            "-color_primaries", "bt2020", "-color_trc", "smpte2084", "-colorspace", "bt2020nc", "-color_range", "tv", temporary
        })
            start.ArgumentList.Add(argument);

        try
        {
            using var process = Process.Start(start)
                ?? throw new IOException("FFmpeg を起動できませんでした。");
            Task<string> error = process.StandardError.ReadToEndAsync();
            using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            try
            {
                await process.WaitForExitAsync(timeout.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                if (!process.HasExited) process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync().ConfigureAwait(false);
                await error.ConfigureAwait(false);
                throw new TimeoutException("AVIF 変換がタイムアウトしました。");
            }

            string details = await error.ConfigureAwait(false);
            if (process.ExitCode != 0)
                throw new IOException($"FFmpeg 変換に失敗しました ({process.ExitCode})。\n{details.Trim()}");
            if (!File.Exists(temporary) || new FileInfo(temporary).Length == 0)
                throw new IOException("FFmpeg が AVIF 画像を出力しませんでした。");

            // Publish only a complete image, never overwrite an existing screenshot.
            File.Move(temporary, output);
            return output;
        }
        finally
        {
            if (File.Exists(temporary)) File.Delete(temporary);
        }
    }
}
