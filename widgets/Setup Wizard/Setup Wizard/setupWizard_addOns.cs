using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    public partial class setupWizard_addOns
    {
        public setupWizard_addOns()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            Refresh();
            _translation_apikey_lbl.Name = "translation_apikey_lbl";
            _translationApiKey.Name = "translationApiKey";
            _weather_provider_lbl.Name = "weather_provider_lbl";
            _weatherProvider.Name = "weatherProvider";
            _translation_provider_lbl.Name = "translation_provider_lbl";
            _translationProvider.Name = "translationProvider";
            _enableWeather.Name = "enableWeather";
            _enableTranslation.Name = "enableTranslation";
            _weather_apikey_lbl.Name = "weather_apikey_lbl";
            _weatherApiKey.Name = "weatherApiKey";
            _PictureBox1.Name = "PictureBox1";
        }

        private languageTranslations translations = new languageTranslations();
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
                enableTranslation.Text = translations.getText("AddonsSelectTranslations");
                translation_provider_lbl.Text = translations.getText("AddonsProvider");
                translation_apikey_lbl.Text = translations.getText("AddonsApiKey");
                enableWeather.Text = translations.getText("AddonsSelectWeather");
                weather_provider_lbl.Text = translations.getText("AddonsProvider");
                weather_apikey_lbl.Text = translations.getText("AddonsApiKey");
                ResumeLayout();
            }
        }

        private void setupWizard_1_Load(object sender, EventArgs e)
        {
            enableTranslation.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            translation_provider_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            translation_apikey_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            translationProvider.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            translationApiKey.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            enableWeather.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            weather_provider_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            weather_apikey_lbl.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            weatherProvider.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            weatherApiKey.Font = new Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular);
            translationProvider.SelectedIndex = 0;
            weatherProvider.SelectedIndex = 0;
        }

        private void wizardGoForward()
        {
            if (enableTranslation.Checked & (translationProvider.SelectedIndex < 0 | translationApiKey.Text.Equals("")))
            {
                return;
            }

            if (enableWeather.Checked & (weatherProvider.SelectedIndex < 0 | weatherApiKey.Text.Equals("")))
            {
                return;
            }

            if (enableTranslation.Checked)
            {
                mainform.settings.isTranslationEnabled = true;
                mainform.settings.translationProvider = translationProvider.SelectedItem.ToString();
                mainform.settings.translationApiKey = translationApiKey.Text;
            }

            if (enableWeather.Checked)
            {
                mainform.settings.isWeatherEnabled = true;
                mainform.settings.weatherProvider = weatherProvider.SelectedItem.ToString();
                mainform.settings.weatherApiKey = weatherApiKey.Text;
            }
        }

        private void enableTranlation_CheckedChanged(object sender, EventArgs e)
        {
            if (enableTranslation.Checked)
            {
                translationApiKey.Enabled = true;
                translationProvider.Enabled = true;
                translation_apikey_lbl.ForeColor = Color.Black;
                translation_provider_lbl.ForeColor = Color.Black;
            }
            else
            {
                translationApiKey.Enabled = false;
                translationProvider.Enabled = false;
                translation_apikey_lbl.ForeColor = Color.Gray;
                translation_provider_lbl.ForeColor = Color.Gray;
            }
        }

        private void enableWeather_CheckedChanged(object sender, EventArgs e)
        {
            if (enableWeather.Checked)
            {
                weatherApiKey.Enabled = true;
                weatherProvider.Enabled = true;
                weather_apikey_lbl.ForeColor = Color.Black;
                weather_provider_lbl.ForeColor = Color.Black;
            }
            else
            {
                weatherApiKey.Enabled = false;
                weatherProvider.Enabled = false;
                weather_apikey_lbl.ForeColor = Color.Gray;
                weather_provider_lbl.ForeColor = Color.Gray;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void weather_provider_lbl_Click(object sender, EventArgs e)
        {
        }
    }
}