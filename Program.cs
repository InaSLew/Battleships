using System;
using System.Linq;

namespace Battleships
{
    class Program
    {
        private static void Main()
        {
            Player currentPlayer;
            var player1 = new Player(PlayerName.Player1);
            PlaceShipsPhase(player1);

            var player2 = new Player(PlayerName.Player2);
            PlaceShipsPhase(player2);

            Console.WriteLine("Strike Phase begins!");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine($"{player1}'s turn");
                currentPlayer = player1;
                PlayerAction.StrikeShip(player1, player2);
                if (CheckIfAllShipsSunken(player1)) break;
                
                Console.WriteLine($"{player2}'s turn");
                currentPlayer = player2;
                PlayerAction.StrikeShip(player2, player1);
                if (CheckIfAllShipsSunken(player2)) break;
            }

            Console.WriteLine($"{currentPlayer}'s victory!");
        }

        private static void PlaceShipsPhase(Player player)
        {
            Console.WriteLine($"{player}'s turn to place ships");
            Console.WriteLine();
            PlayerAction.DrawShipGrid(player);
            PlayerAction.PlaceShips(player);
            Console.WriteLine($"End of {player}'s turn to place ships");
            HandleEndOfPhase();
        }

        private static void HandleEndOfPhase()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The console will be cleared; please make sure to remember your board before proceeding.");
            Console.ResetColor();
            Console.WriteLine("Press any key to clear the console");
            Console.ReadKey();
            Console.Clear();
        }
        
        private static bool CheckIfAllShipsSunken(Player player)
        {
            return player.Ships.ToList().All(x => x.IsSunken);
        }
    }
}
