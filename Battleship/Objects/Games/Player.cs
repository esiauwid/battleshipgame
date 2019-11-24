using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleshipGame.Objects.Boards;
using BattleshipGame.Objects.Ships;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Games
{
    class Player
    {
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        public FiringBoard FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }



        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
        }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public void OutputBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                          Firing Board:");

            // Coordinates
            Console.Write("   ");
            for (int ownColumn = 1; ownColumn <= Constants.MAXCOL; ownColumn++)
            {
                Console.Write("{0} ", ownColumn);
            }
            Console.Write("               ");
            for (int firingColumn = 1; firingColumn <= Constants.MAXCOL; firingColumn++)
            {
                Console.Write("{0} ", firingColumn);
            }
            Console.WriteLine();
            
            // Panels
            for (int row = 1; row <= Constants.MAXROW; row++)
            {
                if (row>=10)
                    Console.Write("{0} ", row);
                else
                    Console.Write(" {0} ", row);

                for (int ownColumn = 1; ownColumn <= Constants.MAXCOL; ownColumn++)
                {
                    Console.Write("{0} ", GameBoard.Panels.At(row, ownColumn).StatusDescription);
                }
                Console.Write("                ");
                for (int firingColumn = 1; firingColumn <= Constants.MAXCOL; firingColumn++)
                {
                    Console.Write("{0} ", FiringBoard.Panels.At(row, firingColumn).StatusDescription);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PlaceShips()
        {
            //Random class creation stolen from http://stackoverflow.com/a/18267477/106356
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed panels are occupied, place the ship
                //Do this for all ships

                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, Constants.MAXCOL+1);
                    var startrow = rand.Next(1, Constants.MAXROW + 1);
                    int endrow = startrow, endcolumn = startcolumn;

                    List<int> panelNumbers = new List<int>();

                    if (rand.Next(1, (Constants.MAXROW * Constants.MAXCOL) + 1) % 2 == 0) //0 for Horizontal
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endrow++;
                        }
                    }
                        
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endcolumn++;
                        }
                    }

                    //We cannot place ships beyond the boundaries of the board
                    if (endrow > Constants.MAXROW || endcolumn > Constants.MAXCOL)
                    {
                        isOpen = true;
                        continue;
                    }

                    //Check if specified panels are occupied
                    var affectedPanels = GameBoard.Panels.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedPanels.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var panel in affectedPanels)
                    {
                        panel.OccupationType = ship.OccupationType;
                    }
                    isOpen = false;
                }
            }
        }


        public void SetHit(int row, int col)
        {
            FiringBoard.SetStatus(row, col, OccupationType.Hit);
        }

        public void SetMiss(int row, int col)
        {
            FiringBoard.SetStatus(row, col, OccupationType.Miss);
        }

        public ShotResult ProcessShot(Coordinates coords)
        {
            // Check if the panel for a given row & col is occupied (has a ship)
            var panel = GameBoard.Panels.At(coords.Row, coords.Column);
            if (!panel.IsOccupied)
            {
                Console.WriteLine(Name + " says: \"Miss!\"");
                return ShotResult.Miss;
            }

            // Find the ship of the found OccupationType during a hit, increment the hits
            var ship = Ships.First(x => x.OccupationType == panel.OccupationType);
            ship.Hits++;
            Console.WriteLine(Name + " says: \"Hit!\"");

            // Check if the ship has Sunk - damaged on all the panels.
            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }
            return ShotResult.Hit;
        }
    }
}
