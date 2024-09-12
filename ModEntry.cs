using HarmonyLib;
using StardewModdingAPI;

namespace RobinBuildPosition;

internal class ModEntry : Mod {

    public override void Entry(IModHelper helper) {
        var harmony = new Harmony(ModManifest.UniqueID);

        harmony.PatchAll();
    }

}
