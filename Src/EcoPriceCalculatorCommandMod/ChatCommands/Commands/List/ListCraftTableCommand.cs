using Eco.Gameplay.Components;
using EPC.CommandMod.Notification;
using EPC.CommandMod.Util;
using EPC.Core.Recipe;
using System.Collections.Generic;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListCraftTableCommand : EPCChatCommand
    {
        protected override void Implementation(CmdContext context)
        {
            _userTables = context.UserHandle.AllOwnedCraftTables();
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();
            msg.Write("Craft tables owned: ").NewLine();

            foreach(var t in _userTables)
            {
                msg.Write(" - ").Location(t.StationInstanceName).Write(" (").Item(t.StationTypeName).Write(")").NewLine();
            }

            return msg;
        }

        private IEnumerable<ICraftStation>? _userTables;
    }
}
