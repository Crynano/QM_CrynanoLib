using CrynanoLib.Extensions;
using MGSC;

namespace CrynanoLib.Contracts.Perks
{
    public abstract class BasePerk
    {
        public PropertiesTooltip GetBaseCustomTooltip(BaseEffect effect, bool wide = false, bool red = false)
        {
            var builderInstance = SingletonMonoBehaviour<TooltipFactory>.Instance;
            return builderInstance.BuildEmptyTooltip(wide, red);
        }
    }
}