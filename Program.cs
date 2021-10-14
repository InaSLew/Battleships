using System;
using System.Threading.Channels;

namespace Battleships
{
    
    class Program
    {
        private const int AsciiOffset = 65;
        private const int ColumnOffset = 1;
        private const int RowOffset = 1;
        private const int BiggestShipSize = 5;

        private static void Main()
        {
            var ships = new[]
            {
                new Ship(2), new Ship(2), new Ship(3), new Ship(4), new Ship(5)
            };
            var player1 = new Player(PlayerName.Player1);
            DrawShipGrid(player1);
            PlayerPlaceShips(player1, ships);
            DrawShipGrid(player1);
        }

        private static void PlayerPlaceShips(Player player1, Ship[] ships)
        {
            foreach (var ship in ships)
            {
                // TODO input validation to avoid incorrect format exception
                Console.WriteLine($"On which column do you want to place your {ship.Size}x {ship.Name}?");
                var col = Convert.ToInt32(Convert.ToChar(Console.ReadLine().ToUpper())) - AsciiOffset;
                Console.WriteLine($"On which row do you want to place your {ship.Size}x {ship.Name}?");
                var row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Horizontal? y/n");
                var isHorizontal = Console.ReadLine() == "y";
                ship.IsHorizontal = isHorizontal;
                for (var i = 0; i < ship.Size; i++)
                {
                    var targetCell = isHorizontal
                        ? new GridCell(col + i, row, CellType.ActiveShip)
                        : new GridCell(col, row + i, CellType.ActiveShip);
                    targetCell.ShipId = ship.id;
                    WriteShipGrid(player1, targetCell);
                }
            }
        }

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

        private static void DrawShipGrid(Player player)
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
    }

    class GridCell
    {
        public GridCell(int column, int row, CellType cellType, string token = "", PlayerName? playerName = null)
        {
            Column = column;
            Row = row;
            Token = token;
            CellType = cellType;
            PlayerName = playerName;
        }
        public int Column { get; }
        public int Row { get; }
        public string Token { get; set; }
        public CellType CellType { get; set; }
        public PlayerName? PlayerName { get; set; }
        public int ShipId { get; set; }
    }

    internal enum CellType
    {
        ActiveShip,
        DestroyedShip,
        Hit,
        Miss,
        Undecided
    }

    class Player
    {
        public Player(PlayerName playerName)
        {
            PlayerName = playerName;
            ShipGrid = new GridCell[11, 11]
            {
                {
                    new GridCell(0, 0, CellType.Undecided), new GridCell(0, 1, CellType.Undecided), new GridCell(0, 2, CellType.Undecided), new GridCell(0, 3, CellType.Undecided), new GridCell(0, 4, CellType.Undecided),
                    new GridCell(0, 5, CellType.Undecided), new GridCell(0, 6, CellType.Undecided), new GridCell(0, 7, CellType.Undecided), new GridCell(0, 8, CellType.Undecided), new GridCell(0, 9, CellType.Undecided),
                    new GridCell(0, 10, CellType.Undecided),
                },
                {
                    new GridCell(1, 0, CellType.Undecided), new GridCell(1, 1, CellType.Undecided), new GridCell(1, 2, CellType.Undecided), new GridCell(1, 3, CellType.Undecided), new GridCell(1, 4, CellType.Undecided),
                    new GridCell(1, 5, CellType.Undecided), new GridCell(1, 6, CellType.Undecided), new GridCell(1, 7, CellType.Undecided), new GridCell(1, 8, CellType.Undecided), new GridCell(1, 9, CellType.Undecided),
                    new GridCell(1, 10, CellType.Undecided),
                },
                {
                    new GridCell(2, 0, CellType.Undecided), new GridCell(2, 1, CellType.Undecided), new GridCell(2, 2, CellType.Undecided), new GridCell(2, 3, CellType.Undecided), new GridCell(2, 4, CellType.Undecided),
                    new GridCell(2, 5, CellType.Undecided), new GridCell(2, 6, CellType.Undecided), new GridCell(2, 7, CellType.Undecided), new GridCell(2, 8, CellType.Undecided), new GridCell(2, 9, CellType.Undecided),
                    new GridCell(2, 10, CellType.Undecided),
                },
                {
                    new GridCell(3, 0, CellType.Undecided), new GridCell(3, 1, CellType.Undecided), new GridCell(3, 2, CellType.Undecided), new GridCell(3, 3, CellType.Undecided), new GridCell(3, 4, CellType.Undecided),
                    new GridCell(3, 5, CellType.Undecided), new GridCell(3, 6, CellType.Undecided), new GridCell(3, 7, CellType.Undecided), new GridCell(3, 8, CellType.Undecided), new GridCell(3, 9, CellType.Undecided),
                    new GridCell(3, 10, CellType.Undecided),
                },
                {
                    new GridCell(4, 0, CellType.Undecided), new GridCell(4, 1, CellType.Undecided), new GridCell(4, 2, CellType.Undecided), new GridCell(4, 3, CellType.Undecided), new GridCell(4, 4, CellType.Undecided),
                    new GridCell(4, 5, CellType.Undecided), new GridCell(4, 6, CellType.Undecided), new GridCell(4, 7, CellType.Undecided), new GridCell(4, 8, CellType.Undecided), new GridCell(4, 9, CellType.Undecided),
                    new GridCell(4, 10, CellType.Undecided),
                },
                {
                    new GridCell(5, 0, CellType.Undecided), new GridCell(5, 1, CellType.Undecided), new GridCell(5, 2, CellType.Undecided), new GridCell(5, 3, CellType.Undecided), new GridCell(5, 4, CellType.Undecided),
                    new GridCell(5, 5, CellType.Undecided), new GridCell(5, 6, CellType.Undecided), new GridCell(5, 7, CellType.Undecided), new GridCell(5, 8, CellType.Undecided), new GridCell(5, 9, CellType.Undecided),
                    new GridCell(5, 10, CellType.Undecided),
                },
                {
                    new GridCell(6, 0, CellType.Undecided), new GridCell(6, 1, CellType.Undecided), new GridCell(6, 2, CellType.Undecided), new GridCell(6, 3, CellType.Undecided), new GridCell(6, 4, CellType.Undecided),
                    new GridCell(6, 5, CellType.Undecided), new GridCell(6, 6, CellType.Undecided), new GridCell(6, 7, CellType.Undecided), new GridCell(6, 8, CellType.Undecided), new GridCell(6, 9, CellType.Undecided),
                    new GridCell(6, 10, CellType.Undecided),
                },
                {
                    new GridCell(7, 0, CellType.Undecided), new GridCell(7, 1, CellType.Undecided), new GridCell(7, 2, CellType.Undecided), new GridCell(7, 3, CellType.Undecided), new GridCell(7, 4, CellType.Undecided),
                    new GridCell(7, 5, CellType.Undecided), new GridCell(7, 6, CellType.Undecided), new GridCell(7, 7, CellType.Undecided), new GridCell(7, 8, CellType.Undecided), new GridCell(7, 9, CellType.Undecided),
                    new GridCell(7, 10, CellType.Undecided),
                },
                {
                    new GridCell(8, 0, CellType.Undecided), new GridCell(8, 1, CellType.Undecided), new GridCell(8, 2, CellType.Undecided), new GridCell(8, 3, CellType.Undecided), new GridCell(8, 4, CellType.Undecided),
                    new GridCell(8, 5, CellType.Undecided), new GridCell(8, 6, CellType.Undecided), new GridCell(8, 7, CellType.Undecided), new GridCell(8, 8, CellType.Undecided), new GridCell(8, 9, CellType.Undecided),
                    new GridCell(8, 10, CellType.Undecided),
                },
                {
                    new GridCell(9, 0, CellType.Undecided), new GridCell(9, 1, CellType.Undecided), new GridCell(9, 2, CellType.Undecided), new GridCell(9, 3, CellType.Undecided), new GridCell(9, 4, CellType.Undecided),
                    new GridCell(9, 5, CellType.Undecided), new GridCell(9, 6, CellType.Undecided), new GridCell(9, 7, CellType.Undecided), new GridCell(9, 8, CellType.Undecided), new GridCell(9, 9, CellType.Undecided),
                    new GridCell(9, 10, CellType.Undecided),
                },
                {
                    new GridCell(10, 0, CellType.Undecided), new GridCell(10, 1, CellType.Undecided), new GridCell(10, 2, CellType.Undecided), new GridCell(10, 3, CellType.Undecided),
                    new GridCell(10, 4, CellType.Undecided), new GridCell(10, 5, CellType.Undecided), new GridCell(10, 6, CellType.Undecided), new GridCell(10, 7, CellType.Undecided),
                    new GridCell(10, 8, CellType.Undecided), new GridCell(10, 9, CellType.Undecided), new GridCell(10, 10, CellType.Undecided),
                },
            };
            StrikeGrid = new GridCell[11, 11]
            {
                {
                    new GridCell(0, 0, CellType.Undecided), new GridCell(0, 1, CellType.Undecided), new GridCell(0, 2, CellType.Undecided), new GridCell(0, 3, CellType.Undecided), new GridCell(0, 4, CellType.Undecided),
                    new GridCell(0, 5, CellType.Undecided), new GridCell(0, 6, CellType.Undecided), new GridCell(0, 7, CellType.Undecided), new GridCell(0, 8, CellType.Undecided), new GridCell(0, 9, CellType.Undecided),
                    new GridCell(0, 10, CellType.Undecided),
                },
                {
                    new GridCell(1, 0, CellType.Undecided), new GridCell(1, 1, CellType.Undecided), new GridCell(1, 2, CellType.Undecided), new GridCell(1, 3, CellType.Undecided), new GridCell(1, 4, CellType.Undecided),
                    new GridCell(1, 5, CellType.Undecided), new GridCell(1, 6, CellType.Undecided), new GridCell(1, 7, CellType.Undecided), new GridCell(1, 8, CellType.Undecided), new GridCell(1, 9, CellType.Undecided),
                    new GridCell(1, 10, CellType.Undecided),
                },
                {
                    new GridCell(2, 0, CellType.Undecided), new GridCell(2, 1, CellType.Undecided), new GridCell(2, 2, CellType.Undecided), new GridCell(2, 3, CellType.Undecided), new GridCell(2, 4, CellType.Undecided),
                    new GridCell(2, 5, CellType.Undecided), new GridCell(2, 6, CellType.Undecided), new GridCell(2, 7, CellType.Undecided), new GridCell(2, 8, CellType.Undecided), new GridCell(2, 9, CellType.Undecided),
                    new GridCell(2, 10, CellType.Undecided),
                },
                {
                    new GridCell(3, 0, CellType.Undecided), new GridCell(3, 1, CellType.Undecided), new GridCell(3, 2, CellType.Undecided), new GridCell(3, 3, CellType.Undecided), new GridCell(3, 4, CellType.Undecided),
                    new GridCell(3, 5, CellType.Undecided), new GridCell(3, 6, CellType.Undecided), new GridCell(3, 7, CellType.Undecided), new GridCell(3, 8, CellType.Undecided), new GridCell(3, 9, CellType.Undecided),
                    new GridCell(3, 10, CellType.Undecided),
                },
                {
                    new GridCell(4, 0, CellType.Undecided), new GridCell(4, 1, CellType.Undecided), new GridCell(4, 2, CellType.Undecided), new GridCell(4, 3, CellType.Undecided), new GridCell(4, 4, CellType.Undecided),
                    new GridCell(4, 5, CellType.Undecided), new GridCell(4, 6, CellType.Undecided), new GridCell(4, 7, CellType.Undecided), new GridCell(4, 8, CellType.Undecided), new GridCell(4, 9, CellType.Undecided),
                    new GridCell(4, 10, CellType.Undecided),
                },
                {
                    new GridCell(5, 0, CellType.Undecided), new GridCell(5, 1, CellType.Undecided), new GridCell(5, 2, CellType.Undecided), new GridCell(5, 3, CellType.Undecided), new GridCell(5, 4, CellType.Undecided),
                    new GridCell(5, 5, CellType.Undecided), new GridCell(5, 6, CellType.Undecided), new GridCell(5, 7, CellType.Undecided), new GridCell(5, 8, CellType.Undecided), new GridCell(5, 9, CellType.Undecided),
                    new GridCell(5, 10, CellType.Undecided),
                },
                {
                    new GridCell(6, 0, CellType.Undecided), new GridCell(6, 1, CellType.Undecided), new GridCell(6, 2, CellType.Undecided), new GridCell(6, 3, CellType.Undecided), new GridCell(6, 4, CellType.Undecided),
                    new GridCell(6, 5, CellType.Undecided), new GridCell(6, 6, CellType.Undecided), new GridCell(6, 7, CellType.Undecided), new GridCell(6, 8, CellType.Undecided), new GridCell(6, 9, CellType.Undecided),
                    new GridCell(6, 10, CellType.Undecided),
                },
                {
                    new GridCell(7, 0, CellType.Undecided), new GridCell(7, 1, CellType.Undecided), new GridCell(7, 2, CellType.Undecided), new GridCell(7, 3, CellType.Undecided), new GridCell(7, 4, CellType.Undecided),
                    new GridCell(7, 5, CellType.Undecided), new GridCell(7, 6, CellType.Undecided), new GridCell(7, 7, CellType.Undecided), new GridCell(7, 8, CellType.Undecided), new GridCell(7, 9, CellType.Undecided),
                    new GridCell(7, 10, CellType.Undecided),
                },
                {
                    new GridCell(8, 0, CellType.Undecided), new GridCell(8, 1, CellType.Undecided), new GridCell(8, 2, CellType.Undecided), new GridCell(8, 3, CellType.Undecided), new GridCell(8, 4, CellType.Undecided),
                    new GridCell(8, 5, CellType.Undecided), new GridCell(8, 6, CellType.Undecided), new GridCell(8, 7, CellType.Undecided), new GridCell(8, 8, CellType.Undecided), new GridCell(8, 9, CellType.Undecided),
                    new GridCell(8, 10, CellType.Undecided),
                },
                {
                    new GridCell(9, 0, CellType.Undecided), new GridCell(9, 1, CellType.Undecided), new GridCell(9, 2, CellType.Undecided), new GridCell(9, 3, CellType.Undecided), new GridCell(9, 4, CellType.Undecided),
                    new GridCell(9, 5, CellType.Undecided), new GridCell(9, 6, CellType.Undecided), new GridCell(9, 7, CellType.Undecided), new GridCell(9, 8, CellType.Undecided), new GridCell(9, 9, CellType.Undecided),
                    new GridCell(9, 10, CellType.Undecided),
                },
                {
                    new GridCell(10, 0, CellType.Undecided), new GridCell(10, 1, CellType.Undecided), new GridCell(10, 2, CellType.Undecided), new GridCell(10, 3, CellType.Undecided),
                    new GridCell(10, 4, CellType.Undecided), new GridCell(10, 5, CellType.Undecided), new GridCell(10, 6, CellType.Undecided), new GridCell(10, 7, CellType.Undecided),
                    new GridCell(10, 8, CellType.Undecided), new GridCell(10, 9, CellType.Undecided), new GridCell(10, 10, CellType.Undecided),
                },
            };
            Token = "X";
        }
        public GridCell[,] ShipGrid { get; set; }
        public GridCell[,] StrikeGrid { get; set; }
        public PlayerName PlayerName { get; }
        public string Token { get; }
    }

    class Ship
    {
        public readonly int id;
        private static int nextId;
        public Ship(int size)
        {
            id = nextId++;
            Size = size;
            Name = Size switch
            {
                5 => "Carrier",
                4 => "Battleship",
                3 => "Cruiser",
                _ => "Destroyer"
            };
            IsHorizontal = false;
        }
        public string Name { get; }
        public int Size { get; }
        public bool IsHorizontal { get; set; }
    }

    internal enum PlayerName
    {
        Player1,
        Player2
    }
}
