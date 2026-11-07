using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class PassivePerk : BasePerk, IPassivePerk
    {
        public abstract string GetPassivePerkDescriptionLocalizationKey();
        public abstract void OnImplantEquipped(Creature creature);
        public abstract void OnImplantUnequipped(Creature creature);
    }
}
