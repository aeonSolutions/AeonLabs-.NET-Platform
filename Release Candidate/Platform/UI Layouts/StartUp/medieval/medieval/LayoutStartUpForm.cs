using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Layouts.StartUp
{
    public sealed partial class LayoutStartUpForm
    {
        public LayoutStartUpForm()
        {
            InitializeComponent();
            _VersionLabel.Name = "VersionLabel";
            _cancelCard_lbl.Name = "cancelCard_lbl";
            _statusMessage.Name = "statusMessage";
            _titleLabel.Name = "titleLabel";
            _locationLabel.Name = "locationLabel";
            _quoteOfTheDaySentenceLabel.Name = "quoteOfTheDaySentenceLabel";
            _versionTitleLabel.Name = "versionTitleLabel";
            _TitleFlavourLabel.Name = "TitleFlavourLabel";
            _websiteLink.Name = "websiteLink";
            _progressbar.Name = "progressbar";
            _panelLogin.Name = "panelLogin";
            _loginBtn.Name = "loginBtn";
            _cardId_lbl.Name = "cardId_lbl";
            _cardId.Name = "cardId";
            _access_code.Name = "access_code";
            _codetxt.Name = "codetxt";
            _show_password.Name = "show_password";
            _PanelLocationText.Name = "PanelLocationText";
            _animatedBackGround.Name = "animatedBackGround";
        }

        public LayoutStartUpForm(environmentVarsCore _envarsCore, ref environmentVarsCore.updateMainLayoutDelegate _updateMainApp)
        {
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            enVars = _envarsCore;
            updateMainApp = _updateMainApp;
            startupBackgroundTasks = new startupBackgroundTasksClass(enVars);
            _VersionLabel.Name = "VersionLabel";
            _cancelCard_lbl.Name = "cancelCard_lbl";
            _statusMessage.Name = "statusMessage";
            _titleLabel.Name = "titleLabel";
            _locationLabel.Name = "locationLabel";
            _quoteOfTheDaySentenceLabel.Name = "quoteOfTheDaySentenceLabel";
            _versionTitleLabel.Name = "versionTitleLabel";
            _TitleFlavourLabel.Name = "TitleFlavourLabel";
            _websiteLink.Name = "websiteLink";
            _progressbar.Name = "progressbar";
            _panelLogin.Name = "panelLogin";
            _loginBtn.Name = "loginBtn";
            _cardId_lbl.Name = "cardId_lbl";
            _cardId.Name = "cardId";
            _access_code.Name = "access_code";
            _codetxt.Name = "codetxt";
            _show_password.Name = "show_password";
            _PanelLocationText.Name = "PanelLocationText";
            _animatedBackGround.Name = "animatedBackGround";
        }

        private environmentVarsCore _enVars;

        public environmentVarsCore enVars
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _enVars;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_enVars != null)
                {
                }

                _enVars = value;
                if (_enVars != null)
                {
                }
            }
        }

        private environmentLoading.loadEnvironment _loadEnVars;

        private environmentLoading.loadEnvironment loadEnVars
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadEnVars;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadEnVars != null)
                {

                    // ' finnsihed loading location data
                    _loadEnVars.environmentDataLoadedCompleted -= state_environmentDataLoadedCompleted;
                }

                _loadEnVars = value;
                if (_loadEnVars != null)
                {
                    _loadEnVars.environmentDataLoadedCompleted += state_environmentDataLoadedCompleted;
                }
            }
        }

        private startupBackgroundTasksClass _startupBackgroundTasks;

        private startupBackgroundTasksClass startupBackgroundTasks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _startupBackgroundTasks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_startupBackgroundTasks != null)
                {
                    _startupBackgroundTasks.updatePrgressBar -= startupBackgroundTasks_updatePrgressBar;
                    _startupBackgroundTasks.updateStatusMessage -= startupBackgroundTasks_updateStatusMessage;
                    _startupBackgroundTasks.loginError -= startupBackgroundTasks_loginError;
                    _startupBackgroundTasks.startUpTasksCompleted -= startupBackgroundTasks_startUpTasksCompleted;
                }

                _startupBackgroundTasks = value;
                if (_startupBackgroundTasks != null)
                {
                    _startupBackgroundTasks.updatePrgressBar += startupBackgroundTasks_updatePrgressBar;
                    _startupBackgroundTasks.updateStatusMessage += startupBackgroundTasks_updateStatusMessage;
                    _startupBackgroundTasks.loginError += startupBackgroundTasks_loginError;
                    _startupBackgroundTasks.startUpTasksCompleted += startupBackgroundTasks_startUpTasksCompleted;
                }
            }
        }

        private environmentVarsCore.updateMainLayoutDelegate updateMainApp;
        private bool showPass;
        private messageBoxForm msgbox;
        private BackgroundWorker _bwDoCardAuth;

        private BackgroundWorker bwDoCardAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _bwDoCardAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_bwDoCardAuth != null)
                {
                    _bwDoCardAuth.DoWork -= bwDoCardAuth_DoWork;
                    _bwDoCardAuth.RunWorkerCompleted -= bwDoCardAuth_RunWorkerCompleted;
                }

                _bwDoCardAuth = value;
                if (_bwDoCardAuth != null)
                {
                    _bwDoCardAuth.DoWork += bwDoCardAuth_DoWork;
                    _bwDoCardAuth.RunWorkerCompleted += bwDoCardAuth_RunWorkerCompleted;
                }
            }
        }

        private int locationTextW, panelTextW;
        private smartCard _smartcard;

        private smartCard smartcard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _smartcard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_smartcard != null)
                {
                }

                _smartcard = value;
                if (_smartcard != null)
                {
                }
            }
        }

        private bool authByCard = false;
        private bool loading = true;

        protected new override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 33554432;
                return cp;
            }
        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
            cancelCard_lbl.Text = My.Resources.strings.cancelBtn;
            cancelCard_lbl.Location = new Point(this.Width - 5 - cancelCard_lbl.Width, this.Height - 5 - cancelCard_lbl.Height);
            access_code.Text = My.Resources.strings.accessCode;
            cardId_lbl.Text = My.Resources.strings.cardId;
            cardId.Text = "";
            codetxt.Text = "";
            loginBtn.Enabled = true;
            codetxt.Focus();
            this.StartPosition = FormStartPosition.CenterScreen;
            panelLogin.Visible = true;
            panelLogin.Location = new Point(this.Width / 2 - panelLogin.Width / 2, panelLogin.Location.Y);

            // Copyright info
            VersionLabel.Text = My.MyProject.Application.Info.Version.Major + "." + My.MyProject.Application.Info.Version.Minor;
            versionTitleLabel.Text = My.Resources.strings.Version;
            int padding = 50;
            panelTextW = PanelLocationText.Width;
            SuspendLayout();
            versionTitleLabel.Location = new Point(this.Width - versionTitleLabel.Width - padding, versionTitleLabel.Location.Y);
            versionTitleLabel.Parent = animatedBackGround;
            versionTitleLabel.BackColor = Color.Transparent;
            VersionLabel.Location = new Point(this.Width - VersionLabel.Width - padding, VersionLabel.Location.Y);
            VersionLabel.Parent = animatedBackGround;
            VersionLabel.BackColor = Color.Transparent;
            progressbar.Parent = animatedBackGround;
            progressbar.BackColor = Color.Transparent;
            progressbar.Location = new Point(this.Width - progressbar.Width - padding, progressbar.Location.Y);
            progressbar.Visible = false;
            statusMessage.Location = animatedBackGround.PointToClient(this.PointToScreen(statusMessage.Location));
            statusMessage.Parent = animatedBackGround;
            statusMessage.BackColor = Color.Transparent;
            statusMessage.Location = new Point(this.Width - statusMessage.Width - padding, statusMessage.Location.Y);
            titleLabel.Parent = animatedBackGround;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Location = new Point(this.Width - titleLabel.Width - padding, titleLabel.Location.Y);
            TitleFlavourLabel.Parent = animatedBackGround;
            TitleFlavourLabel.BackColor = Color.Transparent;
            TitleFlavourLabel.Location = new Point(this.Width - TitleFlavourLabel.Width - padding, TitleFlavourLabel.Location.Y);
            cancelCard_lbl.Parent = animatedBackGround;
            cancelCard_lbl.BackColor = Color.Transparent;
            cancelCard_lbl.Location = new Point(this.Width - cancelCard_lbl.Width - padding, cancelCard_lbl.Location.Y);
            websiteLink.Parent = animatedBackGround;
            websiteLink.BackColor = Color.Transparent;
            websiteLink.Location = new Point(this.Width - websiteLink.Width - padding, websiteLink.Location.Y);

            // 'quoteLabel.Location = backGroundImage.PointToClient(Me.PointToScreen(quoteLabel.Location))
            quoteOfTheDaySentenceLabel.Parent = animatedBackGround;
            quoteOfTheDaySentenceLabel.BackColor = Color.Transparent;
            quoteOfTheDaySentenceLabel.Location = new Point(this.Width - quoteOfTheDaySentenceLabel.Width - padding, quoteOfTheDaySentenceLabel.Location.Y);
            PanelLocationText.Location = new Point(this.Width - PanelLocationText.Width - padding, PanelLocationText.Location.Y);
            PanelLocationText.Parent = animatedBackGround;
            PanelLocationText.BackColor = Color.Transparent;
            locationLabel.Parent = PanelLocationText;
            locationLabel.BackColor = Color.Transparent;
            // 'locationLabel.Location = New Point(Me.Width - locationLabel.Width - padding, locationLabel.Location.Y)
            locationLabel.Text = "";
            panelLogin.Location = animatedBackGround.PointToClient(this.PointToScreen(panelLogin.Location));
            panelLogin.Parent = animatedBackGround;
            cardId_lbl.Location = animatedBackGround.PointToClient(this.PointToScreen(cardId_lbl.Location));
            cardId_lbl.Parent = panelLogin;
            cardId.Location = animatedBackGround.PointToClient(this.PointToScreen(cardId.Location));
            cardId.Parent = panelLogin;
            cardId.BackColor = Color.White;
            access_code.Location = animatedBackGround.PointToClient(this.PointToScreen(access_code.Location));
            access_code.Parent = panelLogin;
            codetxt.Location = animatedBackGround.PointToClient(this.PointToScreen(codetxt.Location));
            codetxt.Parent = panelLogin;
            codetxt.BackColor = Color.White;
            show_password.Location = animatedBackGround.PointToClient(this.PointToScreen(show_password.Location));
            show_password.Parent = panelLogin;
            loginBtn.Location = animatedBackGround.PointToClient(this.PointToScreen(loginBtn.Location));
            loginBtn.Parent = panelLogin;
            ResumeLayout();
            Refresh();
        }

        private void SplashScreen_visibility(object sender, EventArgs e)
        {
            if (this.Visible & loading)
            {
                enVars.successLogin = false;
                progressbar.Bar1.Value = 0;
                progressbar.Visible = false;
                progressbar.ResetText();
                statusMessage.Visible = true;
                cardId.Text = "";
                codetxt.Text = "";
                panelLogin.Visible = false;
                SuspendLayout();
                statusMessage.Text = My.Resources.strings.loading;
                // LOAD COOL SENTENCE
                quoteOfTheDaySentenceLabel.Text = loadSentenceQuoteOfTheDay();
                ResumeLayout();
                locationTextTimer.Enabled = true;
                locationTextTimer.Start();
                loadEnVars = new loadEnvironment(enVars);
                loadEnVars.loadLocation();
                showPass = true;
                authByCard = false;
                try
                {
                    smartcard = (IsmartCard)loadExternalAssembly(enVars, "smartcard.dll", "smartCard");
                }
                catch (Exception ex)
                {
                    smartcard = default;
                }

                if (smartcard is object)
                {
                    if (smartcard.SelectDevice())
                    {
                        var smartCardReaders = new List<string>();
                        string errMsg = "";
                        if (smartcard.GetAvailableReaders(smartCardReaders, errMsg))
                        {
                            authByCard = true;
                            doCardAuthByNFC();
                        }
                    }
                }

                panelLogin.Visible = true;
            }
        }

        private void SplashScreen1_Shown(object sender, EventArgs e)
        {
        }

        private void startupBackgroundTasks_updatePrgressBar(object sender, int value)
        {
            progressbar.Invoke(() =>
            {
                progressbar.Visible = true;
                progressbar.Bar1.Value = value;
            });
        }

        private void startupBackgroundTasks_updateStatusMessage(object sender, string message)
        {
            statusMessage.Invoke(() => statusMessage.Text = message);
        }

        private void startupBackgroundTasks_loginError(object sender, string message)
        {
            msgbox = new messageBoxForm(message + " " + My.Resources.strings.tryAgain + " ?", My.Resources.strings.question, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            if (!message.Equals("skip") && msgbox.ShowDialog == DialogResult.Cancel)
            {
                Application.Exit();
                return;
            }
            else
            {
                codetxt.Invoke(() =>
                {
                    codetxt.Enabled = true;
                    codetxt.Text = "";
                });
                cardId.Invoke(() =>
                {
                    cardId.Enabled = true;
                    cardId.Text = "";
                });
                panelLogin.Invoke(() => panelLogin.Visible = true);
                if (authByCard)
                {
                    cancelCard_lbl.Invoke(() => cancelCard_lbl.Visible = true);
                }
                else
                {
                    cardId.Invoke(() => cardId.Visible = true);
                }

                if (authByCard)
                {
                    doCardAuthByNFC();
                }
            }
        }

        private void codetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                validateCode();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (showPass)
            {
                show_password.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("show_password.png"));
                codetxt.PasswordChar = Conversions.ToChar("");
                showPass = false;
            }
            else
            {
                show_password.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("hide_password.png"));
                codetxt.PasswordChar = '•';
                showPass = true;
            }
        }

        private void state_environmentDataLoadedCompleted()
        {
            if (!this.IsHandleCreated)
            {
                return;
            }

            enVars = loadEnVars.GetEnviroment();
            locationLabel.Invoke(() =>
            {
                locationLabel.Text = enVars.locationData.state + ", " + enVars.locationData.country;
                locationTextW = locationLabel.Width;
            });
        }

        private void doCardAuthByNFC()
        {
            cancelCard_lbl.Visible = true;
            statusMessage.Text = My.Resources.strings.passCardOnReader;
            show_password.Visible = false;
            cardId.Visible = false;
            codetxt.Enabled = false;
            cardId.Enabled = false;
            bwDoCardAuth = new BackgroundWorker();
            bwDoCardAuth.WorkerSupportsCancellation = true;
            bwDoCardAuth.RunWorkerAsync();
        }

        private void bwDoCardAuth_DoWork(object sender, DoWorkEventArgs e)
        {
            var cardData = new string[2];
            enVars.successLogin = false;
            if (smartcard.SelectDevice())
            {
                smartcard.establishContext();
                while (enVars.successLogin.Equals(false))
                {
                    if (smartcard.connectCard())
                    {
                        if (smartcard.readCardUID() && !smartcard.getCardUIDString().Equals(""))
                        {
                            cardData[0] = Convert.ToInt64(smartcard.getCardUIDString(), 16).ToString();
                            cardData[1] = !smartcard.readStringOnCard(12, 5) ? "" : smartcard.getReadedString();
                            e.Result = cardData;
                            smartcard.Close();
                            return;
                        }
                    }
                }
            }
        }

        private void bwDoCardAuth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusMessage.Text = My.Resources.strings.commServer;
            codetxt.Text = Conversions.ToString(e.Result((object)1));
            cardId.Text = Conversions.ToString(e.Result((object)0));
            if (authByCard)
            {
                cancelCard_lbl.Visible = false;
            }
            else
            {
                cardId.Visible = false;
            }

            validateCode();
        }

        private void validateCode()
        {
            enVars.successLogin = false;
            cardId.Enabled = false;
            codetxt.Enabled = false;
            statusMessage.Text = My.Resources.strings.commServer;
            statusMessage.Visible = true;
            if (codetxt.Text.Equals("") | !Information.IsNumeric(codetxt.Text) | cardId.Text.Equals("") | !Information.IsNumeric(cardId.Text))
            {
                msgbox = new messageBoxForm(My.Resources.strings.loginFailed + ". " + My.Resources.strings.tryAgain + " ?", My.Resources.strings.question, MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
                if (msgbox.ShowDialog == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                }

                access_code.Text = My.Resources.strings.accessCode;
                codetxt.Enabled = true;
                cardId.Enabled = true;
                cardId.Enabled = true;
                statusMessage.Visible = true;
                codetxt.Text = "";
                cardId.Text = "";
                return;
            }

            panelLogin.Visible = false;
            panelLogin.Refresh();
            startupBackgroundTasks.doLogin(cardId.Text.ToString(), codetxt.Text.ToString());
        }

        private void startupBackgroundTasks_startUpTasksCompleted(object sender, environmentVarsCore enVarsResult)
        {
            enVars = enVarsResult;
            var dataUpdate = new updateMainAppClass();
            dataUpdate.envars = enVars;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_MAIN;
            updateMainApp.Invoke(this, dataUpdate);
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            validateCode();
        }

        private void cancelCard_lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dataUpdate = new updateMainAppClass();
            dataUpdate.envars = enVars;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_MAIN;
            updateMainApp.Invoke(this, dataUpdate);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void websiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(enVars.customization.websiteToLoadProgram);
        }

        private void locationTextTimer_Tick(object sender, EventArgs e)
        {
            if (locationTextW > panelTextW)
            {
                locationLabel.Left = locationLabel.Left - 3;
                if (locationLabel.Left < 0 - locationLabel.Width)
                {
                    locationLabel.SuspendLayout();
                    locationLabel.Left = PanelLocationText.Width;
                    locationLabel.ResumeLayout();
                }
            }
        }
    }
}