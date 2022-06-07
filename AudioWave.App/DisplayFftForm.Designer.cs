namespace AudioWave.App;

partial class FormMicrophone
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.eventLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.cbAutoAxis = new System.Windows.Forms.CheckBox();
            this.lblPeak = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDevices
            // 
            this.devicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesComboBox.FormattingEnabled = true;
            this.devicesComboBox.Location = new System.Drawing.Point(14, 29);
            this.devicesComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(140, 23);
            this.devicesComboBox.TabIndex = 0;
            this.devicesComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeInputDevice);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Audio Device";
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(14, 60);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(905, 445);
            this.formsPlot1.TabIndex = 2;
            // 
            // timer1
            // 
            this.eventLoopTimer.Enabled = true;
            this.eventLoopTimer.Interval = 20;
            this.eventLoopTimer.Tick += new System.EventHandler(this.RunSingleIteration);
            // 
            // cbAutoAxis
            // 
            this.cbAutoAxis.AutoSize = true;
            this.cbAutoAxis.Checked = true;
            this.cbAutoAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoAxis.Location = new System.Drawing.Point(162, 31);
            this.cbAutoAxis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbAutoAxis.Name = "cbAutoAxis";
            this.cbAutoAxis.Size = new System.Drawing.Size(79, 19);
            this.cbAutoAxis.TabIndex = 3;
            this.cbAutoAxis.Text = "Auto-Axis";
            this.cbAutoAxis.UseVisualStyleBackColor = true;
            // 
            // lblPeak
            // 
            this.lblPeak.AutoSize = true;
            this.lblPeak.Location = new System.Drawing.Point(303, 10);
            this.lblPeak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeak.Name = "lblPeak";
            this.lblPeak.Size = new System.Drawing.Size(137, 15);
            this.lblPeak.TabIndex = 9;
            this.lblPeak.Text = "Peak Frequency";
            // 
            // FormMicrophone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.lblPeak);
            this.Controls.Add(this.cbAutoAxis);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AudioWave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display input signal";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox devicesComboBox;
    private System.Windows.Forms.Label label1;
    private ScottPlot.FormsPlot formsPlot1;
    private System.Windows.Forms.Timer eventLoopTimer;
    private System.Windows.Forms.CheckBox cbAutoAxis;
    private System.Windows.Forms.Label lblPeak;
}