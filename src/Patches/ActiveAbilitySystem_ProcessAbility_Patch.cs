using CrynanoLib.Contracts.Perks;
using CrynanoLib.Implementation;
using HarmonyLib;
using MGSC;

namespace CrynanoLib.Patches
{
    [HarmonyPatch(typeof(ActiveAbilitySystem), nameof(ActiveAbilitySystem.ProcessAbility))]
    public static class ActiveAbilitySystem_ProcessAbility_Patch
    {
        public static bool Prefix(
            Creature creature, 
            Perk ability, 
            CellPosition targetCellPos, 
            MapGrid mapGrid, 
            MapRenderer mapRenderer, 
            TurnController turnController, 
            MapController mapController, 
            MapObstacles mapObstacles, 
            MapEntities mapEntities, 
            Creatures creatures, 
            ItemsOnFloor itemsOnFloor, 
            FireController fireController, 
            Visibilities visibilities, 
            Entities entities, 
            RaidMetadata raidMetadata, 
            MagnumProgression magnumProgression, 
            CombatLog combatLog, Difficulty difficulty, PerkFactory perkFactory, Mercenaries mercenaries,
            bool __result)
        {
            var abilityId = ability.PerkId;
            var effect = AbilityRegister.GetEffect(abilityId);
            __result = false;
            if(effect is ActivatablePerk activatableAbility)
            {
                Logger.LogDebug($"{nameof(ActiveAbilitySystem_ProcessAbility_Patch)}: Processing activatable ability for perk: " + abilityId);
                __result = activatableAbility.ActivateAbility(creature, ability, targetCellPos);
                return false;
            }
            return true;
        }
    }
}
