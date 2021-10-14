namespace Battleships
{
    internal class GridCell
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
}