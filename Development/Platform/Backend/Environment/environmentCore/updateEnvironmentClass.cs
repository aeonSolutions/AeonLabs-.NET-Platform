using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Environment.Core
{
    public class updateEnvironmentClass
    {
        public static event UpDateEnvironemntEventHandler UpDateEnvironemnt;

        public delegate void UpDateEnvironemntEventHandler(object sender, environmentVarsCore envars);

        public void RaiseEnventUpDateEnvironemnt(object sender, environmentVarsCore envars)
        {
            UpDateEnvironemnt?.Invoke(sender, envars);
        }

        public updateEnvironmentClass()
        {
        }

        public Dictionary<string, environmentAssembliesClass> addAssemblies(object assembly)
        {
            var result = new Dictionary<string, environmentAssembliesClass>();
            var assToLoad = new environmentAssembliesClass();
            if (assembly is Dictionary<string, string>)
            {
                foreach (KeyValuePair<string, string> ass in (IEnumerable)assembly)
                {
                    assToLoad = new environmentAssembliesClass();
                    assToLoad.friendlyUID = Conversions.ToString(ass.Key);
                    assToLoad.assemblyFileName = Conversions.ToString(ass.Value);
                    result.Add(Conversions.ToString(ass.Key), assToLoad);
                }
            }

            return result;
        }
    }
}