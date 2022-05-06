using System.Collections.Generic;
using HarmonyLib;
using Peglin.PegMinigame;
using UnityEngine;

namespace PeglinGPS.Patches
{
    [HarmonyPatch]
    public class SlotManagerColor
    {
        [HarmonyPatch(typeof(PostBattleController), "StartNavigation")]
        [HarmonyPostfix]
        public static void PostBattleControllerPatch(PostBattleController __instance)
        {
            if (StaticGameData.currentNode.ChildNodes.Length == 1)
            {
                Utils.RecolorSlotManager(__instance._centerSlotManager);
            }
            else
            {
                Utils.RecolorSlotManagers(__instance._leftSlotManager, __instance._rightSlotManager);   
            }
        }

        [HarmonyPatch(typeof(NavOnlyController), "PrepareForNavigation")]
        [HarmonyPostfix]
        public static void NavOnlyControllerPatch(NavOnlyController __instance)
        {
            Utils.RecolorSlotManagers(__instance._leftSlotManager, __instance._rightSlotManager);
        }
    }

    [HarmonyPatch]
    public class DynamicSlotTriggerHacks
    {
        private static List<DynamicSlotTrigger> thisIsDisgusting;
        
        [HarmonyPatch(typeof(PegMinigameManager), "CreateSlots")]
        [HarmonyPostfix]
        public static void HackToGrabDynamicSlotTriggers(List<DynamicSlotTrigger> __result)
        {
            thisIsDisgusting = __result;
        }

        [HarmonyPatch(typeof(PegMinigameManager), "CreateNavigationBouncersAndSlots")]
        [HarmonyPostfix]
        public static void ColorDynamicSlotTriggers()
        {
            if (thisIsDisgusting == null) return;
            for (int i = 0; i < thisIsDisgusting.Count; i++)
            {
                DynamicSlotTrigger dynamicSlotTrigger = thisIsDisgusting[i];
                var mapNodeSpriteRenderer = Utils.GetSpriteRenderer(StaticGameData.currentNode.ChildNodes[i]);
                dynamicSlotTrigger.iconSpriteRenderer.color = mapNodeSpriteRenderer.color;
            }

            thisIsDisgusting = null;
        }
        
    }
}