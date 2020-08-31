using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeonLabs.PlugIns.SideBar.Settings
{
    static class Program { 
   

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new lateralSettingsForm(new Environment.Core.environmentVarsCore()));

        }
    }
}