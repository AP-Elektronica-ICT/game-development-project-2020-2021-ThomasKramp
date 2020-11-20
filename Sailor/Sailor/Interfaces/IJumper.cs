using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IJumper : IGameObject
    {
        public bool Jumped { get; set; }
        public bool Falling { get; set; }
        public bool Ground { get; set; }
    }
}
