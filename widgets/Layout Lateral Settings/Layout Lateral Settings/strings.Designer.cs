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

namespace AeonLabs.PlugIns.SideBar.Settings.My.Resources
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
                    var temp = new System.Resources.ResourceManager("AeonLabs.PlugIns.SideBar.Settings.strings", typeof(strings).Assembly);
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
        /// Looks up a localized string similar to Background Image.
        /// </summary>
        internal static string backGroundImage
        {
            get
            {
                return ResourceManager.GetString("backGroundImage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change transparency color.
        /// </summary>
        internal static string colorPallete
        {
            get
            {
                return ResourceManager.GetString("colorPallete", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image.
        /// </summary>
        internal static string imageFile
        {
            get
            {
                return ResourceManager.GetString("imageFile", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Open File....
        /// </summary>
        internal static string openFile
        {
            get
            {
                return ResourceManager.GetString("openFile", resourceCulture);
            }
        }
    }
}