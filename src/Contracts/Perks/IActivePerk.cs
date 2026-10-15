using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public interface IActivePerk
    {
        bool ActivateAbility(Creature creature, Perk ability, CellPosition targetCell);
    }
}
