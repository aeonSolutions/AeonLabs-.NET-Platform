using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_settingUp
    {
        public setupWizard_settingUp()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _PictureBox1.Name = "PictureBox1";
            _progress_status_text.Name = "progress_status_text";
            _ProgressBar.Name = "ProgressBar";
            _PictureBox2.Name = "PictureBox2";
        }

        private messageBoxForm msgbox;
        private languageTranslations translations;
        private int progressValueTop = 0;
        private setupWizardMainForm mainform;
        private HttpDataPostData _getSecretHttp;

        private HttpDataPostData getSecretHttp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _getSecretHttp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_getSecretHttp != null)
                {
                    _getSecretHttp.dataArrived -= getSecretHttp_dataarrived;
                }

                _getSecretHttp = value;
                if (_getSecretHttp != null)
                {
                    _getSecretHttp.dataArrived += getSecretHttp_dataarrived;
                }
            }
        }

        private HttpDataPostData _registerPC;

        private HttpDataPostData registerPC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _registerPC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_registerPC != null)
                {
                    _registerPC.dataArrived -= registerPC_dataarrived;
                }

                _registerPC = value;
                if (_registerPC != null)
                {
                    _registerPC.dataArrived += registerPC_dataarrived;
                }
            }
        }

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
                progress_status_text.Text = translations.getText("settingUp") + " ...";
                ResumeLayout();
                mainform.enVars.currentLang = mainform.settings.lang;
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            progress_status_text.Font = new Font(mainform.enVars.fontText.Families(0), 9, FontStyle.Bold);
        }

        private void setupWizard_1_shown(object sender, EventArgs e)
        {
            translations = new languageTranslations(mainform.enVars);
            if (mainform.settings.isSharedServer)
            {
                if (mainform.settings.isNewServer) // shared new 
                {
                    SaveSettingsSharedNew();
                }
                else // shared existing
                {
                    SaveSettingsSharedExisting();
                }
            }
            else if (mainform.settings.isNewServer) // own new 
            {
                SaveSettingsOwnNew();
            }
            else // own existing
            {
                SaveSettingsOwnExisting();
            }
        }

        private void SaveSettingsSharedExisting()
        {
        }

        private void SaveSettingsSharedNew()
        {
        }

        private void SaveSettingsOwnNew()
        {
            // REQUEST INSTALL FILES BY FTP ON SITELOGISTICS.CONSTRUCTION

            // REQUEST INSTALL DB ON OWN SERVER (AFTER FILES INSTALATION) + CONFIGURE ADDONS + DELETE SETUP FILES

            // GET SECRET KEY

            // REGISTER PROGRAM ID ON DB

            // REGISTER ADMIN

            // ADD AUTHORIZATIONS FOR DIAGONSTICS AND CRASH DATA ON SITELOGISTICS.CONSTRUCTION

        }

        private void SaveSettingsOwnExisting()
        {
            progressValueTop = 33;
            // GET SECRETE KEY
            getSecretKey();
        }

        private void getSecretKey()
        {
            var vars = new Dictionary<string, string>();
            vars.Add("task", "1020");
            vars.Add("id", mainform.settings.userId);
            // INSTALL DEFAULT SECRET KEY
            mainform.enVars.secretKey = mainform.defaultEncryptionKey;
            mainform.enVars.currentLang = mainform.settings.lang;
            getSecretHttp = new HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr + mainform.settings.ApiServerAddrPath);
            getSecretHttp.loadQueue(vars);
            getSecretHttp.startRequest();
        }

        private void getSecretHttp_dataarrived(object sender, string responseData, Dictionary<string, string> msic)
        {
            if (!IsResponseOk(responseData))
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                BringToFront();
                Application.DoEvents();
                if (msgbox.ShowDialog == DialogResult.Retry)
                {
                    SaveSettingsOwnExisting();
                    return;
                }
                else
                {
                    translations.load("setupWizard");
                    string message = translations.getText("cannotContinue");
                    translations.load("messagebox");
                    msgbox = new messageBoxForm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                    Application.DoEvents();
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }

            try
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);
                if (data.ContainsKey("key"))
                {
                    mainform.settings.ApiEncryptionKey = data["key"].ToString();
                }
                else
                {
                    translations.load("errorMessages");
                    string message = translations.getText("errorLoadingDataFile") + ". " + translations.getText("contactEnterpriseSupport");
                    translations.load("messagebox");
                    msgbox = new messageBoxForm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                    Application.DoEvents();
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }
            catch (Exception e)
            {
                translations.load("errorMessages");
                string message = translations.getText("errorLoadingDataFile") + ". " + translations.getText("contactEnterpriseSupport");
                translations.load("messagebox");
                msgbox = new messageBoxForm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                BringToFront();
                Application.DoEvents();
                msgbox.ShowDialog();
                Application.Exit();
                return;
            }

            ProgressBar.Value = 33;
            progressValueTop = 66;

            // REGISTER COMPUTER programID ON DB
            registerComputerPIDonDB();
        }

        private void registerComputerPIDonDB()
        {
            var vars = new Dictionary<string, string>();
            vars.Add("task", "1021");
            vars.Add("id", mainform.settings.userId);
            vars.Add("pid", mainform.settings.programId);
            // INSTALL DEFAULT SECRETE KEY
            mainform.enVars.secretKey = mainform.settings.ApiEncryptionKey;
            mainform.enVars.currentLang = mainform.settings.lang;
            registerPC = new HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr + mainform.settings.ApiServerAddrPath);
            registerPC.loadQueue(vars);
            registerPC.startRequest();
        }

        private void registerPC_dataarrived(object sender, string responseData, Dictionary<string, string> msic)
        {
            if (!IsResponseOk(responseData))
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                BringToFront();
                Application.DoEvents();
                if (msgbox.ShowDialog == DialogResult.Retry)
                {
                    SaveSettingsOwnExisting();
                    return;
                }
                else
                {
                    translations.load("setupWizard");
                    string message = translations.getText("cannotContinue");
                    translations.load("messagebox");
                    msgbox = new messageBoxForm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }

            ProgressBar.Value = 66;
            progressValueTop = 100;
            // SAVE SETTINGS FILE
            mainform.enVars.secretKey = mainform.enVars.SettingsSecretKey;
            mainform.settings.updateState(mainform.enVars);
            Application.DoEvents();
            mainform.settings.save();
            ProgressBar.Value = 100;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Value < progressValueTop)
            {
                ProgressBar.Increment(1);
            }

            if (ProgressBar.Value == 100)
            {
                Hide();
                Timer.Enabled = false;
                mainform.updateform();
            }
        }

        private void AlphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void title_Click(object sender, EventArgs e)
        {
        }
    }
}