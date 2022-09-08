using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Notifications;
using Eco.Shared.Localization;
using Eco.Shared.Services;
using EPC.CommandMod.ChatCommands;

namespace EPC.CommandMod.Notification
{
    internal class NotificationSender : IMessageSender
    {
        public void SendMessage(NotificationMessage message, User toUser = null)
        {
            var user = toUser == null ? CmdContext.Current.UserHandle : toUser;
            NotificationManager.ServerMessageToPlayer(new LocString(message.GetSendText()), toUser, style: NotificationStyle.Chat);
        }

        public void SendError(string errorMessage)
        {
            NotificationManager.ServerMessageToPlayer(new LocString($"EPC Error: {errorMessage}"), CmdContext.Current.UserHandle, style: NotificationStyle.Error);
        }
    }
}
