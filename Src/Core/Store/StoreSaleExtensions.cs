using EPC.Core.Item;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPC.Core.Store
{
    public static class StoreSaleExtensions
    {
        public static IStoreSale? SaleForItem(this IEnumerable<IStoreSale> sl, IGameItem item)
        {
            return sl.Where(s => s.SoldItem.ID == item.ID).FirstOrDefault();
        }

        public static IEnumerable<IStoreSale> SalesForTag(this IEnumerable<IStoreSale> sl, string tag)
        {
            return sl.Where(s => s.SoldItem.Tag.Contains(tag));
        }

        public static IStoreSale? LowestPrice(this IEnumerable<IStoreSale> sl)
        {
            IStoreSale currentLowest = null;
            var currentLowestPrice = float.MaxValue;

            foreach (var s in sl)
            {
                if (s.Price < currentLowestPrice)
                {
                    currentLowest = s;
                    currentLowestPrice = s.Price;
                }
            }


            return currentLowest;
        }
    }
}
