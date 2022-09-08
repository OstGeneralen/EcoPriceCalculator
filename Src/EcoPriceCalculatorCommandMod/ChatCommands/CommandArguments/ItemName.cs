using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPC.Core;
using EPC.Core.Item;

namespace EPC.CommandMod.ChatCommands.CommandArguments
{
    internal class ItemName
    {
        public ItemName(string s)
        {
            _str = new CleanString(s);
        }

        public IGameItem Item { get => CmdContext.Current.Database.NameToItem(_str); }

        public static implicit operator ItemName(string s) => new ItemName(s);
        public static implicit operator string(ItemName i) => i._str; 

        public string AsString() => _str;

        private string _str;
    }
}
