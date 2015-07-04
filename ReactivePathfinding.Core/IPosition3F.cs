using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public interface IPosition3F
    {
        float X { get; }
        float Y { get; }
        float Z { get; }
        float Distance(IPosition3F other);
    }
}
