using MGSC;

namespace CrynanoLib.Helpers
{
    internal static class TooltipHelper
    {
        public static PropertiesTooltip BuildTooltip(BaseEffect effect, bool wide = false, bool red = false)
        {
            var builderInstance = SingletonMonoBehaviour<TooltipFactory>.Instance;
            var tooltip = builderInstance.BuildEmptyTooltip(wide, red);

            var effectName = effect.GetType().Name;
            tooltip.SetCaption1(Localization.Get($"ui.effect.{effectName}.title"), Colors.Green);
            tooltip.SetCaption2(Localization.Get($"ui.effect.{effectName}.caption"));

            return tooltip;
        }
    }
}
