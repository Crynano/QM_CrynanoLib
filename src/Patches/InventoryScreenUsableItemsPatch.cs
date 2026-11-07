using HarmonyLib;
using MGSC;

namespace CrynanoLib.Patches
{
    [HarmonyPatch(typeof(InventoryScreen), nameof(InventoryScreen.DragControllerShowContextMenuCallback))]
    public static class InventoryScreenUsableItemsPatch
    {
        [HarmonyPostfix]
        static void Postfix(ItemSlot obj)
        {
            var item = obj.Item;
            if (item.Is<UsableItemRecord>())
            {
                // Da fuq you mean usable items are not usable?
                SetupCommand(ContextMenuCommand.Use);
            }
        }

        private static void SetupCommand(ContextMenuCommand command)
        {
            var contextMenu = UI.Get<CommonContextMenu>();
            contextMenu.SetupCommand(Localization.Get("ui.context." + command), (int)command);
        }
    }
}