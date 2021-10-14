namespace Battleships
{
    public class Ship
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
}