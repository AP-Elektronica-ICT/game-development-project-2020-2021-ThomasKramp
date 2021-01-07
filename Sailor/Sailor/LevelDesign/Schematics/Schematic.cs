using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LevelDesign.Schematics
{
    abstract class Schematic
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
         * Skull = 10
         */
        // 6 spaces between platforms full jump

        /* Foreground number:
         * NextDoor = 1
         * PreviousDoor = 2
         * EndDoor = 3
         * Window = 4
         * Title Sign = 10
         * Move Sign = 11
         * Punch Sign = 12
         * Thorw Sign = 13
         * Warp Sign = 14
         * Jump Sign = 15
         */

        public byte[,] BackgroundArray { get; protected set; }
        public byte[,] SurroundingsArray { get; protected set; }
        public byte[,] ForegroundArray { get; protected set; }
    }
}
