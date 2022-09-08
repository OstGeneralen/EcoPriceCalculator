using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using EPC.CommandMod.EcoWrapper.Types;
using EPC.Core.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.CommandMod.Util
{
    internal static class UserExtensions
    {
        public static IEnumerable<ICraftStation> AllOwnedCraftTables(this User u)
        {
            var ownedTables = WorldObjectUtil.AllObjsWithComponent<CraftingComponent>().Where(c => c.Owners != null && c.Owners.ContainsUser(u));
            var csList = new List<ICraftStation>();

            foreach(var t in ownedTables)
            {
                csList.Add(new CraftStation(t));
            }

            return csList;
        }
    }
}
