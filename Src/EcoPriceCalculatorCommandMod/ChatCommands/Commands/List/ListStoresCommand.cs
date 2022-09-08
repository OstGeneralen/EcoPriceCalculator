using EPC.CommandMod.Notification;
using EPC.Core.Store;
using System.Collections.Generic;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListStoresCommand : EPCChatCommand
    {
        protected override void Implementation(CmdContext context)
        {
            _stores = context.Database.AllStores;
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();

            msg.WriteLine("Shops in world:");

            foreach(var s in _stores)
            {
                msg.Write(" - ").Location(s.StoreName).NewLine();
            }

            return msg;
        }

        private IEnumerable<IPlayerStore> _stores;
    }
}
