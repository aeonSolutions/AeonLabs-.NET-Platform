﻿// ------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
// Runtime Version:4.0.30319.42000
// 
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.Diagnostics;

namespace AeonLabs.Settings.My.Resources
{

    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [DebuggerNonUserCode()]
    [System.Runtime.CompilerServices.CompilerGenerated()]
    internal class strings
    {
        private static System.Resources.ResourceManager resourceMan;
        private static System.Globalization.CultureInfo resourceCulture;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() : base()
        {
        }

        /// <summary>
        /// Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    var temp = new System.Resources.ResourceManager("AeonLabs.Settings.strings", typeof(strings).Assembly);
                    resourceMan = temp;
                }

                return resourceMan;
            }
        }

        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }

            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact support for more information.
        /// </summary>
        internal static string contactEnterpriseSupport
        {
            get
            {
                return ResourceManager.GetString("contactEnterpriseSupport", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to DataFile not found.
        /// </summary>
        internal static string errorDataFileNotFound
        {
            get
            {
                return ResourceManager.GetString("errorDataFileNotFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error erasing data.
        /// </summary>
        internal static string errorDeletingData
        {
            get
            {
                return ResourceManager.GetString("errorDeletingData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error saving data to disk.
        /// </summary>
        internal static string errorSavingData
        {
            get
            {
                return ResourceManager.GetString("errorSavingData", resourceCulture);
            }
        }
    }
}