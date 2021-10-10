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
        
        static void Main()
        {
            Console.WriteLine("Welcome to Battleships!");
            Console.WriteLine();
            UpdatePlayerGrid();
            Console.WriteLine("Where would you like to place your 5X ship?");
            var position = Console.ReadLine();
            Console.WriteLine("Horizontal? (y/n)");
            var isHorizontal = Console.ReadLine() == "y";
            var ship = new Ship(RowTitles.IndexOf(position[1]), ColumnTitles.IndexOf(position[0]), isHorizontal);
            UpdatePlayerGrid(ship);
        }

        private static void UpdatePlayerGrid(Ship shipToDraw = null)
        {
            var rows = playerGrid.GetLength(0);
            var cols = playerGrid.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                var tmp = "";
                for(int j = 0; j < cols; j++)
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

                    // if (shipToDraw != null && i == shipToDraw.Position.Item1 + 1 && j == shipToDraw.Position.Item2 + 1)
                    if (shipToDraw != null)
                    {
                        var startRowPosition = shipToDraw.Position.Item1 + 1;
                        var startColPosition = shipToDraw.Position.Item2 + 1;
                        if (shipToDraw.IsHorizontal)
                        {
                            if (i == startRowPosition && j == startColPosition) tmp += "X_|";
                            else if (i == startRowPosition && j == startColPosition + 1) tmp += "X_|";
                            else tmp += "__|";
                        }
                        else
                        {
                            if (i == startRowPosition && j == startColPosition) tmp += "X_|";
                            else if (i == startRowPosition + 1 && j == startColPosition) tmp += "X_|";
                            else tmp += "__|";
                        }
                    }
                    else tmp += "__|";
                }
                Console.WriteLine(tmp);
            }
        }
    }

    class Ship
    {
        private int row;
        private int column;
        public bool IsHorizontal {get;}
        public (int, int) Position {get;}

        public Ship(int row, int column, bool isHorizontal)
        {
            IsHorizontal = isHorizontal;
            this.row = row;
            this.column = column;
            Position = (row, column);
        }
        
    }
}
