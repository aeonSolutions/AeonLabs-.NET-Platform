using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_platformType
    {
        public setupWizard_platformType()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _ownBtn.Name = "ownBtn";
            _sharedBtn.Name = "sharedBtn";
            _ownConnectExisting.Name = "ownConnectExisting";
            _ownSetupNew.Name = "ownSetupNew";
            _SharedConnectExisting.Name = "SharedConnectExisting";
            _sharedSetupNew.Name = "sharedSetupNew";
            _PictureBox1.Name = "PictureBox1";
        }

        private environmentVars stateCore = new environmentVars();
        private languageTranslations translations;
        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
            stateCore = mainform.enVars;
        }

        private void setupWizard_1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                translations = new languageTranslations(mainform.enVars);
                translations.load("setupWizard");
                sharedBtn.Text = translations.getText("sharedPlatform");
                ownBtn.Text = translations.getText("ownPlatform");
                sharedSetupNew.Text = translations.getText("setupNewPlatform");
                SharedConnectExisting.Text = translations.getText("connectExistingPlatform");
                ownSetupNew.Text = translations.getText("setupNewPlatform");
                ownConnectExisting.Text = translations.getText("connectExistingPlatform");
                if (!Information.IsNothing(mainform.settings.isSharedServer))
                {
                    if (!Information.IsNothing(mainform.settings.isNewServer))
                    {
                        if (mainform.settings.isSharedServer)
                        {
                            sharedBtn.Checked = true;
                            ownBtn.Checked = false;
                            if (!Information.IsNothing(mainform.settings.disableOptions))
                            {
                                if (mainform.settings.disableOptions.Equals(true))
                                {
                                    ownBtn.Enabled = false;
                                    sharedBtn.Enabled = false;
                                }
                            }

                            if (mainform.settings.isNewServer)
                            {
                                sharedSetupNew.Checked = true;
                                SharedConnectExisting.Checked = false;
                                ownSetupNew.Checked = false;
                                ownConnectExisting.Checked = false;
                                if (!Information.IsNothing(mainform.settings.disableOptions))
                                {
                                    if (mainform.settings.disableOptions.Equals(true))
                                    {
                                        SharedConnectExisting.Enabled = false;
                                        ownSetupNew.Enabled = false;
                                        ownConnectExisting.Enabled = false;
                                    }
                                }
                            }
                            else
                            {
                                sharedSetupNew.Checked = false;
                                SharedConnectExisting.Checked = true;
                                ownSetupNew.Checked = false;
                                ownConnectExisting.Checked = false;
                                if (!Information.IsNothing(mainform.settings.disableOptions))
                                {
                                    if (mainform.settings.disableOptions.Equals(true))
                                    {
                                        sharedSetupNew.Enabled = false;
                                        ownConnectExisting.Enabled = false;
                                        ownSetupNew.Enabled = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            sharedBtn.Checked = false;
                            ownBtn.Checked = true;
                            if (!Information.IsNothing(mainform.settings.disableOptions))
                            {
                                if (mainform.settings.disableOptions.Equals(true))
                                {
                                    sharedBtn.Enabled = false;
                                    ownBtn.Enabled = false;
                                }
                            }

                            if (mainform.settings.isNewServer)
                            {
                                sharedSetupNew.Checked = false;
                                SharedConnectExisting.Checked = false;
                                ownSetupNew.Checked = true;
                                ownConnectExisting.Checked = false;
                                if (!Information.IsNothing(mainform.settings.disableOptions))
                                {
                                    if (mainform.settings.disableOptions.Equals(true))
                                    {
                                        SharedConnectExisting.Enabled = false;
                                        sharedSetupNew.Enabled = false;
                                        ownConnectExisting.Enabled = false;
                                    }
                                }
                            }
                            else
                            {
                                sharedSetupNew.Checked = false;
                                SharedConnectExisting.Checked = false;
                                ownSetupNew.Checked = false;
                                ownConnectExisting.Checked = true;
                                if (!Information.IsNothing(mainform.settings.disableOptions))
                                {
                                    if (mainform.settings.disableOptions.Equals(true))
                                    {
                                        sharedSetupNew.Enabled = false;
                                        SharedConnectExisting.Enabled = false;
                                        ownSetupNew.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }

                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            ownBtn.Font = new Font(stateCore.fontTitle.Families(0), 11, FontStyle.Bold);
            sharedBtn.Font = new Font(stateCore.fontTitle.Families(0), 11, FontStyle.Bold);
            sharedSetupNew.Font = new Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold);
            SharedConnectExisting.Font = new Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold);
            ownSetupNew.Font = new Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold);
            ownConnectExisting.Font = new Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold);
            ResumeLayout();
        }

        private void updateSettings()
        {
            if (sharedBtn.Checked)
            {
                mainform.settings.isSharedServer = true;
                if (SharedConnectExisting.Checked)
                {
                    mainform.settings.isNewServer = false;
                }
                else
                {
                    mainform.settings.isNewServer = true;
                }
            }
            else
            {
                mainform.settings.isSharedServer = false;
                if (ownConnectExisting.Checked)
                {
                    mainform.settings.isNewServer = false;
                }
                else
                {
                    mainform.settings.isNewServer = true;
                }
            }

            if (mainform.settings.isSharedServer)
            {
                if (mainform.settings.isNewServer)
                {
                }
                // ToDo: setup new shared
                else
                {
                    mainform.settings.serverWebAddr = "http://www.sitelogistics.construction/shared";
                    mainform.settings.isNewServer = false;
                    mainform.settings.ApiServerAddrPath = "/csaml/api/index.php";
                }
            }
            else if (mainform.settings.isNewServer)
            {
            }
            else
            {
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void sharedSetupNew_CheckedChanged(object sender, EventArgs e)
        {
            if (sharedSetupNew.Checked)
            {
                SharedConnectExisting.Checked = false;
                ownConnectExisting.Enabled = false;
                ownSetupNew.Enabled = false;
            }

            updateSettings();
        }

        private void SharedConnectExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedConnectExisting.Checked)
            {
                sharedSetupNew.Checked = false;
                ownSetupNew.Checked = false;
                ownConnectExisting.Checked = false;
            }

            updateSettings();
        }

        private void ownSetupNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ownSetupNew.Checked)
            {
                ownConnectExisting.Checked = false;
                SharedConnectExisting.Enabled = false;
                sharedSetupNew.Enabled = false;
            }

            updateSettings();
        }

        private void ownConnectExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (ownConnectExisting.Checked)
            {
                ownSetupNew.Checked = false;
                SharedConnectExisting.Enabled = false;
                sharedSetupNew.Enabled = false;
            }

            updateSettings();
        }

        private void sharedBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (sharedBtn.Checked)
            {
                ownConnectExisting.Enabled = false;
                ownSetupNew.Enabled = false;
                ownSetupNew.Checked = false;
                ownConnectExisting.Checked = false;
                SharedConnectExisting.Enabled = true;
                sharedSetupNew.Enabled = true;
                SharedConnectExisting.Checked = false;
                sharedSetupNew.Checked = false;
                ownBtn.Checked = false;
            }
            else
            {
                SharedConnectExisting.Enabled = false;
                sharedSetupNew.Enabled = false;
                SharedConnectExisting.Checked = false;
                sharedSetupNew.Checked = false;
            }

            updateSettings();
        }

        private void ownBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ownBtn.Checked)
            {
                SharedConnectExisting.Enabled = false;
                sharedSetupNew.Enabled = false;
                ownConnectExisting.Enabled = true;
                ownSetupNew.Enabled = true;
                ownSetupNew.Checked = false;
                ownConnectExisting.Checked = false;
                SharedConnectExisting.Enabled = false;
                sharedSetupNew.Enabled = false;
                SharedConnectExisting.Checked = false;
                sharedSetupNew.Checked = false;
                sharedBtn.Checked = false;
            }
            else
            {
                ownConnectExisting.Enabled = false;
                ownSetupNew.Enabled = false;
                ownSetupNew.Checked = false;
                ownConnectExisting.Checked = false;
            }

            updateSettings();
        }
    }
}