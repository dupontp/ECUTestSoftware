using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string SettingsContent = PathTxtBox.Text + "\r\n" + IndividualPathRadioBtn.Checked.ToString() + "\r\n" + SelectedPathRadioBtn.Checked.ToString();

            StreamWriter SW = new StreamWriter(Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset");

            SW.Write(SettingsContent);

            SW.Close();
            SW.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
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
