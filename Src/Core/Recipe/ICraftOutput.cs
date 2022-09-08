using EPC.Core.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Recipe
{
    public interface ICraftOutput
    {
        IGameItem CraftedItem { get; }
        float Quantity { get; }
    }
}
