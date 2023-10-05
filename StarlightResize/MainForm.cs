﻿using System;
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
        }

        private string[] _targetProcesses =
        {
            "imascgstage",
            "twinkle_starknightsX"
        };

        private bool IsAspectRatioReversed => checkBoxReverseAspectRatio.Checked;

        private void ReloadDisplayList()
        {
            comboBoxDisplay.Items.Clear();
            foreach (var screen in Screen.AllScreens)
            {
                comboBoxDisplay.Items.Add(screen);
            }

            if (comboBoxDisplay.Items.Count > 0)
            {
                comboBoxDisplay.SelectedItem = comboBoxDisplay.Items[0];
                buttonSetResToDisplay_Click(this, default);
            }
        }

        private Process GetTargetProcess()
        {
            return _targetProcesses.SelectMany(Process.GetProcessesByName).FirstOrDefault();
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            var screen = comboBoxDisplay.SelectedItem as Screen;
            if (screen == null)
            {
                MessageBox.Show("ディスプレイが指定されていません。\n先にデレステを表示するディスプレイを選択してください。", "StarlightResize", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var process = GetTargetProcess();
            if (process == null)
            {
                MessageBox.Show("デレステのウィンドウが見つかりませんでした。\nデレステが起動していることを確認してください。", "StarlightResize", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var newPoint = new Point();
            newPoint.X = screen.Bounds.X;
            newPoint.Y = screen.Bounds.Y;
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
            PInvoke.MoveWindow(hWnd, newPoint.X, newPoint.Y, width + frameWidth, height + frameHeight, true);
            PInvoke.MoveWindow(hWnd, newPoint.X, newPoint.Y, width + frameWidth, height + frameHeight, true);
        }

        private void SetResolution(int width, int height)
        {
            numericUpDownWidth.Value = width;
            numericUpDownHeight.Value = height;
        }

        private void buttonSetResTo1280_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution(405, 720);
            }
            else
            {
                SetResolution(1280, 720);
            }
        }

        private void buttonSetResTo1920_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution(608, 1080);
            }
            else
            {
                SetResolution(1920, 1080);
            }
        }

        private void buttonSetResTo2560_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution(810, 1440);
            }
            else
            {
                SetResolution(2560, 1440);
            }
        }

        private void buttonSetResTo3840_Click(object sender, EventArgs e)
        {
            if (IsAspectRatioReversed)
            {
                SetResolution(1215, 2160);
            }
            else
            {
                SetResolution(3840, 2160);
            }
        }

        private void buttonSetResToDisplay_Click(object sender, EventArgs e)
        {
            var screen = comboBoxDisplay.SelectedItem as Screen;
            if (screen == null)
            {
                MessageBox.Show("ディスプレイが指定されていません。\n先にデレステを表示するディスプレイを選択してください", "StarlightResize", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsAspectRatioReversed)
            {
                SetResolution((screen.Bounds.Height / 16) * 9, screen.Bounds.Height);
            }
            else
            {
                SetResolution(screen.Bounds.Width, (screen.Bounds.Width / 16) * 9);
            }
        }

        private string getScreenshotFolder()
        {
            var picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures, Environment.SpecialFolderOption.Create);
            var starlightResizePicturesFolder = picturesFolder + "\\StarlightResize";
            Directory.CreateDirectory(starlightResizePicturesFolder);
            return starlightResizePicturesFolder;
        }

        private void buttonScreenShot_Click(object sender, EventArgs e)
        {
            // とりあえず保存先を作っておく
            // TODO: 保存先を変えられるようにする
            var starlightResizePicturesFolder = getScreenshotFolder();

            var process = GetTargetProcess();
            if (process == null)
            {
                MessageBox.Show("デレステのウィンドウが見つかりませんでした。\nデレステが起動していることを確認してください。", "StarlightResize", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var hWnd = (HWND)process.MainWindowHandle;
            PInvoke.GetClientRect(hWnd, out var clientRect);
            // 絶妙に黒に近い色がなんか透過色になってしまう (GIFじゃねーんだぞ)
            // ホーム画面に [吹きすさぶ青嵐] 渋谷凛 (特訓前) を指定して
            // その上に何らかのモーダル (お知らせとか) を重ねると吹き出しのあたりで再現する
            // とりあえず 24bpp にすることで #000000 になるので透過されてしまっているよりは目立ちにくいが
            // よ～く見るとわかってしまうのでそのうちなんとかしたい
            // というかそもそも Windows.Graphics.Capture API を使うべきである (かなり新しい Windows 10 でないと使えないが)
            using var bitmap = new Bitmap(clientRect.right - clientRect.left, clientRect.bottom - clientRect.top, PixelFormat.Format24bppRgb);
            var graphics = Graphics.FromImage(bitmap);
            var dc = (HDC)graphics.GetHdc();
            // Windows 7 だと PW_RENDERFULLCONTENT が使えないので動かないかも (いい加減 10 にしてください)
            // というかそもそも Windows.Graphics.Capture API を…
            bool result = PInvoke.PrintWindow(hWnd, dc, PRINT_WINDOW_FLAGS.PW_CLIENTONLY | (PRINT_WINDOW_FLAGS)PInvoke.PW_RENDERFULLCONTENT);
            graphics.ReleaseHdc(dc);
            graphics.Dispose();
            byte[] png;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                png = stream.ToArray();
            }

            string GetNotExistsFileName(string prefix, string suffix, int i = 0)
            {
                if (i > 9) throw new Exception("ファイル多すぎです");
                var path = i == 0 ? $"{prefix}{suffix}" : $"{prefix}_{i}{suffix}";
                if (!File.Exists(path)) return path;
                return GetNotExistsFileName(prefix, suffix, i + 1);
            }

            var path = GetNotExistsFileName($"{starlightResizePicturesFolder}\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}", ".png");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(png);
            }
            labelScreenShotState.Text = $"{Path.GetFileName(path)} に保存しました";
        }

        private void buttonOpenScreenShotFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getScreenshotFolder());
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            var currentValue = numericUpDownWidth.Value;

            decimal heightValue;
            if (IsAspectRatioReversed)
            {
                heightValue = (currentValue / 9) * 16;
            }
            else
            {
                heightValue = (currentValue / 16) * 9;
            }

            numericUpDownHeight.Value = heightValue;
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            var currentValue = numericUpDownHeight.Value;

            decimal widthValue;
            if (IsAspectRatioReversed)
            {
                widthValue = (currentValue / 16) * 9;
            }
            else
            {
                widthValue = (currentValue / 9) * 16;
            }

            numericUpDownWidth.Value = widthValue;
        }

        private void checkBoxReverseAspectRatio_CheckStateChanged(object sender, EventArgs e)
        {
            buttonSetResToDisplay_Click(sender, e);
        }
    }
}
