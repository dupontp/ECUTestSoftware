﻿using Etas.OpenEE;
using Etas.OpenEE.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using bosch.de.abt.beg.microLC.API;
using System.Reflection;
using System.Xml.Linq;
using System.Threading;
using System.Windows;
using ASAM.XIL.Interfaces.Testbench.MAPort.Enum;
using System.IO;
using TextBox = System.Windows.Forms.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;

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

        static MicroLCManager manager = MicroLCManager.InitializeManager(true);
        Device myDevice = manager.Devices[0];

        string Path = "C:\\Users\\p.dupont.MCG1.000\\Documents\\GoogleDrive\\Dokumente\\HTW\\2. Semester (WS)\\Seminar und Projekt\\INCA-Projekt\\Software\\Konfigurationen";
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
            //_EventSink = new WidgetHostEventSink(this);
            //an instance of the new WidgetHostEventSink object with this InstrumentControl as parameter

            V1ComboBox.Items.Add("");
            V1ComboBox.Items.Add("n");
            V1ComboBox.Items.Add("alpha");

            V2ComboBox.Items.Add("");
            V2ComboBox.Items.Add("n");
            V2ComboBox.Items.Add("alpha");

            FirmwareTxtBox.Text = myDevice.FirmwareId;
            IsVirtualTxtBox.Text = myDevice.IsVirtual.ToString();
            SoftwareversionTxtBox.Text = myDevice.Softwareversion;
            SerialTxtBox.Text = myDevice.Serial;
            TypeTxtBox.Text = myDevice.Type;

            foreach(string file in Directory.GetFiles(Path))
            {
                FileNameLoadComboBox.Items.Add(file.Replace(Path + "\\", "").Replace(".ptm", ""));
            }
            
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if(V1ComboBox.SelectedItem.ToString() == V2ComboBox.SelectedItem.ToString())
            {
                MessageBox.Show("Dumm?", "FEHLER");
            }

            V1TxtBox.Text = V1ComboBox.SelectedItem.ToString();
            V2TxtBox.Text = V2ComboBox.SelectedItem.ToString();

            V1TxtBox.Update();
            V2TxtBox.Update();

            if (V1ComboBox.SelectedItem == "n" && V2ComboBox.SelectedItem == "alpha")
            {
                if (myDevice.ThrottleValve != null) // MicroLC 2 doesn´t have a Throttle Valve Simulation
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
                else
                {
                    MessageBox.Show("Gerät unterstützt keine Drosselklappenstellungssimulation!", "FEHLER");
                }
            }
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

        private void V1TxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void V2TxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StepSlider_Scroll(object sender, EventArgs e)
        {
            StepsTxtBox.Text = StepSlider.Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(FileNameTxtBox.Text.Trim() == "")
            {
                FileNameTxtBox.Text = "Config" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                FileNameTxtBox.Update();
            }

            try
            {
                string Content = "";

                foreach (Control element in this.Controls)
                {
                    if (element.GetType() == typeof(TextBox))
                    {
                        TextBox ele = element as TextBox;

                        Content += ele.Text + "#";
                    }
                    if (element.GetType() == typeof(ComboBox))
                    {
                        ComboBox ele = element as ComboBox;

                        Content += ele.SelectedItem + "#";
                    }
                }

                //Content: Filename, MeasureTime, Steps, V2max, V1max
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

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader SR = new StreamReader(Path + "\\" + FileNameLoadComboBox.SelectedItem + ".ptm");

                string[] Content = SR.ReadToEnd().Split('#');

                SR.Close();
                SR.Dispose();

                int Index = 0;

                foreach (Control element in this.Controls)
                {
                    if (element.GetType() == typeof(TextBox))
                    {
                        TextBox ele = element as TextBox;

                        ele.Text = Content[Index];
                        Index++;
                    }
                    if (element.GetType() == typeof(ComboBox))
                    {
                        ComboBox ele = element as ComboBox;

                        ele.SelectedItem = Content[Index];
                        Index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Konfiguration! \r\n\r\n" + ex.Message, "FEHLER");
            }
        }

        private void FileNameLoadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
