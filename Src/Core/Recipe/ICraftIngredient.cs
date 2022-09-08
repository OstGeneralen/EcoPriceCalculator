using EPC.Core.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Recipe
{
    public interface ICraftIngredient
    {
        /// <summary>
        /// If true, this is a tag and not a specific item
        /// </summary>
        bool IsTag { get; }

        /// <summary>
        /// The tag required. String.Empty if IsTag == false
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// The ingredient item. Null if IsTag == true
        /// </summary>
        IGameItem IngredientItem { get; }

        float QuantityRequiredAtTable(ICraftStation station);
    }
}
