
namespace StarlightResize
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
            System.Windows.Forms.Label labelDisplay;
            System.Windows.Forms.Label labelPos;
            System.Windows.Forms.Label labelRes;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRes;
            System.Windows.Forms.Label labelLength;
            System.Windows.Forms.Label labelMul;
            System.Windows.Forms.Label labelWidth;
            System.Windows.Forms.Button buttonSetResTo1280;
            System.Windows.Forms.Button buttonSetResTo1920;
            System.Windows.Forms.Button buttonSetResTo2560;
            System.Windows.Forms.Button buttonSetResTo3840;
            System.Windows.Forms.Button buttonSetResToDisplay;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelPos;
            System.Windows.Forms.Button buttonScreenShot;
            System.Windows.Forms.Button buttonOpenScreenShotFolder;
            comboBoxDisplay = new System.Windows.Forms.ComboBox();
            numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            labelProcess = new System.Windows.Forms.Label();
            flowLayoutPanelProcess = new System.Windows.Forms.FlowLayoutPanel();
            comboBoxProcess = new System.Windows.Forms.ComboBox();
            buttonRefresh = new System.Windows.Forms.Button();
            radioButtonPosLeftTop = new System.Windows.Forms.RadioButton();
            radioButtonPosLeftBottom = new System.Windows.Forms.RadioButton();
            radioButtonPosCenter = new System.Windows.Forms.RadioButton();
            radioButtonPosRightBottom = new System.Windows.Forms.RadioButton();
            radioButtonPosRightTop = new System.Windows.Forms.RadioButton();
            groupBoxControl = new System.Windows.Forms.GroupBox();
            labelFactorMul = new System.Windows.Forms.Label();
            labelWidthFactor = new System.Windows.Forms.Label();
            labelLengthFactor = new System.Windows.Forms.Label();
            numericUpDownWidthFactor = new System.Windows.Forms.NumericUpDown();
            numericUpDownLengthFactor = new System.Windows.Forms.NumericUpDown();
            checkBoxReverseAspectRatio = new System.Windows.Forms.CheckBox();
            buttonResize = new System.Windows.Forms.Button();
            labelScreenShotState = new System.Windows.Forms.Label();
            tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            labelDisplay = new System.Windows.Forms.Label();
            labelPos = new System.Windows.Forms.Label();
            labelRes = new System.Windows.Forms.Label();
            flowLayoutPanelRes = new System.Windows.Forms.FlowLayoutPanel();
            labelLength = new System.Windows.Forms.Label();
            labelMul = new System.Windows.Forms.Label();
            labelWidth = new System.Windows.Forms.Label();
            buttonSetResTo1280 = new System.Windows.Forms.Button();
            buttonSetResTo1920 = new System.Windows.Forms.Button();
            buttonSetResTo2560 = new System.Windows.Forms.Button();
            buttonSetResTo3840 = new System.Windows.Forms.Button();
            buttonSetResToDisplay = new System.Windows.Forms.Button();
            tableLayoutPanelPos = new System.Windows.Forms.TableLayoutPanel();
            buttonScreenShot = new System.Windows.Forms.Button();
            buttonOpenScreenShotFolder = new System.Windows.Forms.Button();
            tableLayoutPanelMain.SuspendLayout();
            flowLayoutPanelRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            flowLayoutPanelProcess.SuspendLayout();
            tableLayoutPanelPos.SuspendLayout();
            groupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidthFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLengthFactor).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelMain.AutoSize = true;
            tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMain.Controls.Add(comboBoxDisplay, 1, 0);
            tableLayoutPanelMain.Controls.Add(labelDisplay, 0, 0);
            tableLayoutPanelMain.Controls.Add(labelPos, 0, 4);
            tableLayoutPanelMain.Controls.Add(labelRes, 0, 2);
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelRes, 1, 2);
            tableLayoutPanelMain.Controls.Add(labelProcess, 0, 1);
            tableLayoutPanelMain.Controls.Add(flowLayoutPanelProcess, 1, 1);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelPos, 0, 4);
            tableLayoutPanelMain.Controls.Add(groupBoxControl, 1, 3);
            tableLayoutPanelMain.Location = new System.Drawing.Point(11, 9);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 5;
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelMain.Size = new System.Drawing.Size(682, 195);
            tableLayoutPanelMain.TabIndex = 23;
            // 
            // comboBoxDisplay
            // 
            comboBoxDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDisplay.FormattingEnabled = true;
            comboBoxDisplay.Location = new System.Drawing.Point(71, 3);
            comboBoxDisplay.Name = "comboBoxDisplay";
            comboBoxDisplay.Size = new System.Drawing.Size(605, 23);
            comboBoxDisplay.TabIndex = 3;
            // 
            // labelDisplay
            // 
            labelDisplay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelDisplay.AutoSize = true;
            labelDisplay.Location = new System.Drawing.Point(3, 7);
            labelDisplay.Name = "labelDisplay";
            labelDisplay.Size = new System.Drawing.Size(62, 15);
            labelDisplay.TabIndex = 4;
            labelDisplay.Text = "ディスプレイ:";
            // 
            // labelPos
            // 
            labelPos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelPos.AutoSize = true;
            labelPos.Location = new System.Drawing.Point(31, 165);
            labelPos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            labelPos.Name = "labelPos";
            labelPos.Size = new System.Drawing.Size(34, 15);
            labelPos.TabIndex = 13;
            labelPos.Text = "位置:";
            // 
            // labelRes
            // 
            labelRes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelRes.AutoSize = true;
            labelRes.Location = new System.Drawing.Point(19, 71);
            labelRes.Name = "labelRes";
            labelRes.Size = new System.Drawing.Size(46, 15);
            labelRes.TabIndex = 5;
            labelRes.Text = "解像度:";
            // 
            // flowLayoutPanelRes
            // 
            flowLayoutPanelRes.AutoSize = true;
            flowLayoutPanelRes.Controls.Add(labelLength);
            flowLayoutPanelRes.Controls.Add(numericUpDownWidth);
            flowLayoutPanelRes.Controls.Add(labelMul);
            flowLayoutPanelRes.Controls.Add(labelWidth);
            flowLayoutPanelRes.Controls.Add(numericUpDownHeight);
            flowLayoutPanelRes.Controls.Add(buttonSetResTo1280);
            flowLayoutPanelRes.Controls.Add(buttonSetResTo1920);
            flowLayoutPanelRes.Controls.Add(buttonSetResTo2560);
            flowLayoutPanelRes.Controls.Add(buttonSetResTo3840);
            flowLayoutPanelRes.Controls.Add(buttonSetResToDisplay);
            flowLayoutPanelRes.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanelRes.Location = new System.Drawing.Point(68, 64);
            flowLayoutPanelRes.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanelRes.Name = "flowLayoutPanelRes";
            flowLayoutPanelRes.Size = new System.Drawing.Size(611, 29);
            flowLayoutPanelRes.TabIndex = 6;
            flowLayoutPanelRes.WrapContents = false;
            // 
            // labelLength
            // 
            labelLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelLength.AutoSize = true;
            labelLength.Location = new System.Drawing.Point(0, 7);
            labelLength.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            labelLength.Name = "labelLength";
            labelLength.Size = new System.Drawing.Size(31, 15);
            labelLength.TabIndex = 7;
            labelLength.Text = "長辺";
            // 
            // numericUpDownWidth
            // 
            numericUpDownWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            numericUpDownWidth.Location = new System.Drawing.Point(37, 3);
            numericUpDownWidth.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDownWidth.Name = "numericUpDownWidth";
            numericUpDownWidth.Size = new System.Drawing.Size(56, 23);
            numericUpDownWidth.TabIndex = 1;
            numericUpDownWidth.Value = new decimal(new int[] { 1280, 0, 0, 0 });
            numericUpDownWidth.ValueChanged += numericUpDownWidth_ValueChanged;
            // 
            // labelMul
            // 
            labelMul.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelMul.AutoSize = true;
            labelMul.Location = new System.Drawing.Point(99, 7);
            labelMul.Name = "labelMul";
            labelMul.Size = new System.Drawing.Size(13, 15);
            labelMul.TabIndex = 6;
            labelMul.Text = "x";
            // 
            // labelWidth
            // 
            labelWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelWidth.AutoSize = true;
            labelWidth.Location = new System.Drawing.Point(118, 7);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new System.Drawing.Size(31, 15);
            labelWidth.TabIndex = 8;
            labelWidth.Text = "短辺";
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            numericUpDownHeight.Location = new System.Drawing.Point(155, 3);
            numericUpDownHeight.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new System.Drawing.Size(56, 23);
            numericUpDownHeight.TabIndex = 2;
            numericUpDownHeight.Value = new decimal(new int[] { 720, 0, 0, 0 });
            numericUpDownHeight.ValueChanged += numericUpDownHeight_ValueChanged;
            // 
            // buttonSetResTo1280
            // 
            buttonSetResTo1280.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonSetResTo1280.Location = new System.Drawing.Point(217, 3);
            buttonSetResTo1280.Name = "buttonSetResTo1280";
            buttonSetResTo1280.Size = new System.Drawing.Size(81, 23);
            buttonSetResTo1280.TabIndex = 9;
            buttonSetResTo1280.Text = "←長辺1280";
            buttonSetResTo1280.UseVisualStyleBackColor = true;
            buttonSetResTo1280.Click += buttonSetResTo1280_Click;
            // 
            // buttonSetResTo1920
            // 
            buttonSetResTo1920.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonSetResTo1920.Location = new System.Drawing.Point(304, 3);
            buttonSetResTo1920.Name = "buttonSetResTo1920";
            buttonSetResTo1920.Size = new System.Drawing.Size(57, 23);
            buttonSetResTo1920.TabIndex = 10;
            buttonSetResTo1920.Text = "←1920";
            buttonSetResTo1920.UseVisualStyleBackColor = true;
            buttonSetResTo1920.Click += buttonSetResTo1920_Click;
            // 
            // buttonSetResTo2560
            // 
            buttonSetResTo2560.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonSetResTo2560.Location = new System.Drawing.Point(367, 3);
            buttonSetResTo2560.Name = "buttonSetResTo2560";
            buttonSetResTo2560.Size = new System.Drawing.Size(57, 23);
            buttonSetResTo2560.TabIndex = 20;
            buttonSetResTo2560.Text = "←2560";
            buttonSetResTo2560.UseVisualStyleBackColor = true;
            buttonSetResTo2560.Click += buttonSetResTo2560_Click;
            // 
            // buttonSetResTo3840
            // 
            buttonSetResTo3840.Location = new System.Drawing.Point(430, 3);
            buttonSetResTo3840.Name = "buttonSetResTo3840";
            buttonSetResTo3840.Size = new System.Drawing.Size(57, 23);
            buttonSetResTo3840.TabIndex = 21;
            buttonSetResTo3840.Text = "←3840";
            buttonSetResTo3840.UseVisualStyleBackColor = true;
            buttonSetResTo3840.Click += buttonSetResTo3840_Click;
            // 
            // buttonSetResToDisplay
            // 
            buttonSetResToDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonSetResToDisplay.Location = new System.Drawing.Point(493, 3);
            buttonSetResToDisplay.Name = "buttonSetResToDisplay";
            buttonSetResToDisplay.Size = new System.Drawing.Size(115, 23);
            buttonSetResToDisplay.TabIndex = 11;
            buttonSetResToDisplay.Text = "←ディスプレイ解像度";
            buttonSetResToDisplay.UseVisualStyleBackColor = true;
            buttonSetResToDisplay.Click += buttonSetResToDisplay_Click;
            // 
            // labelProcess
            // 
            labelProcess.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelProcess.AutoSize = true;
            labelProcess.Location = new System.Drawing.Point(18, 39);
            labelProcess.Name = "labelProcess";
            labelProcess.Size = new System.Drawing.Size(47, 15);
            labelProcess.TabIndex = 23;
            labelProcess.Text = "プロセス:";
            // 
            // flowLayoutPanelProcess
            // 
            flowLayoutPanelProcess.AutoSize = true;
            flowLayoutPanelProcess.Controls.Add(comboBoxProcess);
            flowLayoutPanelProcess.Controls.Add(buttonRefresh);
            flowLayoutPanelProcess.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanelProcess.Location = new System.Drawing.Point(71, 32);
            flowLayoutPanelProcess.Name = "flowLayoutPanelProcess";
            flowLayoutPanelProcess.Size = new System.Drawing.Size(608, 29);
            flowLayoutPanelProcess.TabIndex = 27;
            // 
            // comboBoxProcess
            // 
            comboBoxProcess.FormattingEnabled = true;
            comboBoxProcess.Location = new System.Drawing.Point(3, 3);
            comboBoxProcess.Name = "comboBoxProcess";
            comboBoxProcess.Size = new System.Drawing.Size(521, 23);
            comboBoxProcess.TabIndex = 24;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new System.Drawing.Point(530, 3);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new System.Drawing.Size(75, 23);
            buttonRefresh.TabIndex = 25;
            buttonRefresh.Text = "再読み込み";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // tableLayoutPanelPos
            // 
            tableLayoutPanelPos.AutoSize = true;
            tableLayoutPanelPos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelPos.ColumnCount = 3;
            tableLayoutPanelPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelPos.Controls.Add(radioButtonPosLeftTop, 0, 0);
            tableLayoutPanelPos.Controls.Add(radioButtonPosLeftBottom, 0, 1);
            tableLayoutPanelPos.Controls.Add(radioButtonPosCenter, 1, 0);
            tableLayoutPanelPos.Controls.Add(radioButtonPosRightBottom, 2, 1);
            tableLayoutPanelPos.Controls.Add(radioButtonPosRightTop, 2, 0);
            tableLayoutPanelPos.Location = new System.Drawing.Point(68, 145);
            tableLayoutPanelPos.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelPos.Name = "tableLayoutPanelPos";
            tableLayoutPanelPos.RowCount = 2;
            tableLayoutPanelPos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelPos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelPos.Size = new System.Drawing.Size(165, 50);
            tableLayoutPanelPos.TabIndex = 22;
            // 
            // radioButtonPosLeftTop
            // 
            radioButtonPosLeftTop.AutoSize = true;
            radioButtonPosLeftTop.Location = new System.Drawing.Point(3, 3);
            radioButtonPosLeftTop.Name = "radioButtonPosLeftTop";
            radioButtonPosLeftTop.Size = new System.Drawing.Size(49, 19);
            radioButtonPosLeftTop.TabIndex = 14;
            radioButtonPosLeftTop.Text = "左上";
            radioButtonPosLeftTop.UseVisualStyleBackColor = true;
            radioButtonPosLeftTop.CheckedChanged += radionButtonPos_CheckedChanged;
            // 
            // radioButtonPosLeftBottom
            // 
            radioButtonPosLeftBottom.AutoSize = true;
            radioButtonPosLeftBottom.Location = new System.Drawing.Point(3, 28);
            radioButtonPosLeftBottom.Name = "radioButtonPosLeftBottom";
            radioButtonPosLeftBottom.Size = new System.Drawing.Size(49, 19);
            radioButtonPosLeftBottom.TabIndex = 17;
            radioButtonPosLeftBottom.Text = "左下";
            radioButtonPosLeftBottom.UseVisualStyleBackColor = true;
            radioButtonPosLeftBottom.CheckedChanged += radionButtonPos_CheckedChanged;
            // 
            // radioButtonPosCenter
            // 
            radioButtonPosCenter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            radioButtonPosCenter.AutoSize = true;
            radioButtonPosCenter.Checked = true;
            radioButtonPosCenter.Location = new System.Drawing.Point(58, 15);
            radioButtonPosCenter.Name = "radioButtonPosCenter";
            tableLayoutPanelPos.SetRowSpan(radioButtonPosCenter, 2);
            radioButtonPosCenter.Size = new System.Drawing.Size(49, 19);
            radioButtonPosCenter.TabIndex = 16;
            radioButtonPosCenter.TabStop = true;
            radioButtonPosCenter.Text = "中央";
            radioButtonPosCenter.UseVisualStyleBackColor = true;
            radioButtonPosCenter.CheckedChanged += radionButtonPos_CheckedChanged;
            // 
            // radioButtonPosRightBottom
            // 
            radioButtonPosRightBottom.AutoSize = true;
            radioButtonPosRightBottom.Location = new System.Drawing.Point(113, 28);
            radioButtonPosRightBottom.Name = "radioButtonPosRightBottom";
            radioButtonPosRightBottom.Size = new System.Drawing.Size(49, 19);
            radioButtonPosRightBottom.TabIndex = 18;
            radioButtonPosRightBottom.Text = "右下";
            radioButtonPosRightBottom.UseVisualStyleBackColor = true;
            radioButtonPosRightBottom.CheckedChanged += radionButtonPos_CheckedChanged;
            // 
            // radioButtonPosRightTop
            // 
            radioButtonPosRightTop.AutoSize = true;
            radioButtonPosRightTop.Location = new System.Drawing.Point(113, 3);
            radioButtonPosRightTop.Name = "radioButtonPosRightTop";
            radioButtonPosRightTop.Size = new System.Drawing.Size(49, 19);
            radioButtonPosRightTop.TabIndex = 15;
            radioButtonPosRightTop.Text = "右上";
            radioButtonPosRightTop.UseVisualStyleBackColor = true;
            radioButtonPosRightTop.CheckedChanged += radionButtonPos_CheckedChanged;
            // 
            // groupBoxControl
            // 
            groupBoxControl.Controls.Add(labelFactorMul);
            groupBoxControl.Controls.Add(labelWidthFactor);
            groupBoxControl.Controls.Add(labelLengthFactor);
            groupBoxControl.Controls.Add(numericUpDownWidthFactor);
            groupBoxControl.Controls.Add(numericUpDownLengthFactor);
            groupBoxControl.Controls.Add(checkBoxReverseAspectRatio);
            groupBoxControl.Location = new System.Drawing.Point(71, 96);
            groupBoxControl.Name = "groupBoxControl";
            groupBoxControl.Size = new System.Drawing.Size(220, 46);
            groupBoxControl.TabIndex = 28;
            groupBoxControl.TabStop = false;
            groupBoxControl.Text = "制御";
            // 
            // labelFactorMul
            // 
            labelFactorMul.AutoSize = true;
            labelFactorMul.Location = new System.Drawing.Point(129, 21);
            labelFactorMul.Name = "labelFactorMul";
            labelFactorMul.Size = new System.Drawing.Size(13, 15);
            labelFactorMul.TabIndex = 17;
            labelFactorMul.Text = "x";
            // 
            // labelWidthFactor
            // 
            labelWidthFactor.AutoSize = true;
            labelWidthFactor.Location = new System.Drawing.Point(143, 22);
            labelWidthFactor.Name = "labelWidthFactor";
            labelWidthFactor.Size = new System.Drawing.Size(19, 15);
            labelWidthFactor.TabIndex = 16;
            labelWidthFactor.Text = "短";
            // 
            // labelLengthFactor
            // 
            labelLengthFactor.AutoSize = true;
            labelLengthFactor.Location = new System.Drawing.Point(62, 23);
            labelLengthFactor.Name = "labelLengthFactor";
            labelLengthFactor.Size = new System.Drawing.Size(19, 15);
            labelLengthFactor.TabIndex = 15;
            labelLengthFactor.Text = "長";
            // 
            // numericUpDownWidthFactor
            // 
            numericUpDownWidthFactor.Location = new System.Drawing.Point(168, 17);
            numericUpDownWidthFactor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownWidthFactor.Name = "numericUpDownWidthFactor";
            numericUpDownWidthFactor.Size = new System.Drawing.Size(40, 23);
            numericUpDownWidthFactor.TabIndex = 14;
            numericUpDownWidthFactor.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // numericUpDownLengthFactor
            // 
            numericUpDownLengthFactor.Location = new System.Drawing.Point(87, 17);
            numericUpDownLengthFactor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownLengthFactor.Name = "numericUpDownLengthFactor";
            numericUpDownLengthFactor.Size = new System.Drawing.Size(40, 23);
            numericUpDownLengthFactor.TabIndex = 13;
            numericUpDownLengthFactor.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // checkBoxReverseAspectRatio
            // 
            checkBoxReverseAspectRatio.AutoSize = true;
            checkBoxReverseAspectRatio.Location = new System.Drawing.Point(6, 22);
            checkBoxReverseAspectRatio.Name = "checkBoxReverseAspectRatio";
            checkBoxReverseAspectRatio.Size = new System.Drawing.Size(50, 19);
            checkBoxReverseAspectRatio.TabIndex = 12;
            checkBoxReverseAspectRatio.Text = "反転";
            checkBoxReverseAspectRatio.UseVisualStyleBackColor = true;
            checkBoxReverseAspectRatio.CheckStateChanged += checkBoxReverseAspectRatio_CheckStateChanged;
            // 
            // buttonScreenShot
            // 
            buttonScreenShot.Location = new System.Drawing.Point(11, 240);
            buttonScreenShot.Name = "buttonScreenShot";
            buttonScreenShot.Size = new System.Drawing.Size(99, 23);
            buttonScreenShot.TabIndex = 24;
            buttonScreenShot.Text = "スクリーンショット";
            buttonScreenShot.UseVisualStyleBackColor = true;
            buttonScreenShot.Click += buttonScreenShot_Click;
            // 
            // buttonOpenScreenShotFolder
            // 
            buttonOpenScreenShotFolder.Location = new System.Drawing.Point(569, 240);
            buttonOpenScreenShotFolder.Name = "buttonOpenScreenShotFolder";
            buttonOpenScreenShotFolder.Size = new System.Drawing.Size(118, 23);
            buttonOpenScreenShotFolder.TabIndex = 25;
            buttonOpenScreenShotFolder.Text = "SSの保存場所を開く";
            buttonOpenScreenShotFolder.UseVisualStyleBackColor = true;
            buttonOpenScreenShotFolder.Click += buttonOpenScreenShotFolder_Click;
            // 
            // buttonResize
            // 
            buttonResize.Location = new System.Drawing.Point(11, 212);
            buttonResize.Name = "buttonResize";
            buttonResize.Size = new System.Drawing.Size(75, 23);
            buttonResize.TabIndex = 22;
            buttonResize.Text = "実行！";
            buttonResize.UseVisualStyleBackColor = true;
            buttonResize.Click += buttonResize_Click;
            // 
            // labelScreenShotState
            // 
            labelScreenShotState.AutoSize = true;
            labelScreenShotState.Location = new System.Drawing.Point(116, 244);
            labelScreenShotState.Name = "labelScreenShotState";
            labelScreenShotState.Size = new System.Drawing.Size(55, 15);
            labelScreenShotState.TabIndex = 26;
            labelScreenShotState.Text = "準備完了";
            labelScreenShotState.UseMnemonic = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(700, 272);
            Controls.Add(labelScreenShotState);
            Controls.Add(buttonOpenScreenShotFolder);
            Controls.Add(buttonScreenShot);
            Controls.Add(tableLayoutPanelMain);
            Controls.Add(buttonResize);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "StarlightResize";
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            flowLayoutPanelRes.ResumeLayout(false);
            flowLayoutPanelRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
            flowLayoutPanelProcess.ResumeLayout(false);
            tableLayoutPanelPos.ResumeLayout(false);
            tableLayoutPanelPos.PerformLayout();
            groupBoxControl.ResumeLayout(false);
            groupBoxControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidthFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLengthFactor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonPosLeftTop;
        private System.Windows.Forms.RadioButton radioButtonPosLeftBottom;
        private System.Windows.Forms.RadioButton radioButtonPosCenter;
        private System.Windows.Forms.RadioButton radioButtonPosRightBottom;
        private System.Windows.Forms.RadioButton radioButtonPosRightTop;
        private System.Windows.Forms.ComboBox comboBoxDisplay;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.CheckBox checkBoxReverseAspectRatio;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Label labelScreenShotState;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.ComboBox comboBoxProcess;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProcess;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.NumericUpDown numericUpDownWidthFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownLengthFactor;
        private System.Windows.Forms.Label labelWidthFactor;
        private System.Windows.Forms.Label labelLengthFactor;
        private System.Windows.Forms.Label labelFactorMul;
    }
}

