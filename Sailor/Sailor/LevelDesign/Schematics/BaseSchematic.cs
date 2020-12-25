using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LevelDesign.Schematics
{
    abstract class BaseSchematic
    {
        /* Texture number:
         * Nothing = 0
         * Tile = 1
         * Player = 2
         * Enemy = 3
         * Barrel = 4
         * Table = 5
         * Chair = 6
         * Small Platform = 7
         * Big Platform = 8
         * Door = 9
         */
        // 6 spaces between platforms full jump
        
        public byte[,] BackgroundArray { get; protected set; }
        public byte[,] SurroundingsArray { get; protected set; }
        public byte[,] ForegroundArray { get; protected set; }
    }
}
