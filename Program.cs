using System;

namespace Battleships
{
    class Program
    {
        private static void Main()
        {
            var ships = new[]
            {
                new Ship(2), new Ship(2), new Ship(3), new Ship(4), new Ship(5)
            };
            
            var player1 = new Player(PlayerName.Player1);
            PlaceShipsPhase(player1, ships);

            var player2 = new Player(PlayerName.Player2);
            PlaceShipsPhase(player2, ships);

            Console.WriteLine("Strike Phase begins!");
            Console.WriteLine();
            Console.WriteLine($"{player1}'s turn");
            PlayerAction.StrikeShip(player1, player2);
        }

        private static void PlaceShipsPhase(Player player, Ship[] ships)
        {
            Console.WriteLine($"{player}'s turn to place ships");
            Console.WriteLine();
            PlayerAction.DrawShipGrid(player);
            PlayerAction.PlaceShips(player, ships);
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
    }
}
