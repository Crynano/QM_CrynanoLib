using CrynanoLib.Contracts.Perks;
using CrynanoLib.Implementation;
using HarmonyLib;
using MGSC;
using System.Linq;
using System.Reflection;

namespace CrynanoLib
{
    public static class CrynanoLibMain
    {
        internal static Harmony HarmonyInstance { get; private set; }

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfigsLoaded(IModContext context)
        {
            ApplyPatches();
        }

        [Hook(ModHookType.AfterDungeonLoaded)]
        public static void AfterDungeonLoaded(IModContext context)
        {
            ApplyPassiveAbilitiesToPlayer(context);
        }
        
        private static void ApplyPatches()
        {
            Logger.LogDebug($"Applying Harmony patches for {Assembly.GetExecutingAssembly().GetName().Name}");
            var modAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            HarmonyInstance = new Harmony("Crynano_" + modAssemblyName);
            HarmonyInstance.PatchAll();
        }

        private static void ApplyPassiveAbilitiesToPlayer(IModContext context)
        {
            var player = context.State.Get<DungeonGameMode>().Creatures.Player;

            if (AugmentationSystem.HasAnyInstalledImplants(player.CreatureData))
            {
                ActivatePassiveAbilities(player);
            }
        }

        private static void ActivatePassiveAbilities(Player player)
        {
            var implants = player.CreatureData.WoundSlotMap
                .SelectMany(kvp => kvp.Value.InstalledImplantsData)
                .Select(implantData => implantData.ImplantId);

            foreach (var implantId in implants)
            {
                var foundEffect = AbilityRegister.GetEffect(implantId);
                if (foundEffect is IPassivePerk passiveAbility)
                {
                    passiveAbility.OnImplantEquipped(player);
                }
            }
        }
    }
}