﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Up.DataAccess.Scripts {
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
    internal class Data {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Data() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Up.DataAccess.Resources.Data", typeof(Data).Assembly);
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
        ///   Looks up a localized string similar to -- Insert dummy data for the Company table.
        ///INSERT INTO &quot;Company&quot; (&quot;CompanyName&quot;, &quot;CompanyInfo&quot;)
        ///VALUES (&apos;Tech Innovators Inc.&apos;, &apos;A leading technology company specializing in software development.&apos;);
        ///
        ///-- Insert dummy data for the Department table.
        ///INSERT INTO &quot;Department&quot; (&quot;DepartmentName&quot;)
        ///VALUES (&apos;Engineering&apos;),
        ///       (&apos;Human Resources&apos;),
        ///       (&apos;Sales&apos;),
        ///       (&apos;Marketing&apos;),
        ///       (&apos;Customer Support&apos;);
        ///
        ///-- Insert dummy data for the Position table.
        ///INSERT INTO &quot;Position&quot; (&quot;PositionName&quot;,  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Data_staging {
            get {
                return ResourceManager.GetString("Data.staging", resourceCulture);
            }
        }
    }
}
