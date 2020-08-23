using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_ServerAddress
    {
        public setupWizard_ServerAddress()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _domain_web_ex.Name = "domain_web_ex";
            _server_web_addr_lbl.Name = "server_web_addr_lbl";
            _server_web_addr.Name = "server_web_addr";
            _PictureBox1.Name = "PictureBox1";
            _selectionOkpic.Name = "selectionOkpic";
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
                if (IsValidUrl("http|https", mainform.settings.serverWebAddr).Equals(true))
                {
                    selectionOkpic.Visible = false;
                }
                else
                {
                    selectionOkpic.Visible = true;
                }

                server_web_addr_lbl.Text = translations.getText("serverWebAddr");
                if (!Information.IsNothing(mainform.settings.serverWebAddr))
                {
                    server_web_addr.Text = mainform.settings.serverWebAddr;
                }

                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            server_web_addr.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_web_addr_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            domain_web_ex.Font = new Font(mainform.enVars.fontTitle.Families(0), 7, FontStyle.Regular);
            ResumeLayout();
        }

        private void setupWizard_1_shown(object sender, EventArgs e)
        {
        }

        private void server_web_addr_TextChanged(object sender, EventArgs e)
        {
            if (server_web_addr.Text.ToString().IndexOf("www.") > -1 & server_web_addr.Text.ToString().IndexOf("http://") == -1 & server_web_addr.Text.ToString().IndexOf("https://") == -1)
            {
                server_web_addr.Text = "http://" + server_web_addr.Text;
                server_web_addr.SelectionStart = server_web_addr.Text.Length + 1;
            }

            if (server_web_addr.Text.Equals(""))
            {
                selectionOkpic.Visible = false;
                TimerCheckIsOnline.Enabled = false;
                TimerCheckIsOnline.Stop();
            }
            else if (IsValidUrl("http|https", server_web_addr.Text).Equals(true))
            {
                TimerCheckIsOnline.Enabled = true;
                TimerCheckIsOnline.Start();
            }
            else
            {
                selectionOkpic.Visible = false;
                TimerCheckIsOnline.Enabled = false;
                TimerCheckIsOnline.Stop();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void title_Click(object sender, EventArgs e)
        {
        }

        private void TimerCheckIsOnline_Tick(object sender, EventArgs e)
        {
            if (IsValidUrl("http|https", server_web_addr.Text).Equals(true))
            {
                if (IsOnline(server_web_addr.Text))  // check if is online and working
                {
                    mainform.settings.serverWebAddr = server_web_addr.Text;
                    mainform.settings.isNewServer = false;
                    mainform.settings.ApiServerAddrPath = mainform.defaultApiServerAddrPath;
                    selectionOkpic.Visible = true;
                }
                else
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars);
                    msgbox.ShowDialog();
                }
            }
        }
    }
}