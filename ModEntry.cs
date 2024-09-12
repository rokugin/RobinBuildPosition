using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.GameData.Buildings;

namespace RobinBuildPosition {
    internal class ModEntry : Mod {

        public override void Entry(IModHelper helper) {
            var harmony = new Harmony(ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(NPC), "updateConstructionAnimation"),
                postfix: new HarmonyMethod(typeof(ModEntry), nameof(UpdateConstructionAnimation_Postfix))
            );
        }

        static void UpdateConstructionAnimation_Postfix() {
            if (Game1.IsThereABuildingUnderConstruction()) {
                Building b = Game1.GetBuildingUnderConstruction();
                BuildingData data = b.GetData();
                int X = 1, Y = 5;

                if (data != null && data.CustomFields.TryGetValue("rokugin.robinbuildposition", out string? value)) {
                    string[] position = value!.Split(" ");
                    if (!Int32.TryParse(position[0], out X)) {
                        X = 1;
                    }
                    if (!Int32.TryParse(position[1], out Y)) {
                        Y = 5;
                    }
                }

                if (b.daysUntilUpgrade.Value > 0 && b.GetIndoors() != null) {
                    NPC robin = Game1.getCharacterFromName("Robin");
                    robin.setTilePosition(X, Y);
                }
            }
        }

    }
}
