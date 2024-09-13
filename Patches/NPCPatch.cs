using StardewValley.Buildings;
using StardewValley.GameData.Buildings;
using StardewValley;

namespace RobinBuildPosition.Patches;
internal class NPCPatch {

    public static void UpdateConstructionAnimation_Postfix(NPC __instance) {
        if (Game1.IsThereABuildingUnderConstruction()) {
            Building b = Game1.GetBuildingUnderConstruction();
            BuildingData data = b.GetData();
            int X = 1, Y = 5;

            if (data != null && data.CustomFields != null && data.CustomFields.TryGetValue("rokugin.robinbuildposition", out string? value)) {
                string[] position = value!.Split(" ");
                if (!Int32.TryParse(position[0], out X)) {
                    X = 1;
                }
                if (!Int32.TryParse(position[1], out Y)) {
                    Y = 5;
                }
            }

            if (b.daysUntilUpgrade.Value > 0 && b.GetIndoors() != null) {
                __instance.setTilePosition(X, Y);
            } else {
                (__instance).position.X += X;
                (__instance).position.Y += Y;
            }
        }
    }

}