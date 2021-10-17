using System;

namespace Battleships
{
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
                var coordinates = GetCoordinates(player.ShipGrid, ship);
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

        internal static bool StrikeShip(Player player, Player opponent)
        {
            DrawStrikeGrid(player, opponent);
            var coordinates = GetCoordinates(player.StrikeGrid);
            var isHit = UpdateStrikeGrids(player, opponent, coordinates);
            DrawStrikeGrid(player, opponent);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return isHit;
        }

        private static bool UpdateStrikeGrids(Player player, Player opponent, Coordinate coordinates)
        {
            bool result;
            var target = opponent.ShipGrid[coordinates.Row, coordinates.Column];
            var targetOnStrikeGrid = player.StrikeGrid[coordinates.Row, coordinates.Column];
            if (target.CellType == CellType.ActiveShip)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hit!");
                ShipTakeHit(opponent.Ships[target.ShipId]);
                Console.ResetColor();
                target.CellType = CellType.DestroyedShip;
                targetOnStrikeGrid.CellType = CellType.Hit;
                targetOnStrikeGrid.Token = "X";
                targetOnStrikeGrid.ShipId = target.ShipId;
                result = true;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Miss!");
                Console.ResetColor();
                targetOnStrikeGrid.CellType = CellType.Miss;
                targetOnStrikeGrid.Token = "O";
                result = false;
            }

            return result;
        }

        private static void ShipTakeHit(Ship hitShip)
        {
            hitShip.TakeHit();
            if (hitShip.IsSunken) Console.WriteLine("Ship sunken!");
        }

        private static void DrawStrikeGrid(Player player, Player opponent)
        {
            var grid = player.StrikeGrid;
            var totalRows = grid.GetLength(0);
            var totalColumns = grid.GetLength(1);
            for (var rowIdx = 0; rowIdx < totalRows; rowIdx++)
            {
                for (var colIdx = 0; colIdx < totalColumns; colIdx++)
                {
                    if (rowIdx == 0 && colIdx >= 1) Console.Write($"_{Convert.ToChar(colIdx - ColumnOffset + UpperCaseAsciiOffset)}|");
                    else if (colIdx == 0 && rowIdx >= 1) Console.Write($"_{rowIdx - RowOffset}|");
                    else if (grid[rowIdx, colIdx].Token != "")
                    {
                        var cell = grid[rowIdx, colIdx];
                        if (cell.CellType == CellType.Hit && opponent.Ships[cell.ShipId].IsSunken)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"{grid[rowIdx, colIdx].Token}_|");
                            Console.ResetColor();
                        }
                        else Console.Write($"{grid[rowIdx, colIdx].Token}_|");
                    }
                    else Console.Write("__|");
                }
                Console.Write("\n");
            }
        }

        internal static void DrawShipGrid(Player player)
        {
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
        }
        
        // private methods below
        
        // NOTE
        // Currently adding the offsets in GetCoordinates();
        // everytime it's called, the output is being used to write to a grid
        private static Coordinate GetCoordinates(GridCell[,] grid, Ship ship = null)
        {
            var isTaken = true;
            Console.WriteLine($"Where do you want to {(ship == null ? "strike" : $"place your {ship.Size}x {ship.Name}")}?");
            Console.WriteLine("Example: type C9 or c9 (case-insensitive)");
            var input = Console.ReadLine();
            while (isTaken)
            {
                while (string.IsNullOrEmpty(input) || !IsValid(input))
                {
                    Console.WriteLine("Invalid input, try again :)");
                    input = Console.ReadLine();
                }

                isTaken = CheckIsTaken(grid, input);
                if (isTaken)
                {
                    Console.WriteLine("Position taken, try again :)");
                    input = Console.ReadLine();
                }
            }
            return new Coordinate(Convert.ToInt32(char.ToUpper(input[0])) - UpperCaseAsciiOffset + ColumnOffset, Convert.ToInt32(input[1].ToString()) + RowOffset);
        }

        private static bool CheckIsTaken(GridCell[,]grid, string input)
        {
                return grid[Convert.ToInt32(input[1].ToString()) + RowOffset,
                    Convert.ToInt32(char.ToUpper(input[0])) - UpperCaseAsciiOffset + ColumnOffset].CellType != CellType.Undecided;
        }

        private static bool IsValid(string input)
        {
            return input.Length == ValidInputLength && (char.IsLetter(input[0]) && IsInCharRange(input[0])) && char.IsDigit(input[1]);
        }

        private static bool IsInCharRange(char c)
        {
            var convertedChar = Convert.ToInt32(Char.ToUpper(c));
            return (convertedChar - UpperCaseAsciiOffset >= 0) && (convertedChar - UpperCaseAsciiOffset <= 9);
        }
    }
}