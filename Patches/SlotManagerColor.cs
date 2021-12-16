using HarmonyLib;

namespace PeglinGPS.Patches
{
    [HarmonyPatch]
    public class SlotManagerColor
    {
        [HarmonyPatch(typeof(PostBattleController), "StartNavigation")]
        [HarmonyPostfix]
        public static void PostBattleControllerPatch(PostBattleController __instance)
        {
            Utils.RecolorSlotManagers(__instance._leftSlotManager, __instance._rightSlotManager);
        }

        [HarmonyPatch(typeof(NavOnlyController), "PrepareForNavigation")]
        [HarmonyPostfix]
        public static void NavOnlyControllerPatch(NavOnlyController __instance)
        {
            Utils.RecolorSlotManagers(__instance._leftSlotManager, __instance._rightSlotManager);
        }
    }
}