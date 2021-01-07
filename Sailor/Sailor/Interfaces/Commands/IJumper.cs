using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    public interface IJumper : IGameObject
    {
        public bool Jumped { get; set; }
        public bool Falling { get; set; }
    }
}
