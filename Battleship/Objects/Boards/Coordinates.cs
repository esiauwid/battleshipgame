using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Objects.Boards
{
    public class Coordinates
    {
        // Coordinate in Battleship is represented by row and column

        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

    }
}
