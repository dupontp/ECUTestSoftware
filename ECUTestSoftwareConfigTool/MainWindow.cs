namespace ECUTestSoftwareConfigTool
{
    public partial class MainWindow : Form
    {
        //TODO: Settings Window implementieren
        public string Path = "C:\\Users\\p.dupont.MCG1.000\\Documents\\GoogleDrive\\Dokumente\\HTW\\2. Semester (WS)\\Seminar und Projekt\\INCA-Projekt\\Software\\Konfigurationen";

        public MainWindow()
        {
            InitializeComponent();

            V1ComboBox.Items.Add("");
            V1ComboBox.Items.Add("n");
            V1ComboBox.Items.Add("alpha");

            V2ComboBox.Items.Add("");
            V2ComboBox.Items.Add("n");
            V2ComboBox.Items.Add("alpha");

            StepsTxtBox.Text = "2";

            LoadFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FileNameTxtBox.Text.Trim() == "")
            {
                FileNameTxtBox.Text = "Config" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                FileNameTxtBox.Update();
            }

            try
            {
                string Content = "";

                Content += FileNameTxtBox.Text + "#";
                Content += V1ComboBox.SelectedItem + "#";
                Content += V1minTxtBox.Text + "#";
                Content += V1maxTxtBox.Text + "#";
                Content += V2ComboBox.SelectedItem + "#";
                Content += V2minTxtBox.Text + "#";
                Content += V2maxTxtBox.Text + "#";
                Content += MeasurementActiveTxtBox.Text + "#";
                Content += StepsTxtBox.Text;


                StreamWriter SW = new StreamWriter(Path + "\\" + FileNameTxtBox.Text + ".ptm");

                SW.Write(Content);

                SW.Close();
                SW.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern der Konfiguration! \r\n\r\n" + ex.Message + "\r\n\r\n" + Path, "FEHLER");
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (V1ComboBox.SelectedItem.ToString() == V2ComboBox.SelectedItem.ToString())
            {
                MessageBox.Show("Dumm?", "FEHLER");

                return;
            }

            bool Proceed = true;

            if(GetSimTime() > 120)
            {
                DialogResult dialogResult = MessageBox.Show("Simulation is going to take over 2 minutes. Do you want to proceed?", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Proceed = true;
                }
                else
                {
                    Proceed = false;
                }
            }

            V1TxtBox.Text = V1ComboBox.SelectedItem.ToString();
            V2TxtBox.Text = V2ComboBox.SelectedItem.ToString();

            V1TxtBox.Update();
            V2TxtBox.Update();

            if (Proceed && V1ComboBox.SelectedItem.ToString() == "n" && V2ComboBox.SelectedItem.ToString() == "alpha")
            {
                float V1min = float.Parse(V1minTxtBox.Text);
                float V1max = float.Parse(V1maxTxtBox.Text);
                int Steps = Int32.Parse(StepsTxtBox.Text);

                float V1delta = (V1max - V1min) / Steps;

                float V2min = float.Parse(V2minTxtBox.Text);
                float V2max = float.Parse(V2maxTxtBox.Text);

                float V2delta = (V2max - V2min) / Steps;

                deltaV1TxtBox.Text = V1delta.ToString();
                deltaV2TxtBox.Text = V2delta.ToString();

                deltaV1TxtBox.Update();
                deltaV2TxtBox.Update();

                for (float n = V1min; n <= V1max; n += V1delta)
                {
                    for (float alpha = V2min; alpha <= V2max; alpha += V2delta)
                    {
                        //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                        V1ValueTxtBox.Text = n.ToString();
                        V2ValueTxtBox.Text = alpha.ToString();

                        V1ValueTxtBox.Update();
                        V2ValueTxtBox.Update();

                        try
                        {
                            Thread.Sleep(int.Parse(MeasurementActiveTxtBox.Text));
                        }
                        catch
                        {
                            MessageBox.Show("Active Measurement Time falsch codiert! Es wird 500ms gewählt.", "FEHLER");
                            MeasurementActiveTxtBox.Text = "500";

                            MeasurementActiveTxtBox.Update();

                            Thread.Sleep(500);
                        }
                    }
                }
                MessageBox.Show("Simulation erfolgreich beendet!", "INFO");
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            FileNameLoadComboBox.Items.Clear();

            LoadFiles();
        }

        private void LoadFiles()
        {
            foreach (string file in Directory.GetFiles(Path))
            {
                if (file.Contains(".ptm"))
                {
                    FileNameLoadComboBox.Items.Add(file.Replace(Path + "\\", "").Replace(".ptm", ""));
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void SettingsBtnClicked(object sender, EventArgs e)
        {
            SettingsWindow FrmSet = new SettingsWindow();

            FrmSet.Show();
        }

        private void StepsTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StepSlider.Value = int.Parse(StepsTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("\"Steps\" müssen ein Integer-Wert sein!", "FEHLER");
            }
        }

        private void StepSlider_Scroll(object sender, EventArgs e)
        {
            StepsTxtBox.Text = StepSlider.Value.ToString();
        }

        private void MeasurementActiveTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(MeasurementActiveTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("Falsches Format!", "FEHLER");
            }
        }

        private void FileNameLoadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StreamReader SR = new StreamReader(Path + "\\" + FileNameLoadComboBox.SelectedItem + ".ptm");

                string[] Content = SR.ReadToEnd().Split('#');

                SR.Close();
                SR.Dispose();


                FileNameTxtBox.Text = Content[0];
                V1ComboBox.SelectedItem = Content[1];
                V1minTxtBox.Text = Content[2];
                V1maxTxtBox.Text = Content[3];
                V2ComboBox.SelectedItem = Content[4];
                V2minTxtBox.Text = Content[5];
                V2maxTxtBox.Text = Content[6];
                MeasurementActiveTxtBox.Text= Content[7];
                StepsTxtBox.Text = Content[8];






            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Konfiguration! \r\n\r\n" + ex.Message, "FEHLER");
            }
        }

        private void CalcSimTimeBtn_Click(object sender, EventArgs e)
        {
            float SimTime = GetSimTime();

            if (SimTime == -1)
            {
                SimTimeTxtBox.Text = "ERROR";
                SimTimeTxtBox.BackColor = Color.White;
            }
            else if (SimTime == 0)
            {
                SimTimeTxtBox.Text = "As quick as possible";
                SimTimeTxtBox.BackColor = Color.White;
            }
            else if (SimTime >= 300)
            {
                SimTimeTxtBox.Text = SimTime.ToString();

                SimTimeTxtBox.BackColor = Color.Red;
            }
            else
            {
                SimTimeTxtBox.Text = SimTime.ToString();

                SimTimeTxtBox.BackColor = Color.White;
            }

        }

        private float GetSimTime()
        {
            try
            {
                float Steps = float.Parse(StepsTxtBox.Text);

                float MeasurementTime = (float.Parse(MeasurementActiveTxtBox.Text) / 1000);

                float Time = Steps * Steps * MeasurementTime;

                return Time;
            }
            catch
            {
                MessageBox.Show("Falsches Format!", "FEHLER");
            }

            return -1;
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            AboutWindow frmAbout = new AboutWindow();

            frmAbout.Show();
        }

        private void ConfigArchiveBtn_Click(object sender, EventArgs e)
        {
            ArchiveWindow FormArchive = new ArchiveWindow();

            FormArchive.Load(Path);
        }
    }
}