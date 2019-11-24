using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Width = 3;
            OccupationType = OccupationType.Cruiser;
        }
    }

}
