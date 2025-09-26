using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Lilly.GravshipThrusterNoBlocked
{
    [StaticConstructorOnStartup]
    public class Startup
    {
        static Startup()
        {
            MyLog.Message($"ST");
            // 서브 클래스 중 HarmonyPatch가 붙은 것만 필터링
            //nestedPatchTypes = typeof(Patch).GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
            //    .Where(t => t.GetCustomAttributes(typeof(HarmonyPatch), false).Any()).ToList();
            
            Patch.OnPatch();
            MyLog.Message($"ED");
        }
    }
}
