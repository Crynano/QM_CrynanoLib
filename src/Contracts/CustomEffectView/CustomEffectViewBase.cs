using CrynanoLib.Helpers;
using MGSC;
using UnityEngine;

namespace CrynanoLib.Contracts.CustomEffectView
{
    public abstract class CustomEffectViewBase : ICustomEffectView
    {
        public virtual CommonEffectPanel GetEffectViewPerkPanel(BaseEffect effect, IEffectWithView effectWithView, Creatures creatures)
        {
            return GetBaseCustomPanel(effect, effectWithView, creatures);
        }

        protected CommonEffectPanel GetBaseCustomPanel(BaseEffect effect, IEffectWithView effectWithView, Creatures creatures)
        {
            return EffectViewHelper.BuildBaseCustomPanel(effectWithView, creatures, GetUISprite());
        }

        public virtual Sprite GetUISprite()
        {
            return EffectViewHelper.GetDefaultSprite();
        }

        public virtual PropertiesTooltip GetEffectViewTooltip(BaseEffect effect, bool wide = false, bool red = false)
        {
            return GetBaseCustomTooltip(effect, wide, red);
        }

        protected PropertiesTooltip GetBaseCustomTooltip(BaseEffect effect, bool wide = false, bool red = false)
        {
            return TooltipHelper.BuildTooltip(effect, wide, red);
        }
    }
}
