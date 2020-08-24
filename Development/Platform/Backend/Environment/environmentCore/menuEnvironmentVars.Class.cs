using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AeonLabs.Environment.Core
{
    public class menuEnvironmentVarsClass
    {
        // duplicate on layout env
        public menuClass menu { get; set; } = new menuClass();

        public class menuClass
        {
            public PanelDoubleBuffer menuPanelContainer { get; set; } = new PanelDoubleBuffer();
            public Color MenuPanelBackColor { get; set; }
            public List<menuItemClass> items { get; set; } = new List<menuItemClass>(); // menu items
            public List<int> menuSort { get; set; } = new List<int>();
            public menuDesignPropertiesClass properties { get; set; } = new menuDesignPropertiesClass();

            public class menuDesignPropertiesClass
            {
                public int height { get; set; }
                public int width { get; set; }
                public int ClosedStateSize { get; set; }
                public Color backColor { get; set; }
                public bool border { get; set; }
                public int activeBarWidth { get; set; }
                public Color activeBarColor { get; set; }
            }
        }

        public class menuItemClass
        {
            // settings for loading contents
            public string nameSpaceString { get; set; }         // Note that I´m in namespace  "ConsoleApplication1.MyClassA"
            public string assemblyFriendlyUID { get; set; }
            public Form formWithContentsToLoad { get; set; }
            public bool showAsDialog { get; set; }

            // settings for executing internal code tasks
            public List<string> tasks { get; set; } = new List<string>();

            // settings for design 
            public string menuUID { get; set; }
            public string menuTitle { get; set; }               // menu title string for translations
            public int menuIndex { get; set; }              // 1 is the first on TOP; 0 is disabled
            public int subMenuIndex { get; set; } = -1;      // 1 is the first on TOP; false means is a menu 
            public int menuListIndex { get; set; }            // index of the TOP menu item within the menuitems list
            public menuClass.menuDesignPropertiesClass menuDesignProperties { get; set; }
            public int notifications { get; set; }          // number of notification pending on menu item
            public string icon { get; set; }
            public PanelDoubleBuffer menuItemPanel { get; set; }
            public PanelDoubleBuffer menuActiveBarPanel { get; set; } = null;
            public List<PictureBox> iconPicHolder { get; set; } = new List<PictureBox>(new PictureBox[] { null, null });
            public List<FontAwesome.Sharp.IconPictureBox> iconPicHolderFontAwesome { get; set; } = new List<FontAwesome.Sharp.IconPictureBox>(new FontAwesome.Sharp.IconPictureBox[] { null, null });

            // menu wrapper
            public PanelDoubleBuffer menuWrapperPanel { get; set; }
            public bool isOpen { get; set; }
            public int menuWrapperOpenHeight { get; set; }
        }
    }
}