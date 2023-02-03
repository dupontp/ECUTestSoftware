using Etas.OpenEE;
using System.Resources;
using System.Xml.Linq;

namespace HTW_Saar.ECUTestSoftware
{
    public class InstrumentPlugin : IWidgetPlugin
    {
        #region IWidgetPlugin Members

        public XElement TypeDescription
        {
            get;
            private set;
        }

        public XElement PropertiesDescription
        {
            get;
            private set;
        }

        public void Initialize(IWidgetPluginHost pluginHost)
        {
            TypeDescription = XElement.Parse(InstrumentResources.InstrumentType);
            PropertiesDescription = XElement.Parse(InstrumentResources.InstrumentProperties);
        }

        public void DeInitialize()
        {

        }

        public ResourceManager Resources
        {
            get { return new ResourceManager(typeof(InstrumentResources)); }
        }

        public IWidget CreateInstrument()
        {
            return new InstrumentControl();
        }

        #endregion
    }
}
