using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using AeonLabs.Environment;
using AeonLabs.Network;
using AeonLabs.Security;
using AeonLabs.Settings;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AeonLabs.environmentLoading
{
    public class loadEnvironment
    {
        private bool dataLoaded = false;

        // 'SETTINGS 
        public const int LOAD_ALL = 1;
        public const int LOAD_SETTINGS = 2;
        public const int LOAD_LOCATION = 3;
        public const int LOAD_ADDONS = 4;
        public const int LOAD_ASSEMBLIES = 5;
        public const int LOAD_CONFIG = 6;

        public event environmentDataLoadedCompletedEventHandler environmentDataLoadedCompleted;

        public delegate void environmentDataLoadedCompletedEventHandler(int task);

        private HttpDataPostData _loadAddOnsData;

        private HttpDataPostData loadAddOnsData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadAddOnsData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadAddOnsData != null)
                {
                    _loadAddOnsData.dataArrived -= loadAddOnsData_dataArrived;
                }

                _loadAddOnsData = value;
                if (_loadAddOnsData != null)
                {
                    _loadAddOnsData.dataArrived += loadAddOnsData_dataArrived;
                }
            }
        }

        private HttpDataGetData _loadLocationData;

        private HttpDataGetData loadLocationData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadLocationData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadLocationData != null)
                {
                    _loadLocationData.dataArrived -= loadLocationData_dataArrived;
                }

                _loadLocationData = value;
                if (_loadLocationData != null)
                {
                    _loadLocationData.dataArrived += loadLocationData_dataArrived;
                }
            }
        }

        private HttpDataGetData _loadIpAddressData;

        private HttpDataGetData loadIpAddressData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadIpAddressData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadIpAddressData != null)
                {
                    _loadIpAddressData.dataArrived -= loadIpAddressData_dataArrived;
                }

                _loadIpAddressData = value;
                if (_loadIpAddressData != null)
                {
                    _loadIpAddressData.dataArrived += loadIpAddressData_dataArrived;
                }
            }
        }

        private HttpDataGetData _loadLocationCoordinates;

        private HttpDataGetData loadLocationCoordinates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadLocationCoordinates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadLocationCoordinates != null)
                {
                    _loadLocationCoordinates.dataArrived -= loadLocationCoordinates_dataArrived;
                }

                _loadLocationCoordinates = value;
                if (_loadLocationCoordinates != null)
                {
                    _loadLocationCoordinates.dataArrived += loadLocationCoordinates_dataArrived;
                }
            }
        }

        private int dataLoadedStatusQueue = 0;
        private AeonLabs.Environment.environmentVarsCore enVars;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public environmentVarsCore GetEnviroment()
        {
            return enVars;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void CopyFieldsFromCore(AeonLabs.Environment.environmentVarsCore enVarsCore)
        {
            var bindingFlagsSelection = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fieldValues = enVarsCore.GetType().GetFields(bindingFlagsSelection);
            foreach (var field in fieldValues)
            {
                var info = GetType().GetMember(field.Name);
                FieldInfo meField = info[0] as FieldInfo;
                meField.SetValue(this, field.GetValue(enVarsCore));
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public loadEnvironment(AeonLabs.Environment.environmentVarsCore _enVars, int settings = -100)
        {
            enVars = _enVars;
            enVars.loadEnvironmentcoreDefaults();
            dataLoaded = false;
            dataLoadedStatusQueue = 0;
            load(settings);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void load(int settings = -100)
        {
            if (settings.Equals(LOAD_ALL))
            {
                var settingsFile = new FileInfo(Path.Combine(enVars.libraryPath, "ScrewDriver.eon"));
                settingsFile.Refresh();
                if (settingsFile.Exists)
                {
                    loadSettings();
                    loadAddons();
                }

                loadLocation();
            }
            else if (settings.Equals(LOAD_SETTINGS))
            {
                loadSettings();
            }
            else if (settings.Equals(LOAD_LOCATION))
            {
                loadLocation();
            }
            else if (settings.Equals(LOAD_ADDONS))
            {
                // REQUIRES VALID USER ID
                // TODO move to cloud settings on startup
                loadAddons();
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void loadSettings()
        {
            changeDataLoadedState(true);
            var settings = new Settings.Settings(enVars);
            enVars = settings.load();
            if (settings.hasError)
            {
                enVars.settingsLoaded = false;
                enVars.stateErrorMessage = settings.errorMessage;
                return;
            }

            var configFile = new FileInfo(Path.Combine(enVars.libraryPath, "ScrewDriver.cfg"));
            configFile.Refresh();
            if (configFile.Exists)
            {
                loadConfig();
            }

            changeDataLoadedState(false, LOAD_SETTINGS);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void loadConfig()
        {
            changeDataLoadedState(true);
            var cfgstate = new AeonLabs.Environment.environmentVarsCore();
            cfgstate.secretKey = enVars.secretKey;
            var encryption = new AesCipher(cfgstate);
            var settingsFile = new FileInfo(Path.Combine(cfgstate.libraryPath, "ScrewDriver.cfg"));
            settingsFile.Refresh();
            if (settingsFile.Exists)
            {
                {
                    var withBlock = enVars;
                    try
                    {
                        var bytes = File.ReadAllBytes(Path.Combine(cfgstate.libraryPath, "ScrewDriver.cfg"));
                        string encrypted = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string decrypted = encryption.decrypt(encrypted);
                        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(decrypted);

                        // datatable color schemes
                        withBlock.layoutDesign.buttonColor = Color.FromArgb(Conversions.ToInteger(data["buttonColor"].ToString()));
                        withBlock.layoutDesign.dividerColor = Color.FromArgb(Conversions.ToInteger(data["dividerColor"].ToString()));
                        withBlock.colorSite = Color.FromArgb(Conversions.ToInteger(data["colorSite"].ToString()));
                        withBlock.colorSection = Color.FromArgb(Conversions.ToInteger(data["colorSection"].ToString()));
                        withBlock.colorCompany = Color.FromArgb(Conversions.ToInteger(data["colorCompany"].ToString()));
                        withBlock.colorWorkCategories = Color.FromArgb(Conversions.ToInteger(data["colorWorkCategories"].ToString()));
                        withBlock.colorAbsense = Color.FromArgb(Conversions.ToInteger(data["colorAbsense"].ToString()));
                        withBlock.colorWithoutRecord = Color.FromArgb(Conversions.ToInteger(data["colorWithoutRecord"].ToString()));
                        withBlock.colorWeekends = Color.FromArgb(Conversions.ToInteger(data["colorWeekends"].ToString()));
                        withBlock.colorHolidays = Color.FromArgb(Conversions.ToInteger(data["colorHolidays"].ToString()));
                        withBlock.colorWithRecord = Color.FromArgb(Conversions.ToInteger(data["colorWithRecord"].ToString()));
                        withBlock.colorAbsentDay = Color.FromArgb(Conversions.ToInteger(data["colorAbsentDay"].ToString()));
                        withBlock.colorFermetureAnnual = Color.FromArgb(Conversions.ToInteger(data["colorFermetureAnnual"].ToString()));
                        withBlock.colorPartialDayValidated = Color.FromArgb(Conversions.ToInteger(data["colorPartialDayValidated"].ToString()));
                        withBlock.colorPlannedChangeOfSite = Color.FromArgb(Conversions.ToInteger(data["colorPlannedChangeOfSite"].ToString()));
                        withBlock.colorPlannedTeam = Color.FromArgb(Conversions.ToInteger(data["colorPlannedTeam"].ToString()));
                        withBlock.colorFullDayValidated = Color.FromArgb(Conversions.ToInteger(data["colorFullDayValidated"].ToString()));
                        withBlock.layoutDesign.colorMainMenu = Color.FromArgb(Conversions.ToInteger(data["colorMainMenu"].ToString()));
                        // font files
                        withBlock.layoutDesign.fontTitleFile = data["fontTitleFile"].ToString();
                        withBlock.layoutDesign.fontTextFile = data["fontTextFile"].ToString();
                        // delay Days Validation Attendance
                        withBlock.delayDaysValidationAttendance = Conversions.ToInteger(data["delayDaysValidationAttendance"].ToString());
                        withBlock.layoutDesign.fontTitle.AddFontFile(withBlock.fontsPath + withBlock.layoutDesign.fontTitleFile);
                        withBlock.layoutDesign.fontText.AddFontFile(withBlock.fontsPath + withBlock.layoutDesign.fontTextFile);
                    }
                    catch (Exception ex)
                    {
                        withBlock.stateErrorMessage = ex.ToString();
                    }
                }
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
                enVars.stateErrorMessage = My.Resources.strings.errorDataFileNotFound;
            }

            changeDataLoadedState(false, LOAD_CONFIG);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void loadAddons() // REQUIRES VALID USER ID
        {
            changeDataLoadedState(true);
            if (enVars.userId.Equals(""))
            {
                changeDataLoadedState(false);
                enVars.addonsLoaded = false;
                return;
            }

            var vars = new Dictionary<string, string>();
            vars.Add("task", enVars.taskId["addons"]);
            vars.Add("id", enVars.userId);
            loadAddOnsData = new HttpDataPostData(enVars);
            loadAddOnsData.initialize();
            loadAddOnsData.loadQueue(vars, null, null);
            loadAddOnsData.startRequest();
        }

        private void loadAddOnsData_dataArrived(object sender, string requestData, Dictionary<string, string> misc)
        {
            if (!ManagementNetwork.IsResponseOk(requestData))
            {
                changeDataLoadedState(false, LOAD_ADDONS);
                enVars.stateErrorMessage = ManagementNetwork.GetMessage(requestData);
                enVars.addonsLoaded = false;
                return;
            }

            try
            {
                var jsonLatResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(requestData);
                if (jsonLatResult.ContainsKey("addons"))
                {
                    var Jaddons = JArray.Parse(jsonLatResult["addons"].ToString());
                    foreach (var Jaddon in Jaddons)
                    {
                        var addonItem = new Dictionary<string, string>();
                        addonItem.Add("url", (string)Jaddon["url"]);
                        addonItem.Add("name", (string)Jaddon["name"]);
                        enVars.addons.Add((string)Jaddon["type"], addonItem);
                    }

                    enVars.addonsLoaded = true;
                }
            }
            catch (Exception ex)
            {
                enVars.addonsLoaded = false;
                enVars.stateErrorMessage = ex.ToString();
            }

            changeDataLoadedState(false, LOAD_ADDONS);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void loadLocation()
        {
            changeDataLoadedState(true);
            loadIpAddressData = new HttpDataGetData(enVars, "https://api.ipify.org");
            loadIpAddressData.initialize();
            loadIpAddressData.startRequest();
        }

        private void loadIpAddressData_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            IPAddress _ip = null;
            if (IPAddress.TryParse(responseData, out _ip).Equals(true))
            {
                enVars.currentIpAddress = responseData;
                loadLocationCoordinates = new HttpDataGetData(enVars, "http://ip-api.com/json/" + responseData);
                loadLocationCoordinates.initialize();
                loadLocationCoordinates.startRequest();
            }
        }

        private void loadLocationCoordinates_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            AeonLabs.Environment.environmentVarsCore.locationDataStructure locationDataItem;
            locationDataItem = enVars.locationData;
            try
            {
                var jsonLatResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);
                if (jsonLatResult.ContainsKey("lat") & jsonLatResult.ContainsKey("lon"))
                {
                    locationDataItem.latitude = jsonLatResult["lat"].ToString().Replace(",", ".");
                    locationDataItem.longitude = jsonLatResult["lon"].ToString().Replace(",", ".");
                    enVars.locationData = locationDataItem;
                    loadLocationData = new HttpDataGetData(enVars, "http://nominatim.openstreetmap.org/reverse?format=json&lat=" + enVars.locationData.latitude + "&lon=" + enVars.locationData.longitude + "&zoom=18&addressdetails=1");
                    loadLocationData.initialize();
                    loadLocationData.startRequest();
                }
            }
            catch (Exception ex)
            {
                changeDataLoadedState(false, LOAD_LOCATION);
                enVars.stateErrorMessage = ex.ToString();
            }
        }

        private void loadLocationData_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            AeonLabs.Environment.environmentVarsCore.locationDataStructure locationDataItem;
            locationDataItem = enVars.locationData;
            try
            {
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);
                if (jsonResult.ContainsKey("display_name"))
                {
                    locationDataItem.displayName = Conversions.ToString(jsonResult["display_name"]);
                }

                if (jsonResult.ContainsKey("address"))
                {
                    var jsonAddresult = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResult["address"].ToString());
                    locationDataItem.road = Conversions.ToString(jsonAddresult["road"]);
                    locationDataItem.hamlet = Conversions.ToString(jsonAddresult["hamlet"]);
                    locationDataItem.state = Conversions.ToString(jsonAddresult["state"]);
                    locationDataItem.postCode = Conversions.ToString(jsonAddresult["postcode"]);
                    locationDataItem.country = Conversions.ToString(jsonAddresult["country"]);
                    locationDataItem.countryCode = Conversions.ToString(jsonAddresult["country_code"]);
                    enVars.locationData = locationDataItem;
                }
            }
            catch (Exception ex)
            {
                enVars.stateErrorMessage = ex.ToString();
            }

            changeDataLoadedState(false, LOAD_LOCATION);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void changeDataLoadedState(bool loadState, int task = default)
        {
            if (loadState.Equals(true))
            {
                // add queue
                dataLoadedStatusQueue += 1;
                dataLoaded = false;
            }
            else if (loadState.Equals(false))
            {
                if (dataLoadedStatusQueue.Equals(1))
                {
                    dataLoadedStatusQueue = 0;
                    dataLoaded = true;
                    environmentDataLoadedCompleted?.Invoke(task);
                }
                else
                {
                    dataLoadedStatusQueue -= 1;
                }
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void LoadAssemblies()
        {
            changeDataLoadedState(true);
            // TODO ? is needed ?
            changeDataLoadedState(false, LOAD_ASSEMBLIES);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}