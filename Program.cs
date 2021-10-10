using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    
    class Program
    {
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
        private static List<MoveLogEntry> moveLog = new List<MoveLogEntry>();
        private static bool isStrikePhase;
        private static bool isGameOver;
        
        static void Main()
        {
            isGameOver = false;
            Console.WriteLine("Welcome to Battleships!");
            Console.WriteLine();

            isStrikePhase = false;
            currentPlayer = Player.Player1;
            Console.WriteLine("Player1's turn");
            Console.WriteLine("Where would you like to place your 5X ship?");
            UpdateGrid(playerGrid);
            var position = Console.ReadLine();
            Console.WriteLine("Horizontal? (y/n)");
            var isHorizontal = Console.ReadLine() == "y";
            var mark = new Mark(RowTitles.IndexOf(position[1]), ColumnTitles.IndexOf(position[0]), isHorizontal, 5);
            UpdateGrid(playerGrid, markToDraw: mark);

            currentPlayer = Player.Player2;
            Console.WriteLine("Player2's turn");
            Console.WriteLine("Where would you like to place your 5X ship?");
            UpdateGrid(playerGrid);
            var position2 = Console.ReadLine();
            Console.WriteLine("Horizontal? (y/n)");
            var isHorizontal2 = Console.ReadLine() == "y";
            var mark2 = new Mark(RowTitles.IndexOf(position2[1]), ColumnTitles.IndexOf(position2[0]), isHorizontal2, 5);
            UpdateGrid(playerGrid, markToDraw: mark2);

            currentPlayer = Player.Player1;

            while (!isGameOver)
            {
                isStrikePhase = true;
                // UpdateGrid(playerGrid);
                // Console.WriteLine("Where would you like to place your 5X ship?");
                // var position = Console.ReadLine();
                // Console.WriteLine("Horizontal? (y/n)");
                // var isHorizontal = Console.ReadLine() == "y";
                // var mark = new Mark(RowTitles.IndexOf(position[1]), ColumnTitles.IndexOf(position[0]), isHorizontal, 5);
                // UpdateGrid(playerGrid, markToDraw: mark);
                Console.WriteLine($"{currentPlayer}'s turn");
                Console.WriteLine("Where would you like to strike?");
                UpdateGrid(strikeGrid);
                var strikePosition = Console.ReadLine();
                CheckIsHit(strikePosition);
                SwitchPlayer();
            }
        }

        private static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
        }

        private static void CheckIsHit(string? strikePosition)
        {
            var rowPosition = RowTitles.IndexOf(strikePosition[1]) + 1;
            var colPosition = ColumnTitles.IndexOf(strikePosition[0]) + 1;
            var opponent = currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
            var isHit = false;
            for (int i = 0; i < moveLog.Count; i++)
            {
                var tmp = moveLog[i];
                var index = tmp.OccupiedPositions.FindIndex(x => x == (rowPosition, colPosition, false));
                if (tmp.Player == opponent && index != -1)
                {
                    Console.WriteLine("HIT!");
                    tmp.OccupiedPositions.ToArray()[index].Item3 = true;
                    isHit = true;
                    break;
                }
            }
            if (!isHit) Console.WriteLine("MISSED :(");
            var mark = new Mark(RowTitles.IndexOf(strikePosition[1]), ColumnTitles.IndexOf(strikePosition[0]), false,
                1);
            UpdateGrid(strikeGrid, sign: isHit ? "X" : "O", markToDraw: mark);
        }

        private static void InitializePlayer1()
        {
            currentPlayer = Player.Player1;
        }

        private static void UpdateGrid(string[,] targetGrid, string sign = "X", Mark markToDraw = null)
        {
            var rows = targetGrid.GetLength(0);
            var cols = targetGrid.GetLength(1);
            var logEntry = new MoveLogEntry(currentPlayer, markToDraw, isStrikePhase);
            for (int i = 0, l = 0; i < rows; i++)
            {
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

                    if (markToDraw != null)
                    {
                        var startRowPosition = markToDraw.StartPosition.Item1 + 1;
                        var startColPosition = markToDraw.StartPosition.Item2 + 1;

                        if (markToDraw.IsHorizontal)
                        {
                            if (i == startRowPosition && j == startColPosition + k)
                            {
                                tmp += $"{sign}_|";
                                logEntry.OccupiedPositions.Add((i, j, false));
                                k++;
                                if (k == markToDraw.Size) k = 0;
                            }
                            else tmp += "__|";
                        }
                        else
                        {
                            if (i == startRowPosition + l && j == startColPosition)
                            {
                                tmp += $"{sign}_|";
                                logEntry.OccupiedPositions.Add((i, j, false));
                                l++;
                                if (l == markToDraw.Size) l = 0;
                            }
                            else tmp += "__|";
                        }
                    }
                    else tmp += "__|";
                }
                Console.WriteLine(tmp);
            }
            if (logEntry.Mark != null) moveLog.Add(logEntry);
        }
    }

    class MoveLogEntry
    {
        public Player Player {get;}
        public Mark Mark {get;}
        private List<(int, int, bool)> occupiedPositions; 
        public List<(int, int, bool)> OccupiedPositions {get => occupiedPositions; set => occupiedPositions = value; }
        public bool IsStrikePhase { get; }

        public MoveLogEntry(Player currentPlayer, Mark mark, bool isStrikePhase)
        {
            Player = currentPlayer;
            Mark = mark;
            occupiedPositions = new List<(int, int, bool)>();
            IsStrikePhase = isStrikePhase;
        }
    }

    // class StrikeLogEntry
    // {
    //     public Player Player { get; set; }
    //     public List<(int, int, bool)> StrikePositions {get; set; }
    //
    //     public StrikeLogEntry(Player player)
    //     {
    //         Player = player;
    //         StrikePositions = new List<(int, int, bool)>();
    //     }
    // }

    enum Player
    {
        Player1,
        Player2
    }

    class Mark
    {
        private int row;
        private int column;
        public bool IsHorizontal {get;}
        public (int, int) StartPosition {get;}
        public int Size {get;}

        public Mark(int row, int column, bool isHorizontal, int size)
        {
            IsHorizontal = isHorizontal;
            this.row = row;
            this.column = column;
            StartPosition = (row, column);
            Size = size;
        }
        
    }
}
