using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace AeonLabs.Environment
{
    public class environmentVarsCore
    {
        #region "constructor"
        public environmentVarsCore()
        {

            layoutDesign = new environmentLayoutClass();
            layoutDesign.loadDefaults(this);
        }
        #endregion

        #region "Events"
        public event dataChangedEventHandler dataChanged;

        public delegate void dataChangedEventHandler(object sender, environmentVarsCore envars);

        public delegate void updateMainLayoutDelegate(object sender, ref updateMainAppClass updateContents);

        public void updateMainLayout(object sender, ref updateMainAppClass updateContents)
        {
        }

        #endregion


        #region "Customization"
        public customization customization { get; set; } = new customization();
        #endregion

        #region
        public Dictionary<string, environmentAssembliesClass> assemblies { get; set; } = new Dictionary<string, environmentAssembliesClass>();
        public Dictionary<string, List<EnvironmentAssignedToControlClass>> assignedAssembliesToControl { get; set; } = new Dictionary<string, List<EnvironmentAssignedToControlClass>>();
        #endregion

        #region "settings"
        public object SettingsSecretKey { get; set; } = "29kdzQaFwSuNJ85t"; // it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 

        // ÚSER SETTINGS
        public userSettingsClass userSettings { get; set; } = new userSettingsClass();

        // UPDATES
        public bool checkForUpdatesIsEnabled { get; set; } = false;
        public bool packageUpdatesIsEnabled { get; set; } = false;
        public bool plugInsUpdatesIsEnabled { get; set; } = false;
        // LANGUAGE
        public string currentLang { get; set; } = "";
        public string country { get; set; } = "";
        public object defaultTranslatedLang { get; set; } = "fr";
        #endregion

        #region "layout settings"
        public List<notificationsClass> notifications { get; set; } = new List<notificationsClass>();

        private environmentLayoutClass _layoutDesign;

        public environmentLayoutClass layoutDesign
        {
            get
            {
                return _layoutDesign;
            }

            set
            {
                _layoutDesign = value;
            }
        }
        #endregion

        #region "file paths"
        public string imagesPath { get; set; } = string.Format(@"{0}\images\", System.Environment.CurrentDirectory);
        public string basePath { get; set; } = string.Format(@"{0}\", System.Environment.CurrentDirectory);
        public string tmpPath { get; set; } = string.Format(@"{0}\tmp\", System.Environment.CurrentDirectory);
        public string fontsPath { get; set; } = string.Format(@"{0}\fonts\", System.Environment.CurrentDirectory);
        public string libraryPath { get; set; } = string.Format(@"{0}\library\", System.Environment.CurrentDirectory);
        public string templatesPath { get; set; } = string.Format(@"{0}\templates\", System.Environment.CurrentDirectory);
        public string packagesPath { get; set; } = string.Format(@"{0}\packages\", System.Environment.CurrentDirectory);
        public string plugInsPath { get; set; } = string.Format(@"{0}\plugins\", System.Environment.CurrentDirectory);
        #endregion

        #region "diagnostics data"
        public bool SendDiagnosticData { get; set; } = false;
        public bool SendCrashData { get; set; } = false;
        #endregion

        #region "env. state"
        public bool stateLoaded { get; set; } = false;
        public bool settingsLoaded { get; set; } = false;
        public bool dataLoaded { get; set; } = false;
        public bool stateErrorFound { get; set; } = false;
        public string stateErrorMessage { get; set; } = "";
        #endregion

        public Dictionary<string, string> externalFilesToLoad { get; set; } = new Dictionary<string, string>(); // TODO remove entries when assembly is unloaded

        // TO BE CLASSIF. and SORTED
        public string ServerBaseAddr { get; set; } = ""; // base path without final slash
        public string ApiServerAddrPath { get; set; } = "";
        public string ApiHttpHeaderToken { get; set; } = ""; // GEN STRING ON LOAD
        public Dictionary<string, string> taskId { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> authorizedFileTemplates { get; set; }
        public object secretKey { get; set; } = "26kozQaKwRuNJ24t"; // it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 
        public string AppId { get; set; } = "";
        public string currentIpAddress { get; set; } = "";
        public bool successLogin { get; set; } = false;
        public string userId { get; set; } = "";
        public string username { get; set; } = "";
        public string userConnType { get; set; } = "";
        public string userType { get; set; } = "";
        public string userPhoto { get; set; } = "";
        public string journalResponsables { get; set; } = "Miguel Silva";

        // runtime user selections and settings
        public TableSearchOptionsStructure tableSearchOptions { get; set; } = new TableSearchOptionsStructure();
        public DataTable datatableContents { get; set; } = new DataTable();
        public locationDataStructure locationData { get; set; }

        // INTO SETTINGS: 
        // ToDo: settings to add on DB settings table
        public int delayDaysValidationAttendance { get; set; } = 1;
        public TimeSpan AutomaticLogoutTime { get; set; } = new TimeSpan(0, 15, 0); // 15 min timeout - integer (Hours, Minutes, Seconds) 
        public int maxMinutesForClearCheckout { get; set; } = 300;
        public bool isWorkingHoursIncompleteWorkDayHoursLogged { get; set; } = false;
        public TimeSpan maxWorkHoursDay { get; set; } = TimeSpan.Parse("10:00:00");

        // VISUAL STYLES
        // datatable color schemes
        public Color colorFullDayValidated { get; set; } = Color.FromArgb(192, 255, 192);
        public Color colorPlannedTeam { get; set; } = Color.FromArgb(204, 255, 117);
        public Color colorPlannedChangeOfSite { get; set; } = Color.LightSkyBlue;
        public Color colorPartialDayValidated { get; set; } = Color.FromArgb(255, 218, 117);
        public Color colorFermetureAnnual { get; set; } = Color.LightGray;
        public Color colorRecordDeleted { get; set; } = Color.LightGray;
        public Color colorAbsentDay { get; set; } = Color.MistyRose;
        public Color colorWithRecord { get; set; } = Color.Gold;
        public Color colorHolidays { get; set; } = Color.FromArgb(204, 236, 255);
        public Color colorWeekends { get; set; } = Color.Tan;
        public Color colorWithoutRecord { get; set; } = Color.IndianRed;
        public Color colorDarkGray { get; set; } = Color.Gainsboro;
        public Color colorLightGray { get; set; } = Color.LightGray;
        public Color colorAbsense { get; set; } = Color.PaleGoldenrod;
        public Color colorWorkCategories { get; set; } = Color.Beige;
        public Color colorCompany { get; set; } = Color.Linen;
        public Color colorSection { get; set; } = Color.Bisque;
        public Color colorSite { get; set; } = Color.Bisque;
        public Color colorDuplicate { get; set; } = Color.Red;

        // ADDONS
        public bool addonsLoaded { get; set; } = false;
        public Dictionary<string, Dictionary<string, string>> addons { get; set; } = new Dictionary<string, Dictionary<string, string>>();

        // QUERY FIELDS
        public string[] querySettingsFields { get; set; } = new[] { "disable_checkin", "disable_checkout", "max_days_delay_validation", "work_hours", "company_name" };
        public string[] querySiteFields { get; set; } = new[] { "cod_site", "name", "address", "initials", "gps_lat", "gps_lon", "ref_contrato", "cod_company", "data_inicio", "data_fim", "distancia", "authentication_radius", "active", "regie_hourly", "craneman_hourly", "machinist_hourly", "regie_weekends", "machinist_weekends", "craneman_weekends", "regie_after_hours", "machinist_after_hours", "craneman_after_hours", "project_languages", "primary_lang" };
        public string[] queryEntreprisePartnersFields { get; set; } = new[] { "cod_entreprise", "name", "contact" };
        public string[] querySiteSectionFields { get; set; } = new[] { "cod_section", "cod_site", "description", "attendances_last_close" };
        public string[] queryWorkerCategoryFields { get; set; } = new[] { "cod_category", "designation", "reference" };
        public string[] queryHolidaysFields { get; set; } = new[] { "date" };
        public string[] queryAbsenseFields { get; set; } = new[] { "cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo" };
        public string[] queryWorkersFields { get; set; } = new[] { "cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "contact112", "photo", "data_nascimento", "idade", "estado_civil", "nacionalidade", "cc", "cc_validade", "nif", "niss", "filhos", "filhos_encargo", "email", "data_inicio_trabalho", "morada", "prob_saude", "nib", "peso", "altura", "calcas", "pe", "casaco", "contrato_inicio", "contrato_fim", "contrato_file", "destacamento_inicio", "destacamento_fim", "destacamento_file", "act_inicio", "act_fim", "act_file", "a1_inicio", "a1_fim", "a1_file", "mutuelle_inicio", "mutuelle_file", "medico_inicio", "medico_file", "gruista_file", "refeicao", "ajudascusto", "salario", "classificacao", "localizacao", "naturalidade", "concelho", "cc_file", "csaude_file", "activo", "activo_date", "csaude_validade", "cod_meal_place", "cod_lodging", "notes", "room", "card_auth_key" };
        public string[] queryNonValidatedEntriesFields { get; set; } = new[] { "cod_site", "name", "date", "cod_worker" };
        public string[] queryDuplicatesFields { get; set; } = new[] { "cod_site", "name", "description" };
        public string[] querySiteClosureFields { get; set; } = new[] { "cod_closure", "cod_site", "start", "end", "motivo" };
        public string[] querySiteClothesFields { get; set; } = new[] { "cod_clothes", "cod_worker", "data", "clothes", "note", "request_date", "delivered" };
        public string[] querySiteMaterialsReceptionFields { get; set; } = new[] { "cod_materials_reception", "cod_site", "cod_section", "data", "start", "end", "qtd", "units", "material", "notas" };
        public string[] queryMobileDevicesFields { get; set; } = new[] { "cod_tablet", "worker.name", "pin", "tablet_id", "puk", "mobile", "name", "sw_version", "serial", "site.name", "site_section.description", "active", "date", "email" };
        public string[] querySiteContractorFields { get; set; } = new[] { "cod_company", "nome", "phone", "tva", "address", "email", "logo" };
        public string[] querySiteManagerFields { get; set; } = new[] { "cod_manager", "telef", "email", "name", "cod_site", "job", "cod_nfc", "cod_section", "photo", "auth_string" };
        public string[] queryTeamFields { get; set; } = new[] { "cod_worker", "cod_category" };
        public string[] queryBordereauFields { get; set; } = new[] { "cod_task", "descricao", "enabled", "units", "previous_task", "translations", "contractor_ref", "pu", "qtd" };
        public string[] queryWorkersOnSiteFields { get; set; } = new[] { "cod_worker", "name", "photo" };
        public string[] querySiteDailyReportFields { get; set; } = new[] { "activities", "ocurrences" };
        public string[] queryWorkerAbsensesFields { get; set; } = new[] { "cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo" };
        public string[] queryWorkersMealsPlace { get; set; } = new[] { "cod_meal_place", "name" };
        public string[] queryWorkersLodgingPlace { get; set; } = new[] { "cod_lodging", "name" };
        public string[] queryReportMonthly { get; set; } = new[] { "cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise" };
        public string[] queryReportDetailed { get; set; } = new[] { "cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "cod_site", "cod_section" };
        public string[] queryAttendanceRecords { get; set; } = new[] { "checkin", "checkout", "date", "status", "absense", "notas", "cod_site", "cod_section", "validation_reason" };
        public string[] queryLimosaRecords { get; set; } = new[] { "cod_limosa", "inicio", "fim", "file", "name", "qrcode" };
        public string[] queryAusenciasRecords { get; set; } = new[] { "cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo" };
        public string[] queryProfileFields { get; set; } = new[] { "name", "email", "photo", "contact", "cod_user", "pin" };
        public string[] queryTransportsFields { get; set; } = new[] { "cod_vehicle", "designation", "initials", "active", "rental" };

        // options on queries
        public string[] queryWorkerOptionsClothes { get; set; } = new[] { "pe", "calcas", "casaco", "peso", "altura" };

        public struct TableSearchOptionsStructure
        {
            public bool viewPlanningAssignmentWorkers;
            public bool viewOtherConstructionSitesAttendance;
            public bool viewThisConstructionSiteAttendance;
        }

        public struct locationDataStructure
        {
            public string displayName;
            public string address;
            public string houseNumber;
            public string road;
            public string hamlet;
            public string municipality;
            public string state;
            public string postCode;
            public string country;
            public string countryCode;
            public string latitude;
            public string longitude;
        }

        public void loadEnvironmentcoreDefaults()
        {
            layoutDesign.loadDefaults(this);

            // TODO move tableSearchOptions to its assembly
            var options = new TableSearchOptionsStructure();
            options.viewPlanningAssignmentWorkers = false;
            options.viewOtherConstructionSitesAttendance = false;
            options.viewThisConstructionSiteAttendance = false;
            tableSearchOptions = options;
        }
    }
}