using AeonLabs.Environment.Core;
using System.Globalization;
using System.Reflection;
using System.Resources;
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
        load_profile_menu();
        load_menu_help();
        return enVars;
    }

#region Load Menu Profile
    private void load_profile_menu()
    {

        //Assembly assembly = Assembly.GetExecutingAssembly();
        //foreach (string s in assembly.GetManifestResourceNames())
        //    System.Diagnostics.Debug.WriteLine(s);

    var menuItem = new menuItemClass();
        global::System.Int32 subMenuIdx = 0;
        menuItem.menuUID = "MyProfile";
        menuItem.menuTitle = rm.GetString("menuItemMyProfile", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = "MyProfile";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = PROFILE;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU SETTINGS
        subMenuIdx += 1;
        menuItem.menuUID = "Settings";
        menuItem.menuTitle = rm.GetString("menuItemSettings", CultureInfo.CurrentCulture); 
        menuItem.assemblyFriendlyUID = "MySettings";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU LOGOUT 
        subMenuIdx += 1;
        menuItem.menuUID = "Logout";
        menuItem.menuTitle = rm.GetString("menuItemLogout", CultureInfo.CurrentCulture);
        menuItem.assemblyFriendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(constants.runInternalTask.LOGOUT.ToString() );
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU EXIT APP
        subMenuIdx += 1;
        menuItem.menuUID = "Exit";
        menuItem.menuTitle = rm.GetString("menuItemLogout", CultureInfo.CurrentCulture); 
        menuItem.assemblyFriendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = default;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(constants.runInternalTask.EXITAPP.ToString() );
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
        menuItem.friendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "help.icon.png";
        menuItem.subMenuIndex = 0;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU CHECK FOR UPDATES
        subMenuIdx += 1;
        menuItem.menuUID = "CheckUpdates";
        menuItem.menuTitle = rm.GetString("menuItemCheckUpdate", CultureInfo.CurrentCulture);
        menuItem.friendlyUID = "update.dll";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU ABOUT
        subMenuIdx += 1;
        menuItem.menuUID = "About";
        menuItem.menuTitle = rm.GetString("menuItemAbout", CultureInfo.CurrentCulture) + " " + enVars.customization.ApplicationBrandNAme;
        menuItem.friendlyUID = "about.dll";
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