using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Aircraft Carrier";
            Width = 5;
            OccupationType = OccupationType.Carrier;
        }
    }

}
