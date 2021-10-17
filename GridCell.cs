namespace Battleships
{
    internal class GridCell
    {
        public GridCell(int row, int column, CellType cellType, string token = "", PlayerName? playerName = null)
        {
            Column = column;
            Row = row;
            Token = token;
            CellType = cellType;
            PlayerName = playerName;
        }

        private int Column { get; }
        private int Row { get; }
        internal string Token { get; set; }
        internal CellType CellType { get; set; }
        internal PlayerName? PlayerName { get; set; }
        internal int ShipId { get; set; }
    }

    internal struct Coordinate
    {
        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
        }
        internal int Column { get; set; }
        internal int Row { get; set; }
    }
}