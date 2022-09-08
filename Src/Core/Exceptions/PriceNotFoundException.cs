using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Exceptions
{
    public class PriceNotFoundException : Exception
    {
        public PriceNotFoundException(string item)
            : base($"No price could be found for {item}. No shop selling?")
        {
        }
    }
}
