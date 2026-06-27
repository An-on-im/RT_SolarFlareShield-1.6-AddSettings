using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Verse;

namespace RT_SolarFlareShield
{
    public class Mod : Verse.Mod
    {
        private Settings settings;

        public Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
            var harmony = new Harmony("io.github.ratysz.rt_solarflareshield");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override string SettingsCategory()
        {
            return "RT_SolarFlareShield_ModName".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            // Idle power draw
            Rect idleRect = listing.GetRect(30f);
            Widgets.Label(idleRect, "RT_Setting_IdlePowerDraw".Translate() + ": " + settings.idlePowerDraw.ToString("F0") + " W");
            TooltipHandler.TipRegion(idleRect, "RT_Setting_IdlePowerDraw_Tooltip".Translate());
            settings.idlePowerDraw = listing.Slider(settings.idlePowerDraw, 0f, 500f);

            listing.Gap();

            // Active power draw
            Rect activeRect = listing.GetRect(30f);
            Widgets.Label(activeRect, "RT_Setting_ActivePowerDraw".Translate() + ": " + settings.activePowerDraw.ToString("F0") + " W");
            TooltipHandler.TipRegion(activeRect, "RT_Setting_ActivePowerDraw_Tooltip".Translate());
            settings.activePowerDraw = listing.Slider(settings.activePowerDraw, 0f, 100000f);

            listing.Gap();

            // Heat generation
            Rect heatRect = listing.GetRect(30f);
            Widgets.Label(heatRect, "RT_Setting_HeatPerTick".Translate() + ": " + settings.heatingPerTick.ToString("F2"));
            TooltipHandler.TipRegion(heatRect, "RT_Setting_HeatPerTick_Tooltip".Translate());
            settings.heatingPerTick = listing.Slider(settings.heatingPerTick, 0f, 5f);

            listing.Gap();

            // Rotator speed active
            Rect rotActiveRect = listing.GetRect(30f);
            Widgets.Label(rotActiveRect, "RT_Setting_RotatorSpeedActive".Translate() + ": " + settings.rotatorSpeedActive.ToString("F1"));
            TooltipHandler.TipRegion(rotActiveRect, "RT_Setting_RotatorSpeedActive_Tooltip".Translate());
            settings.rotatorSpeedActive = listing.Slider(settings.rotatorSpeedActive, 0f, 50f);

            listing.Gap();

            // Rotator speed idle
            Rect rotIdleRect = listing.GetRect(30f);
            Widgets.Label(rotIdleRect, "RT_Setting_RotatorSpeedIdle".Translate() + ": " + settings.rotatorSpeedIdle.ToString("F1"));
            TooltipHandler.TipRegion(rotIdleRect, "RT_Setting_RotatorSpeedIdle_Tooltip".Translate());
            settings.rotatorSpeedIdle = listing.Slider(settings.rotatorSpeedIdle, 0f, 5f);

            listing.Gap();

            if (listing.ButtonText("RT_ResetToDefaults".Translate()))
            {
                settings.ResetToDefaults();
            }

            listing.End();
            settings.Write();
        }
    }

    [StaticConstructorOnStartup]
    public static class Resources
    {
        public static Material rotatorTexture
            = MaterialPool.MatFrom("RT_Buildings/Building_RTMagneticShield_Top", ShaderDatabase.Cutout);
    }
}