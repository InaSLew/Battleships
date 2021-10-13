using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    
    class Program
    {

        static void Main()
        {
            // TODO Use 4 2D-arrays (each player got one ship grid and one strike grid)
            // TODO Each grid should store information inside the cells
            // TODO A draw function to draw the grid and nothing else
            // TODO A write function to write onto the grid and nothing else
            var player1 = new Player(PlayerName.Player1);
            //var player2 = new Player(PlayerName.Player2);

            DrawShipGrid(player1);
            // ask for input
            // WriteGrid(player1, col, row);
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
                    if (rowIdx == 0 && colIdx >= 1)
                    {
                        tmp += $"_{Convert.ToChar(colIdx - 1 + 65)}|";
                    }
                    else if (colIdx == 0 && rowIdx >= 1)
                    {
                        tmp += $"_{rowIdx - 1}|";
                    }
                    else tmp += "__|";


                }
                Console.WriteLine(tmp);
            }
        }
    }

    struct GridCell
    {
        public GridCell(int column, int row)
        {
            Column = column;
            Row = row;
            Token = "";
            CellType = CellType.Undecided;
        }
        public int Column { get; }
        public int Row { get; }
        public string Token { get; set; }
        public CellType CellType { get; }
    }

    internal enum CellType
    {
        Ship,
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
                    new GridCell(0, 0), new GridCell(0, 1), new GridCell(0, 2), new GridCell(0, 3), new GridCell(0, 4),
                    new GridCell(0, 5), new GridCell(0, 6), new GridCell(0, 7), new GridCell(0, 8), new GridCell(0, 9),
                    new GridCell(0, 10),
                },
                {
                    new GridCell(1, 0), new GridCell(1, 1), new GridCell(1, 2), new GridCell(1, 3), new GridCell(1, 4),
                    new GridCell(1, 5), new GridCell(1, 6), new GridCell(1, 7), new GridCell(1, 8), new GridCell(1, 9),
                    new GridCell(1, 10),
                },
                {
                    new GridCell(2, 0), new GridCell(2, 1), new GridCell(2, 2), new GridCell(2, 3), new GridCell(2, 4),
                    new GridCell(2, 5), new GridCell(2, 6), new GridCell(2, 7), new GridCell(2, 8), new GridCell(2, 9),
                    new GridCell(2, 10),
                },
                {
                    new GridCell(3, 0), new GridCell(3, 1), new GridCell(3, 2), new GridCell(3, 3), new GridCell(3, 4),
                    new GridCell(3, 5), new GridCell(3, 6), new GridCell(3, 7), new GridCell(3, 8), new GridCell(3, 9),
                    new GridCell(3, 10),
                },
                {
                    new GridCell(4, 0), new GridCell(4, 1), new GridCell(4, 2), new GridCell(4, 3), new GridCell(4, 4),
                    new GridCell(4, 5), new GridCell(4, 6), new GridCell(4, 7), new GridCell(4, 8), new GridCell(4, 9),
                    new GridCell(4, 10),
                },
                {
                    new GridCell(5, 0), new GridCell(5, 1), new GridCell(5, 2), new GridCell(5, 3), new GridCell(5, 4),
                    new GridCell(5, 5), new GridCell(5, 6), new GridCell(5, 7), new GridCell(5, 8), new GridCell(5, 9),
                    new GridCell(5, 10),
                },
                {
                    new GridCell(6, 0), new GridCell(6, 1), new GridCell(6, 2), new GridCell(6, 3), new GridCell(6, 4),
                    new GridCell(6, 5), new GridCell(6, 6), new GridCell(6, 7), new GridCell(6, 8), new GridCell(6, 9),
                    new GridCell(6, 10),
                },
                {
                    new GridCell(7, 0), new GridCell(7, 1), new GridCell(7, 2), new GridCell(7, 3), new GridCell(7, 4),
                    new GridCell(7, 5), new GridCell(7, 6), new GridCell(7, 7), new GridCell(7, 8), new GridCell(7, 9),
                    new GridCell(7, 10),
                },
                {
                    new GridCell(8, 0), new GridCell(8, 1), new GridCell(8, 2), new GridCell(8, 3), new GridCell(8, 4),
                    new GridCell(8, 5), new GridCell(8, 6), new GridCell(8, 7), new GridCell(8, 8), new GridCell(8, 9),
                    new GridCell(8, 10),
                },
                {
                    new GridCell(9, 0), new GridCell(9, 1), new GridCell(9, 2), new GridCell(9, 3), new GridCell(9, 4),
                    new GridCell(9, 5), new GridCell(9, 6), new GridCell(9, 7), new GridCell(9, 8), new GridCell(9, 9),
                    new GridCell(9, 10),
                },
                {
                    new GridCell(10, 0), new GridCell(10, 1), new GridCell(10, 2), new GridCell(10, 3),
                    new GridCell(10, 4), new GridCell(10, 5), new GridCell(10, 6), new GridCell(10, 7),
                    new GridCell(10, 8), new GridCell(10, 9), new GridCell(10, 10),
                },
            };
            StrikeGrid = new GridCell[11, 11]
            {
                {
                    new GridCell(0, 0), new GridCell(0, 1), new GridCell(0, 2), new GridCell(0, 3), new GridCell(0, 4),
                    new GridCell(0, 5), new GridCell(0, 6), new GridCell(0, 7), new GridCell(0, 8), new GridCell(0, 9),
                    new GridCell(0, 10),
                },
                {
                    new GridCell(1, 0), new GridCell(1, 1), new GridCell(1, 2), new GridCell(1, 3), new GridCell(1, 4),
                    new GridCell(1, 5), new GridCell(1, 6), new GridCell(1, 7), new GridCell(1, 8), new GridCell(1, 9),
                    new GridCell(1, 10),
                },
                {
                    new GridCell(2, 0), new GridCell(2, 1), new GridCell(2, 2), new GridCell(2, 3), new GridCell(2, 4),
                    new GridCell(2, 5), new GridCell(2, 6), new GridCell(2, 7), new GridCell(2, 8), new GridCell(2, 9),
                    new GridCell(2, 10),
                },
                {
                    new GridCell(3, 0), new GridCell(3, 1), new GridCell(3, 2), new GridCell(3, 3), new GridCell(3, 4),
                    new GridCell(3, 5), new GridCell(3, 6), new GridCell(3, 7), new GridCell(3, 8), new GridCell(3, 9),
                    new GridCell(3, 10),
                },
                {
                    new GridCell(4, 0), new GridCell(4, 1), new GridCell(4, 2), new GridCell(4, 3), new GridCell(4, 4),
                    new GridCell(4, 5), new GridCell(4, 6), new GridCell(4, 7), new GridCell(4, 8), new GridCell(4, 9),
                    new GridCell(4, 10),
                },
                {
                    new GridCell(5, 0), new GridCell(5, 1), new GridCell(5, 2), new GridCell(5, 3), new GridCell(5, 4),
                    new GridCell(5, 5), new GridCell(5, 6), new GridCell(5, 7), new GridCell(5, 8), new GridCell(5, 9),
                    new GridCell(5, 10),
                },
                {
                    new GridCell(6, 0), new GridCell(6, 1), new GridCell(6, 2), new GridCell(6, 3), new GridCell(6, 4),
                    new GridCell(6, 5), new GridCell(6, 6), new GridCell(6, 7), new GridCell(6, 8), new GridCell(6, 9),
                    new GridCell(6, 10),
                },
                {
                    new GridCell(7, 0), new GridCell(7, 1), new GridCell(7, 2), new GridCell(7, 3), new GridCell(7, 4),
                    new GridCell(7, 5), new GridCell(7, 6), new GridCell(7, 7), new GridCell(7, 8), new GridCell(7, 9),
                    new GridCell(7, 10),
                },
                {
                    new GridCell(8, 0), new GridCell(8, 1), new GridCell(8, 2), new GridCell(8, 3), new GridCell(8, 4),
                    new GridCell(8, 5), new GridCell(8, 6), new GridCell(8, 7), new GridCell(8, 8), new GridCell(8, 9),
                    new GridCell(8, 10),
                },
                {
                    new GridCell(9, 0), new GridCell(9, 1), new GridCell(9, 2), new GridCell(9, 3), new GridCell(9, 4),
                    new GridCell(9, 5), new GridCell(9, 6), new GridCell(9, 7), new GridCell(9, 8), new GridCell(9, 9),
                    new GridCell(9, 10),
                },
                {
                    new GridCell(10, 0), new GridCell(10, 1), new GridCell(10, 2), new GridCell(10, 3),
                    new GridCell(10, 4), new GridCell(10, 5), new GridCell(10, 6), new GridCell(10, 7),
                    new GridCell(10, 8), new GridCell(10, 9), new GridCell(10, 10),
                },
            };
        }
        public GridCell[,] ShipGrid { get; set; }
        public GridCell[,] StrikeGrid { get; set; }
        public PlayerName PlayerName { get; }
    }

    internal enum PlayerName
    {
        Player1,
        Player2
    }
}
