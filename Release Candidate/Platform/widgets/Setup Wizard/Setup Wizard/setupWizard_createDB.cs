using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_createDB
    {
        public setupWizard_createDB()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _db_name.Name = "db_name";
            _db_name_lbl.Name = "db_name_lbl";
            _db_user.Name = "db_user";
            _PictureBox1.Name = "PictureBox1";
            _db_user_lbl.Name = "db_user_lbl";
            _db_pwd.Name = "db_pwd";
            _db_pwd_lbl.Name = "db_pwd_lbl";
        }

        private languageTranslations translations;
        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void setupWizard_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                translations = new languageTranslations(mainform.enVars);
                translations.load("setupWizard");
                db_name_lbl.Text = translations.getText("dbName");
                db_user_lbl.Text = translations.getText("dbUser");
                db_pwd_lbl.Text = translations.getText("dbPwd");
                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            db_name.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            db_name_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
        }

        private void db_name_TextChanged(object sender, EventArgs e)
        {
            if (!db_name.Text.Equals("") & !db_user.Text.Equals("") & !db_pwd.Text.Equals(""))
            {
                mainform.settings.dbName = db_name.Text;
                mainform.settings.dbPwd = db_pwd.Text;
                mainform.settings.dbUser = db_user.Text;
            }
            else
            {
            }
        }

        private void db_user_TextChanged(object sender, EventArgs e)
        {
            if (!db_name.Text.Equals("") & !db_user.Text.Equals("") & !db_pwd.Text.Equals(""))
            {
                mainform.settings.dbName = db_name.Text;
                mainform.settings.dbPwd = db_pwd.Text;
                mainform.settings.dbUser = db_user.Text;
            }
            else
            {
            }
        }

        private void db_pwd_TextChanged(object sender, EventArgs e)
        {
            if (!db_name.Text.Equals("") & !db_user.Text.Equals("") & !db_pwd.Text.Equals(""))
            {
                mainform.settings.dbName = db_name.Text;
                mainform.settings.dbPwd = db_pwd.Text;
                mainform.settings.dbUser = db_user.Text;
            }
            else
            {
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }
    }
}