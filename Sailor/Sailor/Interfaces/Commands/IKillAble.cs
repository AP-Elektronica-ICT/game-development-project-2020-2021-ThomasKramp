using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    interface IKillAble
    {
        public int Levens { get; set; }
        public bool Hit { get; set; }
        public bool Dead { get; set; }
    }
}
