using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECUTestSoftwareConfigTool
{
    public partial class ArchiveWindow : Form
    {
        string FolderPath = "";
        public ArchiveWindow()
        {
            InitializeComponent();
        }

        public void LoadWindow(string Path)
        {
            FolderPath = Path;

            bool Done = false;

            while (!Done)
            {
                Done = true;
                foreach (Control element in this.Controls)
                {
                    if (element.GetType() == typeof(TextBox))
                    {
                        TextBox ele = element as TextBox;

                        if (Int32.Parse(element.Name.Replace("textBox", "")) >= 18)
                        {
                            this.Controls.Remove(ele);
                            Done = false;
                        }
                    }
                    else if (element.GetType() == typeof(Button))
                    {
                        Button ele = element as Button;

                        if (Int32.Parse(element.Name.Replace("button", "")) >= 3)
                        {
                            this.Controls.Remove(ele);
                            Done = false;
                        }
                    }
                }
            }
            


            int Index = 0;
            foreach (string file in Directory.GetFiles(Path))
            {

                if (file.Contains(".ptm"))
                {
                    if (Index > 0)
                    {
                        CreateTextBoxes(Index);
                    }

                    StreamReader SR = new StreamReader(file);

                    string[] Content = SR.ReadToEnd().Split('#');

                    SR.Close();
                    SR.Dispose();

                    foreach (TextBox ele in this.Controls.OfType<TextBox>())
                    {
                        if (ele.Name == "textBox" + ((17 * Index) + 1))
                        {
                            ele.Text = Content[0];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 2))
                        {
                            ele.Text = Content[1];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 3))
                        {
                            ele.Text = Content[2];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 4))
                        {
                            ele.Text = Content[3];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 5))
                        {
                            ele.Text = Content[4];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 6))
                        {
                            ele.Text = Content[5];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 7))
                        {
                            ele.Text = Content[6];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 8))
                        {
                            ele.Text = Content[7];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 9))
                        {
                            ele.Text = Content[8];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 10))
                        {
                            ele.Text = Content[9];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 11))
                        {
                            ele.Text = Content[10];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 12))
                        {
                            ele.Text = Content[11];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 13))
                        {
                            ele.Text = Content[12];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 14))
                        {
                            ele.Text = Content[13];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 15))
                        {
                            ele.Text = Content[14];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 16))
                        {
                            ele.Text = Content[15];
                        }
                        else if (ele.Name == "textBox" + ((17 * Index) + 17))
                        {
                            ele.Text = Content[16];
                        }
                    }
                    Index++;
                }
                
            }
            this.Show();
        }

        private void CreateTextBoxes(int Index)
        {
            for(int i = 1; i <= 17; i++)
            {
                TextBox ele = new TextBox();

                ele.Name = "textBox" + ((17 * Index) + i).ToString();

                ele.ReadOnly = true;

                int Height = 34 + Index * 29;

                switch (i)
                {
                    case 1:
                        ele.Location = new Point(12, Height);
                        ele.Size = new System.Drawing.Size(255, 23);
                        break;
                    case 2:
                        ele.Location = new Point(273, Height);
                        ele.Size = new System.Drawing.Size(67, 23);
                        break;
                    case 3:
                        ele.Location = new Point(346, Height);
                        ele.Size = new System.Drawing.Size(98, 23);
                        break;
                    case 4:
                        ele.Location = new Point(450, Height);
                        ele.Size = new System.Drawing.Size(98, 23);
                        break;
                    case 5:
                        ele.Location = new Point(554, Height);
                        ele.Size = new System.Drawing.Size(67, 23);
                        break;
                    case 6:
                        ele.Location = new Point(627, Height);
                        ele.Size = new System.Drawing.Size(98, 23);
                        break;
                    case 7:
                        ele.Location = new Point(731, Height);
                        ele.Size = new System.Drawing.Size(98, 23);
                        break;
                    case 8:
                        ele.Location = new Point(835, Height);
                        ele.Size = new System.Drawing.Size(113, 23);
                        break;
                    case 9:
                        ele.Location = new Point(954, Height);
                        ele.Size = new System.Drawing.Size(62, 23);
                        break;
                    case 10:
                        ele.Location = new Point(1022, Height);
                        ele.Size = new System.Drawing.Size(153, 23);
                        break;
                    case 11:
                        ele.Location = new Point(1181, Height);
                        ele.Size = new System.Drawing.Size(45, 23);
                        break;
                    case 12:
                        ele.Location = new Point(1232, Height);
                        ele.Size = new System.Drawing.Size(45, 23);
                        break;
                    case 13:
                        ele.Location = new Point(1283, Height);
                        ele.Size = new System.Drawing.Size(23, 23);
                        break;
                    case 14:
                        ele.Location = new Point(1312, Height);
                        ele.Size = new System.Drawing.Size(153, 23);
                        break;
                    case 15:
                        ele.Location = new Point(1471, Height);
                        ele.Size = new System.Drawing.Size(45, 23);
                        break;
                    case 16:
                        ele.Location = new Point(1522, Height);
                        ele.Size = new System.Drawing.Size(45, 23);
                        break;
                    case 17:
                        ele.Location = new Point(1572, Height);
                        ele.Size = new System.Drawing.Size(23, 23);
                        break;
                }
                string s = ele.Name;
                this.Controls.Add(ele);
            }
            for (int i = 1; i <= 2; i++)
            {
                Button ele = new Button();

                ele.Name = "button" + ((2 * Index) + i).ToString();
                ele.Size = new System.Drawing.Size(88, 23);
                int Height = 34 + Index * 29;
                ele.Click += new System.EventHandler(this.BtnClick);

                switch (i)
                {
                    case 1:
                        ele.Location = new Point(1601, Height);
                        ele.Text = "Delete";
                        break;
                    case 2:
                        ele.Location = new Point(1695, Height);
                        ele.Text = "Export";
                        break;
                }

  
                this.Controls.Add(ele);
            }
        }

        private void ArchiveWindow_Load(object sender, EventArgs e)
        {

        }

        private void BtnClick(object sender, EventArgs e)
        {
            try
            {
                Button ele = sender as Button;
                int ButtonNr = Int16.Parse(ele.Name.Replace("button", ""));

                if (ButtonNr % 2 == 0)
                {
                    //Export Button
                    foreach (TextBox TxtBoxele in this.Controls.OfType<TextBox>())
                    {
                        double UnroundedNr = (double)ButtonNr / (double)2;
                        int DeleteIndex = (int)Math.Ceiling(UnroundedNr) - 1;
                        if (TxtBoxele.Name == "textBox" + (17 * DeleteIndex + 1))
                        {
                            using (var fbd = new FolderBrowserDialog())
                            {
                                DialogResult result = fbd.ShowDialog();

                                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                                {
                                    DialogResult dialogResult = MessageBox.Show("Soll die Konfigurationsdatei hierhin exportiert werden?", "EXPORTIEREN", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        File.Copy(FolderPath + "\\" + TxtBoxele.Text + ".ptm", fbd.SelectedPath + "\\" + TxtBoxele.Text + ".ptm");

                                        Thread.Sleep(100);
                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    //Delete Button
                    foreach (TextBox TxtBoxele in this.Controls.OfType<TextBox>())
                    {
                        double UnroundedNr = (double)ButtonNr / (double)2;
                        int DeleteIndex = (int)Math.Ceiling(UnroundedNr) - 1;
                        if (TxtBoxele.Name == "textBox" + (17 * DeleteIndex + 1))
                        {
                            DialogResult dialogResult = MessageBox.Show("Soll die Konfigurationsdatei " + TxtBoxele.Text + " wirklich gelöscht werden?", "LÖSCHEN", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                File.Delete(FolderPath + "\\" + TxtBoxele.Text + ".ptm");

                                Thread.Sleep(100);
                            }
                        }
                    }
                }

                LoadWindow(FolderPath);
            }
            catch
            {

            }
        }
    }
}
