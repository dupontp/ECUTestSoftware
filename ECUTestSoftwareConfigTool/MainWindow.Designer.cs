namespace ECUTestSoftwareConfigTool
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button LoadBtn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.V1ComboBox = new System.Windows.Forms.ComboBox();
            this.V2ComboBox = new System.Windows.Forms.ComboBox();
            this.V1minTxtBox = new System.Windows.Forms.TextBox();
            this.V2minTxtBox = new System.Windows.Forms.TextBox();
            this.V2maxTxtBox = new System.Windows.Forms.TextBox();
            this.V1maxTxtBox = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StepSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StepsTxtBox = new System.Windows.Forms.TextBox();
            this.MeasurementActiveTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deltaV2TxtBox = new System.Windows.Forms.TextBox();
            this.deltaV1TxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.V2TxtBox = new System.Windows.Forms.TextBox();
            this.V2ValueTxtBox = new System.Windows.Forms.TextBox();
            this.V1TxtBox = new System.Windows.Forms.TextBox();
            this.V1ValueTxtBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.FileNameTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FileNameLoadComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.DocumentationBtn = new System.Windows.Forms.ToolStripButton();
            this.ConfigArchiveBtn = new System.Windows.Forms.ToolStripButton();
            this.AboutBtn = new System.Windows.Forms.ToolStripButton();
            this.label11 = new System.Windows.Forms.Label();
            this.SimTimeTxtBox = new System.Windows.Forms.TextBox();
            this.CalcSimTimeBtn = new System.Windows.Forms.Button();
            this.SawBtn = new System.Windows.Forms.RadioButton();
            this.TriangleBtn = new System.Windows.Forms.RadioButton();
            LoadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StepSlider)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            LoadBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadBtn.Location = new System.Drawing.Point(288, 659);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new System.Drawing.Size(132, 52);
            LoadBtn.TabIndex = 20;
            LoadBtn.Text = "Refresh";
            LoadBtn.UseVisualStyleBackColor = true;
            LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable";
            // 
            // V1ComboBox
            // 
            this.V1ComboBox.FormattingEnabled = true;
            this.V1ComboBox.Location = new System.Drawing.Point(12, 43);
            this.V1ComboBox.Name = "V1ComboBox";
            this.V1ComboBox.Size = new System.Drawing.Size(121, 23);
            this.V1ComboBox.TabIndex = 1;
            // 
            // V2ComboBox
            // 
            this.V2ComboBox.FormattingEnabled = true;
            this.V2ComboBox.Location = new System.Drawing.Point(12, 72);
            this.V2ComboBox.Name = "V2ComboBox";
            this.V2ComboBox.Size = new System.Drawing.Size(121, 23);
            this.V2ComboBox.TabIndex = 2;
            // 
            // V1minTxtBox
            // 
            this.V1minTxtBox.Location = new System.Drawing.Point(139, 43);
            this.V1minTxtBox.Name = "V1minTxtBox";
            this.V1minTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V1minTxtBox.TabIndex = 3;
            // 
            // V2minTxtBox
            // 
            this.V2minTxtBox.Location = new System.Drawing.Point(139, 72);
            this.V2minTxtBox.Name = "V2minTxtBox";
            this.V2minTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V2minTxtBox.TabIndex = 4;
            // 
            // V2maxTxtBox
            // 
            this.V2maxTxtBox.Location = new System.Drawing.Point(424, 72);
            this.V2maxTxtBox.Name = "V2maxTxtBox";
            this.V2maxTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V2maxTxtBox.TabIndex = 6;
            // 
            // V1maxTxtBox
            // 
            this.V1maxTxtBox.Location = new System.Drawing.Point(424, 43);
            this.V1maxTxtBox.Name = "V1maxTxtBox";
            this.V1maxTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V1maxTxtBox.TabIndex = 5;
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.Location = new System.Drawing.Point(920, 43);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(132, 52);
            this.StartBtn.TabIndex = 7;
            this.StartBtn.Text = "TEST";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(139, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Minimal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(424, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Maximal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Steps";
            // 
            // StepSlider
            // 
            this.StepSlider.Location = new System.Drawing.Point(12, 131);
            this.StepSlider.Maximum = 1000;
            this.StepSlider.Minimum = 2;
            this.StepSlider.Name = "StepSlider";
            this.StepSlider.Size = new System.Drawing.Size(829, 45);
            this.StepSlider.TabIndex = 12;
            this.StepSlider.Value = 2;
            this.StepSlider.Scroll += new System.EventHandler(this.StepSlider_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(19, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(809, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "1000";
            // 
            // StepsTxtBox
            // 
            this.StepsTxtBox.Location = new System.Drawing.Point(12, 182);
            this.StepsTxtBox.Name = "StepsTxtBox";
            this.StepsTxtBox.Size = new System.Drawing.Size(121, 23);
            this.StepsTxtBox.TabIndex = 15;
            this.StepsTxtBox.TextChanged += new System.EventHandler(this.StepsTxtBox_TextChanged);
            // 
            // MeasurementActiveTxtBox
            // 
            this.MeasurementActiveTxtBox.Location = new System.Drawing.Point(1144, 61);
            this.MeasurementActiveTxtBox.Name = "MeasurementActiveTxtBox";
            this.MeasurementActiveTxtBox.Size = new System.Drawing.Size(279, 23);
            this.MeasurementActiveTxtBox.TabIndex = 16;
            this.MeasurementActiveTxtBox.TextChanged += new System.EventHandler(this.MeasurementActiveTxtBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1215, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Measurement active time";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.deltaV2TxtBox);
            this.panel1.Controls.Add(this.deltaV1TxtBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.V2TxtBox);
            this.panel1.Controls.Add(this.V2ValueTxtBox);
            this.panel1.Controls.Add(this.V1TxtBox);
            this.panel1.Controls.Add(this.V1ValueTxtBox);
            this.panel1.Location = new System.Drawing.Point(1059, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 318);
            this.panel1.TabIndex = 18;
            // 
            // deltaV2TxtBox
            // 
            this.deltaV2TxtBox.Location = new System.Drawing.Point(94, 90);
            this.deltaV2TxtBox.Name = "deltaV2TxtBox";
            this.deltaV2TxtBox.ReadOnly = true;
            this.deltaV2TxtBox.Size = new System.Drawing.Size(267, 23);
            this.deltaV2TxtBox.TabIndex = 21;
            // 
            // deltaV1TxtBox
            // 
            this.deltaV1TxtBox.Location = new System.Drawing.Point(94, 61);
            this.deltaV1TxtBox.Name = "deltaV1TxtBox";
            this.deltaV1TxtBox.ReadOnly = true;
            this.deltaV1TxtBox.Size = new System.Drawing.Size(267, 23);
            this.deltaV1TxtBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Delta V2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Delta V1";
            // 
            // V2TxtBox
            // 
            this.V2TxtBox.Location = new System.Drawing.Point(3, 32);
            this.V2TxtBox.Name = "V2TxtBox";
            this.V2TxtBox.ReadOnly = true;
            this.V2TxtBox.Size = new System.Drawing.Size(76, 23);
            this.V2TxtBox.TabIndex = 3;
            // 
            // V2ValueTxtBox
            // 
            this.V2ValueTxtBox.Location = new System.Drawing.Point(85, 32);
            this.V2ValueTxtBox.Name = "V2ValueTxtBox";
            this.V2ValueTxtBox.ReadOnly = true;
            this.V2ValueTxtBox.Size = new System.Drawing.Size(276, 23);
            this.V2ValueTxtBox.TabIndex = 2;
            // 
            // V1TxtBox
            // 
            this.V1TxtBox.Location = new System.Drawing.Point(3, 3);
            this.V1TxtBox.Name = "V1TxtBox";
            this.V1TxtBox.ReadOnly = true;
            this.V1TxtBox.Size = new System.Drawing.Size(76, 23);
            this.V1TxtBox.TabIndex = 1;
            // 
            // V1ValueTxtBox
            // 
            this.V1ValueTxtBox.Location = new System.Drawing.Point(85, 3);
            this.V1ValueTxtBox.Name = "V1ValueTxtBox";
            this.V1ValueTxtBox.ReadOnly = true;
            this.V1ValueTxtBox.Size = new System.Drawing.Size(276, 23);
            this.V1ValueTxtBox.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveBtn.Location = new System.Drawing.Point(12, 659);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(132, 52);
            this.SaveBtn.TabIndex = 19;
            this.SaveBtn.Text = "Save Config";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.Location = new System.Drawing.Point(12, 630);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.Size = new System.Drawing.Size(270, 23);
            this.FileNameTxtBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(12, 612);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Filename";
            // 
            // FileNameLoadComboBox
            // 
            this.FileNameLoadComboBox.FormattingEnabled = true;
            this.FileNameLoadComboBox.Location = new System.Drawing.Point(288, 630);
            this.FileNameLoadComboBox.Name = "FileNameLoadComboBox";
            this.FileNameLoadComboBox.Size = new System.Drawing.Size(263, 23);
            this.FileNameLoadComboBox.TabIndex = 23;
            this.FileNameLoadComboBox.SelectedIndexChanged += new System.EventHandler(this.FileNameLoadComboBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsBtn,
            this.DocumentationBtn,
            this.ConfigArchiveBtn,
            this.AboutBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1435, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SettingsBtn.Image = global::ECUTestSoftwareConfigTool.Properties.Resources.SettingsIcon1;
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(69, 22);
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtnClicked);
            // 
            // DocumentationBtn
            // 
            this.DocumentationBtn.Image = global::ECUTestSoftwareConfigTool.Properties.Resources.dok;
            this.DocumentationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DocumentationBtn.Name = "DocumentationBtn";
            this.DocumentationBtn.Size = new System.Drawing.Size(110, 22);
            this.DocumentationBtn.Text = "Documentation";
            // 
            // ConfigArchiveBtn
            // 
            this.ConfigArchiveBtn.Image = ((System.Drawing.Image)(resources.GetObject("ConfigArchiveBtn.Image")));
            this.ConfigArchiveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConfigArchiveBtn.Name = "ConfigArchiveBtn";
            this.ConfigArchiveBtn.Size = new System.Drawing.Size(103, 22);
            this.ConfigArchiveBtn.Text = "ConfigArchive";
            this.ConfigArchiveBtn.Click += new System.EventHandler(this.ConfigArchiveBtn_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Image = global::ECUTestSoftwareConfigTool.Properties.Resources.AboutIcon;
            this.AboutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(60, 22);
            this.AboutBtn.Text = "About";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(1215, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "Estimated simulation time";
            // 
            // SimTimeTxtBox
            // 
            this.SimTimeTxtBox.Location = new System.Drawing.Point(1144, 131);
            this.SimTimeTxtBox.Name = "SimTimeTxtBox";
            this.SimTimeTxtBox.Size = new System.Drawing.Size(279, 23);
            this.SimTimeTxtBox.TabIndex = 25;
            // 
            // CalcSimTimeBtn
            // 
            this.CalcSimTimeBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalcSimTimeBtn.Location = new System.Drawing.Point(1059, 131);
            this.CalcSimTimeBtn.Name = "CalcSimTimeBtn";
            this.CalcSimTimeBtn.Size = new System.Drawing.Size(79, 23);
            this.CalcSimTimeBtn.TabIndex = 27;
            this.CalcSimTimeBtn.Text = "CALC";
            this.CalcSimTimeBtn.UseVisualStyleBackColor = true;
            this.CalcSimTimeBtn.Click += new System.EventHandler(this.CalcSimTimeBtn_Click);
            // 
            // SawBtn
            // 
            this.SawBtn.AutoSize = true;
            this.SawBtn.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.dok;
            this.SawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SawBtn.Location = new System.Drawing.Point(709, 44);
            this.SawBtn.Name = "SawBtn";
            this.SawBtn.Size = new System.Drawing.Size(94, 19);
            this.SawBtn.TabIndex = 28;
            this.SawBtn.TabStop = true;
            this.SawBtn.Text = "                       ";
            this.SawBtn.UseVisualStyleBackColor = true;
            // 
            // TriangleBtn
            // 
            this.TriangleBtn.AutoSize = true;
            this.TriangleBtn.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.dok;
            this.TriangleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TriangleBtn.Location = new System.Drawing.Point(809, 44);
            this.TriangleBtn.Name = "TriangleBtn";
            this.TriangleBtn.Size = new System.Drawing.Size(94, 19);
            this.TriangleBtn.TabIndex = 29;
            this.TriangleBtn.TabStop = true;
            this.TriangleBtn.Text = "                       ";
            this.TriangleBtn.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1435, 723);
            this.Controls.Add(this.TriangleBtn);
            this.Controls.Add(this.SawBtn);
            this.Controls.Add(this.CalcSimTimeBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SimTimeTxtBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.FileNameLoadComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.FileNameTxtBox);
            this.Controls.Add(LoadBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MeasurementActiveTxtBox);
            this.Controls.Add(this.StepsTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StepSlider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.V2maxTxtBox);
            this.Controls.Add(this.V1maxTxtBox);
            this.Controls.Add(this.V2minTxtBox);
            this.Controls.Add(this.V1minTxtBox);
            this.Controls.Add(this.V2ComboBox);
            this.Controls.Add(this.V1ComboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StepSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox V1ComboBox;
        private ComboBox V2ComboBox;
        private TextBox V1minTxtBox;
        private TextBox V2minTxtBox;
        private TextBox V2maxTxtBox;
        private TextBox V1maxTxtBox;
        private Button StartBtn;
        private Label label2;
        private Label label3;
        private Label label5;
        private TrackBar StepSlider;
        private Label label4;
        private Label label6;
        private TextBox StepsTxtBox;
        private TextBox MeasurementActiveTxtBox;
        private Label label7;
        private Panel panel1;
        private TextBox V1TxtBox;
        private TextBox V1ValueTxtBox;
        private TextBox V2TxtBox;
        private TextBox V2ValueTxtBox;
        private Label label8;
        private TextBox deltaV1TxtBox;
        private Label label9;
        private TextBox deltaV2TxtBox;
        private Button SaveBtn;
        private Button LoadBtn;
        private TextBox FileNameTxtBox;
        private Label label10;
        private ComboBox FileNameLoadComboBox;
        private ToolStrip toolStrip1;
        private ToolStripButton SettingsBtn;
        private ToolStripButton AboutBtn;
        private ToolStripButton DocumentationBtn;
        private ToolStripButton ConfigArchiveBtn;
        private Label label11;
        private TextBox SimTimeTxtBox;
        private Button CalcSimTimeBtn;
        private RadioButton SawBtn;
        private RadioButton TriangleBtn;
    }
}