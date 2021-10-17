using System;

namespace Battleships
{
    class Program
    {
        private static void Main()
        {
            var isGameOver = false;

            var player1 = new Player(PlayerName.Player1);
            PlaceShipsPhase(player1);

            var player2 = new Player(PlayerName.Player2);
            PlaceShipsPhase(player2);

            Console.WriteLine("Strike Phase begins!");
            Console.WriteLine();
            while (!isGameOver)
            {
                Console.WriteLine($"{player1}'s turn");
                PlayerAction.StrikeShip(player1, player2);
                Console.WriteLine($"{player2}'s turn");
                PlayerAction.StrikeShip(player2, player1);
                Console.WriteLine($"{player1}'s turn");
                PlayerAction.StrikeShip(player1, player2);
                Console.WriteLine($"{player2}'s turn");
                PlayerAction.StrikeShip(player2, player1);
                isGameOver = true;
            }
            
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
    }
}
