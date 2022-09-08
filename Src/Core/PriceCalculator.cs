using EPC.Core.Item;
using EPC.Core.Recipe;
using EPC.Core.Store;
using EPC.Core.Utility;
using System.Collections.Generic;

namespace Core
{
    public class PriceCalculator
    {
        public static float CalculatePriceFor(IGameItem item, ICraftRecipe recipe, ICraftStation craftingTable, IEnumerable<IPlayerStore> stores )
        {
            return IngredientsCost(recipe, craftingTable, stores) / recipe.ItemOutput(item).Quantity;
        }

        private static float IngredientsCost(ICraftRecipe recipe, ICraftStation craftingTable, IEnumerable<IPlayerStore> stores)
        {
            var ingredientsCost = 0.0f;

            foreach(var ingredient in recipe.Ingredients)
            {
                var ingredientPrice = LowestPriceForIngredient(ingredient, stores) * ingredient.QuantityRequiredAtTable(craftingTable);
                ingredientsCost += ingredientPrice;
            }

            return ingredientsCost;
        }

        private static float LowestPriceForIngredient(ICraftIngredient ingredient, IEnumerable<IPlayerStore> stores)
        {
            float lowestPrice = 0.0f;

            if(ingredient.IsTag)
            {
                lowestPrice = stores.LowestPriceSaleForTag(ingredient.Tag).Price;
            }
            else
            {
                lowestPrice = stores.LowestPriceSaleForItem(ingredient.IngredientItem).Price;
            }

            return lowestPrice;
        }
    }
}
