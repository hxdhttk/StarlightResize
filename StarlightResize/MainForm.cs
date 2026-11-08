using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.Storage.Xps;

namespace StarlightResize
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ReloadDisplayList();
            ReloadProcessList();
        }

        private bool IsAspectRatioReversed => checkBoxReverseAspectRatio.Checked;

        private int LengthFactor => (int)numericUpDownLengthFactor.Value;

        private int WidthFactor => (int)numericUpDownWidthFactor.Value;

        private bool _updatingResolution;

        private RadioButton[] _radioButtonPosList =>
            new RadioButton[]
            {
                radioButtonPosLeftTop,
                radioButtonPosCenter,
                radioButtonPosRightTop,
                radioButtonPosLeftBottom,
                radioButtonPosRightBottom
            };

        private void ReloadDisplayList()
        {
            comboBoxDisplay.Items.Clear();
            foreach (var screen in Screen.AllScreens)
            {
                comboBoxDisplay.Items.Add(screen);
            }

            if (comboBoxDisplay.Items.Count > 0)
            {
                comboBoxDisplay.SelectedItem = Screen.FromControl(this);
                if (comboBoxDisplay.SelectedIndex < 0)
                    comboBoxDisplay.SelectedIndex = 0;
            }
        }

        private void ReloadProcessList(string? text = null)
        {
            comboBoxProcess.Items.Clear();

            var processes = Process
                .GetProcesses()
                .Where(p => p.Id != Environment.ProcessId)
                .Where(p => !string.IsNullOrEmpty(p.MainWindowTitle))
                .Select(
                    p =>
                        new ProcessItem()
                        {
                            Text = $"{p.ProcessName} | {p.MainWindowTitle}",
                            ProcessId = p.Id
                        }
                );

            foreach (var process in processes)
            {
                comboBoxProcess.Items.Add(process);
            }

            if (processes.Any())
            {
                if (text != null)
                {
                    for (int i = 0; i < comboBoxProcess.Items.Count; i++)
                    {
                        if ((comboBoxProcess.Items[i] as ProcessItem)?.Text == text)
                        {
                            comboBoxProcess.SelectedItem = comboBoxProcess.Items[i];
                            return;
                        }
                    }

                    comboBoxProcess.SelectedItem = comboBoxProcess.Items[0];
                }
                else
                {
                    comboBoxProcess.SelectedItem = comboBoxProcess.Items[0];
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ReloadProcessList((comboBoxProcess.SelectedItem as ProcessItem)?.Text);
        }

        private void radionButtonPos_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton?.Checked ?? false)
            {
                foreach (var item in _radioButtonPosList)
                {
                    item.Checked = item == radioButton;
                }
            }
        }

        private Process? GetTargetProcess()
        {
            var targetProcessItem = comboBoxProcess.SelectedItem as ProcessItem;

            Process? targetProcess = null;
            try
            {
                targetProcess = Process.GetProcessById(targetProcessItem?.ProcessId ?? -1);
            }
            catch
            {
                ReloadProcessList(targetProcessItem?.Text);
                try
                {
                    if (
                        targetProcessItem?.Text
                        != (comboBoxProcess.SelectedItem as ProcessItem)?.Text
                    )
                    {
                        return null;
                    }
                    else
                    {
                        targetProcessItem = comboBoxProcess.SelectedItem as ProcessItem;
                        targetProcess = Process.GetProcessById(targetProcessItem?.ProcessId ?? -1);
                    }
                }
                catch
                {
                    // Ignore all exceptions
                }
            }

            return targetProcess;
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            if (comboBoxDisplay.SelectedItem is not Screen screen)
            {
                MessageBox.Show(
                    "ディスプレイが指定されていません。\n先にウィンドウを表示するディスプレイを選択してください。",
                    "StarlightResize",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            var process = GetTargetProcess();
            if (process == null)
            {
                MessageBox.Show(
                    "ウィンドウが見つかりませんでした。\nアプリケーションが起動していることを確認してください。",
                    "StarlightResize",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var width = (int)numericUpDownWidth.Value;
            var height = (int)numericUpDownHeight.Value;

            var hWnd = (HWND)process.MainWindowHandle;
            PInvoke.GetWindowRect(hWnd, out var windowRect);
            PInvoke.GetClientRect(hWnd, out var clientRect);
            var screenPoint = new Point();
            PInvoke.ClientToScreen(hWnd, ref screenPoint);
            var windowWidth = windowRect.right - windowRect.left;
            var clientWidth = clientRect.right - clientRect.left;
            var frameWidth = windowWidth - clientWidth;
            var windowHeight = windowRect.bottom - windowRect.top;
            var clientHeight = clientRect.bottom - clientRect.top;
            var frameHeight = windowHeight - clientHeight;

            var newPoint = new Point() { X = screen.Bounds.X, Y = screen.Bounds.Y };
            if (radioButtonPosCenter.Checked)
            {
                // 中央寄せ
                newPoint.X += (screen.Bounds.Width - width) / 2;
                newPoint.Y += (screen.Bounds.Height - height) / 2;
            }
            else
            {
                if (radioButtonPosRightBottom.Checked || radioButtonPosLeftBottom.Checked)
                {
                    // 下寄せ
                    newPoint.Y += screen.Bounds.Height - height;
                }
                if (radioButtonPosRightTop.Checked || radioButtonPosRightBottom.Checked)
                {
                    // 右寄せ
                    newPoint.X += screen.Bounds.Width - width;
                }
            }
            newPoint.X += windowRect.left - screenPoint.X;
            newPoint.Y += windowRect.top - screenPoint.Y;

            // 違うDPIのモニタからウィンドウを移動するとデレステ側？でDPIの差分からのウィンドウサイズ補正がかかる
            // ので2回リサイズ処理を行う
            PInvoke.MoveWindow(
                hWnd,
                newPoint.X,
                newPoint.Y,
                width + frameWidth,
                height + frameHeight,
                true
            );
            PInvoke.MoveWindow(
                hWnd,
                newPoint.X,
                newPoint.Y,
                width + frameWidth,
                height + frameHeight,
                true
            );
        }

        private void SetResolution(int width, int height)
        {
            _updatingResolution = true;
            try
            {
                numericUpDownWidth.Value = Math.Clamp(width, numericUpDownWidth.Minimum, numericUpDownWidth.Maximum);
                numericUpDownHeight.Value = Math.Clamp(height, numericUpDownHeight.Minimum, numericUpDownHeight.Maximum);
            }
            finally
            {
                _updatingResolution = false;
            }
        }

        private void buttonSetResTo1280_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution((int)Math.Round(720m * WidthFactor / LengthFactor), 720);
            }
            else
            {
                SetResolution(1280, (int)Math.Round(1280m * WidthFactor / LengthFactor));
            }
        }

        private void buttonSetResTo1920_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution((int)Math.Round(1080m * WidthFactor / LengthFactor), 1080);
            }
            else
            {
                SetResolution(1920, (int)Math.Round(1920m * WidthFactor / LengthFactor));
            }
        }

        private void buttonSetResTo2560_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution((int)Math.Round(1440m * WidthFactor / LengthFactor), 1440);
            }
            else
            {
                SetResolution(2560, (int)Math.Round(2560m * WidthFactor / LengthFactor));
            }
        }

        private void buttonSetResTo3840_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution((int)Math.Round(2160m * WidthFactor / LengthFactor), 2160);
            }
            else
            {
                SetResolution(3840, (int)Math.Round(3840m * WidthFactor / LengthFactor));
            }
        }

        private void buttonSetResToDisplay_Click(object sender, EventArgs e)
        {
            SetResToDisplay(useScreenAspectRatio: true);
        }

        private void comboBoxDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResToDisplay(useScreenAspectRatio: true);
        }

        private void SetResToDisplay(bool useScreenAspectRatio = false)
        {
            if (comboBoxDisplay.SelectedItem is not Screen screen)
            {
                MessageBox.Show(
                    "ディスプレイが指定されていません。\n先にウィンドウを表示するディスプレイを選択してください。",
                    "StarlightResize",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (useScreenAspectRatio)
            {
                SetScreenAspectRatio(screen.Bounds.Size);
                return;
            }

            if (IsAspectRatioReversed)
            {
                SetResolution(
                    (int)Math.Round((decimal)screen.Bounds.Height * WidthFactor / LengthFactor),
                    screen.Bounds.Height
                );
            }
            else
            {
                SetResolution(
                    screen.Bounds.Width,
                    (int)Math.Round((decimal)screen.Bounds.Width * WidthFactor / LengthFactor)
                );
            }
        }

        private void SetScreenAspectRatio(Size resolution)
        {
            int width = resolution.Width, height = resolution.Height;
            int a = width, b = height;
            while (b != 0) (a, b) = (b, a % b);
            _updatingResolution = true;
            try
            {
                numericUpDownLengthFactor.Value = Math.Max(width, height) / a;
                numericUpDownWidthFactor.Value = Math.Min(width, height) / a;
                checkBoxReverseAspectRatio.Checked = height > width;
            }
            finally
            {
                _updatingResolution = false;
            }
            SetResolution(width, height);
        }

        private static string GetScreenshotFolder()
        {
            var picturesFolder = Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures,
                Environment.SpecialFolderOption.Create
            );
            var starlightResizePicturesFolder = picturesFolder + "\\StarlightResize";
            Directory.CreateDirectory(starlightResizePicturesFolder);
            return starlightResizePicturesFolder;
        }

        private async void buttonScreenShot_Click(object sender, EventArgs e)
        {
            // とりあえず保存先を作っておく
            var starlightResizePicturesFolder = GetScreenshotFolder();

            var process = GetTargetProcess();
            if (process == null)
            {
                MessageBox.Show(
                    "ウィンドウが見つかりませんでした。\nアプリケーションが起動していることを確認してください。",
                    "StarlightResize",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            var hWnd = (HWND)process.MainWindowHandle;
            PInvoke.GetClientRect(hWnd, out var clientRect);

            var isHdrEnabled = HdrHelper.IsHdrEnabledForWindow(hWnd);
            if (isHdrEnabled && OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17134))
            {
                var screenshotButton = (Button)sender;
                screenshotButton.Enabled = false;
                labelScreenShotState.Text = "HDR キャプチャ中…";
                string? jxrPath = null;
                try
                {
                    jxrPath = ScreenshotFileName.GetAvailablePath(starlightResizePicturesFolder, ".jxr", DateTime.Now);
                    bool keepExr = checkBoxKeepExr.Checked;
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        if (!OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17134))
                            throw new PlatformNotSupportedException();
                        var pixels = HdrCapture.Capture(hWnd, out int width, out int height);
                        JxrWriter.Write(jxrPath, width, height, pixels);
                        if (keepExr)
                        {
                            using var file = new FileStream(Path.ChangeExtension(jxrPath, ".exr"), FileMode.CreateNew, FileAccess.Write);
                            ExrWriter.Write(file, width, height, pixels);
                        }
                    });
                    labelScreenShotState.Text = $"{Path.GetFileName(jxrPath)} に保存しました。" + (keepExr ? " (EXR も保存)" : " (HDR)");
                }
                catch (Exception ex)
                {
                    bool jxrSaved = jxrPath != null && File.Exists(jxrPath);
                    labelScreenShotState.Text = jxrSaved
                        ? $"{Path.GetFileName(jxrPath)} は保存済みです。 (EXR 保存失敗)"
                        : "HDR キャプチャに失敗しました。";
                    MessageBox.Show(this, ex.Message, "HDR キャプチャ", MessageBoxButtons.OK,
                        jxrSaved ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
                }
                finally
                {
                    screenshotButton.Enabled = true;
                }
                return;
            }

            using var bitmap = new Bitmap(
                clientRect.right - clientRect.left,
                clientRect.bottom - clientRect.top,
                PixelFormat.Format24bppRgb
            );
            bool result;
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var dc = (HDC)graphics.GetHdc();
                try
                {
                    result = PInvoke.PrintWindow(
                        hWnd,
                        dc,
                        PRINT_WINDOW_FLAGS.PW_CLIENTONLY | (PRINT_WINDOW_FLAGS)PInvoke.PW_RENDERFULLCONTENT
                    );
                }
                finally
                {
                    graphics.ReleaseHdc(dc);
                }
            }
            if (!result)
            {
                labelScreenShotState.Text = "スクリーンショットの取得に失敗しました。";
                return;
            }

            // PrintWindow uses GDI and produces an SDR screenshot, even on HDR displays.
            byte[] imageData;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                imageData = stream.ToArray();
            }

            ClipboardInterop.SetClipboardData(bitmap);

            var path = ScreenshotFileName.GetAvailablePath(starlightResizePicturesFolder, ".png", DateTime.Now);
            using (var stream = new FileStream(path, FileMode.CreateNew))
            {
                stream.Write(imageData);
            }

            labelScreenShotState.Text = $"{Path.GetFileName(path)} に保存しました。";
        }

        private void buttonOpenScreenShotFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GetScreenshotFolder());
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_updatingResolution) return;
            var currentValue = numericUpDownWidth.Value;

            decimal heightValue;
            if (IsAspectRatioReversed)
            {
                heightValue = (currentValue / WidthFactor) * LengthFactor;
            }
            else
            {
                heightValue = (currentValue / LengthFactor) * WidthFactor;
            }

            SetResolution((int)currentValue, (int)Math.Round(heightValue));
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            if (_updatingResolution) return;
            var currentValue = numericUpDownHeight.Value;

            decimal widthValue;
            if (IsAspectRatioReversed)
            {
                widthValue = (currentValue / LengthFactor) * WidthFactor;
            }
            else
            {
                widthValue = (currentValue / WidthFactor) * LengthFactor;
            }

            SetResolution((int)Math.Round(widthValue), (int)currentValue);
        }

        private void checkBoxReverseAspectRatio_CheckStateChanged(object sender, EventArgs e)
        {
            if (!_updatingResolution) SetResToDisplay();
        }

        public class ProcessItem
        {
            public string Text { get; init; } = string.Empty;

            public int ProcessId { get; init; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
