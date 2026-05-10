namespace Coursova
{
    public class PathResult
    {
        public string AlgorithmName { get; set; }
        public bool IsPathFound { get; set; }
        public List<Cell> VisitedCells { get; set; }
        public List<Cell> Path { get; set; }
        public int VisitedCount { get; set; }
        public double PathLength { get; set; }
        public double ElapsedTime { get; set; } 
        public Cell StartCell { get; set; }
        public Cell FinishCell { get; set; }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }

        public PathResult(string algorithmName, Cell startCell, Cell finishCell, int mazeRows, int mazeCols)
        {
            AlgorithmName = algorithmName;
            StartCell = startCell;
            FinishCell = finishCell;
            MazeRows = mazeRows;
            MazeCols = mazeCols;

            IsPathFound = false;
            VisitedCells = new List<Cell>();
            Path = new List<Cell>();
            VisitedCount = 0;
            PathLength = 0;
            ElapsedTime = 0;
        }
    }
}