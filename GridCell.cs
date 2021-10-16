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
        public int Column { get; }
        public int Row { get; }
        public string Token { get; set; }
        public CellType CellType { get; set; }
        public PlayerName? PlayerName { get; set; }
        public int ShipId { get; set; }
    }

    internal struct Coordinate
    {
        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
        }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}