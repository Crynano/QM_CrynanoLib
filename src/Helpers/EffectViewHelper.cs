using MGSC;
using UnityEngine;

namespace CrynanoLib.Helpers
{
    public static class EffectViewHelper
    {
        public static CommonEffectPanel BuildBaseCustomPanel(IEffectWithView effectWithView, Creatures creatures, Sprite sprite = null)
        {
            var effectsPanel = UI.Get<DungeonHudScreen>()._effects;
            var panel = effectsPanel.GetPanel();
            panel.Initialize(creatures, effectWithView, sprite ?? GetDefaultSprite());
            return panel;
        }

        public static Sprite GetDefaultSprite()
        {
            return Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), Vector2.zero, 100f);
        }
    }
}
