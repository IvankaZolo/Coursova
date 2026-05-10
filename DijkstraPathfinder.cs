using System.Diagnostics;

namespace Coursova
{
    public class DijkstraPathfinder : PathfinderBase
    {
        public override string Name => "Алгоритм Дейкстри";
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
            double[,] d = new double[maze.Rows, maze.Cols];
            Cell?[,] predecessors = new Cell?[maze.Rows, maze.Cols];
            bool[,] visited = new bool[maze.Rows, maze.Cols];

            for (int r = 0; r < maze.Rows; r++)
            {
                for (int c = 0; c < maze.Cols; c++)
                {
                    d[r, c] = double.MaxValue;
                }
            }

            d[start.Row, start.Col] = 0;
            int visitedCount = 0;
            PriorityQueue<Cell, double> queue = new PriorityQueue<Cell, double>();
            queue.Enqueue(start, 0);

            while (queue.Count > 0)
            {
                Cell current = queue.Dequeue();
                int r = current.Row;
                int c = current.Col;

                if (visited[r, c] == true)
                {
                    continue;
                }
                visited[r, c] = true;
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
                    double newDist = d[r, c] + weight;
                    if (newDist < d[nr, nc])
                    {
                        d[nr, nc] = newDist;
                        predecessors[nr, nc] = current;
                        queue.Enqueue(neighbor, newDist);
                    }
                }
            }
            stopwatch.Stop();
            result.VisitedCount = visitedCount;
            result.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

            if (visited[finish.Row, finish.Col] == true)
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
    }
}