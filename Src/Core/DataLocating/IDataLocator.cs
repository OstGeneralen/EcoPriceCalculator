using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core
{
    public interface IDataLocator<T> where T: ILocatable
    {
        IEnumerable<T> All { get; }
    }
}
