using AeonLabs.Environment;
using System;
using System.Drawing;
using static AeonLabs.Environment.constants;
using static AeonLabs.Environment.menuEnvironmentVarsClass;


    static class TestingVars
    {
        public static environmentVarsCore loadTestingEnvironmentVars(environmentVarsCore envars)
        {
            const int PROFILE = 1;
            const int HELP = 100;
            const int PROFILE2 = 200;
            const int PROFILE3 = 300;
            {
                var withBlock = envars.customization;
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

            {
                var withBlock1 = envars.layoutDesign;
                withBlock1.PanelBackColor = Color.Black;
                withBlock1.PanelTransparencyIndex = 70;
                withBlock1.IconsDefaultSize = 40;
                withBlock1.PANEL_SCROOL_UNDERLAY = 100;
            }

            // MENUS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            {
                var withBlock2 = envars.layoutDesign.menu.properties;
                withBlock2.ClosedStateSize = 40;
                withBlock2.height = 40;
                withBlock2.width = 400;
                withBlock2.activeBarWidth = 5;
                withBlock2.activeBarColor = Color.Orange;
            }

            // MENU PRIFILE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            var menuItem = new menuItemClass();
            int subMenuIdx = 0;
            {
                var withBlock3 = menuItem;
                withBlock3.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock3.menuTitle = "Profile";
                withBlock3.friendlyUID = "profile.dll";
                withBlock3.formWithContentsToLoad = null;
                withBlock3.nameSpaceString = "usersProfileForm";
                withBlock3.showAsDialog = true;
                withBlock3.icon = "icon.person.png";
                withBlock3.subMenuIndex = 0;
                withBlock3.menuIndex = PROFILE;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock4 = menuItem;
                withBlock4.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock4.menuTitle = "Settings";
                withBlock4.friendlyUID = "settings.dll";
                withBlock4.formWithContentsToLoad = null;
                withBlock4.nameSpaceString = "";
                withBlock4.showAsDialog = true;
                withBlock4.icon = "";
                withBlock4.subMenuIndex = subMenuIdx;
                withBlock4.menuIndex = PROFILE;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock5 = menuItem;
                withBlock5.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock5.menuTitle = "Logout";
                withBlock5.friendlyUID = null;
                withBlock5.formWithContentsToLoad = null;
                withBlock5.nameSpaceString = "";
                withBlock5.showAsDialog = true;
                withBlock5.icon = "";
                withBlock5.subMenuIndex = subMenuIdx;
                withBlock5.menuIndex = PROFILE;
                withBlock5.tasks.Add(runInternalTask.LOGOUT.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock6 = menuItem;
                withBlock6.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock6.menuTitle = "Exit";
                withBlock6.friendlyUID = null;
                withBlock6.formWithContentsToLoad = null;
                withBlock6.nameSpaceString = "";
                withBlock6.showAsDialog = false;
                withBlock6.icon = "";
                withBlock6.subMenuIndex = subMenuIdx;
                withBlock6.menuIndex = PROFILE;
                withBlock6.tasks.Add(runInternalTask.EXITAPP.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // MENU profile 2 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            menuItem = new menuItemClass();
            subMenuIdx = 0;
            {
                var withBlock7 = menuItem;
                withBlock7.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock7.menuTitle = "Profile";
                withBlock7.friendlyUID = "profile.dll";
                withBlock7.formWithContentsToLoad = null;
                withBlock7.nameSpaceString = "usersProfileForm";
                withBlock7.showAsDialog = true;
                withBlock7.icon = "icon.person.png";
                withBlock7.subMenuIndex = 0;
                withBlock7.menuIndex = PROFILE2;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock8 = menuItem;
                withBlock8.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock8.menuTitle = "Settings";
                withBlock8.friendlyUID = "settings.dll";
                withBlock8.formWithContentsToLoad = null;
                withBlock8.nameSpaceString = "";
                withBlock8.showAsDialog = true;
                withBlock8.icon = "";
                withBlock8.subMenuIndex = subMenuIdx;
                withBlock8.menuIndex = PROFILE2;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock9 = menuItem;
                withBlock9.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock9.menuTitle = "Logout";
                withBlock9.friendlyUID = null;
                withBlock9.formWithContentsToLoad = null;
                withBlock9.nameSpaceString = "";
                withBlock9.showAsDialog = true;
                withBlock9.icon = "";
                withBlock9.subMenuIndex = subMenuIdx;
                withBlock9.menuIndex = PROFILE2;
                withBlock9.tasks.Add(runInternalTask.LOGOUT.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock10 = menuItem;
                withBlock10.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock10.menuTitle = "Exit";
                withBlock10.friendlyUID = null;
                withBlock10.formWithContentsToLoad = null;
                withBlock10.nameSpaceString = "";
                withBlock10.showAsDialog = false;
                withBlock10.icon = "";
                withBlock10.subMenuIndex = subMenuIdx;
                withBlock10.menuIndex = PROFILE2;
                withBlock10.tasks.Add(runInternalTask.EXITAPP.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // MENU PRIFILE 3++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            menuItem = new menuItemClass();
            subMenuIdx = 0;
            {
                var withBlock11 = menuItem;
                withBlock11.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock11.menuTitle = "Profile";
                withBlock11.friendlyUID = "profile.dll";
                withBlock11.formWithContentsToLoad = null;
                withBlock11.nameSpaceString = "usersProfileForm";
                withBlock11.showAsDialog = true;
                withBlock11.icon = "icon.person.png";
                withBlock11.subMenuIndex = 0;
                withBlock11.menuIndex = PROFILE3;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock12 = menuItem;
                withBlock12.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock12.menuTitle = "Settings";
                withBlock12.friendlyUID = "settings.dll";
                withBlock12.formWithContentsToLoad = null;
                withBlock12.nameSpaceString = "";
                withBlock12.showAsDialog = true;
                withBlock12.icon = "";
                withBlock12.subMenuIndex = subMenuIdx;
                withBlock12.menuIndex = PROFILE3;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock13 = menuItem;
                withBlock13.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock13.menuTitle = "Logout";
                withBlock13.friendlyUID = null;
                withBlock13.formWithContentsToLoad = null;
                withBlock13.nameSpaceString = "";
                withBlock13.showAsDialog = true;
                withBlock13.icon = "";
                withBlock13.subMenuIndex = subMenuIdx;
                withBlock13.menuIndex = PROFILE3;
                withBlock13.tasks.Add(runInternalTask.LOGOUT.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            {
                var withBlock14 = menuItem;
                withBlock14.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock14.menuTitle = "Exit";
                withBlock14.friendlyUID = null;
                withBlock14.formWithContentsToLoad = null;
                withBlock14.nameSpaceString = "";
                withBlock14.showAsDialog = false;
                withBlock14.icon = "";
                withBlock14.subMenuIndex = subMenuIdx;
                withBlock14.menuIndex = PROFILE3;
                withBlock14.tasks.Add(runInternalTask.EXITAPP.ToString());
            }

            envars.layoutDesign.menu.items.Add(menuItem);
            // MENU HELP ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            subMenuIdx = 0;
            menuItem = new menuItemClass();
            {
                var withBlock15 = menuItem;
                withBlock15.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock15.menuTitle = "Help";
                withBlock15.friendlyUID = null;
                withBlock15.formWithContentsToLoad = null;
                withBlock15.nameSpaceString = "";
                withBlock15.showAsDialog = true;
                withBlock15.icon = "icon.help.png";
                withBlock15.subMenuIndex = 0;
                withBlock15.menuIndex = HELP;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU CHECK FOR UPDATES
            subMenuIdx += 1;
            menuItem = new menuItemClass();
            {
                var withBlock16 = menuItem;
                withBlock16.menuUID = Guid.NewGuid().ToString().Replace("-", "");
                withBlock16.menuTitle = "Update";
                withBlock16.friendlyUID = "update.dll";
                withBlock16.formWithContentsToLoad = null;
                withBlock16.nameSpaceString = "";
                withBlock16.showAsDialog = true;
                withBlock16.icon = "";
                withBlock16.subMenuIndex = subMenuIdx;
                withBlock16.menuIndex = HELP;
            }

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU ABOUT
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
            menuItem.menuTitle = "About";
            menuItem.friendlyUID = "about.dll";
            menuItem.formWithContentsToLoad = null;
            menuItem.nameSpaceString = "";
            menuItem.showAsDialog = true;
            menuItem.icon = "";
            menuItem.subMenuIndex = subMenuIdx;
            menuItem.menuIndex = HELP;
            envars.layoutDesign.menu.items.Add(menuItem);
            return envars;
        }
    }
