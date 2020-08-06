using AeonLabs.Environment;

static class AppCustomization
{
    public static environmentVarsCore setupCustomizationVariables(environmentVarsCore enVars)
    {
        {
            var withBlock = enVars.customization;
            withBlock.ApplicationBrandNAme = "MainTestApp";
            withBlock.designLayoutAssemblyFileName = "ltbm.layout.dll";
            withBlock.designLayoutAssemblyNameSpace = "AeonLabs.Layouts.Main";
            withBlock.designStartupLayoutAssemblyFileName = "medieval.startup.layout.dll";
            withBlock.designStartupLayoutAssemblyNameSpace = "AeonLabs.Layouts.StartUp";
            withBlock.hasLogin = true;
            withBlock.hasSetup = true;
            withBlock.hasLocalSettings = true;
            withBlock.hasCloudSettings = true;
            withBlock.hasStaticAssemblies = true;
            withBlock.hasDynamicAssemblies = true;
            withBlock.hasStaticDocumentTemplates = true;
            withBlock.hasDynamicDocumentTemplates = true;

            // TODO: replace by API ACCESS KEY string : office435dfgjdn4235
            withBlock.softwareAccessMode = "humanResources";  // possible values: office, site, contractor, rh
            withBlock.expireDate = "01/01/2021";
            withBlock.updateServerAddr = "http://www.store.aeonlabs.solutions/index.php";
            withBlock.crashReportServerAddr = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash";
            withBlock.websiteToLoadProgram = "http://www.sitelogistics.construction";
        }

        return enVars;
    }
}