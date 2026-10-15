using CrynanoLib.Contracts.Perks;
using CrynanoLib.Implementation;
using HarmonyLib;
using MGSC;

namespace CrynanoLib.Patches
{
    [HarmonyPatch(typeof(ItemTooltipBuilder), nameof(ItemTooltipBuilder.InitImplant))]
    public static class ItemTooltipBuilder_InitImplant_NowConsidersPassives
    {
        static void Postfix(ImplantRecord record, Mercenary mercenary, ItemTooltipBuilder __instance)
        {
            var _factory = __instance._factory;
            if (AbilityRegister.GetEffect(record.Id) is IPassivePerk effect)
            {
                Logger.LogDebug($"{nameof(ItemTooltipBuilder_InitImplant_NowConsidersPassives)}: Building passive ability for implant: " + record.Id);
                PerkRecord record2 = Data.Perks.GetRecord(record.Id);
                if (record2 != null)
                {
                    Logger.LogDebug($"{nameof(ItemTooltipBuilder_InitImplant_NowConsidersPassives)}: Building passive ability tooltip for implant: " + record.Id);
                    _factory
                        .AddPanelToTooltip()
                        .SetIcon("common_implant_sockets")
                        .SetMultilineName(FormatHelper.ReplaceLocalizationTokens(Localization.Get(effect.GetPassivePerkDescriptionLocalizationKey()), record2.Parameters))
                        .SetNameColor(Colors.White);
                }
            }
            else
            {
                Logger.LogDebug($"{nameof(ItemTooltipBuilder_InitImplant_NowConsidersPassives)}: No passive ability found for implant: " + record.Id);
            }
        }
    }
}