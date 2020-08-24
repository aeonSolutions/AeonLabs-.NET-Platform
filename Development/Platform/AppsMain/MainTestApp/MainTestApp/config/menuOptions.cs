using AeonLabs.Environment.Core;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using static AeonLabs.Environment.Core.constants;
using static AeonLabs.Environment.Core.menuEnvironmentVarsClass;

public class menuOptions
{
    private environmentVarsCore enVars = new environmentVarsCore();
    private const global::System.Int32 PROFILE = 1;
    private const global::System.Int32 HELP = 1000;

    private ResourceManager rm = new ResourceManager(Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace + ".config.strings", Assembly.GetExecutingAssembly());

    public environmentVarsCore Load(environmentVarsCore _enVars)
    {
        enVars = _enVars;

        // menu properties
        enVars.layoutDesign.PanelBackColor = Color.Black;
        enVars.layoutDesign.PanelTransparencyIndex = 70;
        enVars.layoutDesign.IconsDefaultSize = 40;
        enVars.layoutDesign.PANEL_SCROOL_UNDERLAY = 100;

        enVars.layoutDesign.menu.properties.ClosedStateSize = 40;
        enVars.layoutDesign.menu.properties.height = 40;
        enVars.layoutDesign.menu.properties.width = 400;
        enVars.layoutDesign.menu.properties.activeBarWidth = 5;
        enVars.layoutDesign.menu.properties.activeBarColor = Color.Orange;

        load_profile_menu();
        //load_menu_help();
        return enVars;
    }

#region Load Menu Profile
    private void load_profile_menu()
    {
        enVars.layoutDesign.menu.items = new System.Collections.Generic.List<menuItemClass>();
        var menuItem = new menuItemClass();
        int subMenuIdx = 0;
        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = rm.GetString("menuItemMyProfile", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = "profile.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "icon.person.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = PROFILE;

        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU SETTINGS
        menuItem = new menuItemClass();
        subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = rm.GetString("menuItemSettings", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = "settings.dll";
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;

        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU LOGOUT 
        menuItem = new menuItemClass();
        subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = rm.GetString("menuItemLogout", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.LOGOUT.ToString());

        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU EXIT APP
        menuItem = new menuItemClass();
        subMenuIdx += 1;

        menuItem.menuUID = Guid.NewGuid().ToString().Replace("-", "");
        menuItem.menuTitle = rm.GetString("menuItemLogout", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = null;
        menuItem.formWithContentsToLoad = null;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = false;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.EXITAPP.ToString());

        enVars.layoutDesign.menu.items.Add(menuItem);
    }
    #endregion

    #region Load Menu Help
    private void load_menu_help()
    {
        global::System.Int32 subMenuIdx = 0;
        var menuItem = new menuItemClass();
        menuItem.menuUID = "Help";
        menuItem.menuTitle = rm.GetString("menuHelpTitle", CultureInfo.CurrentCulture); 
        menuItem.assemblyFriendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "help.icon.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU CHECK FOR UPDATES
        menuItem = new menuItemClass();
        subMenuIdx += 1;
        menuItem.menuUID = "CheckUpdates";
        menuItem.menuTitle = rm.GetString("menuItemCheckUpdate", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = "update.dll";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU ABOUT
        menuItem = new menuItemClass();
        subMenuIdx += 1;
        menuItem.menuUID = "About";
        menuItem.menuTitle = rm.GetString("menuItemAbout", CultureInfo.CurrentCulture) + " " + enVars.customization.ApplicationBrandNAme;
        menuItem.assemblyFriendlyUID = "about.dll";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);
    }
#endregion
}