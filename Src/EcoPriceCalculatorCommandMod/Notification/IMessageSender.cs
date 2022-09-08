using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.CommandMod.Notification
{
    internal interface IMessageSender
    {
        /// <summary>
        /// Send a message as a notification.
        /// </summary>
        /// <param name="formattedMessage">The message to send (in ECO formatting)</param>
        /// <param name="toUser">The user to send to, if null it will be sent to the context user</param>
        void SendMessage(NotificationMessage formattedMessage, User toUser = null);

        /// <summary>
        /// Send an error message
        /// </summary>
        /// <param name="errorMessage">The message in the error (without the "EPC Error" as this will be added by this</param>
        void SendError(string errorMessage);
    }
}
