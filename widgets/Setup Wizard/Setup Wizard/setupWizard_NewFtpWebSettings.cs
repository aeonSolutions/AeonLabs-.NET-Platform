using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_NewFtpWebSettings
    {
        public setupWizard_NewFtpWebSettings()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _password_lbl.Name = "password_lbl";
            _password.Name = "password";
            _username_lbl.Name = "username_lbl";
            _username.Name = "username";
            _connectionType_lbl.Name = "connectionType_lbl";
            _connectionType.Name = "connectionType";
            _server_ftp_port_lbl.Name = "server_ftp_port_lbl";
            _server_ftp_port.Name = "server_ftp_port";
            _domain_ftp_ex.Name = "domain_ftp_ex";
            _server_ftp_addr_lbl.Name = "server_ftp_addr_lbl";
            _server_ftp_addr.Name = "server_ftp_addr";
            _domain_web_ex.Name = "domain_web_ex";
            _server_web_addr_lbl.Name = "server_web_addr_lbl";
            _server_web_addr.Name = "server_web_addr";
            _PictureBox1.Name = "PictureBox1";
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
                server_web_addr_lbl.Text = translations.getText("serverWebAddr");
                server_ftp_addr_lbl.Text = translations.getText("serverFtpAddr");
                server_ftp_port_lbl.Text = translations.getText("serverFtpPort");
                connectionType_lbl.Text = translations.getText("ftpConncetionTypeTitle");
                username_lbl.Text = translations.getText("ftpUsername");
                password_lbl.Text = translations.getText("ftpPassword");
                connectionType.Items.Clear();
                connectionType.Items.Add(translations.getText("ftpConnTypeOverTls"));
                connectionType.Items.Add(translations.getText("ftpConnTypePlain"));
                connectionType.SelectedIndex = 0;
                if (!Information.IsNothing(mainform.settings.serverWebAddr))
                {
                    server_web_addr.Text = mainform.settings.serverWebAddr;
                }

                if (!Information.IsNothing(mainform.settings.serverFtpAddr))
                {
                    server_ftp_addr.Text = mainform.settings.serverFtpAddr;
                }

                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            server_web_addr.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_web_addr_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_ftp_addr.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_ftp_addr_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            domain_web_ex.Font = new Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular);
            domain_ftp_ex.Font = new Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular);
            server_ftp_port_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_ftp_port.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            connectionType_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            connectionType.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            username.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            username_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            password.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            password_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            ResumeLayout();
        }

        private void setupWizard_1_shown(object sender, EventArgs e)
        {
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            wizardGoBack();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            wizardGoBack();
        }

        private void wizardGoBack()
        {
            // 'TODO
            // '        setupWizard_platformType.Show()
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (IsValidUrl("http|https", server_web_addr.Text).Equals(true) & IsValidUrl("ftp", server_ftp_addr.Text).Equals(true) & !username.Text.Equals("") & !password.Text.Equals(""))
            {
                wizardGoForward();
            }
        }

        private void btnContinueTxt_Click(object sender, EventArgs e)
        {
            if (IsValidUrl("http|https", server_web_addr.Text).Equals(true) & IsValidUrl("ftp", server_ftp_addr.Text).Equals(true) & !username.Text.Equals("") & !password.Text.Equals(""))
            {
                wizardGoForward();
            }
        }

        private void wizardGoForward()
        {
            server_web_addr.Text = server_web_addr.Text[server_web_addr.Text.Length - 1].Equals("/") ? server_web_addr.Text.Substring(0, server_web_addr.Text.Length - 2) : server_web_addr.Text;
            server_ftp_addr.Text = server_ftp_addr.Text[server_ftp_addr.Text.Length - 1].Equals("/") ? server_ftp_addr.Text.Substring(0, server_ftp_addr.Text.Length - 2) : server_ftp_addr.Text;
            if (!IsValidUrl("http|https", server_web_addr.Text) && !IsOnline(server_web_addr.Text))  // check if is online and working
            {
                messageBoxForm msgbox;
                msgbox = new messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars);
                msgbox.ShowDialog();
                server_web_addr.Focus();
            }

            bool connectType = false;
            if (connectionType.SelectedIndex.Equals(0))
            {
                connectType = true; // with ssl
            }

            if (!password.Text.Equals("") & !username.Text.Equals("") & !IsValidUrl("ftp", server_ftp_addr.Text) && !IsFtpOnline(connectType, server_ftp_addr.Text, username.Text, password.Text))  // check if is online and working
            {
                messageBoxForm msgbox;
                msgbox = new messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars);
                msgbox.ShowDialog();
                server_web_addr.Focus();
            }

            // web server
            mainform.settings.serverWebAddr = server_web_addr.Text;
            mainform.settings.ApiServerAddrPath = mainform.defaultApiServerAddrPath;
            // ftp server
            mainform.settings.serverFtpAddr = server_ftp_addr.Text;
            mainform.settings.serverFtpPort = server_ftp_port.Text;
            mainform.settings.serverFtpPwd = password.Text;
            mainform.settings.serverFtpUser = username.Text;
            mainform.settings.serverFtpSsl = connectType;

            // 'TODO
            // 'setupWizard_createDB.Show()
        }

        private void server_web_addr_TextChanged(object sender, EventArgs e)
        {
            validateFields();
        }

        private void server_ftp_addr_TextChanged(object sender, EventArgs e)
        {
            validateFields();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            validateFields();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            validateFields();
        }

        private void validateFields()
        {
            if (server_ftp_addr.Text.ToString().IndexOf("ftp.") > -1 & server_ftp_addr.Text.ToString().IndexOf("ftp://") == -1)
            {
                server_ftp_addr.Text = "ftp://" + server_ftp_addr.Text;
                server_ftp_addr.SelectionStart = server_ftp_addr.Text.Length + 1;
            }

            if (server_web_addr.Text.ToString().IndexOf("www.") > -1 & server_web_addr.Text.ToString().IndexOf("http://") == -1 & server_web_addr.Text.ToString().IndexOf("https://") == -1)
            {
                server_web_addr.Text = "http://" + server_web_addr.Text;
                server_web_addr.SelectionStart = server_web_addr.Text.Length + 1;
            }

            if (IsValidUrl("http|https", server_web_addr.Text).Equals(true) & IsValidUrl("ftp", server_ftp_addr.Text).Equals(true) & !username.Text.Equals("") & !password.Text.Equals(""))
            {
            }
            // 'TODO add chdckmark pic
            else
            {
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void title_Click(object sender, EventArgs e)
        {
        }

        private void subtitle_Click(object sender, EventArgs e)
        {
        }
    }
}