using System.Windows.Forms;

namespace AeonLabs.Environment
{
    public class EnvironmentAssignedToControlClass
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public Control control { get; set; }
        public AnchorStyles anchor { get; set; }
        public environmentLoadedAssembliesClass assembly { get; set; }
    }
}