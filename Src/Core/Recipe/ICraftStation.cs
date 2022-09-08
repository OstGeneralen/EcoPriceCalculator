using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Recipe
{
    public interface ICraftStation
    {
        string StationInstanceName { get; }
        string StationTypeName { get; }
        float GetQuantityRequired( ICraftIngredient ingredient );
    }
}
