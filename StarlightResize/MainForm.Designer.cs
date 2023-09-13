
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Button buttonSetResTo1280;
            System.Windows.Forms.Button buttonSetResTo1920;
            System.Windows.Forms.Button buttonSetResTo2560;
            System.Windows.Forms.Button buttonSetResTo3840;
            System.Windows.Forms.Button buttonSetResToDisplay;
            System.Windows.Forms.Button buttonScreenShot;
            System.Windows.Forms.Button buttonOpenScreenShotFolder;
            radioButtonPosLeftTop = new System.Windows.Forms.RadioButton();
            radioButtonPosLeftBottom = new System.Windows.Forms.RadioButton();
            radioButtonPosCenter = new System.Windows.Forms.RadioButton();
            radioButtonPosRightBottom = new System.Windows.Forms.RadioButton();
            radioButtonPosRightTop = new System.Windows.Forms.RadioButton();
            comboBoxDisplay = new System.Windows.Forms.ComboBox();
            numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            checkBoxReverseAspectRatio = new System.Windows.Forms.CheckBox();
            buttonResize = new System.Windows.Forms.Button();
            labelScreenShotState = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            buttonSetResTo1280 = new System.Windows.Forms.Button();
            buttonSetResTo1920 = new System.Windows.Forms.Button();
            buttonSetResTo2560 = new System.Windows.Forms.Button();
            buttonSetResTo3840 = new System.Windows.Forms.Button();
            buttonSetResToDisplay = new System.Windows.Forms.Button();
            buttonScreenShot = new System.Windows.Forms.Button();
            buttonOpenScreenShotFolder = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
            tableLayoutPanel1.Controls.Add(comboBoxDisplay, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(checkBoxReverseAspectRatio, 1, 2);
            tableLayoutPanel1.Location = new System.Drawing.Point(11, 9);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(679, 133);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.Controls.Add(radioButtonPosLeftTop, 0, 0);
            tableLayoutPanel2.Controls.Add(radioButtonPosLeftBottom, 0, 1);
            tableLayoutPanel2.Controls.Add(radioButtonPosCenter, 1, 0);
            tableLayoutPanel2.Controls.Add(radioButtonPosRightBottom, 2, 1);
            tableLayoutPanel2.Controls.Add(radioButtonPosRightTop, 2, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(68, 83);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(165, 50);
            tableLayoutPanel2.TabIndex = 22;
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
            // 
            // radioButtonPosCenter
            // 
            radioButtonPosCenter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            radioButtonPosCenter.AutoSize = true;
            radioButtonPosCenter.Checked = true;
            radioButtonPosCenter.Location = new System.Drawing.Point(58, 15);
            radioButtonPosCenter.Name = "radioButtonPosCenter";
            tableLayoutPanel2.SetRowSpan(radioButtonPosCenter, 2);
            radioButtonPosCenter.Size = new System.Drawing.Size(49, 19);
            radioButtonPosCenter.TabIndex = 16;
            radioButtonPosCenter.TabStop = true;
            radioButtonPosCenter.Text = "中央";
            radioButtonPosCenter.UseVisualStyleBackColor = true;
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
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "ディスプレイ:";
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(31, 88);
            label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(34, 15);
            label6.TabIndex = 13;
            label6.Text = "位置:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(19, 36);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 15);
            label2.TabIndex = 5;
            label2.Text = "解像度:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(numericUpDownWidth);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(numericUpDownHeight);
            flowLayoutPanel1.Controls.Add(buttonSetResTo1280);
            flowLayoutPanel1.Controls.Add(buttonSetResTo1920);
            flowLayoutPanel1.Controls.Add(buttonSetResTo2560);
            flowLayoutPanel1.Controls.Add(buttonSetResTo3840);
            flowLayoutPanel1.Controls.Add(buttonSetResToDisplay);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel1.Location = new System.Drawing.Point(68, 29);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(611, 29);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(0, 7);
            label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 15);
            label4.TabIndex = 7;
            label4.Text = "長辺";
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
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(99, 7);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(13, 15);
            label3.TabIndex = 6;
            label3.Text = "x";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(118, 7);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(31, 15);
            label5.TabIndex = 8;
            label5.Text = "短辺";
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
            // checkBoxReverseAspectRatio
            // 
            checkBoxReverseAspectRatio.AutoSize = true;
            checkBoxReverseAspectRatio.Location = new System.Drawing.Point(71, 61);
            checkBoxReverseAspectRatio.Name = "checkBoxReverseAspectRatio";
            checkBoxReverseAspectRatio.Size = new System.Drawing.Size(50, 19);
            checkBoxReverseAspectRatio.TabIndex = 12;
            checkBoxReverseAspectRatio.Text = "反転";
            checkBoxReverseAspectRatio.UseVisualStyleBackColor = true;
            checkBoxReverseAspectRatio.CheckStateChanged += checkBoxReverseAspectRatio_CheckStateChanged;
            // 
            // buttonScreenShot
            // 
            buttonScreenShot.Location = new System.Drawing.Point(11, 178);
            buttonScreenShot.Name = "buttonScreenShot";
            buttonScreenShot.Size = new System.Drawing.Size(99, 23);
            buttonScreenShot.TabIndex = 24;
            buttonScreenShot.Text = "スクリーンショット";
            buttonScreenShot.UseVisualStyleBackColor = true;
            buttonScreenShot.Click += buttonScreenShot_Click;
            // 
            // buttonOpenScreenShotFolder
            // 
            buttonOpenScreenShotFolder.Location = new System.Drawing.Point(569, 178);
            buttonOpenScreenShotFolder.Name = "buttonOpenScreenShotFolder";
            buttonOpenScreenShotFolder.Size = new System.Drawing.Size(118, 23);
            buttonOpenScreenShotFolder.TabIndex = 25;
            buttonOpenScreenShotFolder.Text = "SSの保存場所を開く";
            buttonOpenScreenShotFolder.UseVisualStyleBackColor = true;
            buttonOpenScreenShotFolder.Click += buttonOpenScreenShotFolder_Click;
            // 
            // buttonResize
            // 
            buttonResize.Location = new System.Drawing.Point(11, 148);
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
            labelScreenShotState.Location = new System.Drawing.Point(116, 182);
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
            ClientSize = new System.Drawing.Size(700, 213);
            Controls.Add(labelScreenShotState);
            Controls.Add(buttonOpenScreenShotFolder);
            Controls.Add(buttonScreenShot);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(buttonResize);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "StarlightResize";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
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
    }
}

