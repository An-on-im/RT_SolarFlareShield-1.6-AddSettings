using Verse;

namespace RT_SolarFlareShield
{
    public class Settings : ModSettings
    {
        public float idlePowerDraw = 50f;
        public float activePowerDraw = 25000f;
        public float heatingPerTick = 0.5f;
        public float rotatorSpeedActive = 20f;
        public float rotatorSpeedIdle = 0.5f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref idlePowerDraw, "idlePowerDraw", 50f);
            Scribe_Values.Look(ref activePowerDraw, "activePowerDraw", 25000f);
            Scribe_Values.Look(ref heatingPerTick, "heatingPerTick", 0.5f);
            Scribe_Values.Look(ref rotatorSpeedActive, "rotatorSpeedActive", 20f);
            Scribe_Values.Look(ref rotatorSpeedIdle, "rotatorSpeedIdle", 0.5f);
            base.ExposeData();
        }

        public void ResetToDefaults()
        {
            idlePowerDraw = 50f;
            activePowerDraw = 25000f;
            heatingPerTick = 0.5f;
            rotatorSpeedActive = 20f;
            rotatorSpeedIdle = 0.5f;
        }
    }
}