using System;
using System.Collections.Generic;
using System.Linq;
using EPC.Core.Exceptions;
using EPC.Core.Item;
using EPC.Core.Recipe;
using EPC.Core.Store;

namespace EPC.Core
{
    public class Database
    {
        public IEnumerable<IPlayerStore> AllStores { get; private set; }
        public IEnumerable<IGameItem> AllItems { get; }
        public IEnumerable<ICraftRecipe> AllRecipes { get; }

        public Database(IEnumerable<IGameItem> items, IEnumerable<ICraftRecipe> recipes, IEnumerable<IPlayerStore> stores)
        {
            AllItems = items;
            AllRecipes = recipes;
            RefreshStores(stores);
        }

        public void RefreshStores(IEnumerable<IPlayerStore> stores)
        {
            AllStores = stores;
        }

        public IGameItem NameToItem(string name)
        {
            var matchingNames = AllItems.Where(i => i.ReadableName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (matchingNames.Count() == 0)
            {
                throw new ItemNotFoundException(name);
            }

            return matchingNames.First();
        }

        public ICraftRecipe NameToRecipe(string name)
        {
            var matchingNames = AllRecipes.Where(r => r.ReadableName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (matchingNames.Count() == 0)
            {
                throw new RecipeNotFoundException(name);
            }

            return matchingNames.First();
        }

        public IEnumerable<ICraftRecipe> GetRecipesForItem(IGameItem item)
        {
            return AllRecipes.Where(r => r.Outputs.Any(o => o.CraftedItem.ID == item.ID));
        }
    }
}
