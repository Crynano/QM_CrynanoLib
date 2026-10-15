using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class ActivatablePerk : BasePerk, IActivePerk
    {
        protected ActivatablePerk(PerkRecord perkRecord) : base(perkRecord)
        {

        }

        public virtual bool ActivateAbility(Creature creature, Perk ability, CellPosition targetCell)
        {
            var perkId = ability.PerkId;
            var cooldownValue = ActiveAbilitySystem.GetCooldownValue(creature.CreatureData, ability.Get("ICooldown").IntVal);
            creature.CreatureData.EffectsController.Add(new AbilityCooldown(cooldownValue, perkId), merge: false);
            return true;
        }
    }
}