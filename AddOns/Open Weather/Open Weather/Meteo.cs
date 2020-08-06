using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace ConstructionSiteLogistics.AddOn.Meteo
{
    public partial class meteo_frm
    {
        public meteo_frm()
        {
            InitializeComponent();
            _weather_pic.Name = "weather_pic";
            _city_txt.Name = "city_txt";
            _site_combo.Name = "site_combo";
            _select_location_lbl.Name = "select_location_lbl";
            _descricao_txt.Name = "descricao_txt";
            _meteo_txt.Name = "meteo_txt";
            _PictureBoxDoubleBuffer1.Name = "PictureBoxDoubleBuffer1";
            _AlphaGradientPanel1.Name = "AlphaGradientPanel1";
            _LabelDoubleBuffer1.Name = "LabelDoubleBuffer1";
            _LabelDoubleBuffer2.Name = "LabelDoubleBuffer2";
            _Label1.Name = "Label1";
        }

        public meteo_frm(environmentVars stateIni, MainMdiForm _mainmdiform)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            stateCore = stateIni;
            mainForm = _mainmdiform;
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            if (!stateCore.addonsLoaded || !stateCore.addons.ContainsKey("weather"))
            {
                translations.load("errorMessages");
                string message3 = translations.getText("errorWeatherAddonNotFound") + ". " + translations.getText("contactEnterpriseSupport");
                translations.load("messagebox");
                msgbox = new messageBoxForm(message3 + ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Location.X + Width / (double)2, Location.Y + Height / (double)2);
                msgbox.ShowDialog();
                mainForm.busy.Close(true);
                return;
            }

            _weather_pic.Name = "weather_pic";
            _city_txt.Name = "city_txt";
            _site_combo.Name = "site_combo";
            _select_location_lbl.Name = "select_location_lbl";
            _descricao_txt.Name = "descricao_txt";
            _meteo_txt.Name = "meteo_txt";
            _PictureBoxDoubleBuffer1.Name = "PictureBoxDoubleBuffer1";
            _AlphaGradientPanel1.Name = "AlphaGradientPanel1";
            _LabelDoubleBuffer1.Name = "LabelDoubleBuffer1";
            _LabelDoubleBuffer2.Name = "LabelDoubleBuffer2";
            _Label1.Name = "Label1";
        }

        private messageBoxForm msgbox;
        private environmentVars stateCore;
        private languageTranslations translations;

        public MainMdiForm mainForm { get; set; }

        private HttpDataGetData _HttpDataRequestOpenWeather;

        private HttpDataGetData HttpDataRequestOpenWeather
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HttpDataRequestOpenWeather;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HttpDataRequestOpenWeather != null)
                {
                    _HttpDataRequestOpenWeather.dataArrived -= httpDataRequestOpenWeather_dataArrived;
                }

                _HttpDataRequestOpenWeather = value;
                if (_HttpDataRequestOpenWeather != null)
                {
                    _HttpDataRequestOpenWeather.dataArrived += httpDataRequestOpenWeather_dataArrived;
                }
            }
        }

        private HttpDataPostData _HttpDataRequest;

        private HttpDataPostData HttpDataRequest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HttpDataRequest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HttpDataRequest != null)
                {
                    _HttpDataRequest.dataArrived -= HttpDataRequest_dataArrived;
                }

                _HttpDataRequest = value;
                if (_HttpDataRequest != null)
                {
                    _HttpDataRequest.dataArrived += HttpDataRequest_dataArrived;
                }
            }
        }

        private Dictionary<string, List<string>> works_site;
        private bool loaded = false;

        // TODO split into a abstract class for reuse outside this FORM - see translation class

        private void CloseMe()
        {
            Close();
        }

        private void meteo_frm_Load(object sender, EventArgs e)
        {
            translations = new languageTranslations(stateCore);
            SuspendLayout();
            select_location_lbl.Font = new Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold);
            city_txt.Font = new Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular);
            meteo_txt.Font = new Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular);
            descricao_txt.Font = new Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular);
            site_combo.Font = new Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular);
            translations.load("commonForm");
            translations.load("busyMessages");
            meteo_txt.Text = translations.getText("commServer");
            translations.load("meteorology");
            select_location_lbl.Text = translations.getText("location");
            city_txt.Text = "";
            descricao_txt.Text = "";
        }

        private void meteo_frm_show(object sender, EventArgs e)
        {
            load_list();
        }

        public void load_list()
        {
            var vars = new Dictionary<string, string>();
            vars.Add("task", stateCore.taskId("queries"));
            vars.Add("request", "sites");
            HttpDataRequest = new HttpDataPostData();
            HttpDataRequest.initialize();
            HttpDataRequest.loadQueue(vars, default, default);
            HttpDataRequest.startRequest();
        }

        private void HttpDataRequest_dataArrived(object sender, string requestData, Dictionary<string, string> misc)
        {
            var vars = new Dictionary<string, string>();
            bool errorFlag = false;
            string errorMsg = "";
            if (!IsResponseOk(requestData))
            {
                errorMsg = GetMessage(requestData);
                errorFlag = true;
                goto lastLine;
            }

            works_site = HttpDataRequest.ConvertDataToArray("sites", stateCore.querySiteFields, requestData);
            if (Information.IsNothing(works_site))
            {
                errorMsg = HttpDataRequest.errorMessage;
                errorFlag = true;
                goto lastLine;
            }

        lastLine:
            ;
            ;
#error Cannot convert LocalDeclarationStatementSyntax - see comment for details
            /* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
               at ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__40.MoveNext()
               at System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
               at System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
               at System.Linq.Buffer`1..ctor(IEnumerable`1 source)
               at System.Linq.OrderedEnumerable`1.<GetEnumerator>d__1.MoveNext()
               at Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(SyntaxNode node, IReadOnlyCollection`1 modifiers, TokenContext context, Boolean isVariableOrConst, SyntaxKind[] extraCsModifierKinds)
               at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitLocalDeclarationStatement>d__31.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

            Input:

                    Static start As Single

             */
            start = Conversions.ToSingle(DateAndTime.Timer);
            while (!IsHandleCreated & DateAndTime.Timer < (double)(start + (float)10))
            {
            }

            if (!IsHandleCreated)
            {
                translations.load("system");
                mainForm.statusMessage = translations.getText("errorFormNoHandle");
                return;
            }

            if (Conversions.ToBoolean(errorMsg))
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(errorMsg) + ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Location.X + Width / (double)2, Location.Y + Height / (double)2);
                msgbox.ShowDialog();
                return;
            }

            translations.load("commonForm");
            site_combo.Items.Clear();
            site_combo.Items.Add(translations.getText("dropdownSelectSite"));
            for (int i = 0, loopTo = works_site["name"].Count - 1; i <= loopTo; i++)
                site_combo.Items.Add(works_site["name"][i]);
            site_combo.SelectedIndex = 0;
            mainForm.busy.Close(true);
        }

        private void site_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stateCore.addons("translation")("name").Equals("openWeather"))
            {
                loadOpenWeather();
            }
        }

        public void loadOpenWeather()
        {
            // http://api.openweathermap.org/data/2.5/weather?appid=7c18fcf0c019a0859fc974d45f6f9d29&units=metric&lang={lang}&lat={latitude}&lon={longitude}
            // MISSING
            // metrics
            // API KEY

            mainForm.busy.Show();
            string latitude = "";
            string longitude = "";
            if (site_combo.SelectedIndex > 0)
            {
                latitude = works_site["gps_lat"][site_combo.SelectedIndex - 1];
                longitude = works_site["gps_lon"][site_combo.SelectedIndex - 1];
            }
            else
            {
                latitude = stateCore.locationData.latitude;
                longitude = stateCore.locationData.longitude;
            }

            string url = stateCore.addons.Item("weather")("url").Replace("{lang}", stateCore.currentLang).Replace("{latitude}", latitude).Replace("{longitude}", longitude).Replace("{key}", stateCore.addons("weather")("key"));
            HttpDataRequestOpenWeather = new HttpDataGetData(stateCore, url);
            HttpDataRequestOpenWeather.initialize();
            HttpDataRequestOpenWeather.loadQueue(default, default, default);
            HttpDataRequestOpenWeather.startRequest();
        }

        private void httpDataRequestOpenWeather_dataArrived(object sender, string requestData, Dictionary<string, string> misc)
        {
            Dictionary<string, object> jsonResult;
            try
            {
                jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(requestData);
            }
            catch (Exception ex)
            {
                translations.load("messagebox");
                msgbox = new messageBoxForm(GetMessage(requestData), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                mainForm.busy.Close(true);
                return;
            }

            string icon = "";
            try
            {
                string subResponse = jsonResult["weather"].ToString().Replace("[", "").Replace("]", "");
                var jsonSubResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(subResponse);
                string id = Conversions.ToString(jsonSubResult["id"]);
                string main = Conversions.ToString(jsonSubResult["main"]);
                string description = Conversions.ToString(jsonSubResult["description"]);
                var TargetEncoding = Encoding.GetEncoding("ISO-8859-1");
                var SourceEncoding = Encoding.UTF8;
                description = SourceEncoding.GetString(TargetEncoding.GetBytes(description));
                icon = Conversions.ToString(jsonSubResult["icon"]);
                subResponse = jsonResult["main"].ToString().Replace("[", "").Replace("]", "");
                jsonSubResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(subResponse);
                string temp = Conversions.ToString(jsonSubResult["temp"]);
                string pressure = Conversions.ToString(jsonSubResult["pressure"]);
                string humidity = Conversions.ToString(jsonSubResult["humidity"]);
                string tempMin = Conversions.ToString(jsonSubResult["temp_min"]);
                string tempMax = Conversions.ToString(jsonSubResult["temp_max"]);
                long vis = (long)(Convert.ToUInt64(jsonResult["visibility"]) / (double)1000);
                string visibility = vis.ToString();
                string Cityname = Conversions.ToString(jsonResult["name"]);
                subResponse = jsonResult["wind"].ToString().Replace("[", "").Replace("]", "");
                jsonSubResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(subResponse);
                string windSpeed = Conversions.ToString(jsonSubResult["speed"]);
                string windDirection = Conversions.ToString(jsonSubResult["deg"]);
                subResponse = jsonResult["sys"].ToString().Replace("[", "").Replace("]", "");
                jsonSubResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(subResponse);
                var tz = TimeSpan.FromSeconds(Convert.ToUInt64(jsonResult["timezone"]));
                var ts = TimeSpan.FromSeconds(Convert.ToUInt64(jsonSubResult["sunrise"]));
                ts = ts + tz;
                string sunrise = string.Format("{0:00}:{1:00}", Math.Floor((decimal)ts.Hours), ts.Minutes);
                ts = TimeSpan.FromSeconds(Convert.ToUInt64(jsonSubResult["sunset"]));
                ts = ts + tz;
                string sunset = string.Format("{0:00}:{1:00}", Math.Floor((decimal)ts.Hours), ts.Minutes);
                city_txt.Text = Cityname;
                descricao_txt.Text = description;
                translations.load("meteorology");
                meteo_txt.Text = translations.getText("temperature") + ": " + temp + "°C  max: " + tempMax + "°C  min: " + tempMin + "°C" + Environment.NewLine + translations.getText("humidity") + ": " + humidity + "%" + Environment.NewLine + translations.getText("pressure") + ": " + pressure + " mb" + Environment.NewLine + Environment.NewLine + translations.getText("visibility") + ": " + visibility + " km" + Environment.NewLine + Environment.NewLine + translations.getText("wind") + ": " + windSpeed + " km/h" + Environment.NewLine + translations.getText("windDirection") + ": " + windDirection + "°" + Environment.NewLine + Environment.NewLine + translations.getText("sunrise") + ": " + sunrise + Environment.NewLine + translations.getText("sunset") + ": " + sunset + Environment.NewLine;






            }
            catch (Exception ex)
            {
                mainForm.statusMessage = ex.Message.ToString();
                saveCrash(ex);
            }

            var tClient = new WebClient();
            try
            {
                Bitmap tImage = (Bitmap)Image.FromStream(new MemoryStream(tClient.DownloadData("http://openweathermap.org/img/w/" + icon + ".png")));
                weather_pic.Image = tImage;
            }
            catch (Exception ex)
            {
                translations.load("errorMessages");
                weather_pic.Image = Image.FromFile(mainForm.state.imagesPath + Convert.ToString("noweather.png"));
                mainForm.statusMessage = translations.getText("errorDownloadingPhoto");
            }

            weather_pic.SizeMode = PictureBoxSizeMode.StretchImage;
            mainForm.busy.Close(true);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}