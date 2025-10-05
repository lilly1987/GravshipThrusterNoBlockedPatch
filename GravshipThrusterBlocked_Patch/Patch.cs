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
        public static HarmonyX harmony = null;
        public static string harmonyId = "Lilly.GravshipThrusterNoBlocked";

        public static void OnPatch(bool repatch = false)
        {
            if (repatch)
            {
                Unpatch();
            }
            if (harmony != null) return;
            harmony = new HarmonyX(harmonyId);
            try
            {
                harmony.PatchAll();
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
            //harmony.UnpatchAll(harmonyId);
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
    

        [HarmonyPatch(typeof(CompGravshipThruster), "IsOutdoors")]
        [HarmonyPrefix]
        public static bool CompGravshipThruster_IsOutdoors(ref bool __result)
        {
            if (Settings.onPatch)
            {
                __result = true;
                return false;
            }
            return true;
        }
    }
}
