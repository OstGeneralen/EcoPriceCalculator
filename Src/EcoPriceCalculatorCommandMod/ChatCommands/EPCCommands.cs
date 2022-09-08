using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using EPC.CommandMod.ChatCommands.Commands;

namespace EPC.CommandMod.ChatCommands
{
    [ChatCommandHandler]
    public static class EPCCommands
    {

        [ChatCommand("", ChatAuthorizationLevel.User)]
        public static void EPC()
        {
        }

        /// <summary>
        /// Calculate the price for the given item & recipe. Will always use the lowest cost for purchases and best worktable (module wise) when produced.
        /// </summary>
        /// <param name="user">The user calling this command</param>
        /// <param name="item">The recipe name to use</param>
        /// <param name="recipe">The item name to use</param>
        [ChatSubCommand("EPC", "Calculate the price for the given item using the given recipe.", "CalcPrice", ChatAuthorizationLevel.User)]
        public static void CalculatePrice(User user, string item, string recipe) => new CalculatePriceCommand(item, recipe).Invoke(user);

        /// <summary>
        /// Lists all recipes for the given item
        /// </summary>
        /// <param name="user">The user calling this command</param>
        /// <param name="item">The name of the item</param>
        [ChatSubCommand("EPC", "Get all recipes available to the caller for the provided item", "ListRecipes", ChatAuthorizationLevel.User)]
        public static void ListItemRecipes(User user, string item) => new ListItemRecipesCommand(item).Invoke(user);

        /// <summary>
        /// Lists all stores available in the world.
        /// </summary>
        /// <param name="user">Calling user</param>

        [ChatSubCommand("EPC", "List all stores that are known to EPC", "ListStores", ChatAuthorizationLevel.User)]
        public static void ListStores(User user) => new ListStoresCommand().Invoke(user);

        /// <summary>
        /// Lists all stores selling the item or tag with their prices for it.
        /// </summary>
        /// <param name="user">Calling user</param>
        /// <param name="itemOrTag">The item or tag to look for</param>
        [ChatSubCommand("EPC", "List all stores selling the item/tag and their price", "ListSales", ChatAuthorizationLevel.User)]
        public static void ListPrices(User user, string itemOrTag) => new ListPricesCommand(itemOrTag).Invoke(user);

        /// <summary>
        /// List the ingredients required to craft using this recipe, will list the ingredients per available work station to the user
        /// </summary>
        /// <param name="user">Calling user</param>
        /// <param name="recipe">Recipe name</param>
        [ChatSubCommand("EPC", "List the ingredients in the given recipe", "Ingredients", ChatAuthorizationLevel.User)]
        public static void ListCraftIngredients(User user, string recipe) => new ListCraftIngredientsCommand(recipe).Invoke(user);

        /// <summary>
        /// List all craft tables that the user is owning
        /// </summary>
        /// <param name="user">Calling user</param>
        [ChatSubCommand("EPC", "List all owned crafting tables by the calling user", "CraftStations", ChatAuthorizationLevel.User)]
        public static void ListCraftTables(User user) => new ListCraftTableCommand().Invoke(user);
    }
}
