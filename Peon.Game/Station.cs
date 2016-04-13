using System;

namespace Peon.Game
{
    public class Station : Located
    {
    }

    public class Base : Station
    {
        public string Name { get; set; }
    }
}
