using System.Linq.Expressions;
using System.Windows.Forms;
using Mathos.Parser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ECUTestSoftwareConfigTool
{
    public partial class MainWindow : Form
    {
        public string[] Settings = new string[3];
        bool ActiveMeasurementTimeSet = false;

        /// <summary>
        /// Prozessabbild der Benutzeroberfläche als Struct
        /// </summary>
        struct UIElementsStatus
        {
            public string V1ComboBoxContent;
            public string V2ComboBoxContent;
            public string V1minTxtBoxContent;
            public string V1maxTxtBoxContent;
            public string V2minTxtBoxContent;
            public string V2maxTxtBoxContent;
            public string StepsTxtBoxContent;
            public string TriangleBtnV1Content;
            public string TriangleBtnV2Content;
            public string SawBtnV1Content;
            public string SawBtnV2Content;
            public string RandBtnV1Content;
            public string RandBtnV2Content;
            public string FuncBtnV1Content;
            public string FuncBtnV2Content;
            public string x1minTxtBoxContent;
            public string x1maxTxtBoxContent;
            public string x2minTxtBoxContent;
            public string x2maxTxtBoxContent;
            public string SuppressChkBox1Content;
            public string SuppressChkBox2Content;
            public string FuncV1TxtBoxContent;
            public string FuncV2TxtBoxContent;
            public string MeasurementActiveTxtBoxContent;
        }

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
            SuppressChkBox1.Visible = false;
            SuppressedTxtBox1.Visible = false;

            FuncV2TxtBox.Visible = false;
            x2maxTxtBox.Visible = false;
            x2minTxtBox.Visible = false;
            x2Label.Visible = false;
            SuppressChkBox2.Visible = false;
            SuppressedTxtBox2.Visible = false;

            LoadSettings();

            LoadFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Funktion zum Laden der gespeicherten Einstellungen
        /// </summary>
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

        /// <summary>
        /// Klick-Funktion des "Speichern"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FileNameTxtBox.Text.Trim() == "")
            {
                FileNameTxtBox.Text = "Config" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                FileNameTxtBox.Update();
            }

            try
            {
                bool Func1Valid = false;
                bool Func2Valid = false;

                string Function1 = "";
                string Function2 = "";

                try
                {
                    MathParser Parser = new MathParser();

                    for (double x = 0; x <= 100; x += 0.5)
                    {
                        double TestValue = Parser.Parse(FuncV1TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));
                    }

                    Func1Valid = true;
                }
                catch
                {
                    Func1Valid = false;
                }

                try
                {
                    MathParser Parser = new MathParser();

                    for (double x = 0; x <= 100; x += 0.5)
                    {
                        double TestValue = Parser.Parse(FuncV2TxtBox.Text.Replace("x", "(" + x.ToString() + ")"));
                    }

                    Func2Valid = true;
                }
                catch
                {
                    Func2Valid = false;
                }

                if (SawBtnV1.Checked)
                {
                    Function1 = "Saw";
                }
                else if (TriangleBtnV1.Checked)
                {
                    Function1 = "Triangle";
                }
                else if (RandBtnV1.Checked)
                {
                    Function1 = "Random";
                }
                else if (FuncBtnV1.Checked && Func1Valid)
                {
                    Function1 = FuncV1TxtBox.Text;
                }
                else
                {
                    MessageBox.Show("Function for V1 invalid! Choosing Saw-Function.", "ERROR");
                }

                if (SawBtnV2.Checked)
                {
                    Function2 = "Saw";
                }
                else if (TriangleBtnV2.Checked)
                {
                    Function2 = "Triangle";
                }
                else if (RandBtnV2.Checked)
                {
                    Function2 = "Random";
                }
                else if (FuncBtnV2.Checked && Func2Valid)
                {
                    Function2 = FuncV2TxtBox.Text;
                }
                else
                {
                    MessageBox.Show("Function for V2 invalid! Choosing Saw-Function.", "ERROR");
                    Function2 = "Saw";
                }

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
                Content += Function1 + "#";
                Content += x1minTxtBox.Text + "#";
                Content += x1maxTxtBox.Text + "#";
                Content += SuppressChkBox1.Checked + "#";
                Content += Function2 + "#";
                Content += x2minTxtBox.Text + "#";
                Content += x2maxTxtBox.Text + "#";
                Content += SuppressChkBox2.Checked;


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

        /// <summary>
        /// Klick-Funktion des "Start"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            ActiveMeasurementTimeSet = false;

            try
            {
                UIElementsStatus CurrentStatus = new UIElementsStatus();

                CurrentStatus.V1ComboBoxContent = V1ComboBox.SelectedItem.ToString();
                CurrentStatus.V2ComboBoxContent = V2ComboBox.SelectedItem.ToString();
                CurrentStatus.V1minTxtBoxContent = V1minTxtBox.Text;
                CurrentStatus.V1maxTxtBoxContent = V1maxTxtBox.Text;
                CurrentStatus.V2minTxtBoxContent = V2minTxtBox.Text;
                CurrentStatus.V2maxTxtBoxContent = V2maxTxtBox.Text;
                CurrentStatus.StepsTxtBoxContent = StepsTxtBox.Text;
                CurrentStatus.TriangleBtnV1Content = TriangleBtnV1.Checked.ToString();
                CurrentStatus.TriangleBtnV2Content = TriangleBtnV2.Checked.ToString();
                CurrentStatus.SawBtnV1Content = SawBtnV1.Checked.ToString();
                CurrentStatus.SawBtnV2Content = SawBtnV2.Checked.ToString();
                CurrentStatus.RandBtnV1Content = RandBtnV1.Checked.ToString();
                CurrentStatus.RandBtnV2Content = RandBtnV2.Checked.ToString();
                CurrentStatus.FuncBtnV1Content = FuncBtnV1.Checked.ToString();
                CurrentStatus.FuncBtnV2Content = FuncBtnV2.Checked.ToString();
                CurrentStatus.x1minTxtBoxContent = x1minTxtBox.Text;
                CurrentStatus.x1maxTxtBoxContent = x1maxTxtBox.Text;
                CurrentStatus.x2minTxtBoxContent = x2minTxtBox.Text;
                CurrentStatus.x2maxTxtBoxContent = x2maxTxtBox.Text;
                CurrentStatus.SuppressChkBox1Content = SuppressChkBox1.Checked.ToString();
                CurrentStatus.SuppressChkBox2Content = SuppressChkBox2.Checked.ToString();
                CurrentStatus.FuncV1TxtBoxContent = FuncV1TxtBox.Text;
                CurrentStatus.FuncV2TxtBoxContent = FuncV2TxtBox.Text;
                CurrentStatus.MeasurementActiveTxtBoxContent = MeasurementActiveTxtBox.Text;

                var t = new Thread(() => TestMethod(CurrentStatus));

                t.Start();
            }
            catch
            {
                MessageBox.Show("Fehler beim Starten der Simulation!", "ERROR");
            }
        }

        /// <summary>
        /// Funktion für den automatisierten Testablauf im parallelen Thread
        /// </summary>
        /// <param name="CurrentStatus">Aktuelles Prozessabbild der Benutzeroberfläche</param>
        private void TestMethod(UIElementsStatus CurrentStatus)
        {
            if (CurrentStatus.V1ComboBoxContent == CurrentStatus.V2ComboBoxContent)
            {
                MessageBox.Show("Es kann nicht eine Variable doppelt simuliert werden!", "FEHLER");

                return;
            }

            bool Proceed = true;

            if (GetSimTime() > 120)
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

            this.Invoke((MethodInvoker)delegate ()
            {
                V1TxtBox.Text = CurrentStatus.V1ComboBoxContent;
                V2TxtBox.Text = CurrentStatus.V2ComboBoxContent;

                V1TxtBox.Update();
                V2TxtBox.Update();
            });

            if (Proceed && CurrentStatus.V1ComboBoxContent == "n" && CurrentStatus.V2ComboBoxContent == "alpha")
            {
                float V1min = float.Parse(CurrentStatus.V1minTxtBoxContent);
                float V1max = float.Parse(CurrentStatus.V1maxTxtBoxContent);
                int Steps = Int32.Parse(CurrentStatus.StepsTxtBoxContent);

                float V1delta = (V1max - V1min) / Steps;

                float V2min = float.Parse(CurrentStatus.V2minTxtBoxContent);
                float V2max = float.Parse(CurrentStatus.V2maxTxtBoxContent);

                float V2delta = (V2max - V2min) / Steps;

                this.Invoke((MethodInvoker)delegate ()
                {
                    deltaV1TxtBox.Text = V1delta.ToString();
                    deltaV2TxtBox.Text = V2delta.ToString();

                    deltaV1TxtBox.Update();
                    deltaV2TxtBox.Update();

                    SuppressedTxtBox1.BackColor = Color.White;
                    SuppressedTxtBox1.Update();
                });
                

                if (bool.Parse(CurrentStatus.TriangleBtnV1Content))
                {
                    for (float V1Value = V1min; V1Value <= V1max; V1Value += (V1delta))
                    {
                        if (bool.Parse(CurrentStatus.TriangleBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.SawBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.RandBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.FuncBtnV2Content))
                        {
                            float x2max = float.Parse(CurrentStatus.x2maxTxtBoxContent);
                            float x2min = float.Parse(CurrentStatus.x2minTxtBoxContent);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(CurrentStatus.FuncV2TxtBoxContent.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2max;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });

                                    }
                                    if (V2Value < V2min && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2min;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()), CurrentStatus.MeasurementActiveTxtBoxContent);
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0, CurrentStatus.MeasurementActiveTxtBoxContent);
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
                        if (bool.Parse(CurrentStatus.TriangleBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                            for (float alpha = V2max; alpha >= V2min; alpha -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.SawBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", alpha, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.RandBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.FuncBtnV2Content))
                        {
                            float x2max = float.Parse(CurrentStatus.x2maxTxtBoxContent);
                            float x2min = float.Parse(CurrentStatus.x2minTxtBoxContent);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(CurrentStatus.FuncV2TxtBoxContent.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2max;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    if (V2Value < V2min && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2min;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()), CurrentStatus.MeasurementActiveTxtBoxContent);
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0, CurrentStatus.MeasurementActiveTxtBoxContent);
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
                else if (bool.Parse(CurrentStatus.SawBtnV1Content))
                {
                    for (float V1Value = V1min; V1Value <= V1max; V1Value += (V1delta))
                    {
                        if (bool.Parse(CurrentStatus.TriangleBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.SawBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.RandBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.FuncBtnV2Content))
                        {
                            float x2max = float.Parse(CurrentStatus.x2maxTxtBoxContent);
                            float x2min = float.Parse(CurrentStatus.x2minTxtBoxContent);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(CurrentStatus.FuncV2TxtBoxContent.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2max;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    if (V2Value < V2min && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2min;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()), CurrentStatus.MeasurementActiveTxtBoxContent);
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0, CurrentStatus.MeasurementActiveTxtBoxContent);
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
                else if (bool.Parse(CurrentStatus.RandBtnV1Content))
                {
                    for (float n = V1min; n <= V1max; n += (V1delta))
                    {
                        Random rnd = new Random();
                        int V1Value = rnd.Next((int)Math.Round(V1min, 0), (int)Math.Round(V1max, 0));

                        if (bool.Parse(CurrentStatus.TriangleBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.SawBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.RandBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rndV2 = new Random();
                                int V2Value = rndV2.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", V1Value, "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.FuncBtnV2Content))
                        {
                            float x2max = float.Parse(CurrentStatus.x2maxTxtBoxContent);
                            float x2min = float.Parse(CurrentStatus.x2minTxtBoxContent);
                            float deltaX = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x = x2min; x <= x2max; x += deltaX)
                            {
                                try
                                {
                                    MathParser Parser = new MathParser();
                                    V2Value = Parser.Parse(CurrentStatus.FuncV2TxtBoxContent.Replace("x", "(" + x.ToString() + ")"));

                                    if (V2Value > V2max && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2max;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    if (V2Value < V2min && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2min;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    SendVariable("n", V1Value, "alpha", float.Parse(V2Value.ToString()), CurrentStatus.MeasurementActiveTxtBoxContent);
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", V1Value, "alpha", 0, CurrentStatus.MeasurementActiveTxtBoxContent);
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
                else if (bool.Parse(CurrentStatus.FuncBtnV1Content))
                {
                    float x1max = float.Parse(CurrentStatus.x1maxTxtBoxContent);
                    float x1min = float.Parse(CurrentStatus.x1minTxtBoxContent);
                    float deltaX = (x1max - x1min) / Steps;

                    double V1Value = 0;

                    for (float x = x1min; x <= x1max; x += deltaX)
                    {
                        MathParser Parser = new MathParser();
                        V1Value = Parser.Parse(CurrentStatus.FuncV1TxtBoxContent.Replace("x", "(" + x.ToString() + ")"));

                        if (bool.Parse(CurrentStatus.TriangleBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);
                                

                                SendVariable("n", float.Parse(V1Value.ToString()), "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                            for (float V2Value = V2max; V2Value >= V2min; V2Value -= (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", float.Parse(V1Value.ToString()), "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.SawBtnV2Content))
                        {
                            for (float V2Value = V2min; V2Value <= V2max; V2Value += V2delta)
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                SendVariable("n", float.Parse(V1Value.ToString()), "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.RandBtnV2Content))
                        {
                            for (float alpha = V2min; alpha <= V2max; alpha += (V2delta))
                            {
                                //myDevice.RPM.Enginespeed = (int)Math.Round(n, 0);

                                Random rnd = new Random();
                                int V2Value = rnd.Next((int)Math.Round(V2min, 0), (int)Math.Round(V2max, 0));

                                SendVariable("n", float.Parse(V1Value.ToString()), "alpha", V2Value, CurrentStatus.MeasurementActiveTxtBoxContent);
                            }
                        }
                        else if (bool.Parse(CurrentStatus.FuncBtnV2Content))
                        {
                            float x2max = float.Parse(CurrentStatus.x2maxTxtBoxContent);
                            float x2min = float.Parse(CurrentStatus.x2minTxtBoxContent);
                            float deltaX2 = (x2max - x2min) / Steps;

                            double V2Value = 0;
                            for (float x2 = x2min; x2 <= x2max; x2 += deltaX2)
                            {
                                try
                                {
                                    MathParser Parser2 = new MathParser();
                                    V2Value = Parser2.Parse(CurrentStatus.FuncV2TxtBoxContent.Replace("x", "(" + x2.ToString() + ")"));

                                    if (V2Value > V2max && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2max;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    if (V2Value < V2min && bool.Parse(CurrentStatus.SuppressChkBox2Content))
                                    {
                                        V2Value = V2min;

                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            SuppressedTxtBox2.BackColor = Color.Red;
                                            SuppressedTxtBox2.Update();
                                        });
                                    }
                                    SendVariable("n", float.Parse(V1Value.ToString()), "alpha", float.Parse(V2Value.ToString()), CurrentStatus.MeasurementActiveTxtBoxContent);
                                }
                                catch (Exception ex)
                                {
                                    if (x.ToString().Contains("E-0") || x.ToString().Contains("E-1"))
                                    {
                                        SendVariable("n", float.Parse(V1Value.ToString()), "alpha", 0, CurrentStatus.MeasurementActiveTxtBoxContent);
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

        /// <summary>
        /// Übertragen der Variablen an den µLC
        /// </summary>
        /// <param name="Variable1">Variablenauswahl 1</param>
        /// <param name="Value1">Wert Variable 1</param>
        /// <param name="Variable2">Variablenauswahl 1</param>
        /// <param name="Value2">Wert Variable 2</param>
        /// <param name="MeasurementActiveTime">Zeit für jeden Testpunkt</param>
        private void SendVariable(string Variable1, float Value1, string Variable2, float Value2, string MeasurementActiveTime)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                V1ValueTxtBox.Text = Value1.ToString();
                V2ValueTxtBox.Text = Value2.ToString();

                V1ValueTxtBox.Update();
                V2ValueTxtBox.Update();
            });


            try
            {
                Thread.Sleep(int.Parse(MeasurementActiveTime));
            }
            catch
            {
                if (ActiveMeasurementTimeSet)
                {
                    MessageBox.Show("Active Measurement Time falsch codiert! Es wird 500ms gewählt.", "FEHLER");

                    ActiveMeasurementTimeSet = true;
                }
                

                this.Invoke((MethodInvoker)delegate ()
                {
                    MeasurementActiveTxtBox.Text = "500";

                    MeasurementActiveTxtBox.Update();
                });

                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Übertragen einer einzelnen Variable an den µLC
        /// </summary>
        /// <param name="Variable">Variablenauswahl</param>
        /// <param name="Value">Wert der Variable</param>
        private void SendSingleVariable(string Variable, float Value)
        {
            V1TxtBox.Text = Variable.ToString();
            V1ValueTxtBox.Text = Value.ToString();

            V2TxtBox.Text = "";
            V2ValueTxtBox.Text = "";
            deltaV1TxtBox.Text = "";
            deltaV2TxtBox.Text = "";
        }

        /// <summary>
        /// Klick-Funktion des "Laden"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            FileNameLoadComboBox.Items.Clear();

            LoadFiles();
        }

        /// <summary>
        /// Füllen der Dateinamen-ComboBox mit den verfügbaren Konfigurationsdateien
        /// </summary>
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

        /// <summary>
        /// Funktion bei Änderung der Steps-Textbox
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void StepsTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StepSlider.Value = int.Parse(StepsTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("\"Steps\" müssen ein Integer-Wert zwischen 2 und 1000 sein!", "FEHLER");
            }
        }

        /// <summary>
        /// Funktion bei Änderung der Slider-Position
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void StepSlider_Scroll(object sender, EventArgs e)
        {
            StepsTxtBox.Text = StepSlider.Value.ToString();
        }

        /// <summary>
        /// Funktion bei Änderung der Measurement Active Time Textbox
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void MeasurementActiveTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(MeasurementActiveTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("Falsches Format!", "FEHLER");

                MeasurementActiveTxtBox.Text = "500";
            }
        }

        /// <summary>
        /// Funktion bei Änderung der Filename-Combobox
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
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
                if (Content[9] == "Saw")
                {
                    SawBtnV1.Checked = true;
                    FuncV1TxtBox.Text = "";
                }
                else if (Content[9] == "Triangle")
                {
                    TriangleBtnV1.Checked = true;
                    FuncV1TxtBox.Text = "";
                }
                else if (Content[9] == "Random")
                {
                    RandBtnV1.Checked = true;
                    FuncV1TxtBox.Text = "";
                }
                else
                {
                    FuncBtnV1.Checked = true;
                    FuncV1TxtBox.Text = Content[9];
                }
                x1minTxtBox.Text = Content[10];
                x1maxTxtBox.Text = Content[11];
                SuppressChkBox1.Checked = bool.Parse(Content[12]);
                if (Content[13] == "Saw")
                {
                    SawBtnV2.Checked = true;
                    FuncV2TxtBox.Text = "";
                }
                else if (Content[13] == "Triangle")
                {
                    TriangleBtnV2.Checked = true;
                    FuncV2TxtBox.Text = "";
                }
                else if (Content[13] == "Random")
                {
                    RandBtnV2.Checked = true;
                    FuncV2TxtBox.Text = "";
                }
                else
                {
                    FuncBtnV2.Checked = true;
                    FuncV2TxtBox.Text = Content[13];
                }
                x2minTxtBox.Text = Content[14];
                x2maxTxtBox.Text = Content[15];
                SuppressChkBox2.Checked = bool.Parse(Content[16]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Konfiguration! \r\n\r\n" + ex.Message, "FEHLER");
            }
        }

        /// <summary>
        /// Klick-Funktion des Buttons zur Berechnung der Simulationszeit
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
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

        /// <summary>
        /// Berechnung der benötigten Simulationszeit
        /// </summary>
        /// <returns>Gibt die ermittelte Zeit zurück</returns>
        private float GetSimTime()
        {
            try
            {
                float Steps = float.Parse(StepsTxtBox.Text);

                float MeasurementTime = ((float)((float.Parse(MeasurementActiveTxtBox.Text) + 0.46) / 1000));

                float Time = float.Parse((Steps * Steps * (MeasurementTime)).ToString());

                return Time;
            }
            catch
            {
                MessageBox.Show("Falsches Format!", "FEHLER");
            }

            return -1;
        }

        /// <summary>
        /// Klick-Funktion des "About"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            AboutWindow frmAbout = new AboutWindow();

            frmAbout.Show();
        }

        /// <summary>
        /// Klick-Funktion des "Archive"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void ConfigArchiveBtn_Click(object sender, EventArgs e)
        {
            ArchiveWindow FormArchive = new ArchiveWindow();

            FormArchive.LoadWindow(Settings[0]);
        }

        /// <summary>
        /// Klick-Funktion des "Settings"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void SettingsBtnClicked(object sender, EventArgs e)
        {
            SettingsWindow FrmSet = new SettingsWindow();

            FrmSet.LoadForm();
        }

        private void TriangleBtnV2_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Klick-Funktion des "Single Value Test Send"-Buttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
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

        /// <summary>
        /// Funktion bei Änderung des FuncBtnV1-Radiobuttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void FuncBtnV1_CheckedChanged(object sender, EventArgs e)
        {
            FuncV1TxtBox.Visible = FuncBtnV1.Checked;
            x1maxTxtBox.Visible = FuncBtnV1.Checked;
            x1minTxtBox.Visible = FuncBtnV1.Checked;
            x1Label.Visible = FuncBtnV1.Checked;
        }

        /// <summary>
        /// Funktion bei Änderung des FuncBtnV2-Radiobuttons
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void FuncBtnV2_CheckedChanged(object sender, EventArgs e)
        {
            FuncV2TxtBox.Visible = FuncBtnV2.Checked;
            x2maxTxtBox.Visible = FuncBtnV2.Checked;
            x2minTxtBox.Visible = FuncBtnV2.Checked;
            x2Label.Visible = FuncBtnV2.Checked;
        }

        /// <summary>
        /// Funktion bei Änderung der SuppressValue-Checkbox
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Eventargs</param>
        private void SuppressChkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}