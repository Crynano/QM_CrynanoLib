using CrynanoLib.Contracts.Perks;
using CrynanoLib.Implementation;
using HarmonyLib;
using MGSC;

namespace CrynanoLib.Patches
{
    [HarmonyPatch(typeof(TooltipFactory), nameof(TooltipFactory.BuildPerkTooltip),
        new System.Type[] { typeof(PerkRecord), typeof(Mercenary), typeof(PerkTooltipMode), typeof(int), typeof(bool) })]
    public static class TooltipFactory_BuildPerkTooltip_Patch
    {
        public static bool Prefix(PerkRecord perkRecord, Mercenary mercenary, PerkTooltipMode perkTooltipMode, int currentExp, bool activeImplantDamaged, TooltipFactory __instance)
        {
            var perkUIBuilder = AbilityRegister.GetEffect(perkRecord.Id);

            Logger.LogDebug("TooltipFactory_AddActiveAbilityDesc_Patch: Found perk UI builder for perk: " + perkRecord.Id);
            if (perkUIBuilder is ActivatablePerk activatableAbility)
            {
                Logger.LogDebug("Building activatable ability button for perk: " + perkRecord.Id);
                activatableAbility.BuildActivatableAbilityButton(__instance, perkRecord, mercenary, perkTooltipMode, currentExp);
                return false;
            }

            return true;
        }
    }

    //[HarmonyPatch(typeof(TooltipFactory), nameof(TooltipFactory.BuildWoundTooltip))]
    //public static class TooltipFactory_BuildWoundTooltip_Patch
    //{
    //    public static void Postfix(string woundSlotId, List<BodyPartWound> wounds, List<ImplicitAugEffect> implicitAugEffects, EffectsController effectsController, int maxSockets, ImplantSocketData socketData, TooltipFactory __instance)
    //    {
    //        if (installedImplants.Count == 0) return;
    //        __instance.StartItemIconsBlock(0);
    //        foreach (var implant in installedImplants)
    //        {
    //            __instance.AddPanelToTooltip()
    //                .SetIcon("common_implant_sockets")
    //                .LocalizeName($"item.{implant}.name")
    //                .SetNameColor(Colors.White);
    //        }
    //        __instance.StartItemIconsBlock(1);
    //    }
    //}
}
