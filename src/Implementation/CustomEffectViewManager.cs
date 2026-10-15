using CrynanoLib.Contracts.CustomEffectView;
using CrynanoLib.Contracts.Perks;
using JetBrains.Annotations;
using MGSC;
using System.Collections.Generic;

namespace CrynanoLib.Implementation
{
    internal static class CustomEffectViewManager
    {
        private static Dictionary<string, ICustomEffectView> RegisteredAbilities { get; set; } = new Dictionary<string, ICustomEffectView>();
        public static void RegisterAbility(string effectId, ICustomEffectView effect)
        {
            if (string.IsNullOrEmpty(effectId)) return;
            if (RegisteredAbilities.ContainsKey(effectId))
            {
                Logger.LogError($"Effect with key {effectId} is already registered.");
            }
            else
            {
                Logger.LogDebug($"Registering effect with key {effectId}.");
                RegisteredAbilities.Add(effectId, effect);
            }
        }

        [CanBeNull]
        internal static ICustomEffectView GetEffect(string effectId)
        {
            return RegisteredAbilities.TryGetValue(effectId, out var effect) ? effect : null;
        }


        [CanBeNull]
        internal static CommonEffectPanel GetEffectViewPerkPanel(BaseEffect baseEffect, IEffectWithView effectWithView, Creatures creatures)
        {
            Logger.LogDebug($"Getting custom panel for {baseEffect.GetType().Name}.");
            return GetPerkWithView(baseEffect.GetType().Name)?.GetEffectViewPerkPanel(baseEffect, effectWithView, creatures);
        }


        [CanBeNull]
        internal static PropertiesTooltip GetEffectViewTooltip(BaseEffect baseEffect)
        {
            return GetPerkWithView(baseEffect.GetType().Name)?.GetEffectViewTooltip(baseEffect);
        }

        [CanBeNull]
        private static ICustomEffectView GetPerkWithView(string effectId)
        {
            var effect = GetEffect(effectId);
            if (effect is ICustomEffectView perkWithView)
            {
                Logger.LogDebug($"Found custom panel for {effectId}.");
                return perkWithView;
            }
            Logger.LogDebug($"No custom panel found for {effectId}.");
            return null;
        }
    }
}
