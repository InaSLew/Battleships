using System;

namespace Battleships
{
    internal class PlayerAction
    {
        private const int AsciiOffset = 65;
        private const int ColumnOffset = 1;
        private const int RowOffset = 1;
        internal static void PlaceShips(Player player, Ship[] ships)
        {
            foreach (var ship in ships)
            {
                // TODO input validation to avoid incorrect format exception
                var coordinates = GetCoordinates(ship);
                Console.WriteLine("Horizontal? y/n");
                var isHorizontal = Console.ReadLine() == "y";
                ship.IsHorizontal = isHorizontal;
                for (var i = 0; i < ship.Size; i++)
                {
                    var targetCell = isHorizontal
                        ? new GridCell(coordinates.Row, coordinates.Column + i, CellType.ActiveShip)
                        : new GridCell(coordinates.Row + i, coordinates.Column, CellType.ActiveShip);
                    targetCell.ShipId = ship.id;
                    WriteShipGrid(player, targetCell);
                }
                DrawShipGrid(player);
            }
        }

        internal static void StrikeShip(Player player, Player opponent)
        {
            var coordinates = GetCoordinates();
            UpdateStrikeGrids(player, opponent, coordinates);
            DrawStrikeWGrid(player);
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
                Console.ResetColor();
                target.CellType = CellType.DestroyedShip;
                targetOnStrikeGrid.CellType = CellType.Hit;
                WriteStrikeGrid(player, targetOnStrikeGrid);
                WriteStrikeGrid(opponent, target);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Miss!");
                Console.ResetColor();
                targetOnStrikeGrid.CellType = CellType.Miss;
                WriteStrikeGrid(player, targetOnStrikeGrid);
            }
        }
        
        internal static void DrawStrikeWGrid(Player player)
        {
            var grid = player.StrikeGrid;
            var totalRows = grid.GetLength(0);
            var totalColumns = grid.GetLength(1);
            for (var rowIdx = 0; rowIdx < totalRows; rowIdx++)
            {
                var tmp = "";
                for (var colIdx = 0; colIdx < totalColumns; colIdx++)
                {
                    if (rowIdx == 0 && colIdx >= 1) tmp += $"_{Convert.ToChar(colIdx - ColumnOffset + AsciiOffset)}|";
                    else if (colIdx == 0 && rowIdx >= 1) tmp += $"_{rowIdx - RowOffset}|";
                    else if (grid[rowIdx, colIdx].Token != "") tmp += $"{grid[rowIdx, colIdx].Token}_|";
                    else tmp += "__|";
                }
                Console.WriteLine(tmp);
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
                    if (rowIdx == 0 && colIdx >= 1) tmp += $"_{Convert.ToChar(colIdx - ColumnOffset + AsciiOffset)}|";
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
        private static Coordinate GetCoordinates(Ship ship = null)
        {
            Console.WriteLine($"On which column do you want to {(ship == null ? "strike" : $"place your {ship.Size}x {ship.Name}")}?");
            var col = Convert.ToInt32(Convert.ToChar(Console.ReadLine().ToUpper())) - AsciiOffset + ColumnOffset;
            Console.WriteLine($"On which row do you want to {(ship == null ? "strike" : $"place your {ship.Size}x {ship.Name}")}?");
            var row = Convert.ToInt32(Console.ReadLine()) + RowOffset;
            return new Coordinate(col, row);
        }
        private static void WriteShipGrid(Player player, GridCell cellToDraw)
        {
            var grid = player.ShipGrid;
            // var targetCol = cellToDraw.Column + ColumnOffset;
            // var targetRow = cellToDraw.Row + RowOffset;
            var targetCol = cellToDraw.Column;
            var targetRow = cellToDraw.Row;
            if (grid[targetRow, targetCol].Token == "")
            {
                grid[targetRow, targetCol].Token = player.Token;
                grid[targetRow, targetCol].PlayerName = player.PlayerName;
                grid[targetRow, targetCol].CellType = CellType.ActiveShip;
                grid[targetRow, targetCol].ShipId = cellToDraw.ShipId;
            }
            else Console.WriteLine("Oops, position taken!");
        }
        private static void WriteStrikeGrid(Player player, GridCell cellToDraw)
        {
            var grid = player.StrikeGrid;
            var targetCol = cellToDraw.Column;
            var targetRow = cellToDraw.Row;
            if (grid[targetRow, targetCol].Token == "")
            {
                grid[targetRow, targetCol].Token = player.Token;
                grid[targetRow, targetCol].PlayerName = player.PlayerName;
                grid[targetRow, targetCol].ShipId = cellToDraw.ShipId;
            }
            else Console.WriteLine("Oops, position taken!");
        }
    }
}