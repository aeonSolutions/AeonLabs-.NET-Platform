using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AeonLabs.Environment
{
    public class environmentLayoutClass
    {
        public environmentLayoutClass()
        {
            menu = new menuEnvironmentVarsClass.menuClass();
        }

        public Dictionary<string, string> externalImages = new Dictionary<string, string>();
        private menuEnvironmentVarsClass.menuClass _menu;

        public menuEnvironmentVarsClass.menuClass menu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _menu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _menu = value;
            }
        }

        // MAIN LAYOUT design scheme
        public Color MENU_BACK_COLOR { get; set; } = Color.Black;
        public int MENU_CLOSED_STATE { get; set; } = 40;
        public int MENU_OPEN_STATE { get; set; } = 400;
        public int PANEL_SCROOL_UNDERLAY { get; set; } = 30;

        // widgets & plugIns design scheme
        public Color labelForeColor { get; set; } = Color.White;
        public Color linkLabelForeColor { get; set; } = Color.White;
        public Color buttonForecolor { get; set; } = Color.White;
        public Color editTextBackColor { get; set; } = Color.White;
        public Color controlWithSelectionBackcolor { get; set; }
        public Color buttonBackcolor { get; set; }
        public Color borderColor { get; set; }
        public Color PanelBackColor { get; set; }
        public double PanelTransparencyIndex { get; set; }
        public int IconsDefaultSize { get; set; }

        // Time interval to change background image on main form
        public TimeSpan RandomBackgroundTimeInterval { get; set; } = new TimeSpan(0, 15, 0); // 15 min timeout - integer (Hours, Minutes, Seconds) 
                                                                                             // fonts
        public PrivateFontCollection fontText = new PrivateFontCollection(), fontTitle = new PrivateFontCollection();

        public string fontTitleFile { get; set; } = "TrajanPro.ttf";
        public string fontTextFile { get; set; } = "Roboto-Medium.ttf";

        // font text size
        public int menuTitleFontSize { get; set; } = 10;
        public int subMenuTitleFontSize { get; set; } = 8;
        public int buttonFontSize { get; set; } = 12;
        public int SmallTextFontSize { get; set; } = 7;
        public int RegularTextFontSize { get; set; } = 9;
        public int DialogTitleFontSize { get; set; } = 12;
        public int groupBoxTitleFontSize { get; set; } = 8;
        // main color schemes
        public Color buttonColor { get; set; } = Color.DarkOrange;
        public Color dividerColor { get; set; } = Color.FromArgb(253, 186, 49);
        public Color colorMainMenu { get; set; } = Color.FromArgb(35, 40, 45);
        public Color colorMainPageHeader { get; set; } = Color.FromArgb(253, 186, 49);

        public void loadDefaults(environmentVarsCore envars)
        {
            // ToDo check default font files are present
            var FontFileName = new FileInfo(envars.fontsPath + fontTitleFile);
            FontFileName.Refresh();
            if (FontFileName.Exists)
            {
                envars.layoutDesign.fontTitle.AddFontFile(envars.fontsPath + fontTitleFile);
            }
            else
            {
                MessageBox.Show("font file not found. reinstall the program");
                throw new Exception("font file not found");
            }

            FontFileName = new FileInfo(envars.fontsPath + fontTextFile);
            FontFileName.Refresh();
            if (FontFileName.Exists)
            {
                envars.layoutDesign.fontText.AddFontFile(envars.fontsPath + fontTextFile);
            }
            else
            {
                MessageBox.Show("font file not found. reinstall the program");
                throw new Exception("font file not found");
            }
        }
    }
}