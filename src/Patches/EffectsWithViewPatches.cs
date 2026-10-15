using CrynanoLib.Implementation;
using HarmonyLib;
using MGSC;
using System;

namespace CrynanoLib.Patches
{
    [HarmonyPatch(typeof(CommonEffectPanel), nameof(CommonEffectPanel.InitTooltip))]
    public static class Patch_CommonEffectPanel_InitTooltip
    {
        public static void Postfix(CommonEffectPanel __instance)
        {
            try
            {
                if (!__instance._createdTooltip)
                {
                    var buff = __instance._effectWithViews[0] as BaseEffect;
                    var uiBuilt = CustomEffectViewManager.GetEffectViewTooltip(buff);
                    if (uiBuilt != null)
                    {
                        __instance._createdTooltip = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in Patch_CommonEffectPanel_InitTooltip: " + ex);
            }
        }
    }

    [HarmonyPatch(typeof(EffectsView), nameof(EffectsView.CreatePanel))]
    public static class Patch_EffectsView_CreatePanel
    {
        public static bool Prefix(BaseEffect effect, IEffectWithView effectWithView, EffectsView __instance, ref object __result)
        {
            var ns = effect.GetType().Namespace;
            Logger.LogDebug($"Checking for custom panel for {effect.GetType().Name} in namespace {ns}.");
            if (ns != null && !ns.Equals("MGSC"))
            {
                Logger.LogDebug($"Buff found for {effect.GetType().Name}. Creating custom panel.");
                var panel = CustomEffectViewManager.GetEffectViewPerkPanel(effect, effectWithView, __instance._creatures);
                if (panel != null)
                {
                    Logger.LogDebug($"Custom panel for {effect.GetType().Name} built successfully.");
                    __result = panel;
                    return false;
                }
            }

            return true;
        }
    }

    
}