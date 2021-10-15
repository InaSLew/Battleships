
namespace Battleships
{
    internal class Player
    {
        internal Player(PlayerName playerName)
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
        public override string ToString() => PlayerName == PlayerName.Player1 ? "Player 1" : "Player 2";
    }
}