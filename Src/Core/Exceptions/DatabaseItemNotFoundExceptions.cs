using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Exceptions
{
    public class NamedItemNotFoundException : Exception
    {
        public NamedItemNotFoundException(string itemTypeName, string name)
            : base($"Invalid {itemTypeName} name: {name}")
        {
        }
    }

    public class ItemNotFoundException : NamedItemNotFoundException
    {
        public ItemNotFoundException(string name)
            : base("Item", name)
        {
        }
    }

    public class RecipeNotFoundException : NamedItemNotFoundException
    {
        public RecipeNotFoundException(string name)
            : base("Recipe", name)
        {
        }
    }

    public class StoreNotFoundException : NamedItemNotFoundException
    {
        public StoreNotFoundException(string name)
            : base("Store", name)
        {
        }
    }

}
