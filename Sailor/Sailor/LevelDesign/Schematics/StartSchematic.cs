﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LevelDesign.Schematics
{
    class StartSchematic : Schematic
    {
        /* Surroundings number:
         * Nothing = 0
         * Tile = 1
         * Player = 2
         * Enemy = 3
         * Barrel = 4
         * Table = 5
         * Chair = 6
         * Reverse Chair = 7
         * Small Platform = 8
         * Big Platform = 9
         * NextDoor = 10
         * PreviousDoor = 11
         * EndDoor = 12
         */
        // 6 spaces between platforms full jump

        /* Foreground number:
         * NextDoor = 1
         * PreviousDoor = 2
         * EndDoor = 3
         * Title Sign = 3
         */

        public StartSchematic()
        {
            BackgroundArray = new Byte[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},

                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},

                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
            };
            SurroundingsArray = new Byte[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},

                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},

                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };
            ForegroundArray = new Byte[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
        }
    }
}
