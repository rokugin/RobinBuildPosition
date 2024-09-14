using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using RobinBuildPosition.Patches;

namespace RobinBuildPosition;

internal class ModEntry : Mod {

    public static IMonitor? SMonitor;

    public override void Entry(IModHelper helper) {
        SMonitor = Monitor;

        var harmony = new Harmony(ModManifest.UniqueID);

        harmony.Patch(
            original: AccessTools.Method(typeof(NPC), "updateConstructionAnimation"),
            postfix: new HarmonyMethod(typeof(NPCPatch), nameof(NPCPatch.UpdateConstructionAnimation_Postfix))
        );
    }

}
