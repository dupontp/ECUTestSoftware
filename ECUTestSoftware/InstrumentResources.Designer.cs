﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTW_Saar.ECUTestSoftware {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class InstrumentResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal InstrumentResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HTW_Saar.ECUTestSoftware.InstrumentResources", typeof(InstrumentResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap htwsaar_Logo_ingwi {
            get {
                object obj = ResourceManager.GetObject("htwsaar_Logo_ingwi", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;PropertiesMetadata Provider=&quot;HTW_Saar&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xsi:noNamespaceSchemaLocation=&quot;
        ///\Program Files (x86)\Common Files\ETAS\INCA7.2\XML\schema\Etas.OpenEE.Properties.xsd&quot;&gt;
        ///  &lt;PropertyGroups&gt;
        ///    &lt;PropertyGroup Type=&quot;InstrumentProperties&quot;&gt;
        ///    &lt;/PropertyGroup&gt;
        ///  &lt;/PropertyGroups&gt;
        ///&lt;/PropertiesMetadata&gt;
        ///&lt;!----&gt;
        ///&lt;!--Description of XML-structure and example:--&gt;
        ///&lt;!--
        ///
        ///As you can see above, if you have appended properties o [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InstrumentProperties {
            get {
                return ResourceManager.GetString("InstrumentProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;Widget Provider=&quot;HTW_Saar&quot; Type=&quot;Instrument&quot; DisplayName=&quot;Str_Instrument&quot; IconName=&quot;Ico_InstrumentIcon&quot; PreferredSize=&quot;100,100&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xsi:noNamespaceSchemaLocation=&quot;C:\Program Files (x86)\Common Files\ETAS\INCA7.2\XML\schema\Etas.OpenEE.Widget.xsd&quot;&gt;
        ///  &lt;Properties RefType=&quot;InstrumentProperties&quot; /&gt;
        ///  &lt;WidgetDataTypes&gt;
        ///    &lt;WidgetData&gt;
        ///      &lt;PossibleSignals MinVariableCount=&quot;1&quot; MaxVariableCount=&quot;1000&quot;&gt;
        ///        &lt;Signa [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InstrumentType {
            get {
                return ResourceManager.GetString("InstrumentType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Marvin {
            get {
                object obj = ResourceManager.GetObject("Marvin", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap SawBtn {
            get {
                object obj = ResourceManager.GetObject("SawBtn", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ECUTestSoftware.
        /// </summary>
        internal static string Str_Instrument {
            get {
                return ResourceManager.GetString("Str_Instrument", resourceCulture);
            }
        }
    }
}
