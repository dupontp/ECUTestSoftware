namespace ECUTestSoftwareConfigTool
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.PathTxtBox = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.IndividualPathRadioBtn = new System.Windows.Forms.RadioButton();
            this.SelectedPathRadioBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export Path";
            // 
            // PathTxtBox
            // 
            this.PathTxtBox.Location = new System.Drawing.Point(12, 41);
            this.PathTxtBox.Name = "PathTxtBox";
            this.PathTxtBox.Size = new System.Drawing.Size(457, 23);
            this.PathTxtBox.TabIndex = 2;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(354, 12);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(115, 23);
            this.BrowseBtn.TabIndex = 3;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(354, 489);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(115, 41);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save Settings";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // IndividualPathRadioBtn
            // 
            this.IndividualPathRadioBtn.AutoSize = true;
            this.IndividualPathRadioBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IndividualPathRadioBtn.Location = new System.Drawing.Point(12, 110);
            this.IndividualPathRadioBtn.Name = "IndividualPathRadioBtn";
            this.IndividualPathRadioBtn.Size = new System.Drawing.Size(235, 20);
            this.IndividualPathRadioBtn.TabIndex = 6;
            this.IndividualPathRadioBtn.TabStop = true;
            this.IndividualPathRadioBtn.Text = "Export to individual path";
            this.IndividualPathRadioBtn.UseVisualStyleBackColor = true;
            // 
            // SelectedPathRadioBtn
            // 
            this.SelectedPathRadioBtn.AutoSize = true;
            this.SelectedPathRadioBtn.Font = new System.Drawing.Font("Montalban", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectedPathRadioBtn.Location = new System.Drawing.Point(12, 135);
            this.SelectedPathRadioBtn.Name = "SelectedPathRadioBtn";
            this.SelectedPathRadioBtn.Size = new System.Drawing.Size(230, 20);
            this.SelectedPathRadioBtn.TabIndex = 7;
            this.SelectedPathRadioBtn.TabStop = true;
            this.SelectedPathRadioBtn.Text = "Export to selected path";
            this.SelectedPathRadioBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 542);
            this.Controls.Add(this.SelectedPathRadioBtn);
            this.Controls.Add(this.IndividualPathRadioBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.PathTxtBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox PathTxtBox;
        private Button BrowseBtn;
        private Button SaveBtn;
        private RadioButton IndividualPathRadioBtn;
        private RadioButton SelectedPathRadioBtn;
    }
}