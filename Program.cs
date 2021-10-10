using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    
    class Program
    {
        // Two players
        // 10x10 grid per player
        // Ships: sizes 5,4,3,2,2
        // Ships may be placed vertically or horizontally
        //     ships may not overlap and may not touch each other
        //     there needs to be at least one empty grid cell around the ship (in every direction)
        private static string ColumnTitles = "abcdefghij";
        private static string RowTitles = "0123456789";
        private static string[,] playerGrid = new string[11,11]
        {
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""}
        };
        private static string[,] strikeGrid = new string[11,11]
        {
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", "", "", "", ""}
        };

        private static Player currentPlayer;
        private static List<PlayerMoveLog> moveLog = new List<PlayerMoveLog>();
        
        static void Main()
        {
            Console.WriteLine("Welcome to Battleships!");
            Console.WriteLine();
            InitializePlayer1();
            UpdatePlayerGrid();
            Console.WriteLine("Where would you like to place your 5X ship?");
            var position = Console.ReadLine();
            Console.WriteLine("Horizontal? (y/n)");
            var isHorizontal = Console.ReadLine() == "y";
            var ship = new Ship(RowTitles.IndexOf(position[1]), ColumnTitles.IndexOf(position[0]), isHorizontal, 5);
            UpdatePlayerGrid(ship);
        }

        private static void InitializePlayer1()
        {
            currentPlayer = Player.Player1;
        }

        private static void UpdatePlayerGrid(Ship shipToDraw = null)
        {
            var rows = playerGrid.GetLength(0);
            var cols = playerGrid.GetLength(1);
            var logEntry = new PlayerMoveLog(currentPlayer, shipToDraw);
            for (int i = 0, l = 0; i < rows; i++)
            {
                // var logEntry = new PlayerMoveLog(currentPlayer, shipToDraw);
                var tmp = "";
                for(int j = 0, k = 0; j < cols; j++)
                {
                    if (i == 0 && j != 0)
                    {
                        tmp += ColumnTitles[j-1] + "_|";
                        continue;
                    }
                    if (i != 0 && j == 0)
                    {
                        tmp += RowTitles[i-1] + "_|";
                        continue;
                    }

                    if (shipToDraw != null)
                    {
                        var startRowPosition = shipToDraw.StartPosition.Item1 + 1;
                        var startColPosition = shipToDraw.StartPosition.Item2 + 1;
                        var occupiedPosition = (-1, -1, false);

                        if (shipToDraw.IsHorizontal)
                        {
                            if (i == startRowPosition && j == startColPosition + k)
                            {
                                tmp += "X_|";
                                logEntry.OccupiedPositions.Add((i, j, false));
                                k++;
                                if (k == shipToDraw.Size) k = 0;
                            }
                            else tmp += "__|";
                        }
                        else
                        {
                            if (i == startRowPosition + l && j == startColPosition)
                            {
                                tmp += "X_|";
                                logEntry.OccupiedPositions.Add((i, j, false));
                                l++;
                                if (l == shipToDraw.Size) l = 0;
                            }
                            else tmp += "__|";
                        }

                        // if (occupiedPosition.Item1 != -1 && occupiedPosition.Item2 != -1) logEntry.OccupiedPositions.Add(occupiedPosition);
                    }
                    else tmp += "__|";
                }
                // if (logEntry.OccupiedPositions.Any()) moveLog.Add(logEntry);
                Console.WriteLine(tmp);
            }
            if (logEntry.Ship != null) moveLog.Add(logEntry);
        }
    }

    class PlayerMoveLog
    {
        public Player Player {get;}
        public Ship Ship {get;}
        public List<(int, int, bool)> OccupiedPositions {get; set; }

        public PlayerMoveLog(Player currentPlayer, Ship ship)
        {
            Player = currentPlayer;
            Ship = ship;
            OccupiedPositions = new List<(int, int, bool)>();
        }
    }

    enum Player
    {
        Player1,
        Player2
    }

    class Ship
    {
        private int row;
        private int column;
        public bool IsHorizontal {get;}
        public (int, int) StartPosition {get;}
        public int Size {get;}

        public Ship(int row, int column, bool isHorizontal, int size)
        {
            IsHorizontal = isHorizontal;
            this.row = row;
            this.column = column;
            StartPosition = (row, column);
            Size = size;
        }
        
    }
}
