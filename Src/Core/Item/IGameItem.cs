using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.Core.Item
{
    public interface IGameItem : ILocatable
    {
        string ILocatable.ReadableName { get => DisplayName; }
        int ID { get; }
        string DisplayName { get; }
        IEnumerable<string> Tag { get; }
    }
}
