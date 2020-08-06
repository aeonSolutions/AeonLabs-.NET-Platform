﻿using AeonLabs.Environment;

public class assembliesToLoadClass
{
    private environmentVarsCore enVars = new environmentVarsCore();

    public environmentVarsCore Load(global::System.Object _enVars)
    {
        enVars = _enVars;
        load_profile_menu();
        load_help_menu();
        return enVars;
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void load_profile_menu()
    {
        var assItem = new environmentAssembliesClass();
        {
            var withBlock = assItem;
            withBlock.assemblyFileName = "profile.dll";
            withBlock.friendlyUID = "MyProfile";
            withBlock.UID = "";
            withBlock.assemblyFormName = "";
            withBlock.assemblyFormToLoad = default;
            withBlock.AssemblyObject = default;
            withBlock.spaceName = "";
        }

        enVars.assemblies.Add("", assItem);
        assItem = new environmentAssembliesClass();
        {
            var withBlock1 = assItem;
            withBlock1.assemblyFileName = "settings.dll";
            withBlock1.friendlyUID = "MySettings";
            withBlock1.UID = "";
            withBlock1.assemblyFormName = "";
            withBlock1.assemblyFormToLoad = default;
            withBlock1.AssemblyObject = default;
            withBlock1.spaceName = "";
        }

        enVars.assemblies.Add("", assItem);
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
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        enVars.assemblies.Add("", assItem);
        assItem = new environmentAssembliesClass();
        assItem.assemblyFileName = "about.dll";
        assItem.friendlyUID = "about";
        assItem.UID = "";
        assItem.assemblyFormName = "";
        assItem.assemblyFormToLoad = default;
        assItem.AssemblyObject = default;
        assItem.spaceName = "";
        enVars.assemblies.Add("", assItem);
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}