using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BattleshipGame.Objects.Boards
{
    public class GameBoard
    {
        public List<Panel> Panels { get; set; }

        public GameBoard()
        {
            // Initialise the Panels object
            Panels = new List<Panel>();
            
            // Create all the panels in the board
            for (int row = 1; row<=Constants.MAXROW; row++)
            {
                for (int col = 1; col<=Constants.MAXCOL; col++)
                {
                    Panels.Add(new Panel(row, col));
                }
            }
        }

        public void SetStatus (int row, int col, OccupationType occupancytype)
        {
            Panel p = Panels.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == col).First();
            p.OccupationType = occupancytype;
        }

    }
}
