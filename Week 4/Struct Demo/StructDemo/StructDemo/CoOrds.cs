namespace StructDemo
{
    public struct Coords
    {
        public double X, Y;

        public Coords(int p1, int p2)
        {
            X = p1;
            Y = p2;
        }

        //public double X { get; set; }
        //public double Y { get; set; }

        public readonly override string ToString() => $"(X = {X}, Y = {Y})";
    }
}