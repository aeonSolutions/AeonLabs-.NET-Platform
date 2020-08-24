using AeonLabs.Environment.Core;

public class assembliesToLoadClass
{
    private environmentVarsCore enVars = new environmentVarsCore();

    public environmentVarsCore Load(environmentVarsCore _enVars)
    {
        enVars = _enVars;
        load_profile_menu();
        load_help_menu();
        return enVars;
    }

#region Load Profile Menu
    private void load_profile_menu()
    {
        var assItem = new environmentAssembliesClass();
        assItem.assemblyFileName = "profile.dll";
        assItem.friendlyUID = "MyProfile";
        assItem.UID = "";
        assItem.assemblyFormName = "";
        assItem.assemblyFormToLoad = default;
        assItem.AssemblyObject = default;
        assItem.spaceName = "";

        enVars.assemblies.Add("MyProfile", assItem);
        assItem = new environmentAssembliesClass();
        assItem.assemblyFileName = "profile.dll";
        assItem.friendlyUID = "MyProfile";
        assItem.UID = "";
        assItem.assemblyFormName = "";
        assItem.assemblyFormToLoad = default;
        assItem.AssemblyObject = default;
        assItem.spaceName = "";

        enVars.assemblies.Add("MySettings", assItem);
        assItem = new environmentAssembliesClass();
        assItem.assemblyFileName = "settings.dll";
        assItem.friendlyUID = "MySettings";
        assItem.UID = "";
        assItem.assemblyFormName = "";
        assItem.assemblyFormToLoad = default;
        assItem.AssemblyObject = default;
        assItem.spaceName = "";
        enVars.assemblies.Add("", assItem);
    }
#endregion

#region Load Help Menu

    private void load_help_menu()
    {
        var assItem = new environmentAssembliesClass();
        {
            var withBlock = assItem;
            withBlock.assemblyFileName = "update.dll";
            withBlock.friendlyUID = "checkUpdate";
            withBlock.UID = "";
            withBlock.assemblyFormName = "";
            withBlock.assemblyFormToLoad = default;
            withBlock.AssemblyObject = default;
            withBlock.spaceName = "";
        }

        enVars.assemblies.Add("checkUpdate", assItem);
        assItem = new environmentAssembliesClass();
        assItem.assemblyFileName = "about.dll";
        assItem.friendlyUID = "about";
        assItem.UID = "";
        assItem.assemblyFormName = "";
        assItem.assemblyFormToLoad = default;
        assItem.AssemblyObject = default;
        assItem.spaceName = "";
        enVars.assemblies.Add("about", assItem);
    }
    #endregion
}