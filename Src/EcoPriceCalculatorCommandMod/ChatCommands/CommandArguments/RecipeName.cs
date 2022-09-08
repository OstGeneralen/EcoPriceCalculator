using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPC.Core;
using EPC.Core.Recipe;

namespace EPC.CommandMod.ChatCommands.CommandArguments
{
    internal class RecipeName
    {
        public RecipeName(string s)
        {
            _str = new CleanString(s);

            if (!_str.EndsWith("recipe", StringComparison.OrdinalIgnoreCase))
            {
                _str += " recipe";
            }
        }

        public ICraftRecipe Recipe { get => CmdContext.Current.Database.NameToRecipe(_str); }

        public static implicit operator RecipeName(string s) => new RecipeName(s);
        public static implicit operator string(RecipeName rn) => rn._str;

        private string _str;
    }
}
