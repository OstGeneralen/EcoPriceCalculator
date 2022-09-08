using EPC.CommandMod.ChatCommands.CommandArguments;
using EPC.CommandMod.EcoWrapper.Types;
using EPC.CommandMod.Notification;
using EPC.CommandMod.Util;
using System.Collections.Generic;
using System.Linq;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListCraftIngredientsCommand : EPCChatCommand
    {
        public ListCraftIngredientsCommand(RecipeName recipe)
        {
            _recipeName = recipe;
        }

        protected override void Implementation(CmdContext context)
        {
            var recipe = _recipeName.Recipe;
            var tableTypeName = recipe.TableName;

            var userOwnedTablesOfType = context.UserHandle.AllOwnedCraftTables().Where(t => t.StationTypeName == tableTypeName);

            foreach (var t in userOwnedTablesOfType)
            {
                var trq = new TableRecipeSummary();
                trq.TableName = t.StationInstanceName;

                foreach (var i in recipe.Ingredients)
                {
                    var ingredient = i as CraftIngredient;
                    var trsIngredient = new TableRecipeSummary.TRSIngredient();

                    if (ingredient.IsTag)
                    {
                        trsIngredient.IsTag = true;
                        trsIngredient.IngredientName = ingredient.Tag;
                    }
                    else
                    {
                        trsIngredient.IsTag = false;
                        trsIngredient.IngredientName = ingredient.IngredientItem.ReadableName;
                    }

                    trsIngredient.Quantity = ingredient.QuantityRequiredAtTable(t);

                    trq.Ingredients.Add(trsIngredient);
                }
                
                _tableRecipes.Add(trq);
            }
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();

            msg.Write("Recipe Ingredients Required for '").Item(_recipeName).Write("':").NewLine();

            foreach (var trs in _tableRecipes)
            {
                msg.Write("At craft station '").Location(trs.TableName).Write("': ").NewLine();

                foreach (var trsi in trs.Ingredients)
                {
                    msg.Write($"  {trsi.Quantity}x ").Item(trsi.IngredientName);

                    if (trsi.IsTag)
                    {
                        msg.Info(" (Tag)");
                    }
                    else
                    {
                        msg.Info(" (Item)");
                    }

                    msg.NewLine();
                }
            }
            return msg;
        }

        private List<TableRecipeSummary> _tableRecipes = new List<TableRecipeSummary>();
        private RecipeName _recipeName;

        private class TableRecipeSummary
        {
            public class TRSIngredient
            {
                public string IngredientName { get; set; }
                public bool IsTag { get; set; }
                public float Quantity { get; set; }
            }

            public string TableName { get; set; }
            public List<TRSIngredient> Ingredients = new List<TRSIngredient>();
        }
    }
}
