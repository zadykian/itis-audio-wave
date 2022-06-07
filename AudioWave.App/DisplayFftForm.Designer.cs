namespace AudioWave.App;

partial class DisplayFftForm
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
            this.devicesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.transformedFormPlot = new ScottPlot.FormsPlot();
            this.eventLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.peakLabel = new System.Windows.Forms.Label();
            this.originalFormPlot = new ScottPlot.FormsPlot();
            this.startRenderButton = new System.Windows.Forms.Button();
            this.autoAxisOriginal = new System.Windows.Forms.CheckBox();
            this.OriginalLabel = new System.Windows.Forms.Label();
            this.transformedLabel = new System.Windows.Forms.Label();
            this.autoAxisTransformed = new System.Windows.Forms.CheckBox();
            this.SpectrogramBox = new System.Windows.Forms.PictureBox();
            this.SpectrogramLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrogramBox)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesComboBox
            // 
            this.devicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesComboBox.FormattingEnabled = true;
            this.devicesComboBox.Location = new System.Drawing.Point(151, 31);
            this.devicesComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(140, 23);
            this.devicesComboBox.TabIndex = 0;
            this.devicesComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeInputDevice);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Audio Device";
            // 
            // transformedFormPlot
            // 
            this.transformedFormPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transformedFormPlot.Location = new System.Drawing.Point(14, 375);
            this.transformedFormPlot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.transformedFormPlot.Name = "transformedFormPlot";
            this.transformedFormPlot.Size = new System.Drawing.Size(905, 228);
            this.transformedFormPlot.TabIndex = 2;
            // 
            // eventLoopTimer
            // 
            this.eventLoopTimer.Enabled = true;
            this.eventLoopTimer.Interval = 500;
            this.eventLoopTimer.Tick += new System.EventHandler(this.RenderAll);
            // 
            // peakLabel
            // 
            this.peakLabel.AutoSize = true;
            this.peakLabel.Location = new System.Drawing.Point(299, 34);
            this.peakLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.peakLabel.Name = "peakLabel";
            this.peakLabel.Size = new System.Drawing.Size(90, 15);
            this.peakLabel.TabIndex = 9;
            this.peakLabel.Text = "Peak Frequency";
            // 
            // originalFormPlot
            // 
            this.originalFormPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalFormPlot.Location = new System.Drawing.Point(14, 109);
            this.originalFormPlot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.originalFormPlot.Name = "originalFormPlot";
            this.originalFormPlot.Size = new System.Drawing.Size(905, 221);
            this.originalFormPlot.TabIndex = 13;
            // 
            // startRenderButton
            // 
            this.startRenderButton.Location = new System.Drawing.Point(810, 34);
            this.startRenderButton.Name = "startRenderButton";
            this.startRenderButton.Size = new System.Drawing.Size(90, 25);
            this.startRenderButton.TabIndex = 14;
            this.startRenderButton.Text = "Stop";
            this.startRenderButton.UseVisualStyleBackColor = true;
            this.startRenderButton.Click += new System.EventHandler(this.OnStartRenderPressed);
            // 
            // autoAxisOriginal
            // 
            this.autoAxisOriginal.AutoSize = true;
            this.autoAxisOriginal.Location = new System.Drawing.Point(194, 356);
            this.autoAxisOriginal.Name = "autoAxisOriginal";
            this.autoAxisOriginal.Size = new System.Drawing.Size(79, 19);
            this.autoAxisOriginal.TabIndex = 15;
            this.autoAxisOriginal.Text = "Auto-Axis";
            this.autoAxisOriginal.UseVisualStyleBackColor = true;
            // 
            // OriginalLabel
            // 
            this.OriginalLabel.AutoSize = true;
            this.OriginalLabel.Location = new System.Drawing.Point(66, 357);
            this.OriginalLabel.Name = "OriginalLabel";
            this.OriginalLabel.Size = new System.Drawing.Size(84, 15);
            this.OriginalLabel.TabIndex = 16;
            this.OriginalLabel.Text = "Original Signal";
            // 
            // transformedLabel
            // 
            this.transformedLabel.AutoSize = true;
            this.transformedLabel.Location = new System.Drawing.Point(66, 91);
            this.transformedLabel.Name = "transformedLabel";
            this.transformedLabel.Size = new System.Drawing.Size(108, 15);
            this.transformedLabel.TabIndex = 18;
            this.transformedLabel.Text = "Transformed Signal";
            // 
            // autoAxisTransformed
            // 
            this.autoAxisTransformed.AutoSize = true;
            this.autoAxisTransformed.Location = new System.Drawing.Point(194, 90);
            this.autoAxisTransformed.Name = "autoAxisTransformed";
            this.autoAxisTransformed.Size = new System.Drawing.Size(79, 19);
            this.autoAxisTransformed.TabIndex = 17;
            this.autoAxisTransformed.Text = "Auto-Axis";
            this.autoAxisTransformed.UseVisualStyleBackColor = true;
            // 
            // SpectrogramBox
            // 
            this.SpectrogramBox.Location = new System.Drawing.Point(66, 642);
            this.SpectrogramBox.Name = "SpectrogramBox";
            this.SpectrogramBox.Size = new System.Drawing.Size(834, 379);
            this.SpectrogramBox.TabIndex = 19;
            this.SpectrogramBox.TabStop = false;
            // 
            // SpectrogramLabel
            // 
            this.SpectrogramLabel.AutoSize = true;
            this.SpectrogramLabel.Location = new System.Drawing.Point(68, 615);
            this.SpectrogramLabel.Name = "SpectrogramLabel";
            this.SpectrogramLabel.Size = new System.Drawing.Size(75, 15);
            this.SpectrogramLabel.TabIndex = 20;
            this.SpectrogramLabel.Text = "Spectrogram";
            // 
            // DisplayFftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 1046);
            this.Controls.Add(this.SpectrogramLabel);
            this.Controls.Add(this.SpectrogramBox);
            this.Controls.Add(this.transformedLabel);
            this.Controls.Add(this.autoAxisTransformed);
            this.Controls.Add(this.OriginalLabel);
            this.Controls.Add(this.autoAxisOriginal);
            this.Controls.Add(this.startRenderButton);
            this.Controls.Add(this.originalFormPlot);
            this.Controls.Add(this.peakLabel);
            this.Controls.Add(this.transformedFormPlot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DisplayFftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display input signal";
            ((System.ComponentModel.ISupportInitialize)(this.SpectrogramBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox devicesComboBox;
    private System.Windows.Forms.Label label1;
    private ScottPlot.FormsPlot transformedFormPlot;
    private System.Windows.Forms.Timer eventLoopTimer;
    private System.Windows.Forms.Label peakLabel;
    private ScottPlot.FormsPlot originalFormPlot;
    private System.Windows.Forms.Button startRenderButton;
    private System.Windows.Forms.CheckBox autoAxisOriginal;
    private System.Windows.Forms.Label OriginalLabel;
    private System.Windows.Forms.Label transformedLabel;
    private System.Windows.Forms.CheckBox autoAxisTransformed;
    private System.Windows.Forms.PictureBox SpectrogramBox;
    private System.Windows.Forms.Label SpectrogramLabel;
}