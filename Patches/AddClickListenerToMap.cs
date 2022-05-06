using System.Collections.Generic;
using HarmonyLib;
using PeglinGPS.Behaviours;
using Worldmap;

namespace PeglinGPS.Patches
{
    [HarmonyPatch(typeof(MapController), "Awake")]
    public class AddClickListenerToMap
    {
        public static void Postfix(MapController __instance)
        {
            if (__instance == null) return;
            List<MapNodeColorSwapper> swappers = new List<MapNodeColorSwapper>();
            foreach (var node in __instance._nodes)
            {
                MapNodeColorSwapper swapper = node.gameObject.AddComponent<MapNodeColorSwapper>();
                swappers.Add(swapper);
            }

            var mapContents = __instance.transform.Find("MapContents");
            var go = mapContents != null ? mapContents.gameObject : __instance.gameObject;
            ColorMapNodeOnClick colorMapNodeOnClick = go.AddComponent<ColorMapNodeOnClick>();
            colorMapNodeOnClick.Init(swappers);
        }
    }
}