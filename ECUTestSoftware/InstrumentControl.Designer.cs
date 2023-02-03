namespace HTW_Saar.ECUTestSoftware
{
    partial class InstrumentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadFileBtn
            // 
            this.LoadFileBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoadFileBtn.Location = new System.Drawing.Point(1104, 3);
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(137, 66);
            this.LoadFileBtn.TabIndex = 0;
            this.LoadFileBtn.Text = "Load File";
            this.LoadFileBtn.UseVisualStyleBackColor = true;
            this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
            // 
            // InstrumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadFileBtn);
            this.Name = "InstrumentControl";
            this.Size = new System.Drawing.Size(1244, 641);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadFileBtn;
    }
}
