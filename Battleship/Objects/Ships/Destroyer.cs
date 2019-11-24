using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 2;
            OccupationType = OccupationType.Destroyer;
        }
    }

}
