using EPC.CommandMod.ChatCommands.CommandArguments;
using EPC.CommandMod.Notification;
using EPC.Core.Exceptions;
using EPC.Core.Store;
using EPC.Core.Utility;
using System.Collections.Generic;
using System.Linq;

namespace EPC.CommandMod.ChatCommands.Commands
{
    internal class ListItemPricesCommand : EPCChatCommand
    {
        public ListItemPricesCommand(ItemName itemName)
        {
            _itemName = itemName;
        }

        protected override void Implementation(CmdContext context)
        {
            var item = _itemName.Item;
            var stores = context.Database.AllStores.SellingItem(item);

            var salesList = new List<IStoreSale>();

            foreach(var s in stores)
            {
                var sale = s.Sales.SaleForItem(item);

                if(sale != null)
                {
                    salesList.Add(sale);
                }
            }

            _itemSales = salesList;
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();
            msg.Write("Prices for item ").Item(_itemName).Write(":").NewLine();

            foreach(var sale in _itemSales)
            {
                msg.Write(" - ").Number(sale.Price.ToString()).Write(" at ").Location(sale.SaleStore.StoreName).NewLine();
            }

            return msg;
        }

        private IEnumerable<IStoreSale> _itemSales;
        private ItemName _itemName;
    }

    internal class ListTagPricesCommand : EPCChatCommand
    { 
        public ListTagPricesCommand(CleanString tag)
        {
            _tag = tag;
        }

        protected override void Implementation(CmdContext context)
        {
            var stores = context.Database.AllStores.SellingItemTag(_tag);
            var salesList = new List<IStoreSale>();

            foreach(var s in stores)
            {
                salesList.Concat(s.Sales.SalesForTag(_tag));
            }


            _tagSales = salesList;
        }

        protected override NotificationMessage? ResultMessage()
        {
            var msg = new NotificationMessage();
            msg.Write("Prices for tag ").Item($"{_tag}").Write(":").NewLine();

            foreach(var s in _tagSales)
            {
                msg.Write(" - ").Number(s.Price.ToString()).Write(" at ").Location(s.SaleStore.StoreName).Write(" ").Item(s.SoldItem.ReadableName).NewLine();
            }

            return msg;
        }

        private IEnumerable<IStoreSale> _tagSales;
        private string _tag;
    }




}
