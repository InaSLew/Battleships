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
            PlayerAction.DrawShipGrid(player1);
            PlayerAction.PlayerPlaceShips(player1, ships);
        }
    }
}
