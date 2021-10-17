namespace Battleships
{
    internal class Ship
    {
        internal readonly int Id;
        public Ship(int size, int id)
        {
            Id = id;
            Size = size;
            Name = Size switch
            {
                5 => "Carrier",
                4 => "Battleship",
                3 => "Cruiser",
                _ => "Destroyer"
            };
            IsHorizontal = false;
            Health = size;
        }
        internal string Name { get; }
        internal int Size { get; }
        internal bool IsHorizontal { get; set; }
        private int Health { get; set; }
        internal bool IsSunken => Health == 0;
        internal void TakeHit() => Health -= 1;
    }
}