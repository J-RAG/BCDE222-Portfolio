namespace ChessMaze
{
    // Coordinates used for positioning
    public class Coord
    {
        public int Row { get; set; }
        public int Col {get; set;}

        public Coord(int row, int col) 
        {
            Row = row; 
            Col = col;
        }
    }
}