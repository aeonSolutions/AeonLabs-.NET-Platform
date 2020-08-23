using AeonLabs.Environment;

static class AppCustomization
{
    public static environmentVarsCore setupCustomizationVariables(environmentVarsCore enVars)
    {
        {
            enVars.customization.ApplicationBrandNAme = "MainTestApp";
            enVars.customization.designLayoutAssemblyFileName = "ltbm.layout.dll";
            enVars.customization.designLayoutAssemblyNameSpace = "AeonLabs.Layouts.Main";
            enVars.customization.designStartupLayoutAssemblyFileName = "medieval.startup.layout.dll";
            enVars.customization.designStartupLayoutAssemblyNameSpace = "AeonLabs.Layouts.StartUp";
            enVars.customization.hasLogin = true;
            enVars.customization.hasSetup = true;
            enVars.customization.hasLocalSettings = true;
            enVars.customization.hasCloudSettings = true;
            enVars.customization.hasStaticAssemblies = true;
            enVars.customization.hasDynamicAssemblies = true;
            enVars.customization.hasStaticDocumentTemplates = true;
            enVars.customization.hasDynamicDocumentTemplates = true;

            // TODO: replace by API ACCESS KEY string : office435dfgjdn4235
            enVars.customization.softwareAccessMode = "humanResources";  // possible values: office, site, contractor, rh
            enVars.customization.expireDate = "01/01/2021";
            enVars.customization.updateServerAddr = "http://www.store.aeonlabs.solutions/index.php";
            enVars.customization.crashReportServerAddr = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash";
            enVars.customization.websiteToLoadProgram = "http://www.sitelogistics.construction";
        }

        return enVars;
    }
}