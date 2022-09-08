using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using EPC.CommandMod.EcoWrapper.Types;
using EPC.Core.Item;
using EPC.Core.Recipe;
using EPC.Core.Store;
using System.Collections.Generic;

namespace EPC.CommandMod.EcoWrapper
{
    public class EcoTypeConverter
    {
        public static IEnumerable<IPlayerStore> ConvertStores()
        {
            var allEcoStores = WorldObjectUtil.AllObjsWithComponent<StoreComponent>();
            var convertedStores = new List<IPlayerStore>();

            foreach(var es in allEcoStores)
            {
                convertedStores.Add(new PlayerStore(es));
            }

            return convertedStores;
        }

        public static IEnumerable<ICraftRecipe> ConvertRecipes()
        {
            var allEcoRecipes = RecipeFamily.AllRecipes;
            var convertedRecipes = new List<ICraftRecipe>();

            foreach(var er in allEcoRecipes)
            {
                convertedRecipes.Add(new CraftRecipe(er));
            }

            return convertedRecipes;
        }

        public static IEnumerable<IGameItem> ConvertItems()
        {
            var allEcoItems = Item.AllItems;
            var convertedItems = new List<IGameItem>();

            foreach(var ei in allEcoItems)
            {
                convertedItems.Add(new GameItem(ei));
            }

            return convertedItems;
        }
    }
}