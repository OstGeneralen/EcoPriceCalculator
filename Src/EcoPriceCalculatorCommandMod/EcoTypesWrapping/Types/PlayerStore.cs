using Eco.Gameplay.Components;
using EPC.Core.Store;
using System.Collections.Generic;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class PlayerStore : IPlayerStore
    {
        public string StoreName { get; }
        public IEnumerable<IStoreSale> Sales { get; }

        public PlayerStore(StoreComponent component)
        {
            StoreName = component.Parent.Name;

            var sales = component.StoreData.SellOffers;

            var itemSales = new List<StoreSale>();

            foreach (var s in sales)
            {
                var asItem = new GameItem(s.Stack.Item);

                itemSales.Add(new StoreSale(asItem, s.Price, this));
            }

            Sales = itemSales;
        }
    }
}
