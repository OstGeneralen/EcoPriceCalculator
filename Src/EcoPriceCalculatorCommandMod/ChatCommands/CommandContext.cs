using System;
using Eco.Gameplay.Players;
using EPC.CommandMod.Notification;
using EPC.Core;

namespace EPC.CommandMod.ChatCommands
{
    /// <summary>
    /// Context with common data that commands may require
    /// </summary>
    internal class CmdContext : IDisposable
    {
        public static CmdContext Current { get; private set; }
        public User UserHandle { get; }
        public IMessageSender MessageSender { get; }
        public Database Database { get; }

        public CmdContext(User userHandle, IMessageSender messageSender, Database db)
        {
            UserHandle = userHandle;
            Current = this;
            MessageSender = messageSender;
            Database = db;
        }

        public void Dispose()
        {
            Current = null;
        }
    }
}
