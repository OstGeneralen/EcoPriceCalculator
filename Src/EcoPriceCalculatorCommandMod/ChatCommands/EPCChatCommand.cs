using System;
using Eco.Gameplay.Players;
using EPC.CommandMod.EcoWrapper;
using EPC.CommandMod.Notification;
using EPC.Core;

namespace EPC.CommandMod.ChatCommands
{
    /// <summary>
    /// Base type for all chat commands.
    /// </summary>
    internal abstract class EPCChatCommand
    {
        public void Invoke(User user)
        {
            if (_dbInstance == null)
            {
                _dbInstance = new Database(EcoTypeConverter.ConvertItems(), EcoTypeConverter.ConvertRecipes(), EcoTypeConverter.ConvertStores());
            }
            _dbInstance.RefreshStores(EcoTypeConverter.ConvertStores());

            var msgSender = new NotificationSender();
            var startMsg = new NotificationMessage().Write("Starting EPC command");

            msgSender.SendMessage(startMsg, user);

            using (var c = new CmdContext(user, msgSender, _dbInstance))
            {
                try
                {
                    Implementation(c);

                    var message = ResultMessage();
                    if (message != null)
                    {
                        c.MessageSender.SendMessage(message, user);
                    }
                }
                catch (Exception e)
                {
                    msgSender.SendError(e.Message);
                }
            }
        }

        protected abstract void Implementation(CmdContext context);
        protected virtual NotificationMessage? ResultMessage() => null;

        private static Database _dbInstance;
    }
}
