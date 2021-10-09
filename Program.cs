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
            Console.WriteLine("Where would you like to place your 5X ship?");
            Console.WriteLine();
            UpdatePlayerGrid();
        }

        private static void UpdatePlayerGrid()
        {
            var rows = playerGrid.GetLength(0);
            var cols = playerGrid.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                var tmp = "";
                for(var j = 0; j < cols; j++)
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

                    // if (i == 1 && j == 2)
                    // {
                    //     tmp += "X_|";
                    // }
                    // else tmp += "__|";
                    tmp += "__|";
                }
                Console.WriteLine(tmp);
            }
        }
    }

}
