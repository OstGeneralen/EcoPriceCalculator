using System.Collections.Generic;
using System.Linq;
using Core;
using EPC.CommandMod.ChatCommands.CommandArguments;
using EPC.CommandMod.Notification;
using EPC.CommandMod.Util;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class CalculatePriceCommand : EPCChatCommand
    {
        public CalculatePriceCommand(ItemName item, RecipeName recipe)
        {
            _itemName = item;
            _recipeName = recipe;
        }

        protected override void Implementation(CmdContext context)
        {
            var item = _itemName.Item;
            var recipe = _recipeName.Recipe;
            var allStores = context.Database.AllStores;

            var ownedTablesForRcp = context.UserHandle.AllOwnedCraftTables().Where(t => t.StationTypeName == recipe.TableName);

            foreach(var table in ownedTablesForRcp)
            {
                var priceAtTable = PriceCalculator.CalculatePriceFor(item, recipe, table, allStores);
                _estimates.Add(new PriceEstimateSummary(table.StationInstanceName, priceAtTable));
            }
        }

        protected override NotificationMessage? ResultMessage()
        {
            var message = new NotificationMessage();
            message.Write("Estimated price per ").Item(_itemName.AsString()).Write(":").NewLine();

            foreach(var pe in _estimates)
            {
                message.Write(" - Crafted at '").Location(pe.TableName).Write("': ");
                message.Number(pe.PriceEstimate.ToString()).NewLine();

            }

            return message;
        }

        private class PriceEstimateSummary
        {
            public string TableName { get; }
            public float PriceEstimate { get; }

            public PriceEstimateSummary(string tableName, float priceEstimate)
            {
                TableName = tableName;
                PriceEstimate = priceEstimate;
            }
        }

        private ItemName _itemName;
        private RecipeName _recipeName;

        private List<PriceEstimateSummary> _estimates = new List<PriceEstimateSummary>(); 
    }
}
