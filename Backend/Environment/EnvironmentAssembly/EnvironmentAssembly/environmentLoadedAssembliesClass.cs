using System;
using System.Windows.Forms;

namespace AeonLabs.Environment.Assembly
{
    public class environmentLoadedAssembliesClass
    {
        public string spaceName { get; set; }
        public string UID { get; set; }
        public Type AssemblyObject { get; set; }
        public FormCustomized assemblyFormToLoad { get; set; }
        public string assemblyFormName { get; set; }
        public int minWidth { get; set; }
        public int minHeight { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public Control control { get; set; }
        public AnchorStyles anchor { get; set; }
    }
}