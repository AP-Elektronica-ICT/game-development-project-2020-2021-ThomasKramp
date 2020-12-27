using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation.Door;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation.Static
{
    class StaticStateAnimatie
    {
        int afstand = 50;
        public virtual void Update(IDrawDoorState transform, IGameObject player)
        {
            float result = PlayerDetection.Search(transform, player);
            if (-afstand < result && result < afstand)
            {
                if (transform.State != DoorState.Open && transform.State != DoorState.Closing)
                    transform.State = DoorState.Opening;
            }
            else if (-afstand * 1.5 < result && result < afstand * 1.5)
            {
                if (transform.State != DoorState.Closed && transform.State != DoorState.Opening)
                    transform.State = DoorState.Closing;
            }
        }
    }
}
