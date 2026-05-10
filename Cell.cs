namespace Coursova
{
    public enum CellType
    {
        Empty,
        Wall,
        Start,
        Finish,
        Visited,
        Path
    }
    public class Cell
    {
        public int Row { get; }
        public int Col { get; }
        public CellType Type { get; set; }
        public bool IsWall => Type == CellType.Wall;

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
            Type = CellType.Empty;
        }

        public void Reset()
        {
            if (Type != CellType.Wall && Type != CellType.Start && Type != CellType.Finish)
            {
                Type = CellType.Empty;
            }
        }
    }
}