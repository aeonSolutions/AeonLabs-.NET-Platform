using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_finnish
    {
        public setupWizard_finnish()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _btnContinueTxt.Name = "btnContinueTxt";
            _btnContinue.Name = "btnContinue";
            _PictureBox1.Name = "PictureBox1";
        }

        private languageTranslations translations;
        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            btnContinueTxt.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            SuspendLayout();
            translations = new languageTranslations(mainform.enVars);
            translations.load("setupWizard");
            btnContinueTxt.Text = translations.getText("startApp");
            ResumeLayout();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            wizardGoForward();
        }

        private void btnContinueTxt_Click(object sender, EventArgs e)
        {
            wizardGoForward();
        }

        private void wizardGoForward()
        {
            Process.Start(Path.Combine(Environment.CurrentDirectory, "finnish.exe"));
            Application.Exit();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void subtitle_Click(object sender, EventArgs e)
        {
        }
    }
}