namespace KeyerGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.boxEdited = new System.Windows.Forms.PictureBox();
            this.boxOriginal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.makeGreatImage = new System.Windows.Forms.Button();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorViewer = new System.Windows.Forms.Panel();
            this.colorPicker = new System.Windows.Forms.Button();
            this.thresholdBar = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.boxEdited)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBar)).BeginInit();
            this.SuspendLayout();
            // 
            // boxEdited
            // 
            this.boxEdited.Location = new System.Drawing.Point(795, 48);
            this.boxEdited.Name = "boxEdited";
            this.boxEdited.Size = new System.Drawing.Size(497, 461);
            this.boxEdited.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxEdited.TabIndex = 1;
            this.boxEdited.TabStop = false;
            // 
            // boxOriginal
            // 
            this.boxOriginal.Location = new System.Drawing.Point(12, 48);
            this.boxOriginal.Name = "boxOriginal";
            this.boxOriginal.Size = new System.Drawing.Size(497, 461);
            this.boxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxOriginal.TabIndex = 2;
            this.boxOriginal.TabStop = false;
            this.toolTip1.SetToolTip(this.boxOriginal, "Кликните в любое место по этому изображению чтобы указать какой цвет будет обраба" +
        "тываться");
            this.boxOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoxOriginal_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(191, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Оригинал";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(984, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Обработанное";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnOpenFile.Location = new System.Drawing.Point(588, 106);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(125, 48);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "Загрузить";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // makeGreatImage
            // 
            this.makeGreatImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.makeGreatImage.Location = new System.Drawing.Point(588, 295);
            this.makeGreatImage.Name = "makeGreatImage";
            this.makeGreatImage.Size = new System.Drawing.Size(125, 48);
            this.makeGreatImage.TabIndex = 6;
            this.makeGreatImage.Text = "Обработать";
            this.makeGreatImage.UseVisualStyleBackColor = true;
            this.makeGreatImage.Click += new System.EventHandler(this.MakeGreatImage_Click);
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnSaveOutput.Location = new System.Drawing.Point(588, 349);
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Size = new System.Drawing.Size(125, 48);
            this.btnSaveOutput.TabIndex = 7;
            this.btnSaveOutput.Text = "Сохранить";
            this.btnSaveOutput.UseVisualStyleBackColor = true;
            this.btnSaveOutput.Click += new System.EventHandler(this.BtnSaveOutput_Click);
            // 
            // colorViewer
            // 
            this.colorViewer.Location = new System.Drawing.Point(547, 170);
            this.colorViewer.Name = "colorViewer";
            this.colorViewer.Size = new System.Drawing.Size(147, 38);
            this.colorViewer.TabIndex = 8;
            // 
            // colorPicker
            // 
            this.colorPicker.BackColor = System.Drawing.SystemColors.Control;
            this.colorPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.colorPicker.Location = new System.Drawing.Point(700, 170);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(40, 38);
            this.colorPicker.TabIndex = 9;
            this.colorPicker.Text = "💉";
            this.toolTip1.SetToolTip(this.colorPicker, "Выбрать цвет для обработки");
            this.colorPicker.UseVisualStyleBackColor = false;
            this.colorPicker.Click += new System.EventHandler(this.ColorPicker_Click);
            // 
            // thresholdBar
            // 
            this.thresholdBar.Location = new System.Drawing.Point(547, 214);
            this.thresholdBar.Maximum = 160;
            this.thresholdBar.Minimum = 10;
            this.thresholdBar.Name = "thresholdBar";
            this.thresholdBar.Size = new System.Drawing.Size(193, 45);
            this.thresholdBar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.thresholdBar, "Определяет цветовой порог при котором будем делать схожие цвета прозрачными\r\nЧем " +
        "значение выше - тем больше цветов будет обрабатываться");
            this.thresholdBar.Value = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 521);
            this.Controls.Add(this.thresholdBar);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.colorViewer);
            this.Controls.Add(this.btnSaveOutput);
            this.Controls.Add(this.makeGreatImage);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxOriginal);
            this.Controls.Add(this.boxEdited);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Keyer";
            ((System.ComponentModel.ISupportInitialize)(this.boxEdited)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boxEdited;
        private System.Windows.Forms.PictureBox boxOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button makeGreatImage;
        private System.Windows.Forms.Button btnSaveOutput;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel colorViewer;
        private System.Windows.Forms.Button colorPicker;
        private System.Windows.Forms.TrackBar thresholdBar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

