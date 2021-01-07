using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IPassable
    {
        public bool PassLeft { get; set; }
        public bool PassRight { get; set; }
        public bool PassTop { get; set; }
        public bool PassBottom { get; set; }
    }
}
