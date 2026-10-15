using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public interface IPassivePerk
    {
        string GetPassivePerkDescriptionLocalizationKey();
        void OnImplantEquipped(Creature creature);
        void OnImplantUnequipped(Creature creature);
    }
}