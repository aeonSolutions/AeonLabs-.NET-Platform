using AeonLabs.Environment;
using AeonLabs.Environment.menuEnvironmentVarsClass;

public class menuOptions
{
    private environmentVarsCore enVars = new environmentVarsCore();
    private const global::System.Int32 PROFILE = 1;
    private const global::System.Int32 HELP = 1000;

    public environmentVarsCore Load(global::System.Object _enVars)
    {
        enVars = _enVars;
        load_profile_menu();
        load_menu_help();
        return enVars;
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void load_profile_menu()
    {
        var menuItem = new menuItemClass();
        global::System.Int32 subMenuIdx = 0;
        menuItem.menuUID = "MyProfile";
        menuItem.menuTitle = My.Resources.strings.menuItemMyProfile;
        menuItem.friendlyUID = "profile.dll";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "usersProfileForm";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = false;
        menuItem.menuIndex = PROFILE;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU SETTINGS
        subMenuIdx += 1;
        menuItem.menuUID = "Settings";
        menuItem.menuTitle = My.Resources.strings.menuItemSettings;
        menuItem.friendlyUID = "settings.dll";
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
        menuItem.menuTitle = My.Resources.strings.menuItemLogout;
        menuItem.friendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.LOGOUT);
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU EXIT APP
        subMenuIdx += 1;
        menuItem.menuUID = "Exit";
        menuItem.menuTitle = My.Resources.strings.menuItemLogout;
        menuItem.friendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = default;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = PROFILE;
        menuItem.tasks.Add(runInternalTask.EXITAPP);
        enVars.layoutDesign.menu.items.Add(menuItem);
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void load_menu_help()
    {
        global::System.Int32 subMenuIdx = 0;
        var menuItem = new menuItemClass();
        menuItem.menuUID = "Help";
        menuItem.menuTitle = My.Resources.strings.menuHelpTitle;
        menuItem.friendlyUID = default;
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "help.icon.png";
        menuItem.subMenuIndex = false;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);

        // SUB MENU CHECK FOR UPDATES
        subMenuIdx += 1;
        menuItem.menuUID = "CheckUpdates";
        menuItem.menuTitle = My.Resources.strings.menuItemCheckUpdate;
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
        menuItem.menuTitle = My.Resources.strings.menuItemAbout + " " + enVars.customization.ApplicationBrandNAme;
        menuItem.friendlyUID = "about.dll";
        menuItem.formWithContentsToLoad = default;
        menuItem.nameSpaceString = "";
        menuItem.showAsDialog = true;
        menuItem.icon = "";
        menuItem.subMenuIndex = subMenuIdx;
        menuItem.menuIndex = HELP;
        enVars.layoutDesign.menu.items.Add(menuItem);
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}