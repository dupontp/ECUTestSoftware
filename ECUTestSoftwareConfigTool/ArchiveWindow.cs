using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECUTestSoftwareConfigTool
{
    public partial class ArchiveWindow : Form
    {
        public ArchiveWindow()
        {
            InitializeComponent();
        }

        public void Load(string Path)
        {
            int Index = 0;
            foreach (string file in Directory.GetFiles(Path))
            {
                if (file.Contains(".ptm"))
                {
                    StreamReader SR = new StreamReader(file);

                    string[] Content = SR.ReadToEnd().Split('#');

                    SR.Close();
                    SR.Dispose();

                    for (int i = 0; i <= 8; i++)
                    {
                        foreach (Control element in this.Controls)
                        {
                            if (element.Name == "textBox" + ((Index * 9) + i + 1).ToString())
                            {
                                TextBox ele = element as TextBox;

                                ele.Text = Content[i];
                            }
                        }
                    }
                    Index++;
                }
            }

            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
