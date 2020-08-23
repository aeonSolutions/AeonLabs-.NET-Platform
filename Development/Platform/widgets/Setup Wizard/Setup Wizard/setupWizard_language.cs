using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_language
    {
        public setupWizard_language()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _defaultLanguage.Name = "defaultLanguage";
            _show_all_lang.Name = "show_all_lang";
            _ListBox1.Name = "ListBox1";
            _PictureBox1.Name = "PictureBox1";
            _selectionOkpic.Name = "selectionOkpic";
        }

        private environmentVars stateCore = new environmentVars();
        private SortedDictionary<string, string> countryList = new SortedDictionary<string, string>();
        private languageTranslations translations;
        private setupWizardMainForm mainform;

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

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
                translations = new languageTranslations(stateCore);
                translations.load("setupWizard");
                if (mainform.settings.lang is null)
                {
                    selectionOkpic.Visible = false;
                }
                else
                {
                    selectionOkpic.Visible = true;
                }

                show_all_lang.Text = translations.getText("showAll");
                defaultLanguage.Text = translations.getText("chooseDefaultLanguage");
                ResumeLayout();
            }
        }

        private void setupWizard_0_frm_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            ListBox1.Font = new Font(stateCore.fontText.Families(0), 9, FontStyle.Regular);
            show_all_lang.Font = new Font(stateCore.fontText.Families(0), 9, FontStyle.Regular);
            defaultLanguage.Font = new Font(stateCore.fontText.Families(0), 12, FontStyle.Bold);
            GetAllCountryLanguages("short");
            ResumeLayout();
        }

        public void GetAllCountryLanguages(string listType)
        {
            // Iterate the Framework Cultures...
            var shortcountryList = new List<string>();
            shortcountryList.Add("fr");
            shortcountryList.Add("en");
            shortcountryList.Add("es");
            shortcountryList.Add("pt");
            shortcountryList.Add("nl");
            ListBox1.Items.Clear();
            countryList.Clear();
            foreach (var ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                var newKeyValuePair = new KeyValuePair<string, string>(ci.DisplayName, ci.TwoLetterISOLanguageName);
                if (show_all_lang.Checked)
                {
                    if (!countryList.ContainsKey(ci.DisplayName))
                    {
                        countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value);
                        ListBox1.Items.Add(ci.DisplayName);
                    }
                }
                else if (!countryList.ContainsKey(ci.DisplayName) & shortcountryList.Contains(ci.TwoLetterISOLanguageName))
                {
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value);
                    ListBox1.Items.Add(ci.DisplayName);
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainform.settings.lang = countryList[ListBox1.SelectedItem.ToString()];
            selectionOkpic.Visible = true;
        }

        private void show_all_lang_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_lang.Checked)
            {
                GetAllCountryLanguages("all");
            }
            else
            {
                GetAllCountryLanguages("short");
            }
        }

        private void AlphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}