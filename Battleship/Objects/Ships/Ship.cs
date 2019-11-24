using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Objects.Ships
{
    // Ship represent the objects that need to be destroyed.

    public class Ship
    {
        public string Name { get; set; }
        public int Width { get; set;}

        // Hits to track
        public int Hits { get; set; }
        public OccupationType OccupationType { get; set; }


        // Ship has the width and will be sunk when the ship has been hit the "width" times.
        // Assume the opponent will never hit the same coordinate twice
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
    }
}
