using System.Collections.Generic;
using System.Linq;
using EPC.CommandMod.ChatCommands.CommandArguments;
using EPC.CommandMod.Notification;
using EPC.Core.Exceptions;
using EPC.Core.Item;
using EPC.Core.Store;
using EPC.Core.Utility;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListPricesCommand : EPCChatCommand
    {
        public ListPricesCommand(CleanString itemOrTag)
        {
            _itemOrTag = itemOrTag;
        }

        protected override void Implementation(CmdContext context)
        {
            if (IsItem(context, out var item))
            {
                _itemOrTagInfoStr = "Item";
                ItemImplementation(context, item);
            }
            else
            {
                _itemOrTagInfoStr = "Tag";
                TagImplementation(context);
            }
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();
            msg.Write("Prices for ").Item(_itemOrTag).Info($" ({_itemOrTagInfoStr})").Write(":").NewLine();

            foreach (var sale in _sales)
            {
                msg.Write(" - ").Number(sale.Price.ToString()).Write(" at ").Location(sale.SaleStore.StoreName).NewLine();
            }

            return msg;
        }

        private void TagImplementation(CmdContext context)
        {
            var stores = context.Database.AllStores.SellingItemTag(_itemOrTag);

            var salesList = new List<IStoreSale>();

            foreach (var s in stores)
            {
                var sales = s.Sales.SalesForTag(_itemOrTag);

                if (sales != null)
                {
                    salesList.Concat(sales);
                }
            }

            _sales = salesList;
        }

        private void ItemImplementation(CmdContext context, IGameItem item)
        {
            var stores = context.Database.AllStores.SellingItem(item);

            var salesList = new List<IStoreSale>();

            foreach (var s in stores)
            {
                var sale = s.Sales.SaleForItem(item);

                if (sale != null)
                {
                    salesList.Add(sale);
                }
            }

            _sales = salesList;
        }

        private bool IsItem(CmdContext c, out IGameItem? item)
        {
            try
            {
                item = c.Database.NameToItem(_itemOrTag);
                return true;
            }
            catch (ItemNotFoundException e)
            {
                item = null;
                return false;
            }
        }

        private IEnumerable<IStoreSale> _sales;
        private string _itemOrTag;
        private string _itemOrTagInfoStr;
    }
}
