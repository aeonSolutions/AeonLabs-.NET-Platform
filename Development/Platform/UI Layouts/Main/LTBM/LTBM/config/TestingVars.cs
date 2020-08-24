using AeonLabs.Environment.Core;
using System;
using System.Drawing;
using static AeonLabs.Environment.Core.constants;
using static AeonLabs.Environment.Core.menuEnvironmentVarsClass;

static class TestingVars
    {
        public static environmentVarsCore loadTestingEnvironmentVars(environmentVarsCore envars)
        {
            const int PROFILE = 1;
            const int HELP = 100;
            const int PROFILE2 = 200;
            const int PROFILE3 = 300;

        envars.customization.ApplicationBrandNAme = "MainTestApp";
        envars.customization.designLayoutAssemblyFileName = "ltbm.layout.dll";
        envars.customization.designLayoutAssemblyNameSpace = "AeonLabs.Layouts.Main";
        envars.customization.designStartupLayoutAssemblyFileName = "medieval.startup.layout.dll";
        envars.customization.designStartupLayoutAssemblyNameSpace = "AeonLabs.Layouts.StartUp";
        envars.customization.hasLogin = true;
        envars.customization.hasSetup = true;
        envars.customization.hasLocalSettings = true;
        envars.customization.hasCloudSettings = true;
        envars.customization.hasStaticAssemblies = true;
        envars.customization.hasDynamicAssemblies = true;
        envars.customization.hasStaticDocumentTemplates = true;
        envars.customization.hasDynamicDocumentTemplates = true;

        // TODO: replace by API ACCESS KEY string : office435dfgjdn4235
        envars.customization.softwareAccessMode = "humanResources";  // possible values: office, site, contractor, rh
        envars.customization.expireDate = "01/01/2021";
        envars.customization.updateServerAddr = "http://www.store.aeonlabs.solutions/index.php";
        envars.customization.crashReportServerAddr = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash";
        envars.customization.websiteToLoadProgram = "http://www.sitelogistics.construction";
            

            
        envars.layoutDesign.PanelBackColor = Color.Black;
        envars.layoutDesign.PanelTransparencyIndex = 70;
        envars.layoutDesign.IconsDefaultSize = 40;
        envars.layoutDesign.PANEL_SCROOL_UNDERLAY = 100;
            

            // MENUS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            
        envars.layoutDesign.menu.properties.ClosedStateSize = 40;
        envars.layoutDesign.menu.properties.height = 40;
        envars.layoutDesign.menu.properties.width = 400;
        envars.layoutDesign.menu.properties.activeBarWidth = 5;
        envars.layoutDesign.menu.properties.activeBarColor = Color.Orange;
            

        // MENU PRIFILE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        envars.layoutDesign.menu.items = new System.Collections.Generic.List<menuItemClass>();
        var menuItem = new menuItemClass();
            int subMenuIdx = 0;
            
        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "Menu 1";
        menuItem.friendlyUID = "profile.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "icon.person.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = PROFILE;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            
        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "Submenu 1";
        menuItem.friendlyUID = "settings.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "Subemenu 2";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.LOGOUT.ToString());
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 3";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = false;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.EXITAPP.ToString());
            
            envars.layoutDesign.menu.items.Add(menuItem);

            // MENU profile 2 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            menuItem = new menuItemClass();
            subMenuIdx = 0;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "menu 2";
        menuItem.friendlyUID = "profile.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "icon.person.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = PROFILE2;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 1";
        menuItem.friendlyUID = "settings.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE2;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 2";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE2;
        menuItem.tasks.Add(runInternalTask.LOGOUT.ToString());
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 3";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = false;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE2;
        menuItem.tasks.Add(runInternalTask.EXITAPP.ToString());
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // MENU PRIFILE 3++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            menuItem = new menuItemClass();
            subMenuIdx = 0;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "menu 3";
        menuItem.friendlyUID = "profile.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "icon.person.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = PROFILE3;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU SETTINGS
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 1";
        menuItem.friendlyUID = "settings.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE3;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU LOGOUT 
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 2";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE3;
        menuItem.tasks.Add(runInternalTask.LOGOUT.ToString());
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU EXIT APP
            menuItem = new menuItemClass();
            subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 3";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = false;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE3;
        menuItem.tasks.Add(runInternalTask.EXITAPP.ToString());
            

            envars.layoutDesign.menu.items.Add(menuItem);
            // MENU HELP ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            subMenuIdx = 0;
            menuItem = new menuItemClass();

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "menu 4";
        menuItem.friendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "icon.help.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = HELP;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU CHECK FOR UPDATES
            subMenuIdx += 1;
            menuItem = new menuItemClass();

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = "sub menu 1";
        menuItem.friendlyUID = "update.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = HELP;
            

            envars.layoutDesign.menu.items.Add(menuItem);

            // SUB MENU ABOUT
            menuItem = new menuItemClass();
            subMenuIdx += 1;
            menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
            menuItem.menuTitle = "sub menu 2";
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
