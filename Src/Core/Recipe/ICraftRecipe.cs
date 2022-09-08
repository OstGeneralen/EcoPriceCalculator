using EPC.Core.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Recipe
{
    public interface ICraftRecipe : ILocatable
    {
        IEnumerable<ICraftOutput> Outputs { get; }
        IEnumerable<ICraftIngredient> Ingredients { get; }
        float Time { get; }
        float Labour { get; }
        string TableName { get; }

        ICraftOutput ItemOutput(IGameItem item)
        {
            return Outputs.Where(o => o.CraftedItem.ID == item.ID).FirstOrDefault();
        }
    }
}
