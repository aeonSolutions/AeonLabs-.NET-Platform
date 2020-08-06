using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Environment
{
    public class updateEnvironmentClass
    {
        public static event UpDateEnvironemntEventHandler UpDateEnvironemnt;

        public static delegate void UpDateEnvironemntEventHandler(object sender, environmentVarsCore envars);

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
                foreach (var ass in (IEnumerable)assembly)
                {
                    assToLoad = new environmentAssembliesClass();
                    assToLoad.friendlyUID = Conversions.ToString(ass.key);
                    assToLoad.assemblyFileName = Conversions.ToString(ass.value);
                    result.Add(Conversions.ToString(ass.key), assToLoad);
                }
            }

            return result;
        }
    }
}