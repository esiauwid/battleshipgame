using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 3;
            OccupationType = OccupationType.Submarine;
        }
    }

}
