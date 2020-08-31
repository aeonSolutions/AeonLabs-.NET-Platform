using AeonLabs.Environment.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeonLabs.Layouts.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            environmentVarsCore enVars = new environmentVarsCore();
            mainAppLayoutForm mainForm2 = new mainAppLayoutForm(enVars);
            enVars.assemblies = initializeAssembly.AssembliesToLoadAtStart();
            Application.Run(mainForm2);
        }
    }
}
