using System;

namespace Peon.Game
{
    public class Station : Located
    {
    }

    public class BaseStation : Station
    {
        public string Name { get; set; }
    }
}
