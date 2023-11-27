using Game;
using Game.Common;
using HarmonyLib;
using VehicleCounter.Systems;

namespace VehicleCounter.Patches {

    [HarmonyPatch(typeof(SystemOrder))]
    public static class SystemOrderPatch {
        [HarmonyPatch("Initialize")]
        [HarmonyPostfix]
        public static void Postfix(UpdateSystem updateSystem) {
            updateSystem.UpdateAt<VehicleCounterSystem>(SystemUpdatePhase.PostSimulation);
            updateSystem.UpdateAt<VehicleCounterUISystem>(SystemUpdatePhase.UIUpdate);
        }
    }
}