using System;
using System.Collections.Generic;
using System.Text;
using BattleshipGame.Objects.Boards;

namespace BattleshipGame.Objects.Games
{
    class Game
    {
        // There are always 2 players in the Battleship game
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {
            // The requirement says that only one player plays the game until all the ship has been sunk.
            Player1 = new Player("Eddy");
            Player2 = new Player("Computer");

            // Randomly place the ships in Player 1 and display the status
            Player1.PlaceShips();
            Player1.OutputBoards();

            // Randomly place the ships in Player 2 and display the status
            Player2.PlaceShips();
            Player2.OutputBoards();

            // Continue Flag - until Player 2 loss all the ships
            bool contFlag = true;

            do
            {
                // Player1 enter the coordinates (Row & Column)
                Console.WriteLine("Player1 - {0} - Fire at", Player1.Name);
                Console.WriteLine("Enter the row?");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the column?");
                int col = int.Parse(Console.ReadLine());

                // Process the firing move
                contFlag = P1Fire(row, col);

                // Display the boards after processing the firing move
                Player1.OutputBoards();
                Player2.OutputBoards();

            } while (contFlag); // no longer continue if Player2 has lost the battle

            Console.ReadLine();
        }

        public bool P1Fire (int row, int col)
        {
            if (Player2.ProcessShot(new Coordinates(row,col)) == ShotResult.Hit)
            {
                // If Hit, Mark X in the Player 1 Firing Board
                Player1.SetHit(row, col);
            }
            else
            {
                // If Miss, Mark M in the Player 1 Firing Board
                Player1.SetMiss(row, col);
            }

            // Check if Player2 has lost all the ships
            if (Player2.HasLost)
            {
                Console.WriteLine(Player2.Name + " has lost the game!");
                return (false);
            }
            return (true);
        }
 
    }
}
