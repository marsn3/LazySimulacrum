using BepInEx;
using UnityEngine;

namespace LazySimulacrum
{
    //This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class LazySimulacrum : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Marsn3";
        public const string PluginName = "LazySimulacrum";
        public const string PluginVersion = "1.0.0";

        //The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            //Init our logging class so that we can properly log for debugging
            Log.Init(Logger);
            
            // Hook Simulacrums Movement Phase
            On.RoR2.InfiniteTowerRun.MoveSafeWard += (orig, self) =>
            {

                Log.LogInfo("Skipping Movement Phase");
                // Get SimulacrumInstance for starting the next Wave
                self._waveController.ForceFinish();
                self.CleanUpCurrentWave();
                self.BeginNextWave();
            };

            Log.LogInfo(nameof(Awake) + " done.");
        }

    }
}
