using CrynanoLib.Contracts.CustomEffectView;
using CrynanoLib.Contracts.Perks;
using CrynanoLib.Helpers;
using CrynanoLib.Implementation;
using MGSC;

namespace CrynanoLib
{
    public static class Api
    {
        public static void RegisterAbility(string effectId, BasePerk effect)
        {
            AbilityRegister.RegisterAbility(effectId, effect);
        }

        public static void RegisterCustomEffectView(string effectId, ICustomEffectView effect)
        {
            CustomEffectViewManager.RegisterAbility(effectId, effect);
        }

        public static CommonEffectPanel BuildBaseCustomPanel(IEffectWithView effectWithView, Creatures creatures, UnityEngine.Sprite sprite = null)
        {
            return EffectViewHelper.BuildBaseCustomPanel(effectWithView, creatures, sprite);
        }

        public static PropertiesTooltip BuildTooltip(BaseEffect effect, bool wide, bool red)
        {
            return TooltipHelper.BuildTooltip(effect, wide, red);
        }
    }
}