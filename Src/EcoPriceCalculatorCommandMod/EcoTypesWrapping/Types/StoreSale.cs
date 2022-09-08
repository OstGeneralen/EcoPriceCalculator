using EPC.Core.Item;
using EPC.Core.Store;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class StoreSale : IStoreSale
    {
        public IPlayerStore SaleStore { get; }
        public IGameItem SoldItem { get; }
        public float Price { get; }

        public StoreSale(IGameItem item, float price, IPlayerStore store)
        {
            SaleStore = store;
            SoldItem = item;
            Price = price;
        }
    }
}
