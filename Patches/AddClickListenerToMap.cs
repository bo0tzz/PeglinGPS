using HarmonyLib;
using PeglinGPS.Behaviours;
using Worldmap;

namespace PeglinGPS.Patches
{
    [HarmonyPatch(typeof(MapController), "Awake")]
    public class AddClickListenerToMap
    {
        public static void Prefix(MapController __instance)
        {
            var mapContents = __instance.transform.Find("MapContents");
            var go = mapContents != null ? mapContents.gameObject : __instance.gameObject;
            go.AddComponent<ColorMapNodeOnClick>();
        }
    }
}