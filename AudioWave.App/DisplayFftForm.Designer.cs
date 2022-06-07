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
            this.transformedGraphPlot = new ScottPlot.FormsPlot();
            this.eventLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.cbAutoAxis = new System.Windows.Forms.CheckBox();
            this.peakLabel = new System.Windows.Forms.Label();
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
            // formsPlot1
            // 
            this.transformedGraphPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transformedGraphPlot.Location = new System.Drawing.Point(14, 60);
            this.transformedGraphPlot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.transformedGraphPlot.Name = "transformedGraphPlot";
            this.transformedGraphPlot.Size = new System.Drawing.Size(905, 445);
            this.transformedGraphPlot.TabIndex = 2;
            // 
            // eventLoopTimer
            // 
            this.eventLoopTimer.Enabled = true;
            this.eventLoopTimer.Interval = 50;
            this.eventLoopTimer.Tick += new System.EventHandler(this.RunSingleIteration);
            // 
            // cbAutoAxis
            // 
            this.cbAutoAxis.AutoSize = true;
            this.cbAutoAxis.Checked = true;
            this.cbAutoAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoAxis.Location = new System.Drawing.Point(310, 33);
            this.cbAutoAxis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbAutoAxis.Name = "cbAutoAxis";
            this.cbAutoAxis.Size = new System.Drawing.Size(79, 19);
            this.cbAutoAxis.TabIndex = 3;
            this.cbAutoAxis.Text = "Auto-Axis";
            this.cbAutoAxis.UseVisualStyleBackColor = true;
            // 
            // peakLabel
            // 
            this.peakLabel.AutoSize = true;
            this.peakLabel.Location = new System.Drawing.Point(397, 34);
            this.peakLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.peakLabel.Name = "peakLabel";
            this.peakLabel.Size = new System.Drawing.Size(90, 15);
            this.peakLabel.TabIndex = 9;
            this.peakLabel.Text = "Peak Frequency";
            // 
            // DisplayFftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.peakLabel);
            this.Controls.Add(this.cbAutoAxis);
            this.Controls.Add(this.transformedGraphPlot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DisplayFftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display input signal";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox devicesComboBox;
    private System.Windows.Forms.Label label1;
    private ScottPlot.FormsPlot transformedGraphPlot;
    private System.Windows.Forms.Timer eventLoopTimer;
    private System.Windows.Forms.CheckBox cbAutoAxis;
    private System.Windows.Forms.Label peakLabel;
}