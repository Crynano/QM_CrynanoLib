using MGSC;

namespace CrynanoLib.Contracts.CustomEffectView
{
    public interface ICustomEffectView
    {
        CommonEffectPanel GetEffectViewPerkPanel(BaseEffect effect, IEffectWithView effectWithView, Creatures creatures);
        PropertiesTooltip GetEffectViewTooltip(BaseEffect effect, bool wide = false, bool red = false);
    }
}
