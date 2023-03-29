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
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuppressedTxtBox2 = new System.Windows.Forms.TextBox();
            this.SuppressChkBox2 = new System.Windows.Forms.CheckBox();
            this.SuppressedTxtBox1 = new System.Windows.Forms.TextBox();
            this.SuppressChkBox1 = new System.Windows.Forms.CheckBox();
            this.x2Label = new System.Windows.Forms.Label();
            this.x1Label = new System.Windows.Forms.Label();
            this.x2maxTxtBox = new System.Windows.Forms.TextBox();
            this.x2minTxtBox = new System.Windows.Forms.TextBox();
            this.x1minTxtBox = new System.Windows.Forms.TextBox();
            this.x1maxTxtBox = new System.Windows.Forms.TextBox();
            this.V1Panel = new System.Windows.Forms.Panel();
            this.FuncV1TxtBox = new System.Windows.Forms.TextBox();
            this.FuncBtnV1 = new System.Windows.Forms.RadioButton();
            this.RandBtnV1 = new System.Windows.Forms.RadioButton();
            this.TriangleBtnV1 = new System.Windows.Forms.RadioButton();
            this.SawBtnV1 = new System.Windows.Forms.RadioButton();
            this.V2Panel = new System.Windows.Forms.Panel();
            this.FuncV2TxtBox = new System.Windows.Forms.TextBox();
            this.FuncBtnV2 = new System.Windows.Forms.RadioButton();
            this.RandBtnV2 = new System.Windows.Forms.RadioButton();
            this.TriangleBtnV2 = new System.Windows.Forms.RadioButton();
            this.SawBtnV2 = new System.Windows.Forms.RadioButton();
            this.CalcSimTimeBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SimTimeTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MeasurementActiveTxtBox = new System.Windows.Forms.TextBox();
            this.StepsTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StepSlider = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.V2maxTxtBox = new System.Windows.Forms.TextBox();
            this.V1maxTxtBox = new System.Windows.Forms.TextBox();
            this.V2minTxtBox = new System.Windows.Forms.TextBox();
            this.V1minTxtBox = new System.Windows.Forms.TextBox();
            this.V2ComboBox = new System.Windows.Forms.ComboBox();
            this.V1ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.DocumentationBtn = new System.Windows.Forms.ToolStripButton();
            this.ConfigArchiveBtn = new System.Windows.Forms.ToolStripButton();
            this.AboutBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.SingleValueTxtBox = new System.Windows.Forms.TextBox();
            this.SingleVariableComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SingleSendBtn = new System.Windows.Forms.Button();
            LoadBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.V1Panel.SuspendLayout();
            this.V2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StepSlider)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            LoadBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadBtn.Location = new System.Drawing.Point(412, 266);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new System.Drawing.Size(132, 52);
            LoadBtn.TabIndex = 20;
            LoadBtn.Text = "Refresh";
            LoadBtn.UseVisualStyleBackColor = true;
            LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
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
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Delta V2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
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
            this.SaveBtn.Location = new System.Drawing.Point(144, 266);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(132, 52);
            this.SaveBtn.TabIndex = 19;
            this.SaveBtn.Text = "Save Config";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.Location = new System.Drawing.Point(6, 237);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.Size = new System.Drawing.Size(270, 23);
            this.FileNameTxtBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(198, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Filename";
            // 
            // FileNameLoadComboBox
            // 
            this.FileNameLoadComboBox.FormattingEnabled = true;
            this.FileNameLoadComboBox.Location = new System.Drawing.Point(282, 237);
            this.FileNameLoadComboBox.Name = "FileNameLoadComboBox";
            this.FileNameLoadComboBox.Size = new System.Drawing.Size(263, 23);
            this.FileNameLoadComboBox.TabIndex = 23;
            this.FileNameLoadComboBox.SelectedIndexChanged += new System.EventHandler(this.FileNameLoadComboBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.SuppressedTxtBox2);
            this.panel2.Controls.Add(this.SuppressChkBox2);
            this.panel2.Controls.Add(this.SuppressedTxtBox1);
            this.panel2.Controls.Add(this.SuppressChkBox1);
            this.panel2.Controls.Add(this.x2Label);
            this.panel2.Controls.Add(this.x1Label);
            this.panel2.Controls.Add(this.x2maxTxtBox);
            this.panel2.Controls.Add(this.x2minTxtBox);
            this.panel2.Controls.Add(this.x1minTxtBox);
            this.panel2.Controls.Add(this.x1maxTxtBox);
            this.panel2.Controls.Add(this.V1Panel);
            this.panel2.Controls.Add(this.V2Panel);
            this.panel2.Controls.Add(this.CalcSimTimeBtn);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.SimTimeTxtBox);
            this.panel2.Controls.Add(this.FileNameLoadComboBox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.FileNameTxtBox);
            this.panel2.Controls.Add(this.MeasurementActiveTxtBox);
            this.panel2.Controls.Add(LoadBtn);
            this.panel2.Controls.Add(this.StepsTxtBox);
            this.panel2.Controls.Add(this.SaveBtn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.StepSlider);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.StartBtn);
            this.panel2.Controls.Add(this.V2maxTxtBox);
            this.panel2.Controls.Add(this.V1maxTxtBox);
            this.panel2.Controls.Add(this.V2minTxtBox);
            this.panel2.Controls.Add(this.V1minTxtBox);
            this.panel2.Controls.Add(this.V2ComboBox);
            this.panel2.Controls.Add(this.V1ComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(9, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1411, 325);
            this.panel2.TabIndex = 36;
            // 
            // SuppressedTxtBox2
            // 
            this.SuppressedTxtBox2.Location = new System.Drawing.Point(1383, 179);
            this.SuppressedTxtBox2.Name = "SuppressedTxtBox2";
            this.SuppressedTxtBox2.ReadOnly = true;
            this.SuppressedTxtBox2.Size = new System.Drawing.Size(23, 23);
            this.SuppressedTxtBox2.TabIndex = 68;
            // 
            // SuppressChkBox2
            // 
            this.SuppressChkBox2.AutoSize = true;
            this.SuppressChkBox2.Location = new System.Drawing.Point(1196, 181);
            this.SuppressChkBox2.Name = "SuppressChkBox2";
            this.SuppressChkBox2.Size = new System.Drawing.Size(181, 19);
            this.SuppressChkBox2.TabIndex = 67;
            this.SuppressChkBox2.Text = "Wertebereich x2 beschränken";
            this.SuppressChkBox2.UseVisualStyleBackColor = true;
            // 
            // SuppressedTxtBox1
            // 
            this.SuppressedTxtBox1.Location = new System.Drawing.Point(1383, 150);
            this.SuppressedTxtBox1.Name = "SuppressedTxtBox1";
            this.SuppressedTxtBox1.ReadOnly = true;
            this.SuppressedTxtBox1.Size = new System.Drawing.Size(23, 23);
            this.SuppressedTxtBox1.TabIndex = 66;
            // 
            // SuppressChkBox1
            // 
            this.SuppressChkBox1.AutoSize = true;
            this.SuppressChkBox1.Location = new System.Drawing.Point(1196, 152);
            this.SuppressChkBox1.Name = "SuppressChkBox1";
            this.SuppressChkBox1.Size = new System.Drawing.Size(181, 19);
            this.SuppressChkBox1.TabIndex = 65;
            this.SuppressChkBox1.Text = "Wertebereich x1 beschränken";
            this.SuppressChkBox1.UseVisualStyleBackColor = true;
            this.SuppressChkBox1.CheckedChanged += new System.EventHandler(this.SuppressChkBox_CheckedChanged);
            // 
            // x2Label
            // 
            this.x2Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.x2Label.Location = new System.Drawing.Point(1276, 123);
            this.x2Label.Name = "x2Label";
            this.x2Label.Size = new System.Drawing.Size(52, 23);
            this.x2Label.TabIndex = 64;
            this.x2Label.Text = "≤ x ≤";
            this.x2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // x1Label
            // 
            this.x1Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.x1Label.Location = new System.Drawing.Point(1276, 94);
            this.x1Label.Name = "x1Label";
            this.x1Label.Size = new System.Drawing.Size(52, 23);
            this.x1Label.TabIndex = 62;
            this.x1Label.Text = "≤ x ≤";
            this.x1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // x2maxTxtBox
            // 
            this.x2maxTxtBox.Location = new System.Drawing.Point(1334, 123);
            this.x2maxTxtBox.Name = "x2maxTxtBox";
            this.x2maxTxtBox.Size = new System.Drawing.Size(72, 23);
            this.x2maxTxtBox.TabIndex = 61;
            // 
            // x2minTxtBox
            // 
            this.x2minTxtBox.Location = new System.Drawing.Point(1198, 123);
            this.x2minTxtBox.Name = "x2minTxtBox";
            this.x2minTxtBox.Size = new System.Drawing.Size(72, 23);
            this.x2minTxtBox.TabIndex = 60;
            // 
            // x1minTxtBox
            // 
            this.x1minTxtBox.Location = new System.Drawing.Point(1198, 94);
            this.x1minTxtBox.Name = "x1minTxtBox";
            this.x1minTxtBox.Size = new System.Drawing.Size(72, 23);
            this.x1minTxtBox.TabIndex = 59;
            // 
            // x1maxTxtBox
            // 
            this.x1maxTxtBox.Location = new System.Drawing.Point(1334, 94);
            this.x1maxTxtBox.Name = "x1maxTxtBox";
            this.x1maxTxtBox.Size = new System.Drawing.Size(72, 23);
            this.x1maxTxtBox.TabIndex = 58;
            // 
            // V1Panel
            // 
            this.V1Panel.Controls.Add(this.FuncV1TxtBox);
            this.V1Panel.Controls.Add(this.FuncBtnV1);
            this.V1Panel.Controls.Add(this.RandBtnV1);
            this.V1Panel.Controls.Add(this.TriangleBtnV1);
            this.V1Panel.Controls.Add(this.SawBtnV1);
            this.V1Panel.Location = new System.Drawing.Point(703, 22);
            this.V1Panel.Name = "V1Panel";
            this.V1Panel.Size = new System.Drawing.Size(703, 31);
            this.V1Panel.TabIndex = 56;
            // 
            // FuncV1TxtBox
            // 
            this.FuncV1TxtBox.Location = new System.Drawing.Point(295, 4);
            this.FuncV1TxtBox.Name = "FuncV1TxtBox";
            this.FuncV1TxtBox.Size = new System.Drawing.Size(403, 23);
            this.FuncV1TxtBox.TabIndex = 52;
            // 
            // FuncBtnV1
            // 
            this.FuncBtnV1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FuncBtnV1.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FuncBtnV1.ForeColor = System.Drawing.Color.Red;
            this.FuncBtnV1.Location = new System.Drawing.Point(225, 6);
            this.FuncBtnV1.Name = "FuncBtnV1";
            this.FuncBtnV1.Size = new System.Drawing.Size(97, 19);
            this.FuncBtnV1.TabIndex = 34;
            this.FuncBtnV1.TabStop = true;
            this.FuncBtnV1.Text = "Func";
            this.FuncBtnV1.UseVisualStyleBackColor = true;
            this.FuncBtnV1.CheckedChanged += new System.EventHandler(this.FuncBtnV1_CheckedChanged);
            // 
            // RandBtnV1
            // 
            this.RandBtnV1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RandBtnV1.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RandBtnV1.ForeColor = System.Drawing.Color.Red;
            this.RandBtnV1.Location = new System.Drawing.Point(145, 6);
            this.RandBtnV1.Name = "RandBtnV1";
            this.RandBtnV1.Size = new System.Drawing.Size(74, 19);
            this.RandBtnV1.TabIndex = 33;
            this.RandBtnV1.TabStop = true;
            this.RandBtnV1.Text = "Rand           ";
            this.RandBtnV1.UseVisualStyleBackColor = true;
            // 
            // TriangleBtnV1
            // 
            this.TriangleBtnV1.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.TriangleBtn;
            this.TriangleBtnV1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TriangleBtnV1.Location = new System.Drawing.Point(74, 6);
            this.TriangleBtnV1.Name = "TriangleBtnV1";
            this.TriangleBtnV1.Size = new System.Drawing.Size(65, 19);
            this.TriangleBtnV1.TabIndex = 32;
            this.TriangleBtnV1.TabStop = true;
            this.TriangleBtnV1.Text = "                       ";
            this.TriangleBtnV1.UseVisualStyleBackColor = true;
            // 
            // SawBtnV1
            // 
            this.SawBtnV1.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.SawBtn;
            this.SawBtnV1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SawBtnV1.Location = new System.Drawing.Point(3, 6);
            this.SawBtnV1.Name = "SawBtnV1";
            this.SawBtnV1.Size = new System.Drawing.Size(65, 19);
            this.SawBtnV1.TabIndex = 31;
            this.SawBtnV1.TabStop = true;
            this.SawBtnV1.Text = "                       ";
            this.SawBtnV1.UseVisualStyleBackColor = true;
            // 
            // V2Panel
            // 
            this.V2Panel.Controls.Add(this.FuncV2TxtBox);
            this.V2Panel.Controls.Add(this.FuncBtnV2);
            this.V2Panel.Controls.Add(this.RandBtnV2);
            this.V2Panel.Controls.Add(this.TriangleBtnV2);
            this.V2Panel.Controls.Add(this.SawBtnV2);
            this.V2Panel.Location = new System.Drawing.Point(703, 51);
            this.V2Panel.Name = "V2Panel";
            this.V2Panel.Size = new System.Drawing.Size(703, 31);
            this.V2Panel.TabIndex = 57;
            // 
            // FuncV2TxtBox
            // 
            this.FuncV2TxtBox.Location = new System.Drawing.Point(295, 5);
            this.FuncV2TxtBox.Name = "FuncV2TxtBox";
            this.FuncV2TxtBox.Size = new System.Drawing.Size(403, 23);
            this.FuncV2TxtBox.TabIndex = 53;
            // 
            // FuncBtnV2
            // 
            this.FuncBtnV2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FuncBtnV2.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FuncBtnV2.ForeColor = System.Drawing.Color.Red;
            this.FuncBtnV2.Location = new System.Drawing.Point(225, 6);
            this.FuncBtnV2.Name = "FuncBtnV2";
            this.FuncBtnV2.Size = new System.Drawing.Size(97, 19);
            this.FuncBtnV2.TabIndex = 35;
            this.FuncBtnV2.TabStop = true;
            this.FuncBtnV2.Text = "Func";
            this.FuncBtnV2.UseVisualStyleBackColor = true;
            this.FuncBtnV2.CheckedChanged += new System.EventHandler(this.FuncBtnV2_CheckedChanged);
            // 
            // RandBtnV2
            // 
            this.RandBtnV2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RandBtnV2.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RandBtnV2.ForeColor = System.Drawing.Color.Red;
            this.RandBtnV2.Location = new System.Drawing.Point(145, 6);
            this.RandBtnV2.Name = "RandBtnV2";
            this.RandBtnV2.Size = new System.Drawing.Size(74, 19);
            this.RandBtnV2.TabIndex = 34;
            this.RandBtnV2.TabStop = true;
            this.RandBtnV2.Text = "Rand           ";
            this.RandBtnV2.UseVisualStyleBackColor = true;
            // 
            // TriangleBtnV2
            // 
            this.TriangleBtnV2.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.TriangleBtn;
            this.TriangleBtnV2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TriangleBtnV2.Location = new System.Drawing.Point(74, 6);
            this.TriangleBtnV2.Name = "TriangleBtnV2";
            this.TriangleBtnV2.Size = new System.Drawing.Size(65, 19);
            this.TriangleBtnV2.TabIndex = 32;
            this.TriangleBtnV2.TabStop = true;
            this.TriangleBtnV2.Text = "                       ";
            this.TriangleBtnV2.UseVisualStyleBackColor = true;
            this.TriangleBtnV2.CheckedChanged += new System.EventHandler(this.TriangleBtnV2_CheckedChanged);
            // 
            // SawBtnV2
            // 
            this.SawBtnV2.BackgroundImage = global::ECUTestSoftwareConfigTool.Properties.Resources.SawBtn;
            this.SawBtnV2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SawBtnV2.Location = new System.Drawing.Point(3, 6);
            this.SawBtnV2.Name = "SawBtnV2";
            this.SawBtnV2.Size = new System.Drawing.Size(65, 19);
            this.SawBtnV2.TabIndex = 31;
            this.SawBtnV2.TabStop = true;
            this.SawBtnV2.Text = "                       ";
            this.SawBtnV2.UseVisualStyleBackColor = true;
            // 
            // CalcSimTimeBtn
            // 
            this.CalcSimTimeBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalcSimTimeBtn.Location = new System.Drawing.Point(1042, 295);
            this.CalcSimTimeBtn.Name = "CalcSimTimeBtn";
            this.CalcSimTimeBtn.Size = new System.Drawing.Size(79, 23);
            this.CalcSimTimeBtn.TabIndex = 55;
            this.CalcSimTimeBtn.Text = "CALC";
            this.CalcSimTimeBtn.UseVisualStyleBackColor = true;
            this.CalcSimTimeBtn.Click += new System.EventHandler(this.CalcSimTimeBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(1198, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 15);
            this.label11.TabIndex = 54;
            this.label11.Text = "Estimated simulation time";
            // 
            // SimTimeTxtBox
            // 
            this.SimTimeTxtBox.Location = new System.Drawing.Point(1127, 295);
            this.SimTimeTxtBox.Name = "SimTimeTxtBox";
            this.SimTimeTxtBox.Size = new System.Drawing.Size(279, 23);
            this.SimTimeTxtBox.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1199, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 15);
            this.label7.TabIndex = 52;
            this.label7.Text = "Measurement active time";
            // 
            // MeasurementActiveTxtBox
            // 
            this.MeasurementActiveTxtBox.Location = new System.Drawing.Point(1128, 233);
            this.MeasurementActiveTxtBox.Name = "MeasurementActiveTxtBox";
            this.MeasurementActiveTxtBox.Size = new System.Drawing.Size(279, 23);
            this.MeasurementActiveTxtBox.TabIndex = 51;
            // 
            // StepsTxtBox
            // 
            this.StepsTxtBox.Location = new System.Drawing.Point(6, 165);
            this.StepsTxtBox.Name = "StepsTxtBox";
            this.StepsTxtBox.Size = new System.Drawing.Size(121, 23);
            this.StepsTxtBox.TabIndex = 50;
            this.StepsTxtBox.TextChanged += new System.EventHandler(this.StepsTxtBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(803, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 49;
            this.label6.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "2";
            // 
            // StepSlider
            // 
            this.StepSlider.Location = new System.Drawing.Point(6, 114);
            this.StepSlider.Maximum = 1000;
            this.StepSlider.Minimum = 2;
            this.StepSlider.Name = "StepSlider";
            this.StepSlider.Size = new System.Drawing.Size(829, 45);
            this.StepSlider.TabIndex = 47;
            this.StepSlider.Value = 2;
            this.StepSlider.Scroll += new System.EventHandler(this.StepSlider_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Steps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(418, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 45;
            this.label3.Text = "Maximal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(133, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "Minimal";
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.Location = new System.Drawing.Point(988, 234);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(132, 52);
            this.StartBtn.TabIndex = 43;
            this.StartBtn.Text = "TEST";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // V2maxTxtBox
            // 
            this.V2maxTxtBox.Location = new System.Drawing.Point(418, 55);
            this.V2maxTxtBox.Name = "V2maxTxtBox";
            this.V2maxTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V2maxTxtBox.TabIndex = 42;
            // 
            // V1maxTxtBox
            // 
            this.V1maxTxtBox.Location = new System.Drawing.Point(418, 26);
            this.V1maxTxtBox.Name = "V1maxTxtBox";
            this.V1maxTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V1maxTxtBox.TabIndex = 41;
            // 
            // V2minTxtBox
            // 
            this.V2minTxtBox.Location = new System.Drawing.Point(133, 55);
            this.V2minTxtBox.Name = "V2minTxtBox";
            this.V2minTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V2minTxtBox.TabIndex = 40;
            // 
            // V1minTxtBox
            // 
            this.V1minTxtBox.Location = new System.Drawing.Point(133, 26);
            this.V1minTxtBox.Name = "V1minTxtBox";
            this.V1minTxtBox.Size = new System.Drawing.Size(279, 23);
            this.V1minTxtBox.TabIndex = 39;
            // 
            // V2ComboBox
            // 
            this.V2ComboBox.FormattingEnabled = true;
            this.V2ComboBox.Location = new System.Drawing.Point(6, 55);
            this.V2ComboBox.Name = "V2ComboBox";
            this.V2ComboBox.Size = new System.Drawing.Size(121, 23);
            this.V2ComboBox.TabIndex = 38;
            // 
            // V1ComboBox
            // 
            this.V1ComboBox.FormattingEnabled = true;
            this.V1ComboBox.Location = new System.Drawing.Point(6, 26);
            this.V1ComboBox.Name = "V1ComboBox";
            this.V1ComboBox.Size = new System.Drawing.Size(121, 23);
            this.V1ComboBox.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Variable";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montalban", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(12, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(395, 35);
            this.label12.TabIndex = 37;
            this.label12.Text = "Multiple Value Test";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montalban", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(9, 522);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(349, 35);
            this.label14.TabIndex = 39;
            this.label14.Text = "Single Value Test";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.SingleValueTxtBox);
            this.panel3.Controls.Add(this.SingleVariableComboBox);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.SingleSendBtn);
            this.panel3.Location = new System.Drawing.Point(9, 559);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 152);
            this.panel3.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(135, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 15);
            this.label13.TabIndex = 62;
            this.label13.Text = "Value";
            // 
            // SingleValueTxtBox
            // 
            this.SingleValueTxtBox.Location = new System.Drawing.Point(135, 25);
            this.SingleValueTxtBox.Name = "SingleValueTxtBox";
            this.SingleValueTxtBox.Size = new System.Drawing.Size(198, 23);
            this.SingleValueTxtBox.TabIndex = 61;
            // 
            // SingleVariableComboBox
            // 
            this.SingleVariableComboBox.FormattingEnabled = true;
            this.SingleVariableComboBox.Location = new System.Drawing.Point(8, 25);
            this.SingleVariableComboBox.Name = "SingleVariableComboBox";
            this.SingleVariableComboBox.Size = new System.Drawing.Size(121, 23);
            this.SingleVariableComboBox.TabIndex = 60;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(8, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 15);
            this.label15.TabIndex = 59;
            this.label15.Text = "Variable";
            // 
            // SingleSendBtn
            // 
            this.SingleSendBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SingleSendBtn.Location = new System.Drawing.Point(201, 93);
            this.SingleSendBtn.Name = "SingleSendBtn";
            this.SingleSendBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SingleSendBtn.Size = new System.Drawing.Size(132, 52);
            this.SingleSendBtn.TabIndex = 58;
            this.SingleSendBtn.Text = "SEND";
            this.SingleSendBtn.UseVisualStyleBackColor = true;
            this.SingleSendBtn.Click += new System.EventHandler(this.SingleSendBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1435, 723);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "ECU Test Software Configuration Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.V1Panel.ResumeLayout(false);
            this.V1Panel.PerformLayout();
            this.V2Panel.ResumeLayout(false);
            this.V2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StepSlider)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private Panel panel2;
        private Panel V1Panel;
        private RadioButton RandBtnV1;
        private RadioButton TriangleBtnV1;
        private RadioButton SawBtnV1;
        private Panel V2Panel;
        private RadioButton TriangleBtnV2;
        private RadioButton SawBtnV2;
        private Button CalcSimTimeBtn;
        private Label label11;
        private TextBox SimTimeTxtBox;
        private Label label7;
        private TextBox MeasurementActiveTxtBox;
        private TextBox StepsTxtBox;
        private Label label6;
        private Label label4;
        private TrackBar StepSlider;
        private Label label5;
        private Label label3;
        private Label label2;
        private Button StartBtn;
        private TextBox V2maxTxtBox;
        private TextBox V1maxTxtBox;
        private TextBox V2minTxtBox;
        private TextBox V1minTxtBox;
        private ComboBox V2ComboBox;
        private ComboBox V1ComboBox;
        private Label label1;
        private ToolStripButton SettingsBtn;
        private ToolStripButton DocumentationBtn;
        private ToolStripButton ConfigArchiveBtn;
        private ToolStripButton AboutBtn;
        private ToolStrip toolStrip1;
        private Label label12;
        private Label label14;
        private Panel panel3;
        private Button SingleSendBtn;
        private Label label13;
        private TextBox SingleValueTxtBox;
        private ComboBox SingleVariableComboBox;
        private Label label15;
        private RadioButton RandBtnV2;
        private RadioButton FuncBtnV1;
        private RadioButton FuncBtnV2;
        private TextBox FuncV1TxtBox;
        private TextBox FuncV2TxtBox;
        private TextBox x2maxTxtBox;
        private TextBox x2minTxtBox;
        private TextBox x1minTxtBox;
        private TextBox x1maxTxtBox;
        private Label x2Label;
        private Label x1Label;
        private CheckBox SuppressChkBox1;
        private TextBox SuppressedTxtBox1;
        private TextBox SuppressedTxtBox2;
        private CheckBox SuppressChkBox2;
    }
}