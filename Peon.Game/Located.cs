using System;
using Peon.Maps;

namespace Peon.Game
{
    public interface ILocated
    {
        int ID { get; set; }
        LatLong Location { get; set; }
    }
}
