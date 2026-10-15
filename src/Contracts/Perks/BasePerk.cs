using CrynanoLib.Extensions;
using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class BasePerk
    {
        public PerkRecord Perk { get; private set; }


        protected BasePerk(PerkRecord perkRecord)
        {
            this.Perk = perkRecord;
        }

        public virtual string GetPerkDescriptionWithParametersReplaced()
        {
            return FormatHelper.ReplaceLocalizationTokens(this.GetPerkDescription(), Perk.Parameters);
        }

        public PropertiesTooltip GetBaseCustomTooltip(BaseEffect effect, bool wide = false, bool red = false)
        {
            var builderInstance = SingletonMonoBehaviour<TooltipFactory>.Instance;
            return builderInstance.BuildEmptyTooltip(wide, red);
        }
    }
}