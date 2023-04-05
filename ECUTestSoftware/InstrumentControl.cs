using bosch.de.abt.beg.microLC.API;
using ECUTestSoftwareConfigTool;
using Etas.OpenEE;
using Mathos.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HTW_Saar.ECUTestSoftware
{
    /// <summary>
    /// This class handles all interactions between INCA and this
    /// instrument. It should react on all events INCA initiates and
    /// accordingly administrate the instrument's user interface.
    /// </summary>
    /// <remarks>
    /// All comments which are surrounded with /* */ present
    /// a little example how an instrument can interact with 
    /// the variables and value accesses of INCA. They are NOT 
    /// necessary to build a faultless working instrument.
    /// </remarks>
    public partial class InstrumentControl : UserControl, IWidget
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

        static MicroLCManager manager = MicroLCManager.InitializeManager(true);
        Device myDevice = manager.Devices[0];

        // string Path = "C:\\Users\\p.dupont.MCG1.000\\Documents\\GoogleDrive\\Dokumente\\HTW\\2. Semester (WS)\\Seminar und Projekt\\INCA-Projekt\\Software\\Konfigurationen";
        private IWidgetHost _WidgetHost; //is supposed to connect to and to react on all of the events included
        //private WidgetHostEventSink _EventSink; 
        //an object of the WidgetHostEventSink class of this custom instrument
        //(This is only one of several possible solutions to manage the context menu.
        // This object is NOT necessary to build a faultless working instrument.)


        /*
        // These objects of the interface ISignalValueAccessScalar and ISignalValueAccessArray of the 
        // Etas.OpenEE library are an example to explain the different possibilites of an access to a 
        // value to get and set information to a measurement or calibration variable:
        private ISignalValueAccessScalar<double> _valueScalarAccessExample; 
        //private ISignalValueAccessArray<double> _valueArrayAccessExample; 
        */

        /// <summary>
        /// Initializes this instrument component.
        /// </summary>
        public InstrumentControl()
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

        /// <summary>
        /// A read only accessor for the widget host of this instrument (widget).
        /// </summary>
        public IWidgetHost WidgetHost
        {
            get { return _WidgetHost; }
        }

        /*
        /// <summary>
        /// A read only accessor for the scalar value access of the current variable
        /// of this instrument.
        /// </summary>
        /// <remarks>
        /// This accessor is only necessary, if you use the WidgetHostEventSink object
        /// in the given example code.
        /// This method is NOT necessary to build a faultless working instrument.
        /// </remarks>
        public ISignalValueAccessScalar<double> ValueScalarAccessExample
        {
            get { return _valueScalarAccessExample; }
        }
        */

        #region Implementation of IWidget

        /// <summary>
        /// This method is called by INCA, if this instrument is initialized by
        /// creating an instance of the instrument or initializing the experiment 
        /// environment with an already existing instance.
        /// </summary>
        /// <param name="host">The host of this widget (instrument).</param>
        public void Initialize(IWidgetHost host)
        {
            _WidgetHost = host;

            host.LoadConfiguration += host_LoadConfiguration;
            host.SaveConfiguration += host_SaveConfiguration;

            host_LoadConfiguration(this, EventArgs.Empty);

            host.InitializeDefaultContextMenus(this);

            host.Configuration.WidgetDatas[0].AssignedElementsChanged +=
                new EventHandler<AssignedElementsChangedEventArgs>(InstrumentControl_AssignedElementsChanged);

            // The collection of all current element references the instrument has:
            IList<IElementReference> initializedElementReferences =
                _WidgetHost.Configuration.WidgetDatas[0].ElementReferences;

            this.InitializeValueAccesses(initializedElementReferences, null);
        }

        /// <summary>
        /// This method handles the "AssignedElementsChanged"-event which is called,
        /// if the user of INCA adds variables to or removes variables from this
        /// instrument.
        /// </summary>
        /// <param name="sender">The object, which initiates the event.</param>
        /// <param name="e">The event arguments, which include a list of all
        /// added and removed element references.</param>
        private void InstrumentControl_AssignedElementsChanged(object sender,
            AssignedElementsChangedEventArgs e)
        {
            this.InitializeValueAccesses(e.Added, e.Removed);
        }

        /// <summary>
        /// This method manages all value accesses of every variable. It is called every
        /// time the user adds or removes variables to this instrument.
        /// </summary>
        /// <remarks>
        /// This is only one of several possible solutions to manage the value accesses.
        /// This method is NOT necessary to build a faultless working instrument.
        /// </remarks>
        /// <param name="addedElements">A list of all added element references.</param>
        /// <param name="removedElements">A list of all removed element references.</param>
        private void InitializeValueAccesses(IList<IElementReference> addedElements,
            IList<IElementReference> removedElements)
        {
            /*
            if (addedElements != null)
            {
               if (addedElements.Count > 0)
               {
                 // These command lines instances the given example of a ISignalValueAccessScalar and -Array object as
                 // DOUBLE type. Also other types for the generic cast at the method ''GetValueAccess'' are possible.
                 _valueScalarAccessExample = addedElements[0].ElementInfo.Scalar.GetValueAccess<double>(EAccessType.Phys, EPageId.Current);
                 //_valueArrayAccessExample = addedElements[0].ElementInfo.Array.GetValueAccess<double>(EAccessType.Phys, EPageId.Current);

                 // With this command lines, you can get the type (Scalar,Array,ASCII,...) and the class (calibration,
                 // measurement) of the given element reference.
                 EElementType elemType = addedElements[0].ElementInfo.Type;
                 EElementClass elemClass = addedElements[0].ElementInfo.Scalar.ElementClass; 

                 // An important event for SignalValueAccesses is the ''ValueChangedEvent''. Here, a new event handler
                 // is set to this event (see corresponding method below).
                 _valueScalarAccessExample.ValueChangedEvent += new EventHandler(exampleValueChangedEvent); 
           
                 // To display the name of a variable you can create an accessor for it. It is of the type IValueAccessScalar<string>
                 // and provides also events to react on changes of the name. This might e.g. occur when the user changes the variable
                 // name setup in INCA.
                 IValueAccessScalar<string> naming = addedElements[0].ElementInfo.GetNaming();
                 string currentName = naming.GetValue("");
               }
            }
            */

            // Process removed elements first

            if (removedElements != null)
            {
                foreach (IElementReference er in removedElements)
                {
                    //TODO implement
                }
            }

            // Then process any added elements

            if (addedElements != null)
            {
                foreach (IElementReference er in addedElements)
                {
                    //TODO implement
                }
            }
        }

        /// <summary>
        /// This method handles the ValueChangedEvent of the valueScalarAccessExample object.
        /// </summary>
        /// <remarks>
        /// This is only one of several possible solutions to manage the ValueChangedEvents.
        /// This method is NOT necessary to build a faultless working instrument.
        /// </remarks>
        /// <param name="sender">The object, which initiates the event.</param>
        /// <param name="e">The event arguments.</param>
        private void exampleValueChangedEvent(object sender, EventArgs e)
        {
            /*
            // Using the method "GetValue", you will receive the actual scalar, vector or array value
            // (dependent on the element type). Because of the instantiation of the ISignalValueAccessScalar
            // object with type DOUBLE, you will get here a value of the type DOUBLE.
            // Please keep in mind that there isn't necessarily a value available always, so we provide
            // a default value of 0.0 in the following code line. Another possibility would be to use
            // the TryGetValue method instead.
            double actualValue = _valueScalarAccessExample.GetValue(0.0);
            */
        }

        /// <summary>
        /// This method is called by INCA, if an instance of this instrument or the
        /// experiment environment closes.
        /// </summary>
        public void DeInitialize()
        {
            _WidgetHost.LoadConfiguration -= host_LoadConfiguration;
            _WidgetHost.SaveConfiguration -= host_SaveConfiguration;

            _WidgetHost = null;

            Dispose();
        }

        /// <summary>
        /// This event handler manages all save configuration events initiated by the widget host. The
        /// save configuration event is called every time the user
        ///     - clicks on the "save"-button at INCA,
        ///     - opens the "variable selection", "display configuration" or "varable configuration" 
        ///       window at the menu "variables" at INCA,
        ///     - closes the experiment environment.
        /// </summary>
        /// <param name="sender">The object, which initiates the event.</param>
        /// <param name="e">The event arguments.</param>
        void host_SaveConfiguration(object sender, System.EventArgs e)
        {
            //TODO implement the persistence of any data that shall be stored within the Experiment

            /*
            // This is an example how you save property informations. In this case, we will set a property
            // with the key "BackgroundColor" to the value of the BackColor used currently in our instrument:
              
            // save the configuration of the background color
            _WidgetHost.Configuration.Properties.SetProperty("BackgroundColor", BackColor);
            
            // All properties defined in the InstrumentProperties.xml are properties public to the
            // user, i.e. they can be seen and configured in the display configuration of INCA.
            // But you are also free to write (and later read) any properties to the configuration that you didn't
            // define in the InstrumentProperties.xml. Just use a key for the property that doesn't 
            // conflict with the keys defined in the InstrumentProperties.xml.
             
            // Remember some private data in a property that is not visible in the display configuration of INCA
            _WidgetHost.Configuration.Properties.SetProperty("MyPrivateConfig", "any kind of data in here....");
            */
        }

        /// <summary>
        /// This event handler manages all load configuration events initiated by the widget host. The
        /// load configuration event is called every time the user creates a new instance of this
        /// instrument at INCA opens the experiment environment with an already existing instance or
        /// changes the display configuration.
        /// </summary>
        /// <param name="sender">The object, which initiates the event.</param>
        /// <param name="e">The event arguments.</param>
        void host_LoadConfiguration(object sender, System.EventArgs e)
        {
            //TODO implement any property loading

            /*
            // The properties you defined in the InstrumentProperties.xml are stored within the experiment.
            // The following example shows how you can access the property value of a property with the
            // key "ModelFile".
            string url;
            bool success  = _WidgetHost.Configuration.Properties.TryGetProperty("ModelFile", out url);

            // For accessing other property types than strings, there exist also some special extension
            // methods in the namespace Etas.OpenEE.Utils, e.g. for a Color
            Color color;
            if(_WidgetHost.Configuration.Properties.TryGetProperty("BackgroundColor", out color))
            {
                BackColor = color;
            }
             
            // Accessing a double value
            double d;
            _WidgetHost.Configuration.Properties.TryGetProperty("NumericPropKey", out d);
             
            */
        }

        /// <summary>
        /// This accessor is necessary for INCA to manage all instruments opened at the experiment
        /// environment (called by INCA at the initialization of this instrument).
        /// </summary>
        public Control Control
        {
            get { return this; }
        }

        /// <summary>
        /// Here, you can return an instance of a class which has implemented the IWidgetHostEventSink
        /// interface. This object is used to handle changes in the default context menu like the optimal
        /// instrument window size or the instrument's properties<seealso cref="IWidgetHostEventSink"/>
        /// (called by INCA at the initialization of this instrument).
        /// </summary>
        /// <remarks>
        /// Change the return value to the commented code line to return a realization of the 
        /// IWidgetHostEventSink interface, implemented by the class WidgetHostEventSink which is appended
        /// to this custom instrument as example standard context menu.
        /// (Please recognize that you also have to use the code lines at the beginning of this class which
        /// initialize the WidgetHostEventSink object called "_EventSink".)
        /// </remarks> 
        public IWidgetHostEventSink WidgetHostEventSink
        {
            get { return null; }
            // get { return (IWidgetHostEventSink)_EventSink; }
        }

        /// <summary>
        /// Here, you can return a list of action description objects. Each with is an action description
        /// serves as a template for context menu items <seealso cref="IActionDescription"/>. (called by INCA
        /// at the initialization of this instrument).
		/// If you need to create dynamic context menu with changing items when one of your subcontrols of your
		/// instrument changes, you need to call "_WidgetHost.EventSink.SelectionChanged()". By calling this method,
		/// INCA will call again GetActionDescriptions(), so that you can define new context menu items.
        /// </summary>
        /// <returns>A list of action descriptions, defined by the instrument.</returns>
        public IList<IActionDescription> GetActionDescriptions()
        {
            return null;
        }

        /// <summary>
        /// This method is called by INCA, if the user of the instrument activates one of the defined context
        /// menu items. Here, the instrument can execute the dependent actions related to the given action
        /// description object.
        /// </summary>
        /// <param name="actionDescription">An action description object which belongs to a specific
        /// context menu item.</param>
        public void ExecuteAction(IActionDescription actionDescription)
        {
            // (default command to remind missing execution if method is called)
            System.Diagnostics.Debug.Assert(false);
        }

        #endregion

        /// <summary>
        /// Funktion zum Laden der gespeicherten Einstellungen
        /// </summary>
        private void LoadSettings()
        {
            //string Path = Directory.GetCurrentDirectory() + "\\InternalData\\Settings\\Settings.ptmset";
            //if (!File.Exists(Path))
            //{
            //    MessageBox.Show("Bei erster Benutzung muss das Programm in den Einstellungen konfiguriert werden!", "INFO");

            //    SettingsWindow frmSet = new SettingsWindow();

            //    frmSet.LoadForm();
            //}
            //else
            //{
            //    StreamReader SR = new StreamReader(Path);

            //    Settings = SR.ReadToEnd().Replace("\r", "").Split('\n');

            //    SR.Close();
            //    SR.Dispose();
            //}
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
                MeasurementActiveTxtBox.Text = Content[7];
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
                try
                {
                    myDevice.RPM.Enginespeed = Int32.Parse(SingleValueTxtBox.Text);
                    SendSingleVariable("n", Value);
                }
                catch
                {
                    MessageBox.Show("Falsches Format!", "ERROR");
                }
                
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
