using System;
using System.Linq;

namespace Battleships
{
    class Program
    {
        private static void Main()
        {
            var player1 = new Player(PlayerName.Player1);
            PlaceShipsPhase(player1);

            var player2 = new Player(PlayerName.Player2);
            PlaceShipsPhase(player2);

            Console.WriteLine("Strike Phase begins!");
            Console.WriteLine();

            var currentPlayer = player1;
            var opponent = player2;
            while (!(CheckIfAllShipsSunken(opponent)))
            {
                var isHit = StrikePhase(currentPlayer, opponent);
                while (!(CheckIfAllShipsSunken(opponent)) && isHit)
                {
                    isHit = StrikePhase(currentPlayer, opponent);
                }

                if (isHit) continue;
                currentPlayer = currentPlayer.PlayerName == PlayerName.Player1 ? player2 : player1;
                opponent = opponent.PlayerName == PlayerName.Player1 ? player2 : player1;
            }
            Console.WriteLine($"{currentPlayer}'s victory!");
        }

        private static bool StrikePhase(Player currentPlayer, Player opponent)
        {
            Console.WriteLine($"{currentPlayer}'s turn");
            return PlayerAction.StrikeShip(currentPlayer, opponent);
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
