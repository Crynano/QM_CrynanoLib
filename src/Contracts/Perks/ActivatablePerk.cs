using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class ActivatablePerk : BasePerk, IActivePerk
    {
        public virtual bool ActivateAbility(Creature creature, Perk ability, CellPosition targetCell)
        {
            var perkId = ability.PerkId;
            var cooldownValue = ActiveAbilitySystem.GetCooldownValue(creature.CreatureData, ability.Get("ICooldown").IntVal);
            creature.CreatureData.EffectsController.Add(new AbilityCooldown(cooldownValue, perkId), merge: false);
            return true;
        }

        public virtual void BuildActivatableAbilityButton(TooltipFactory tooltipFactory, PerkRecord perkRecord, Mercenary mercenary, PerkTooltipMode perkTooltipMode, int currentExp)
        {
            ParseHelper.GetGradeByPerkId(perkRecord.Id, out var level, out var perkTag, out var grade);
            var propertiesTooltip = tooltipFactory.BuildEmptyTooltip(wide: true);

            propertiesTooltip.SetCaption1(Localization.Get("perk." + perkTag + ".name"), tooltipFactory._captionFirstLetterColor);
            propertiesTooltip.SetCaption1(Localization.Get("perk." + perkTag + ".name"), tooltipFactory._captionFirstLetterColor);
            propertiesTooltip.SetCaption2(Localization.Get($"perk.type_{perkRecord.PerkType}"));

            var simpleRecord = Data.Items.GetSimpleRecord<ImplantRecord>(perkRecord.Id);

            int intVal = perkRecord.Get("ICooldown").IntVal;
            if (simpleRecord.HasCharges && mercenary != null)
            {
                tooltipFactory.AddPanelToTooltip().SetIcon("common_battery").LocalizeName("tooltip.Charges").SetValue($"{ActiveAbilitySystem.GetCurrentChargesById(mercenary.CreatureData, simpleRecord.Id)}/{simpleRecord.Charges}");
            }

            tooltipFactory.AddPanelToTooltip().SetIcon("common_time").LocalizeName("tooltip.Restoration").SetValue(string.Format("{0} {1}", intVal, Localization.Get("ui.label.turns")));
            tooltipFactory.AddPanelToTooltip().SetMultilineName(FormatHelper.GetPerkDesc(perkRecord.Id)).SetNameColor(Colors.DarkYellow);
        }
    }
}