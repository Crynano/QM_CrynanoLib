using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class PassivePerk : BasePerk, IPassivePerk
    {
        protected PassivePerk(PerkRecord perkRecord) : base(perkRecord)
        {
        }

        public abstract string GetPassivePerkDescriptionLocalizationKey();
        public abstract void OnImplantEquipped(Creature creature);
        public abstract void OnImplantUnequipped(Creature creature);
    }
}
