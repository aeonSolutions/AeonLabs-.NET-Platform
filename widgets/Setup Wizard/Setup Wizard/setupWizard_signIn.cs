using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_signIn
    {
        public setupWizard_signIn()
        {
            bwRegie = new BackgroundWorker();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _server_msg.Name = "server_msg";
            _signInCode.Name = "signInCode";
            _signInCode_lbl.Name = "signInCode_lbl";
            _send.Name = "send";
            _email_lbl.Name = "email_lbl";
            _email.Name = "email";
            _show_password.Name = "show_password";
            _sign_id.Name = "sign_id";
            _forgot_id.Name = "forgot_id";
            _sign_in_lbl.Name = "sign_in_lbl";
            _PictureBox1.Name = "PictureBox1";
        }

        private bool showpass;
        private languageTranslations translations;
        private messageBoxForm msgbox;
        private BackgroundWorker _bwRegie;

        private BackgroundWorker bwRegie
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _bwRegie;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_bwRegie != null)
                {
                    _bwRegie.DoWork -= bwRegie_DoWork;
                    _bwRegie.RunWorkerCompleted -= bwRegie_RunWorkerCompleted;
                }

                _bwRegie = value;
                if (_bwRegie != null)
                {
                    _bwRegie.DoWork += bwRegie_DoWork;
                    _bwRegie.RunWorkerCompleted += bwRegie_RunWorkerCompleted;
                }
            }
        }

        private IsmartCard nfCard;
        private bool authByCard = false;
        private bool loginSuccess = false;
        private HttpDataPostData _checkCredentialsHttp;

        private HttpDataPostData checkCredentialsHttp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _checkCredentialsHttp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_checkCredentialsHttp != null)
                {
                    _checkCredentialsHttp.dataArrived -= checkCredentialsHttp_dataArrived;
                }

                _checkCredentialsHttp = value;
                if (_checkCredentialsHttp != null)
                {
                    _checkCredentialsHttp.dataArrived += checkCredentialsHttp_dataArrived;
                }
            }
        }

        private HttpDataPostData _sendEmailHttp;

        private HttpDataPostData sendEmailHttp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sendEmailHttp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sendEmailHttp != null)
                {
                    _sendEmailHttp.dataArrived -= sendEmailHttp_dataArrived;
                }

                _sendEmailHttp = value;
                if (_sendEmailHttp != null)
                {
                    _sendEmailHttp.dataArrived += sendEmailHttp_dataArrived;
                }
            }
        }

        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            sign_id.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            sign_in_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            forgot_id.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            signInCode.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            signInCode_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            email.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            email_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            send.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            server_msg.Font = new Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular);
            ResumeLayout();
        }

        private void setupWizard_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                translations = new languageTranslations(mainform.enVars);
                translations.load("setupWizard");
                sign_in_lbl.Text = translations.getText("signIn");
                forgot_id.Text = translations.getText("forgotId") + " ?";
                email_lbl.Text = translations.getText("email");
                send.Text = translations.getText("send");
                signInCode_lbl.Text = translations.getText("code");
                ResumeLayout();
                mainform.enVars.currentLang = mainform.settings.lang;
                showpass = true;
                authByCard = false;
                server_msg.Visible = false;
                mainform.forwardPicBtn.Visible = false;
                try
                {
                    nfCard = (IsmartCard)loadDllObject(mainform.enVars, "contactless.smartcards.dll", "smartCard");
                }
                catch (Exception ex)
                {
                    nfCard = null;
                }

                if (nfCard is object)
                {
                    if (nfCard.SelectDevice())
                    {
                        var smartCardReaders = new List<string>();
                        string errMsg = "";
                        if (nfCard.GetAvailableReaders(smartCardReaders, errMsg))
                        {
                            authByCard = true;
                            server_msg.Visible = true;
                            doCardAuth();
                        }
                    }
                }
            }
        }

        private void doCardAuth()
        {
            signInCode.Enabled = false;
            translations.load("loginDialog");
            server_msg.Text = translations.getText("passCardOnReader");
            sign_id.Enabled = false;
            bwRegie = new BackgroundWorker();
            bwRegie.WorkerSupportsCancellation = true;
            bwRegie.RunWorkerAsync();
        }

        private void bwRegie_DoWork(object sender, DoWorkEventArgs e)
        {
            var cardData = new string[2];
            loginSuccess = false;
            if (nfCard.SelectDevice())
            {
                nfCard.establishContext();
                while (loginSuccess.Equals(false))
                {
                    if (nfCard.readCardUID() && !nfCard.getCardUIDString().Equals(""))
                    {
                        cardData[0] = Convert.ToInt64(nfCard.getCardUIDString(), 16).ToString();
                        cardData[1] = !nfCard.readStringOnCard(12, 5) ? "" : nfCard.getReadedString();
                        e.Result = cardData;
                        nfCard.Close();
                        return;
                    }
                }
            }
        }

        private void bwRegie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            translations.load("busyMessages");
            server_msg.Text = translations.getText("commServer");
            signInCode.Text = Conversions.ToString(e.Result((object)1));
            sign_id.Text = Conversions.ToString(e.Result((object)0));
            checkCredentialsOnWeb();
        }

        private void checkCredentialsOnWeb()
        {
            if (sign_id.Text.Equals("") | !Information.IsNumeric(sign_id.Text))
            {
                return;
            }

            mainform.forwardPicBtn.Visible = false;
            mainform.backPicBtn.Visible = false;
            translations = new languageTranslations(mainform.enVars);
            translations.load("busyDialog");
            var vars = new Dictionary<string, string>();
            vars.Add("task", "101");
            vars.Add("id", sign_id.Text.ToString().Replace(" ", ""));
            vars.Add("idkey", signInCode.Text.ToString().Replace(" ", ""));
            vars.Add("type", "unknown");

            // install default secret key
            mainform.enVars.secretKey = mainform.defaultEncryptionKey;
            mainform.enVars.currentLang = mainform.settings.lang;
            checkCredentialsHttp = new HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr + mainform.settings.ApiServerAddrPath);
            checkCredentialsHttp.loadQueue(vars);
            checkCredentialsHttp.startRequest();
        }

        private void checkCredentialsHttp_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            if (!IsResponseOk(responseData))
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars);
                BringToFront();
                Application.DoEvents();
                msgbox.ShowDialog();
                if (authByCard)
                {
                    doCardAuth();
                }

                mainform.forwardPicBtn.Visible = true;
                mainform.backPicBtn.Visible = true;
                return;
            }

            mainform.settings.userId = sign_id.Text;
            mainform.forwardPicBtn.Visible = true;
            mainform.backPicBtn.Visible = true;
        }

        private void forgot_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            email.Visible = true;
            email_lbl.Visible = true;
            send.Visible = true;
        }

        private void show_password_Click(object sender, EventArgs e)
        {
            if (showpass)
            {
                show_password.Image = Image.FromFile(mainform.enVars.imagesPath + Convert.ToString("show_password.png"));
                signInCode.PasswordChar = Conversions.ToChar("");
                showpass = false;
            }
            else
            {
                show_password.Image = Image.FromFile(mainform.enVars.imagesPath + Convert.ToString("hide_password.png"));
                signInCode.PasswordChar = '•';
                showpass = true;
            }
        }

        private void send_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!IsValidEmailFormat(email.Text))
            {
                return;
            }

            var vars = new Dictionary<string, string>();
            vars.Add("task", "1011");
            vars.Add("email", email.Text);
            vars.Add("type", "unknown");
            // install default secret key
            mainform.enVars.secretKey = mainform.defaultEncryptionKey;
            mainform.enVars.currentLang = mainform.settings.lang;
            sendEmailHttp = new HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr + mainform.settings.ApiServerAddrPath);
            sendEmailHttp.loadQueue(vars);
            sendEmailHttp.startRequest();
        }

        private void sendEmailHttp_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            if (!IsResponseOk(responseData))
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars);
                BringToFront();
                Application.DoEvents();
                msgbox.ShowDialog();
            }
            else
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(responseData), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars);
                BringToFront();
                Application.DoEvents();
                msgbox.ShowDialog();
            }
        }
    }
}