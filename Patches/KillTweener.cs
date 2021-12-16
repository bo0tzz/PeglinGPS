using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using DG.Tweening;
using HarmonyLib;

namespace PeglinGPS.Patches
{
    [HarmonyPatch(typeof(SlotManager), "ConfigureForNavigation")]
    public class KillTweener
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            MethodInfo killMethod = AccessTools.Method(typeof(TweenExtensions), "Kill");
            
            foreach (CodeInstruction i in instructions)
            {
                if (i.opcode != OpCodes.Ret)
                    yield return i;
            }

            yield return new CodeInstruction(OpCodes.Ldloc_1);
            yield return new CodeInstruction(OpCodes.Ldc_I4_0);
            yield return new CodeInstruction(OpCodes.Call, killMethod);
            yield return new CodeInstruction(OpCodes.Ret);
        }
    }
}