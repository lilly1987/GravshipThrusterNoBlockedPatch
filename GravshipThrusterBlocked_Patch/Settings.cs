using Verse;

namespace Lilly.GravshipThrusterNoBlocked
{
    public class Settings : ModSettings
    {
        public static bool onDebug=true;
        public static bool onPatch=true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref onDebug, "onDebug", false);
            Scribe_Values.Look(ref onPatch, "onPatch", true);
        }
    }
}