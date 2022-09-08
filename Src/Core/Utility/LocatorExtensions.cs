using EPC.Core.Item;
using EPC.Core.Exceptions;
using EPC.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EPC.Core.Utility
{
    public static class StoreEnumerableExtensions
    {
        public static IEnumerable<IPlayerStore> SellingItem(this IEnumerable<IPlayerStore> sl, IGameItem item)
        {
            var storesSellingItem = sl.Where(s => s.Sales.Count(sa => sa.SoldItem.ID == item.ID) > 0);

            if(storesSellingItem.Count() == 0)
            {
                throw new PriceNotFoundException(item.ReadableName);
            }
            return storesSellingItem;
        }

        public static IEnumerable<IPlayerStore> SellingItemTag(this IEnumerable<IPlayerStore> sl, string itemTag)
        {
            var s = sl.Where(s => s.Sales.Count(sa => sa.SoldItem.Tag.Contains(itemTag)) > 0); 

            if(s.Count() == 0)
            {
                throw new PriceNotFoundException($"{itemTag} tag");
            }

            return s;
        }

        public static IStoreSale LowestPriceSaleForTag(this IEnumerable<IPlayerStore> sl, string itemTag)
        {
            var sellers = sl.SellingItemTag(itemTag);

            var lowestPrice = float.MaxValue;
            IStoreSale lowestPriceSale = null;

            foreach(var seller in sellers)
            {
                foreach(var sale in seller.Sales.SalesForTag(itemTag))
                {
                    if(sale.Price < lowestPrice)
                    {
                        lowestPrice = sale.Price;
                        lowestPriceSale = sale;
                    }
                }
            }

            return lowestPriceSale;
        }

        public static IStoreSale LowestPriceSaleForItem(this IEnumerable<IPlayerStore> sl, IGameItem item)
        {
            var sellers = sl.SellingItem(item);

            var lowestPrice = float.MaxValue;
            IStoreSale lowestPriceSale = null;

            foreach (var seller in sellers)
            {
                var itemSale = seller.Sales.SaleForItem(item);

                if (itemSale.Price < lowestPrice)
                {
                    lowestPrice = itemSale.Price;
                    lowestPriceSale = itemSale;
                }
            }

            return lowestPriceSale;
        }
    }
}
