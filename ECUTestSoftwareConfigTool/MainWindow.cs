using System.Linq.Expressions;
using Mathos.Parser;

namespace ECUTestSoftwareConfigTool
{
    public partial class MainWindow : Form
    {
        public string[] Settings = new string[3];

        public MainWindow()
        {
            InitializeComponent();

            V1ComboBox.Items.Add("");
            V1ComboBox.Items.Add("n");
            V1ComboBox.Items.Add("alpha");

            V2ComboBox.Items.Add("");
            V2ComboBox.Items.Add("n");
            V2ComboBox.Items.Add("alpha");

            SingleVariableComboBox.Items.Add("");
            SingleVariableComboBox.Items.Add("n");
            SingleVariableComboBox.Items.Add("alpha");

            StepsTxtBox.Text = "2";

            SawBtnV1.Checked = true;
            SawBtnV2.Checked = true;

            FuncV1TxtBox.Visible = false;
            x1maxTxtBox.Visible = false;
            x1minTxtBox.Visible = false;
            x1Label.Visible = false;

            FuncV2TxtBox.Visible = false;
            x2maxTxtBox.Visible = false;
            x2minTxtBox.Visible = false;
            x2Label.Visible = false;

            LoadSettings();

            LoadFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadSettings() 
        {
            string Path = Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset";
            if (!File.Exists(Path))
            {
                MessageBox.Show("Bei erster Benutzung muss das Programm in den Einstellungen konfiguriert werden!", "INFO");

                SettingsWindow frmSet = new SettingsWindow();

                frmSet.LoadForm();
            }
            else
            {
                StreamReader SR = new StreamReader(Path);

                Settings = SR.ReadToEnd().Replace("\r", "").Split('\n');

                SR.Close();
                SR.Dispose();
            }
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
                Content += StepsTxtBox.Text + "#";
                Content += SawBtnV1.Checked + "#";
                Content += TriangleBtnV1.Checked + "#";
                Content += RandBtnV1.Checked + "#";
                Content += SawBtnV2.Checked + "#";
                Content += TriangleBtnV2.Checked + "#";
                Content += RandBtnV2.Checked + "#";


                StreamWriter SW = new StreamWriter(Settings[0] + "\\" + FileNameTxtBox.Text + ".ptm");

                SW.Write(Content);

                SW.Close();
                SW.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern der Konfiguration! \r\n\r\n" + ex.Message + "\r\n\r\n" + Settings[0], "FEHLER");
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (V1ComboBox.SelectedItem.ToString() == V2ComboBox.SelectedItem.ToString())
            {
                MessageBox.Show("Es kann nicht eine Variable doppelt simuliert werden!", "FEHLER");

                return;
            }

            bool Proceed = true;

            if(GetSimTime() > 120)
            {
                DialogResult dialogResult = MessageBox.Show("Simulation dauert über 2 Minuten. Fortfahren?", "WARNING", MessageBoxButtons.YesNo);
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

                SuppressedTxtBox.BackColor = Color.White;
                SuppressedTxtBox.Update();

                if (TriangleBtnV1.Checked)
                {
                    for (float V1Value = V1min; V1Value <= V1max; V1Value += (V1delta))
                    {
                        if (TriangleBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (SawBtnV2.Checked)
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (RandBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));
                                
                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (FuncBtnV2.Checked)
                        {
                            float x2max = float.Parse(x2maxTxtBox.Text);
                            float x2min = float.Parse(x2minTxtBox.Text);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for(float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(FuncV2TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));
                                    
                                    if(V2Value > V2max && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2max;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    if(V2Value < V2min && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2min;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()));
                                }
                                catch (Exception ex)
                                {
                                    if(x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message, "FEHLER");
                                    }
                                }
                                

                            }
                        }
                    }
                    for (float V1Value = V1max; V1Value >= V1min; V1Value -= (V1delta))
                    {
                        if (TriangleBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha);
                            }
                            for (float alpha = V2max; alpha >= V2min; alpha -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha);
                            }
                        }
                        else if (SawBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha);
                            }
                        }
                        else if (RandBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (FuncBtnV2.Checked)
                        {
                            float x2max = float.Parse(x2maxTxtBox.Text);
                            float x2min = float.Parse(x2minTxtBox.Text);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(FuncV2TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2max;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    if (V2Value < V2min && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2min;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()));
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message, "FEHLER");
                                    }
                                }


                            }
                        }
                    }
                }
                else if (SawBtnV1.Checked)
                {
                    for (float V1Value = V1min; V1Value <= V1max; V1Value += (V1delta))
                    {
                        if (TriangleBtnV2.Checked)
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (SawBtnV2.Checked)
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (RandBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (FuncBtnV2.Checked)
                        {
                            float x2max = float.Parse(x2maxTxtBox.Text);
                            float x2min = float.Parse(x2minTxtBox.Text);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(FuncV2TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2max;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    if (V2Value < V2min && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2min;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()));
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message, "FEHLER");
                                    }
                                }


                            }
                        }
                    }
                }
                else if (RandBtnV1.Checked)
                {
                    for (float n = V1min; n <= V1max; n += (V1delta))
                    {
                        Random rnd = new Random();
                        int V1Value = rnd.Next((int)Math.Round(V1min, 0), (int)Math.Round(V1max, 0));

                        if (TriangleBtnV2.Checked)
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (SawBtnV2.Checked)
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (RandBtnV2.Checked)
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rndV2 = new Random();
                                int V2Value = rndV2.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value);
                            }
                        }
                        else if (FuncBtnV2.Checked)
                        {
                            float x2max = float.Parse(x2maxTxtBox.Text);
                            float x2min = float.Parse(x2minTxtBox.Text);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(FuncV2TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2max;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    if (V2Value < V2min && SuppressChkBox.Checked)
                                    {
                                        V2Value = V2min;
                                        SuppressedTxtBox.BackColor = Color.Red;
                                        SuppressedTxtBox.Update();
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()));
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message, "FEHLER");
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Simulation erfolgreich beendet!", "INFO");
            }
        }

        private void SendVariable(string Variable1, float Value1, string Variable2, float Value2)
        {
            V1ValueTxtBox.Text = Value1.ToString();
            V2ValueTxtBox.Text = Value2.ToString();

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

        private void SendSingleVariable(string Variable, float Value)
        {
            V1TxtBox.Text = Variable.ToString();
            V1ValueTxtBox.Text = Value.ToString();

            V2TxtBox.Text = "";
            V2ValueTxtBox.Text = "";
            deltaV1TxtBox.Text = "";
            deltaV2TxtBox.Text = "";
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            FileNameLoadComboBox.Items.Clear();

            LoadFiles();
        }

        private void LoadFiles()
        {
            try
            {

                foreach (string file in Directory.GetFiles(Settings[0]))
                {
                    if (file.Contains(".ptm"))
                    {
                        FileNameLoadComboBox.Items.Add(file.Replace(Settings[0] + "\\", "").Replace(".ptm", ""));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FEHLER");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
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
                StreamReader SR = new StreamReader(Settings[0] + "\\" + FileNameLoadComboBox.SelectedItem + ".ptm");

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

                if(TriangleBtnV1.Checked && TriangleBtnV2.Checked)
                {
                    Time = Time * 4;
                }
                else if(TriangleBtnV1.Checked || TriangleBtnV2.Checked)
                {
                    Time = Time * 2;
                }

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

            FormArchive.Load(Settings[0]);
        }

        private void SettingsBtnClicked(object sender, EventArgs e)
        {
            SettingsWindow FrmSet = new SettingsWindow();

            FrmSet.LoadForm();
        }

        private void TriangleBtnV2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SingleSendBtn_Click(object sender, EventArgs e)
        {
            if (SingleVariableComboBox.SelectedItem == "n")
            {
                float Value = float.Parse(SingleValueTxtBox.Text);
                SendSingleVariable("n", Value);
            }
            else if (SingleVariableComboBox.SelectedItem == "alpha")
            {
                float Value = float.Parse(SingleValueTxtBox.Text);
                SendSingleVariable("alpha", Value);
            }
        }

        private void FuncBtnV1_CheckedChanged(object sender, EventArgs e)
        {
            FuncV1TxtBox.Visible = FuncBtnV1.Checked;
            x1maxTxtBox.Visible = FuncBtnV1.Checked;
            x1minTxtBox.Visible = FuncBtnV1.Checked;
            x1Label.Visible = FuncBtnV1.Checked;
        }

        private void FuncBtnV2_CheckedChanged(object sender, EventArgs e)
        {
            FuncV2TxtBox.Visible = FuncBtnV2.Checked;
            x2maxTxtBox.Visible = FuncBtnV2.Checked;
            x2minTxtBox.Visible = FuncBtnV2.Checked;
            x2Label.Visible = FuncBtnV2.Checked;
        }

        private void SuppressChkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}