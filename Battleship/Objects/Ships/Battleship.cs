using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 4;
            OccupationType = OccupationType.Battleship;
        }
    }

}
