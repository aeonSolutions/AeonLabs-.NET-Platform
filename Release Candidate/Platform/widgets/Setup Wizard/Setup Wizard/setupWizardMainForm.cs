using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizardMainForm : FormCustomized
    {
        public setupWizardMainForm()
        {
            if (ExternalLoadEnVars is object)
            {
                enVars = ExternalLoadEnVars;
            }

            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout();
            this.Refresh();
            translations = new languageTranslations(enVars);

            // for testing only
            loadFormsForTesting();
            // loadAssembly()

            // 'LOAD WIZARD FORMS FORMS    ==============================================
            if (TypesOnAssemblies is object)
            {
                setupWizard_language setupWizardLanguageForm = (setupWizard_language)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_language")) as Form);
                setupWizardLanguageForm.preLoadData(this);
                wizardForms.Add(setupWizardLanguageForm);
                setupWizard_country setupWizardCountryForm = (setupWizard_country)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_country")) as Form);
                setupWizardCountryForm.preLoadData(this);
                wizardForms.Add(setupWizardCountryForm);
                setupWizard_platformType setupWizard_platformTypeForm = (setupWizard_platformType)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_platformType")) as Form);
                setupWizard_platformTypeForm.preLoadData(this);
                wizardForms.Add(setupWizard_platformTypeForm);
                setupWizard_ServerAddress setupWizard_ServerAddressForm = (setupWizard_ServerAddress)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_ServerAddress")) as Form);
                setupWizard_ServerAddressForm.preLoadData(this);
                wizardForms.Add(setupWizard_ServerAddressForm);
                setupWizard_signIn setupWizard_signInForm = (setupWizard_signIn)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_signIn")) as Form);
                setupWizard_signInForm.preLoadData(this);
                wizardForms.Add(setupWizard_signInForm);
                setupWizard_NewFtpWebSettings setupWizard_NewFtpWebSettingsForm = (setupWizard_NewFtpWebSettings)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_NewFtpWebSettings")) as Form);
                setupWizard_NewFtpWebSettingsForm.preLoadData(this);
                wizardForms.Add(setupWizard_NewFtpWebSettingsForm);
                setupWizard_createDB setupWizard_createDBForm = (setupWizard_createDB)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_createDB")) as Form);
                setupWizard_createDBForm.preLoadData(this);
                wizardForms.Add(setupWizard_createDBForm);
                setupWizard_addOns setupWizard_addOnsForm = (setupWizard_addOns)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_addOns")) as Form);
                setupWizard_addOnsForm.preLoadData(this);
                wizardForms.Add(setupWizard_addOnsForm);
                setupWizard_createAdminAccount setupWizard_createAdminAccountForm = (setupWizard_createAdminAccount)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_createAdminAccount")) as Form);
                setupWizard_createAdminAccountForm.preLoadData(this);
                wizardForms.Add(setupWizard_createAdminAccountForm);
                setupWizard_DiagnosticsCrashData setupWizard_DiagnosticsCrashDataForm = (setupWizard_DiagnosticsCrashData)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_DiagnosticsCrashData")) as Form);
                setupWizard_DiagnosticsCrashDataForm.preLoadData(this);
                wizardForms.Add(setupWizard_DiagnosticsCrashDataForm);
                setupWizard_settingUp setupWizard_settingUpForm = (setupWizard_settingUp)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_settingUp")) as Form);
                setupWizard_settingUpForm.preLoadData(this);
                wizardForms.Add(setupWizard_settingUpForm);
                setupWizard_finnish setupWizard_finnishForm = (setupWizard_finnish)(Activator.CreateInstance(TypesOnAssemblies.GetType("ConstructionSiteLogistics.Setup.Gui.setupWizard_finnish")) as Form);
                setupWizard_finnishForm.preLoadData(this);
                wizardForms.Add(setupWizard_finnishForm);
            }
            else
            {
                loadFormsForTesting();
            }

            loadTitlesAndSubTitles();
            _AlphaGradientPanel1.Name = "AlphaGradientPanel1";
            _Panel1.Name = "Panel1";
            _forwardPicBtn.Name = "forwardPicBtn";
            _Panel2.Name = "Panel2";
            _backPicBtn.Name = "backPicBtn";
            _PanelMain.Name = "PanelMain";
            _PanelBottom.Name = "PanelBottom";
            _PanelTop.Name = "PanelTop";
            _title.Name = "title";
            _subtitle.Name = "subtitle";
        }

        public environmentVars ExternalLoadEnVars { get; set; } = default;
        public Assembly TypesOnAssemblies { get; set; } = null;

        public environmentVars enVars = new environmentVars();
        public string defaultEncryptionKey = "26kozQaMwRuNJ24t";
        public string defaultApiServerAddrPath = "/csaml/api/index.php";
        public Settings settings = new Settings();

        public languageTranslations translations { get; set; }
        public FingerPrint programId { get; set; } = new FingerPrint();

        // 'FORMS
        private int FadeAlpha;
        private bool fadeIn;
        private List<Form> wizardForms = new List<Form>();
        private int WizardFormsLoadedIndex = 0;
        private List<string> wizardFormsTitles = new List<string>();
        private List<string> wizardFormsSubtitles = new List<string>();
        private bool formLoaded = false;
        private Form CurrentWrapperForm;

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void loadAssembly()
        {
            try
            {
                var assembly = Assembly.LoadFile(enVars.libraryPath + "setup.dll");
                TypesOnAssemblies = assembly;
            }
            catch (Exception ex)
            {
                messageBoxForm msgbox;
                msgbox = new messageBoxForm("Setup error. You need to download and install the lastest version of the program at ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                Application.Exit();
                return;
            }
        }

        private void loadFormsForTesting()
        {
            var setupWizardLanguageForm = new setupWizard_language();
            setupWizardLanguageForm.preLoadData(this);
            wizardForms.Add(setupWizardLanguageForm);
            var setupWizardCountryForm = new setupWizard_country();
            setupWizardCountryForm.preLoadData(this);
            wizardForms.Add(setupWizardCountryForm);
            var setupWizard_platformTypeForm = new setupWizard_platformType();
            setupWizard_platformTypeForm.preLoadData(this);
            wizardForms.Add(setupWizard_platformTypeForm);
            var setupWizard_ServerAddressForm = new setupWizard_ServerAddress();
            setupWizard_ServerAddressForm.preLoadData(this);
            wizardForms.Add(setupWizard_ServerAddressForm);
            var setupWizard_signInForm = new setupWizard_signIn();
            setupWizard_signInForm.preLoadData(this);
            wizardForms.Add(setupWizard_signInForm);
            var setupWizard_NewFtpWebSettingsForm = new setupWizard_NewFtpWebSettings();
            setupWizard_NewFtpWebSettingsForm.preLoadData(this);
            wizardForms.Add(setupWizard_NewFtpWebSettingsForm);
            var setupWizard_createDBForm = new setupWizard_createDB();
            setupWizard_createDBForm.preLoadData(this);
            wizardForms.Add(setupWizard_createDBForm);
            var setupWizard_addOnsForm = new setupWizard_addOns();
            setupWizard_addOnsForm.preLoadData(this);
            wizardForms.Add(setupWizard_addOnsForm);
            var setupWizard_createAdminAccountForm = new setupWizard_createAdminAccount();
            setupWizard_createAdminAccountForm.preLoadData(this);
            wizardForms.Add(setupWizard_createAdminAccountForm);
            var setupWizard_DiagnosticsCrashDataForm = new setupWizard_DiagnosticsCrashData();
            setupWizard_DiagnosticsCrashDataForm.preLoadData(this);
            wizardForms.Add(setupWizard_DiagnosticsCrashDataForm);
            var setupWizard_settingUpForm = new setupWizard_settingUp();
            setupWizard_settingUpForm.preLoadData(this);
            wizardForms.Add(setupWizard_settingUpForm);
            var setupWizard_finnishForm = new setupWizard_finnish();
            setupWizard_finnishForm.preLoadData(this);
            wizardForms.Add(setupWizard_finnishForm);
        }

        public void loadTitlesAndSubTitles()
        {
            translations.load("setupWizard");
            // 'TITLES
            wizardFormsTitles.Add(translations.getText("titleCountry")); // 'country
            wizardFormsTitles.Add(translations.getText("titleCountry")); // 'language
            wizardFormsTitles.Add(translations.getText("titlePlatformType")); // 'platform type
            wizardFormsTitles.Add(translations.getText("title")); // 'server addr
            wizardFormsTitles.Add(translations.getText("titleSignIn")); // 'sign in
            wizardFormsTitles.Add(translations.getText("title")); // 'new ftp setup
            wizardFormsTitles.Add(translations.getText("titleDb")); // 'new db setup
            wizardFormsTitles.Add(translations.getText("AddonsTitle")); // 'new addons setup
            wizardFormsTitles.Add(translations.getText("AdminTitle")); // 'new admin account setup
            wizardFormsTitles.Add(translations.getText("titleDiagnostics")); // ' diagnostics
            wizardFormsTitles.Add(translations.getText("title") + " ..."); // ' settings up
            wizardFormsTitles.Add(translations.getText("titleFinnish"));
            wizardFormsTitles.Add(translations.getText(""));
            wizardFormsTitles.Add(translations.getText(""));
            wizardFormsTitles.Add(translations.getText(""));
            wizardFormsTitles.Add(translations.getText(""));

            // 'SUBTITLES
            wizardFormsSubtitles.Add(translations.getText("subtitleCountry")); // 'country
            wizardFormsSubtitles.Add(translations.getText("subtitleCountry")); // 'language
            wizardFormsSubtitles.Add(translations.getText("subtitlePlatformType")); // 'platform type
            wizardFormsSubtitles.Add(translations.getText("subtitle")); // 'server addr
            wizardFormsSubtitles.Add(translations.getText("subtitleSignIn")); // 'sign in
            wizardFormsSubtitles.Add(translations.getText("subtitle")); // 'new ftp setup
            wizardFormsSubtitles.Add(translations.getText("subtitleDb")); // 'new db setup
            wizardFormsSubtitles.Add(translations.getText("AddonsSubTitle")); // 'new addons setup
            wizardFormsSubtitles.Add(translations.getText("AdminSubtitle")); // 'new admin acc setup
            wizardFormsSubtitles.Add(translations.getText("subtitlePlatformType")); // 'diagnostics
            wizardFormsSubtitles.Add(""); // 'settings up
            wizardFormsSubtitles.Add(translations.getText("subtitleFinnish"));
            wizardFormsSubtitles.Add(translations.getText(""));
            wizardFormsSubtitles.Add(translations.getText(""));
            wizardFormsSubtitles.Add(translations.getText(""));
            wizardFormsSubtitles.Add(translations.getText(""));
            wizardFormsSubtitles.Add(translations.getText(""));
        }

        private void setupWizard_1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible & formLoaded)
            {
            }
        }

        private void setupWizard_0_frm_Load(object sender, EventArgs e)
        {

            // check if setup.cfg file exists and load setup
            var setupCfg = new setupSettings();
            if (setupCfg.load())
            {
                if (!setupCfg.getText("platform").Equals("error"))
                {
                    if (setupCfg.getText("platform").Equals("custom"))
                    {
                        settings.isSharedServer = false;
                    }

                    if (setupCfg.getText("platform").Equals("shared"))
                    {
                        settings.isSharedServer = true;
                    }
                }

                if (!setupCfg.getText("server").Equals("error"))
                {
                    if (setupCfg.getText("server").Equals("new"))
                    {
                        settings.isNewServer = true;
                    }

                    if (setupCfg.getText("server").Equals("existing"))
                    {
                        settings.isNewServer = false;
                    }
                }

                if (!setupCfg.getText("serverWebAddress").Equals("error"))
                {
                    settings.serverWebAddr = setupCfg.getText("serverWebAddress");
                    settings.serverWebAddr = settings.serverWebAddr(settings.serverWebAddr.Length - 1).Equals("/") ? settings.serverWebAddr.Substring(0, settings.serverWebAddr.Length - 2) : settings.serverWebAddr;
                    if (settings.serverWebAddr.IndexOf("www.") > -1 & settings.serverWebAddr.IndexOf("http://") == -1 & settings.serverWebAddr.IndexOf("https://") == -1)
                    {
                        settings.serverWebAddr = "http://" + settings.serverWebAddr;
                    }

                    if (IsValidUrl("http|https", settings.serverWebAddr).Equals(true))
                    {
                        settings.serverWebAddr = setupCfg.getText("serverWebAddress");
                    }
                    else
                    {
                        settings.serverWebAddr = null;
                    }
                }

                if (!setupCfg.getText("serverFtpAddress").Equals("error"))
                {
                    settings.serverFtpAddr = setupCfg.getText("serverftpAddress");
                    settings.serverFtpAddr = settings.serverFtpAddr(settings.serverFtpAddr.Length - 1).Equals("/") ? settings.serverFtpAddr.Substring(0, settings.serverFtpAddr.Length - 2) : settings.serverFtpAddr;
                    if (settings.serverFtpAddr.IndexOf("ftp.") > -1 & settings.serverFtpAddr.IndexOf("ftp://") == -1)
                    {
                        settings.serverFtpAddr = "ftp://" + settings.serverFtpAddr;
                    }

                    if (IsValidUrl("ftp", settings.serverFtpAddr).Equals(true))
                    {
                        settings.serverFtpAddr = setupCfg.getText("serverftpAddress");
                    }
                    else
                    {
                        settings.serverFtpAddr = null;
                    }
                }

                if (!setupCfg.getText("disableOptions").Equals("error"))
                {
                    if (setupCfg.getText("disableOptions").Equals("true"))
                    {
                        settings.disableOptions = true;
                    }
                    else if (setupCfg.getText("disableOptions").Equals("false"))
                    {
                        settings.disableOptions = false;
                    }
                }

                if (!setupCfg.getText("diagnostics").Equals("error"))
                {
                    if (setupCfg.getText("diagnostics").Equals("true"))
                    {
                        settings.sendDiags = true;
                    }
                    else if (setupCfg.getText("diagnostics").Equals("false"))
                    {
                        settings.sendDiags = false;
                    }
                }

                if (!setupCfg.getText("crashreports").Equals("error"))
                {
                    if (setupCfg.getText("crashreports").Equals("true"))
                    {
                        settings.sendCrash = true;
                    }
                    else if (setupCfg.getText("crashreports").Equals("false"))
                    {
                        settings.sendCrash = false;
                    }
                }
            }

            this.SuspendLayout();
            title.Font = new Font(enVars.fontTitle.Families(0), 24, FontStyle.Bold);
            subtitle.Font = new Font(enVars.fontTitle.Families(0), 12, FontStyle.Regular);
            title.Text = wizardFormsTitles[WizardFormsLoadedIndex];
            subtitle.Text = wizardFormsSubtitles[WizardFormsLoadedIndex];
            settings.programId = programId.Value();
            WizardFormsLoadedIndex = 0;
            loadWizardForm();
            backPicBtn.Visible = false;
            this.ResumeLayout();
            formLoaded = true;
        }

        private void backPicBtn_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void backTxtBtn_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void forwardPicBtn_Click(object sender, EventArgs e)
        {
            goForward();
        }

        private void forwardTxtBtn_Click(object sender, EventArgs e)
        {
            goForward();
        }

        private void goBack()
        {
            if (WizardFormsLoadedIndex > 0)
            {
                subUpdateIndex(-1);
                loadWizardForm();
            }
        }

        private void goForward()
        {
            if (WizardFormsLoadedIndex < wizardForms.Count - 1)
            {
                subUpdateIndex(1);
                loadWizardForm();
            }
        }

        private void subUpdateIndex(int idx)
        {
            if (wizardForms[WizardFormsLoadedIndex] is setupWizard_platformType & idx > 0)
            {
                if (settings.isSharedServer)
                {
                    if (settings.isNewServer)
                    {
                    }
                    // ToDo: setup new shared
                    else
                    {
                        // 'GOTO SIGN IN FRM
                        WizardFormsLoadedIndex = getFormPos(new setupWizard_signIn());
                    }
                }
                else if (settings.isNewServer)
                {
                    // 'GOTO newFTP setings from
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_NewFtpWebSettings());
                }
                else
                {
                    // 'goto server address form
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_ServerAddress());
                }
            }
            else if (wizardForms[WizardFormsLoadedIndex] is setupWizard_signIn)
            {
                if (idx < 0)
                {
                    if (settings.isSharedServer)
                    {
                        if (settings.isNewServer)
                        {
                        }
                        // ' WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)
                        else
                        {
                            WizardFormsLoadedIndex = getFormPos(new setupWizard_platformType());
                        }
                    }
                    else if (settings.isNewServer)
                    {
                        WizardFormsLoadedIndex = getFormPos(new setupWizard_NewFtpWebSettings());
                    }
                    else
                    {
                        WizardFormsLoadedIndex = getFormPos(new setupWizard_ServerAddress());
                    }
                }
                else
                {
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_DiagnosticsCrashData());
                }
            }
            else if (wizardForms[WizardFormsLoadedIndex] is setupWizard_NewFtpWebSettings & idx < 0)
            {
                if (idx < 0)
                {
                    if (settings.isSharedServer)
                    {
                        if (settings.isNewServer)
                        {
                            WizardFormsLoadedIndex = getFormPos(new setupWizard_platformType());
                        }
                        else
                        {
                            WizardFormsLoadedIndex = getFormPos(new setupWizard_platformType());
                        }
                    }
                    else if (settings.isNewServer)
                    {
                        WizardFormsLoadedIndex = getFormPos(new setupWizard_platformType());
                    }
                }
                else
                {
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_DiagnosticsCrashData());
                }
            }
            else if (wizardForms[WizardFormsLoadedIndex] is setupWizard_DiagnosticsCrashData & idx < 0)
            {
                if (settings.isSharedServer)
                {
                    if (settings.isNewServer)
                    {
                    }
                    // ToDo: setup new shared
                    else
                    {
                        WizardFormsLoadedIndex = getFormPos(new setupWizard_signIn());
                    }
                }
                else if (settings.isNewServer)
                {
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_createAdminAccount());
                }
                else
                {
                    WizardFormsLoadedIndex = getFormPos(new setupWizard_signIn());
                }
            }
            else
            {
                WizardFormsLoadedIndex = WizardFormsLoadedIndex + idx;
            }
        }

        public void updateform()
        {
            WizardFormsLoadedIndex = getFormPos(new setupWizard_finnish());
            loadWizardForm();
        }

        private int getFormPos(Form formSearch)
        {
            for (int i = 0, loopTo = wizardForms.Count - 1; i <= loopTo; i++)
            {
                if (wizardForms[i].Name.Equals(formSearch.Name))
                {
                    return i;
                }
            }

            return -1;
        }

        private void loadWizardForm()
        {
            this.SuspendLayout();
            title.Text = wizardFormsTitles[WizardFormsLoadedIndex];
            subtitle.Text = wizardFormsSubtitles[WizardFormsLoadedIndex];
            this.ResumeLayout();
            FadeAlpha = 100;
            fadeIn = true;
            FadeInTimer.Enabled = true; // go!
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (fadeIn)
            {
                FadeAlpha -= 1; // amount of opacity change for each timer tick
            }
            else
            {
                FadeAlpha += 1;
            }

            if (CurrentWrapperForm is object)
            {
                CurrentWrapperForm.Opacity = FadeAlpha / (double)100;
                PanelMain.Refresh();
            }

            if (FadeAlpha <= 0)
            {
                FadeInTimer.Enabled = false; // finished fade-in
                if (CurrentWrapperForm is object)
                {
                    if (PanelMain.Controls.Count > 0)
                    {
                        Control ctrl = null;
                        for (int i = PanelMain.Controls.Count - 1; i >= 0; i -= 1)
                        {
                            ctrl = PanelMain.Controls[i];
                            try
                            {
                                PanelMain.Controls.Remove(ctrl);
                            }
                            catch (Exception ex)
                            {
                                string statusMessage = "Error unloading form";
                            }
                        }
                    }
                }

                loadNextForm();
            }
            else if (FadeAlpha >= 100)
            {
                FadeInTimer.Enabled = false; // finished fade-in
            }
        }

        private void loadNextForm()
        {
            this.SuspendLayout();
            CurrentWrapperForm = wizardForms.ElementAt(WizardFormsLoadedIndex);
            CurrentWrapperForm.TopLevel = false;
            CurrentWrapperForm.Parent = PanelMain;
            CurrentWrapperForm.Size = PanelMain.Size;
            CurrentWrapperForm.Dock = DockStyle.Fill;
            CurrentWrapperForm.Opacity = 0.0;
            PanelMain.Controls.Add(CurrentWrapperForm);
            CurrentWrapperForm.Show();
            if (WizardFormsLoadedIndex.Equals(getFormPos(new setupWizard_settingUp())))
            {
                forwardPicBtn.Visible = false;
                backPicBtn.Visible = true;
            }
            else if (WizardFormsLoadedIndex < wizardForms.Count - 1 & WizardFormsLoadedIndex > 0)
            {
                forwardPicBtn.Visible = true;
                backPicBtn.Visible = true;
            }
            else if (WizardFormsLoadedIndex.Equals(0))
            {
                backPicBtn.Visible = false;
                forwardPicBtn.Visible = true;
            }

            this.ResumeLayout();
            FadeAlpha = 0;
            fadeIn = false;
            FadeInTimer.Enabled = true; // go!
        }

        private void backPicBtn_Click_1(object sender, EventArgs e)
        {
            goBack();
        }

        private void forwardPicBtn_Click_1(object sender, EventArgs e)
        {
            goForward();
        }

        private void title_Click(object sender, EventArgs e)
        {
        }

        private void PanelBottom_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AlphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {
        }
    }
}