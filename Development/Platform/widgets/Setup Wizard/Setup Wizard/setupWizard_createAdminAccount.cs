using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_createAdminAccount
    {
        public setupWizard_createAdminAccount()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _PictureBox3.Name = "PictureBox3";
            _id_verify_lbl.Name = "id_verify_lbl";
            _id_verify.Name = "id_verify";
            _id_lbl.Name = "id_lbl";
            _id.Name = "id";
            _full_name_lbl.Name = "full_name_lbl";
            _full_name.Name = "full_name";
        }

        private languageTranslations translations;
        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void setupWizard_1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                translations = new languageTranslations(mainform.enVars);
                translations.load("setupWizard");
                full_name_lbl.Text = translations.getText("AdminFullName");
                id_lbl.Text = translations.getText("AdminId");
                id_verify_lbl.Text = translations.getText("AdminIdVerify");
                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            full_name.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            full_name_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            full_name.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            full_name_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            id.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            id_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            id_verify.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            id_verify_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
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
            if (full_name.Text.Equals("") | id.Text.Equals("") | id_verify.Text.Equals("") | !id.Text.Equals(id_verify.Text))
            {
                return;
            }

            mainform.settings.adminName = full_name.Text;
            mainform.settings.adminId = id.Text;
            // 'TODO
            // '        setupWizard_DiagnosticsCrashData.Show()
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            var OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Abrir ficheiro...";
            OpenFileDialog1.Multiselect = false;
            OpenFileDialog1.Filter = "Imagem jpg|*.jpg";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = OpenFileDialog1.FileName;
                PictureBox3.Image = Image.FromFile(filename);
                PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void full_name_TextChanged(object sender, EventArgs e)
        {
            if (!full_name.Text.Equals("") & !id.Text.Equals("") & !id_verify.Text.Equals(""))
            {
            }
            else
            {
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            if (!full_name.Text.Equals("") & !id.Text.Equals("") & !id_verify.Text.Equals(""))
            {
            }
            else
            {
            }
        }

        private void id_verify_TextChanged(object sender, EventArgs e)
        {
            if (!full_name.Text.Equals("") & !id.Text.Equals("") & !id_verify.Text.Equals(""))
            {
            }
            else
            {
            }
        }

        private void AlphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void subtitle_Click(object sender, EventArgs e)
        {
        }
    }
}