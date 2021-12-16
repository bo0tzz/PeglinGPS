using HarmonyLib;
using UnityEngine;
using Worldmap;

namespace PeglinGPS.Patches
{
    [HarmonyPatch(typeof(MapNode), "SetActiveState")]
    public class KeepMapNodeColor
    {
        public static void Prefix(MapNode __instance, ref bool __state)
        {
            var rend = Utils.GetSpriteRenderer(__instance);
            if (rend is not null && rend.color == Color.green) __state = true;
        }

        public static void Postfix(MapNode __instance, ref bool __state)
        {
            if (__state)
            {
                var rend = Utils.GetSpriteRenderer(__instance);
                if (rend is not null) rend.color = Color.green;
            }
        }
    }
}