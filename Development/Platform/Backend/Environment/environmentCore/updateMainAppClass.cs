
namespace AeonLabs.Environment.Core
{
    public class updateMainAppClass
    {
        public const int UPDATE_LAYOUT = 10001;
        public const int UPDATE_LAYOUT_BACKGROUND = 10002;
        public const int UPDATE_ENVIRONMENT_VARS = 10003;
        public const int UPDATE_MAIN = 10004;

        public environmentVarsCore envars { get; set; }
        public int updateTask { get; set; } = 0;
        public string backGroundFileName { get; set; } = "";
    }
}