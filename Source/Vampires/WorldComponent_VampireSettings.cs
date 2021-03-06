using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Vampire
{
    public class WorldComponent_VampireSettings : WorldComponent
    {
        public GameMode mode = GameMode.Disabled;
        public float spawnPct = 0.0f;
        public int lowestActiveVampGen = 7;
        public bool eventsEnabled = false;
        public float sunDimming = 0.0f;
        public bool settingsWindowSeen = false;

        public WorldComponent_VampireSettings(World world) : base(world)
        {
        }

        public void ApplySettings()
        {
            switch (mode)
            {
                case GameMode.Disabled:
                    spawnPct = 0.0f;
                    lowestActiveVampGen = 7;
                    eventsEnabled = false;
                    sunDimming = 0f;
                    break;
                case GameMode.EventsOnly:
                    spawnPct = 0.0f;
                    lowestActiveVampGen = 7;
                    eventsEnabled = true;
                    sunDimming = 0f;
                    break;
                case GameMode.Standard:
                    spawnPct = 0.05f;
                    lowestActiveVampGen = 7;
                    eventsEnabled = true;
                    sunDimming = 0.1f;
                    break;
                case GameMode.Custom:
                    break;
            }
            Log.Message("Vampire settings applied.");
            Messages.Message("Vampire settings applied.", null, MessageTypeDefOf.TaskCompletion);
            
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref mode, "mode");
            Scribe_Values.Look(ref spawnPct, "spawnPct", 0f);
            Scribe_Values.Look(ref lowestActiveVampGen, "lowestActiveVampGen", 7);
            Scribe_Values.Look(ref eventsEnabled, "eventsEnabled");
            Scribe_Values.Look(ref sunDimming, "sunDimming");
            Scribe_Values.Look(ref settingsWindowSeen, "settingsWindowSeen");
        }
    }
}