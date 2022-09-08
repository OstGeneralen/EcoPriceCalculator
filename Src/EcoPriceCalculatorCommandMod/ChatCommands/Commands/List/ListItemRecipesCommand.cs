using EPC.CommandMod.ChatCommands.CommandArguments;
using EPC.CommandMod.Notification;
using EPC.Core.Recipe;
using System.Collections.Generic;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListItemRecipesCommand : EPCChatCommand
    {
        public ListItemRecipesCommand(ItemName itemName)
        {
            _itemName = itemName;
        }

        protected override void Implementation(CmdContext context)
        {
            var item = _itemName.Item;
            _recipesForItem = context.Database.GetRecipesForItem(item);
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();

            msg.Write("Recipes for ").Item(_itemName).Write(": ").NewLine();

            foreach (var rcp in _recipesForItem)
            {
                msg.Item(rcp.ReadableName).NewLine();
            }

            return msg;
        }

        private ItemName _itemName;
        private IEnumerable<ICraftRecipe> _recipesForItem;
    }
}
