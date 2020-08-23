using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_DiagnosticsCrashData
    {
        public setupWizard_DiagnosticsCrashData()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _about_diagnostics.Name = "about_diagnostics";
            _share.Name = "share";
            _send.Name = "send";
            _PictureBox1.Name = "PictureBox1";
            _share_details.Name = "share_details";
            _send_details.Name = "send_details";
        }

        private SortedDictionary<string, string> countryList = new SortedDictionary<string, string>();
        private languageTranslations translations;
        private setupWizardMainForm mainform;

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            share.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            share_details.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            send.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            send_details.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            about_diagnostics.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            BringToFront();
            about_diagnostics.Links.Add(0, about_diagnostics.Text.Length - 1, "http://sitelogistics.construction/aboutdiagnostics");
        }

        private void setupWizard_1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                translations = new languageTranslations(mainform.enVars);
                translations.load("setupWizard");
                send.Text = translations.getText("sendDiagnostics");
                share.Text = translations.getText("shareCrashData");
                share_details.Text = translations.getText("crashDataDescription");
                send_details.Text = translations.getText("diagnosticsDescritpion");
                ResumeLayout();
                if (!Information.IsNothing(mainform.settings.sendDiags))
                {
                    if (mainform.settings.sendDiags)
                    {
                        send.Checked = true;
                    }
                    else
                    {
                        send.Checked = false;
                    }
                }

                if (!Information.IsNothing(mainform.settings.sendCrash))
                {
                    if (mainform.settings.sendCrash)
                    {
                        share.Checked = true;
                    }
                    else
                    {
                        share.Checked = false;
                    }
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void send_CheckedChanged(object sender, EventArgs e)
        {
            if (send.Checked)
            {
                mainform.settings.sendDiags = true;
            }
            else
            {
                mainform.settings.sendDiags = false;
            }

            if (share.Checked)
            {
                mainform.settings.sendCrash = true;
            }
            else
            {
                mainform.settings.sendCrash = false;
            }
        }

        private void about_diagnostics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void share_CheckedChanged(object sender, EventArgs e)
        {
            if (send.Checked)
            {
                mainform.settings.sendDiags = true;
            }
            else
            {
                mainform.settings.sendDiags = false;
            }

            if (share.Checked)
            {
                mainform.settings.sendCrash = true;
            }
            else
            {
                mainform.settings.sendCrash = false;
            }
        }
    }
}