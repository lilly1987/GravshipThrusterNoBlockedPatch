using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Lilly.GravshipThrusterNoBlocked
{
    public static class Patch
    {
        public static Harmonyx harmony = null;
        public static string harmonyId = "Lilly.GravshipThrusterNoBlocked";

        //public static List<Type> nestedPatchTypes = typeof(Patch).GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        //        .Where(t => t.GetCustomAttributes(typeof(HarmonyPatch), false).Any()).ToList();

        public static void OnPatch(bool repatch = false)
        {
            if (repatch)
            {
                Unpatch();
            }
            if (harmony != null) return;
            harmony = new Harmonyx(harmonyId);
            try
            {
                harmony.PatchAll();
                //var prefix = AccessTools.Method(typeof(Patch), "CompGravshipThruster_IsBlocked_Patch");
                //harmony.Patch(original, prefix: new HarmonyMethod(prefix));
                //harmony.Patch(HarmonyPatchType.Prefix,
                //    typeof(Patch), "CompGravshipThruster_IsBlocked_Patch",
                //    typeof(CompGravshipThruster), "IsBlocked");

                MyLog.Message($"Patch <color=#00FF00FF>Succ</color>");
            }
            catch (System.Exception e)
            {
                MyLog.Error($"Patch Fail");
                MyLog.Error(e.ToString());
                MyLog.Error($"Patch Fail");
            }
            
        }

        public static void Unpatch()
        {
            MyLog.Message($"UnPatch");
            if (harmony == null) return;
            harmony.UnpatchAll(harmonyId);
            harmony.UnpatchSelf();
            harmony = null;
        }

        [HarmonyPatch(typeof(CompGravshipThruster), "IsBlocked")]
        [HarmonyPrefix]
        public static bool CompGravshipThruster_IsBlocked_Patch(ref bool __result, ThingDef thrusterDef, Map map, IntVec3 position, Rot4 rotation, out Thing blockedBy, out bool blockedBySubstructure)
        {
            blockedBy = null;
            blockedBySubstructure = false;
            if (Settings.onPatch)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
