using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    interface IKillAble
    {
        public bool Hit { get; set; }
        public bool Dead { get; set; }
        public int Levens { get; set; }
    }
}
