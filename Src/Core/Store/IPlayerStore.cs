using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPC.Core;
using EPC.Core.Item;

namespace EPC.Core.Store
{
    public interface IPlayerStore : ILocatable
    {
        string ILocatable.ReadableName { get => StoreName; }
        string StoreName { get; }
        IEnumerable<IStoreSale> Sales { get; }
    }
}
