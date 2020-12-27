using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    public interface IDeathFall : IGameObject
    {
        public int Levens { get; set; }
        public bool Dead { get; set; }
    }
}
