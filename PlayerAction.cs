using System;

namespace Battleships
{
    // TODO: should be able to write to a grid when position is taken
    // TODO: shouldn't be able to place ships next to each other
    internal static class PlayerAction
    {
        private const int UpperCaseAsciiOffset = 65;
        private const int ColumnOffset = 1;
        private const int RowOffset = 1;
        private const int ValidInputLength = 2;
        internal static void PlaceShips(Player player)
        {
            var ships = player.Ships;
            foreach (var ship in ships)
            {
                var coordinates = GetCoordinates(ship);
                Console.WriteLine("Horizontal? y/n");
                var isHorizontal = Console.ReadLine() == "y";
                ship.IsHorizontal = isHorizontal;
                for (var i = 0; i < ship.Size; i++)
                {
                    var target = isHorizontal
                        ? player.ShipGrid[coordinates.Row, coordinates.Column + i]
                        : player.ShipGrid[coordinates.Row + i, coordinates.Column];
                    target.PlayerName = player.PlayerName;
                    target.CellType = CellType.ActiveShip;
                    target.ShipId = ship.Id;
                    target.Token = player.Token;
                }
                DrawShipGrid(player);
            }
        }

        internal static void StrikeShip(Player player, Player opponent)
        {
            DrawStrikeGrid(player);
            var coordinates = GetCoordinates();
            UpdateStrikeGrids(player, opponent, coordinates);
            DrawStrikeGrid(player);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void UpdateStrikeGrids(Player player, Player opponent, Coordinate coordinates)
        {
            var target = opponent.ShipGrid[coordinates.Row, coordinates.Column];
            var targetOnStrikeGrid = player.StrikeGrid[coordinates.Row, coordinates.Column];
            if (target.CellType == CellType.ActiveShip)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hit!");
                ShipTakeHit(player.Ships[target.ShipId]);
                Console.ResetColor();
                target.CellType = CellType.DestroyedShip;
                targetOnStrikeGrid.CellType = CellType.Hit;
                targetOnStrikeGrid.Token = "X";
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Miss!");
                Console.ResetColor();
                targetOnStrikeGrid.CellType = CellType.Miss;
                targetOnStrikeGrid.Token = "O";
            }
        }

        private static void ShipTakeHit(Ship hitShip)
        {
            hitShip.TakeHit();
            if (hitShip.IsSunken) Console.WriteLine("Ship sunken!");
        }

        private static void DrawStrikeGrid(Player player)
        {
            Console.BackgroundColor =
                player.PlayerName == PlayerName.Player1 ? ConsoleColor.Cyan : ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            var grid = player.StrikeGrid;
            var totalRows = grid.GetLength(0);
            var totalColumns = grid.GetLength(1);
            for (var rowIdx = 0; rowIdx < totalRows; rowIdx++)
            {
                var tmp = "";
                for (var colIdx = 0; colIdx < totalColumns; colIdx++)
                {
                    if (rowIdx == 0 && colIdx >= 1) tmp += $"_{Convert.ToChar(colIdx - ColumnOffset + UpperCaseAsciiOffset)}|";
                    else if (colIdx == 0 && rowIdx >= 1) tmp += $"_{rowIdx - RowOffset}|";
                    else if (grid[rowIdx, colIdx].Token != "") tmp += $"{grid[rowIdx, colIdx].Token}_|";
                    else tmp += "__|";
                }
                Console.WriteLine(tmp);
            }
            Console.ResetColor();
        }

        internal static void DrawShipGrid(Player player)
        {
            Console.BackgroundColor =
                player.PlayerName == PlayerName.Player1 ? ConsoleColor.Cyan : ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            var grid = player.ShipGrid;
            var totalRows = grid.GetLength(0);
            var totalColumns = grid.GetLength(1);
            for (var rowIdx = 0; rowIdx < totalRows; rowIdx++)
            {
                var tmp = "";
                for (var colIdx = 0; colIdx < totalColumns; colIdx++)
                {
                    if (rowIdx == 0 && colIdx >= 1) tmp += $"_{Convert.ToChar(colIdx - ColumnOffset + UpperCaseAsciiOffset)}|";
                    else if (colIdx == 0 && rowIdx >= 1) tmp += $"_{rowIdx - RowOffset}|";
                    else if (grid[rowIdx, colIdx].Token != "") tmp += $"{grid[rowIdx, colIdx].Token}_|";
                    else tmp += "__|";
                }
                Console.WriteLine(tmp);
            }
            Console.ResetColor();
        }
        
        // private methods below
        
        // NOTE
        // Currently adding the offsets in GetCoordinates();
        // everytime it's called, the output is being used to write to a grid
        private static Coordinate GetCoordinates(Ship ship = null)
        {
            Console.WriteLine($"Where do you want to {(ship == null ? "strike" : $"place your {ship.Size}x {ship.Name}")}?");
            Console.WriteLine("Example: type C9 or c9 (case-insensitive)");
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !IsValid(input))
            {
                Console.WriteLine("Invalid input, try again :)");
                input = Console.ReadLine();
            }
            return new Coordinate(Convert.ToInt32(char.ToUpper(input[0])) - UpperCaseAsciiOffset + ColumnOffset, Convert.ToInt32(input[1].ToString()) + RowOffset);
        }

        private static bool IsValid(string input)
        {
            return input.Length == ValidInputLength && char.IsLetter(input[0]) && char.IsDigit(input[1]);
        }
    }
}