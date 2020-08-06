using System;
using System.Windows.Forms;

namespace AeonLabs.Environment
{
    public class environmentAssembliesClass
    {
        public const int LAYOUT_PACKAGE = 1;
        public const int STARTUP_PACKAGE = 10;
        public const int REGULAR_PACKAGE = 100;
        public const int WIDGET = 200;
        public int packageType;
        public bool deleteOnExit;

        public string spaceName { get; set; }
        public string friendlyUID { get; set; }
        public string UID { get; set; }
        public Type AssemblyObject { get; set; }
        public string assemblyFileName { get; set; }
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