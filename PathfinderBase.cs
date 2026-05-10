namespace Coursova
{
    public abstract class PathfinderBase
    {
        public abstract string Name { get; }
        public abstract PathResult FindPath(Maze maze);
        protected List<Cell> ReconstructPath(Cell?[,] predecessors, Cell finish)
        {
            var path = new List<Cell>();
            Cell? current = finish;
            while (current != null)
            {
                path.Insert(0, current);
                current = predecessors[current.Row, current.Col];
            }
            return path;
        }

        protected double CalculatePathLength(List<Cell> path)
        {
            double length = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                Cell current = path[i];
                Cell next = path[i + 1];
                bool isDiagonal = (current.Row != next.Row) && (current.Col != next.Col);
                length += isDiagonal ? Math.Sqrt(2) : 1.0;
            }
            return length;
        }
    }
}
