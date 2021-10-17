namespace Battleships
{
    public class Ship
    {
        public readonly int id;
        public Ship(int size, int id)
        {
            this.id = id;
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
        public string Name { get; }
        public int Size { get; }
        public bool IsHorizontal { get; set; }
        private int Health { get; set; }
        public bool IsSunken => Health == 0;
        public void TakeHit() => Health -= 1;
    }
}