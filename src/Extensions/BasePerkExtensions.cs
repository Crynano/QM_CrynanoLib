using CrynanoLib.Contracts.Perks;
using MGSC;

namespace CrynanoLib.Extensions
{
    public static class BasePerkExtensions
    {
        public static string GetPerkName(this BasePerk perk)
        {
            return Localization.Get("perk." + perk.Perk.Id + ".name");
        }

        public static string GetPerkDescription(this BasePerk perk)
        {
            return Localization.Get("perk." + perk.Perk.Id + ".desc");
        }
    }
}
