using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_country
    {
        public setupWizard_country()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _chooseCountry.Name = "chooseCountry";
            _show_all_lang.Name = "show_all_lang";
            _ListBox1.Name = "ListBox1";
            _PictureBox1.Name = "PictureBox1";
            _selectionOkpic.Name = "selectionOkpic";
        }

        private setupWizardMainForm mainform;
        private Dictionary<string, string> countryList = new Dictionary<string, string>();

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        public void preLoadData(setupWizardMainForm _mainForm)
        {
            mainform = _mainForm;
        }

        private void setupWizard_1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SuspendLayout();
                mainform.translations.load("setupWizard");
                show_all_lang.Text = mainform.translations.getText("showAll");
                chooseCountry.Text = mainform.translations.getText("chooseCountry");
                if (mainform.settings.country is null)
                {
                    selectionOkpic.Visible = false;
                }
                else
                {
                    selectionOkpic.Visible = true;
                }

                ResumeLayout();
            }
        }

        private void setupWizard_0_frm_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            show_all_lang.Font = new Font(mainform.enVars.fontText.Families(0), 9, FontStyle.Regular);
            chooseCountry.Font = new Font(mainform.enVars.fontText.Families(0), 12, FontStyle.Bold);
            addCountries("short");
        }

        private void addCountries(string listType)
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
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                // Create new country dictionary entry.
                var newKeyValuePair = new KeyValuePair<string, string>(ci.DisplayName, ci.TwoLetterISOLanguageName);
                // If the country is not already in the countryList add it...
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

            ListBox1.Sorted = true;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainform.settings.country = countryList[ListBox1.SelectedItem.ToString()];
            selectionOkpic.Visible = true;
        }

        private void show_all_lang_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_lang.Checked)
            {
                addCountries("all");
            }
            else
            {
                addCountries("short");
            }
        }
    }
}