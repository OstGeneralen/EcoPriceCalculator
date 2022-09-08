using EPC.Core.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Store
{
    public interface IStoreSale
    {
        IPlayerStore SaleStore { get; }
        IGameItem SoldItem { get; }
        float Price { get; }
    }
}
