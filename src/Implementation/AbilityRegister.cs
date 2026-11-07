using CrynanoLib.Contracts.Perks;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace CrynanoLib.Implementation
{
    internal static class AbilityRegister
    {
        private static Dictionary<string, BasePerk> RegisteredAbilities { get; set; } = new Dictionary<string, BasePerk>();

        public static void RegisterAbility(string effectId, BasePerk effect)
        {
            if (string.IsNullOrEmpty(effectId)) return;
            if (RegisteredAbilities.ContainsKey(effectId))
            {
                Logger.LogError($"Effect with key {effectId} is already registered.");
            }
            else
            {
                RegisteredAbilities.Add(effectId, effect);
            }
        }

        [CanBeNull]
        internal static BasePerk GetEffect(string effectId)
        {
            return RegisteredAbilities.TryGetValue(effectId, out var effect) ? effect : null;
        }
    }
}