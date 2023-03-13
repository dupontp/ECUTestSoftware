using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ECUTestSoftwareConfigTool
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset");
            }

            string SettingsContent = PathTxtBox.Text + "\r\n" + IndividualPathRadioBtn.Checked.ToString() + "\r\n" + SelectedPathRadioBtn.Checked.ToString();

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\InternalData\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\InternalData\\");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\");
            }

            StreamWriter SW = new StreamWriter(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset");

            SW.Write(SettingsContent);

            SW.Close();
            SW.Dispose();
        }

        public void LoadForm()
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset"))
            {
                StreamReader SR = new StreamReader(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset");

                string[] Settings = SR.ReadToEnd().Replace("\r", "").Split('\n');

                SR.Close();
                SR.Dispose();

                PathTxtBox.Text = Settings[0];

                IndividualPathRadioBtn.Checked = bool.Parse(Settings[1]);
                SelectedPathRadioBtn.Checked = bool.Parse(Settings[2]);
            }

            this.Show();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    PathTxtBox.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
