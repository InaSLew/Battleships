using System;

namespace Battleships
{
    public class PlayerAction
    {
        private const int AsciiOffset = 65;
        private const int ColumnOffset = 1;
        private const int RowOffset = 1;
        internal static void PlaceShips(Player player1, Ship[] ships)
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
                        ? new GridCell(coordinates.Column + i, coordinates.Row, CellType.ActiveShip)
                        : new GridCell(coordinates.Column, coordinates.Row + i, CellType.ActiveShip);
                    targetCell.ShipId = ship.id;
                    WriteShipGrid(player1, targetCell);
                }
                DrawShipGrid(player1);
            }
        }

        private static Coordinate GetCoordinates(Ship ship)
        {
            Console.WriteLine($"On which column do you want to place your {ship.Size}x {ship.Name}?");
            var col = Convert.ToInt32(Convert.ToChar(Console.ReadLine().ToUpper())) - AsciiOffset;
            Console.WriteLine($"On which row do you want to place your {ship.Size}x {ship.Name}?");
            var row = Convert.ToInt32(Console.ReadLine());
            return new Coordinate(col, row);
        }

        internal static void StrikeShip(Player player, GridCell targetCell)
        {
            throw new NotImplementedException();
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
        
        // internal static void PlayerStrike
        
        // private methods below
        private static void WriteShipGrid(Player player, GridCell cellToDraw)
        {
            var grid = player.ShipGrid;
            var targetCol = cellToDraw.Column + ColumnOffset;
            var targetRow = cellToDraw.Row + RowOffset;
            if (grid[targetRow, targetCol].Token == "")
            {
                grid[targetRow, targetCol].Token = player.Token;
                grid[targetRow, targetCol].PlayerName = player.PlayerName;
                grid[targetRow, targetCol].CellType = CellType.ActiveShip;
                grid[targetRow, targetCol].ShipId = cellToDraw.ShipId;
            }
            else Console.WriteLine("Oops, position taken!");
        }
    }
}