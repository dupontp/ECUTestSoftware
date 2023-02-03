using Etas.OpenEE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTW_Saar.ECUTestSoftware
{
    /// <summary>
    /// This class is a realization of the IWidgetHostEventSink interface, which determines what happens if 
    /// the user clicks on the "optimal window size" or "properties" menu items at the default context menu
    /// or wants to copy or move variables between other instruments, realized by the IParameter and 
    /// IParameterDescription interfaces.
    /// </summary>
    /// <remarks>
    /// This is only one of several possible solutions to manage the context menu.
    /// This class is NOT necessary to build a faultless working instrument.)
    /// </remarks> 
    public class WidgetHostEventSink : IWidgetHostEventSink
    {
        private InstrumentControl _instrumentControl;
        //The instrument control object of this instrument (widget).

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="instrumentControl">The instrument control object of this instrument (widget).</param>
        public WidgetHostEventSink(InstrumentControl instrumentControl)
        {
            _instrumentControl = instrumentControl;
        }

        #region IWidgetHostEventSink Members

        /// <summary>
        /// This method is called by INCA. It checks, if this widget can compute the parameter (see method
        /// below) identified by the IParameterDescription.Key.
        /// </summary>
        /// <remarks>
        /// Change the return value to the commented code lines to signalize INCA that you have implemented
        /// an ElementsSelection and a ValueSelection for the "ComputeParameter" method below.
        /// </remarks> 
        /// <param name="parameterDescription">Description of the parameter which may be computed 
        /// soon with ComputeParameter.</param>
        /// <returns>True, if the widget can compute the parameter identified by the 
        /// IParameterDescription.Key if passed to ComputeParameter; false otherwise.</returns>
        public bool CanComputeParameter(IParameterDescription parameterDescription)
        {
            return false;
            /*return
              parameterDescription.Key == ParameterIDs.ElementSelection ||
              parameterDescription.Key == ParameterIDs.ValueSelection;*/
        }

        /// <summary>
        /// This method is called by INCA. It demands to a boolean, which gives information
        /// about the property menu item of the context menu. 
        /// </summary>
        /// <returns>True, if the user is allowed to click on the "properties" menu item; 
        /// false otherwise.</returns>
        public bool CanShowProperties()
        {
            return true;
        }

        /// <summary>
        /// This method is called by INCA.
        /// It is run to compute the enabled/disabled state of some context menu entries of
        /// the default context menu (additionaly it is called to get the necessary paramters for an 
        /// IActionDescription which is executed).
        /// </summary>
        /// <remarks>
        /// Change the method to the commented code lines to realize a standard context menu
        /// at INCA, where you can move or copy the given value scalar access (ValueScalarAccessExample)
        /// by context menu. After that implementation, you can also calibrate a calibration variable
        /// by context menu.
        /// </remarks> 
        /// <param name="parameter">A parameter used by actions triggerd from context menus or
        /// key shortcuts.</param>
        /// <returns>True, if the parameter could be comupted without errors; false otherwise.</returns>
        public bool ComputeParameter(IParameter parameter)
        {
            return false;

            /*switch (parameter.Description.Key)
            {
                case ParameterIDs.ElementSelection:
                    parameter.Value = _instrumentControl.WidgetHost.Configuration.WidgetDatas[0].ElementReferences;
                    return true;
                case ParameterIDs.ValueSelection:
                    parameter.Value = new[] { 
                        new ValueSelection(_instrumentControl.ValueScalarAccessExample, EValueFormat.String) };
                    return true;
            }
            return false;*/
        }

        /// <summary>
        /// This method is called by INCA. It demands to a object with type "Size", which gives information
        /// about the optimal window size of this instrument.
        /// </summary>
        /// <returns>The optimal window size of this instrument.</returns>
        public System.Drawing.Size GetOptimalWindowSize()
        {
            //This is an example for an optimal window size:
            System.Drawing.Size size = new System.Drawing.Size(285, 150);
            return size;
        }

        /// <summary>
        /// This method is called by INCA. It demands to a boolean, which gives information
        /// about the optimal window size. 
        /// </summary>
        /// <returns>True, if there exists an optimal window size for this instrument;
        /// false otherwise.</returns>
        public bool HasOptimalWindowSize()
        {
            return true;
        }

        /// <summary>
        /// This method is called, if the user clicks on the "Properties" menu item at the context
        /// menu. 
        /// </summary>
        public void ShowProperties()
        {
            //TODO implement
        }

        #endregion

    }
}
