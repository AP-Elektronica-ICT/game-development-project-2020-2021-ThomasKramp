using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    interface IAttacker : IGameObject
    {
        public bool Attack { get; set; }
        public int Levens { get; set; }
    }
}
