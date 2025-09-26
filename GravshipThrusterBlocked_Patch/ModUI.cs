using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Lilly.GravshipThrusterNoBlocked
{
    public class ModUI : Mod
    {
        public static ModUI instance;
        public static Settings settings;

        public ModUI(ModContentPack content) : base(content)
        {
            MyLog.Message($"ST");

            instance = this;
            settings = GetSettings<Settings>();// 주의. MainSettings의 patch가 먼저 실행됨    

            MyLog.Message($"ED");
        }

        Vector2 scrollPosition;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            var rect = new Rect(0, 0, inRect.width - 16, 1000);
            Widgets.BeginScrollView(inRect, ref scrollPosition, rect);
            Listing_Standard listing = new Listing_Standard();

            listing.Begin(rect);

            listing.CheckboxLabeled("onDebug", ref Settings.onDebug, ".");
            listing.CheckboxLabeled("onPatch", ref Settings.onPatch, ".");
            Patch.OnPatch();

            listing.End();
            Widgets.EndScrollView();

        }

        public override string SettingsCategory()
        {
            return "Gravship Thruster No Blocked".Translate();
        }
    }

    
    
}
