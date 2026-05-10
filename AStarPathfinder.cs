using System.Diagnostics;

namespace Coursova
{
    public enum HeuristicType
    {
        Manhattan,  
        Euclidean  
    }
    public class AStarPathfinder : PathfinderBase
    {
        private HeuristicType _heuristicType;
        public override string Name
        {
            get
            {
                if (_heuristicType == HeuristicType.Manhattan)
                    return "Алгоритм A* (манхеттен)";
                else
                    return "Алгоритм A* (евклід)";
            }
        }

        public AStarPathfinder(HeuristicType heuristicType)
        {
            _heuristicType = heuristicType;
        }

        public override PathResult FindPath(Maze maze)
        {
            Cell start = maze.Start!;
            Cell finish = maze.Finish!;

            PathResult result = new PathResult(
                Name,
                start,
                finish,
                maze.Rows,
                maze.Cols
            );

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double[,] g = new double[maze.Rows, maze.Cols];
            double[,] f = new double[maze.Rows, maze.Cols];
            Cell?[,] predecessors = new Cell?[maze.Rows, maze.Cols];
            bool[,] closedSet = new bool[maze.Rows, maze.Cols];
            for (int r = 0; r < maze.Rows; r++)
            {
                for (int c = 0; c < maze.Cols; c++)
                {
                    g[r, c] = double.MaxValue;
                    f[r, c] = double.MaxValue;
                }
            }

            g[start.Row, start.Col] = 0;
            f[start.Row, start.Col] = ComputeHeuristic(start, finish);
            int visitedCount = 0;
            PriorityQueue<Cell, double> openSet = new PriorityQueue<Cell, double>();
            openSet.Enqueue(start, f[start.Row, start.Col]);

            while (openSet.Count > 0)
            {
                Cell current = openSet.Dequeue();
                int r = current.Row;
                int c = current.Col;

                if (closedSet[r, c] == true)
                {
                    continue;
                }

                closedSet[r, c] = true;
                visitedCount++;
                result.VisitedCells.Add(current);

                if (current.Type != CellType.Start && current.Type != CellType.Finish)
                {
                    current.Type = CellType.Visited;
                }

                if (r == finish.Row && c == finish.Col)
                {
                    break;
                }
                List<(Cell neighbor, double weight)> neighbors = maze.GetNeighbors(current);
                foreach (var (neighbor, weight) in neighbors)
                {
                    int nr = neighbor.Row;
                    int nc = neighbor.Col;

                    if (closedSet[nr, nc] == true)
                    {
                        continue;
                    }
                    double gNew = g[r, c] + weight;
                    if (gNew < g[nr, nc])
                    {
                        g[nr, nc] = gNew;
                        predecessors[nr, nc] = current;
                        f[nr, nc] = gNew + ComputeHeuristic(neighbor, finish);
                        openSet.Enqueue(neighbor, f[nr, nc]);
                    }
                }
            }
            stopwatch.Stop();
            result.VisitedCount = visitedCount;
            result.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

            if (closedSet[finish.Row, finish.Col] == true)
            {
                List<Cell> path = ReconstructPath(predecessors, finish);
                foreach (Cell cell in path)
                {
                    if (cell.Type != CellType.Start && cell.Type != CellType.Finish)
                    {
                        cell.Type = CellType.Path;
                    }
                }
                result.IsPathFound = true;
                result.Path = path;
                result.PathLength = CalculatePathLength(path);
            }
            return result;
        }

        private double ComputeHeuristic(Cell from, Cell to)
        {
            if (_heuristicType == HeuristicType.Manhattan)
            {
                return Math.Abs(from.Row - to.Row) +
                       Math.Abs(from.Col - to.Col);
            }
            else
            {
                double dr = from.Row - to.Row;
                double dc = from.Col - to.Col;
                return Math.Sqrt(dr * dr + dc * dc);
            }
        }
    }
}