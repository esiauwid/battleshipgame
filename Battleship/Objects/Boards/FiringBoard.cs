using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Boards
{
    /// <summary>
    /// Represent a collectin of Panels to show where the player has fired shots
    /// 
    /// </summary>
    public class FiringBoard: GameBoard 
    {

        /// <summary>
        /// Return the list of adjacent panels
        /// </summary>
        /// <returns></returns>
        public List<Coordinates> GetHitNeighbors()
        {
            List<Panel> panels = new List<Panel>();
            var hits = Panels.Where(x => x.OccupationType == OccupationType.Hit);
            foreach (var hit in hits)
            {
                panels.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return panels.Distinct().Where(x => x.OccupationType == OccupationType.Empty).Select(x => x.Coordinates).ToList();
        }

        /// <summary>
        /// Return the maximum of 4 Panels - unless the coordinates are already at the edge of the board.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        /// 
        public List<Panel> GetNeighbors(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Panel> panels = new List<Panel>();
            if (column > 1)
            {
                panels.Add(Panels.At(row, column - 1));
            }
            if (row > 1)
            {
                panels.Add(Panels.At(row - 1, column));
            }
            if (row < Constants.MAXROW)
            {
                panels.Add(Panels.At(row + 1, column));
            }
            if (column < Constants.MAXCOL)
            {
                panels.Add(Panels.At(row, column + 1));
            }
            return panels;
        }
    }
}
