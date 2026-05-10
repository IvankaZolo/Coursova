namespace Coursova
{
    public class Maze
    {
        private Cell[,] _grid;
        private Cell? _start;
        private Cell? _finish;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Cell? Start => _start;
        public Cell? Finish => _finish;

        public Maze(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _grid = new Cell[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    _grid[r, c] = new Cell(r, c);
                }
            }
        }

        public Cell GetCell(int row, int col)
        {
            return _grid[row, col];
        }

        public bool IsInBounds(int row, int col)
        {
            if (row < 0 || row >= Rows) return false;
            if (col < 0 || col >= Cols) return false;
            return true;
        }

        public bool SetStart(int row, int col)
        {
            if (!IsInBounds(row, col)) return false;
            Cell cell = _grid[row, col];
            if (cell.IsWall == true) return false;
            if (cell.Type == CellType.Finish) return false;
            if (_start != null)
            {
                _start.Type = CellType.Empty;
            }
            _start = cell;
            cell.Type = CellType.Start;
            return true;
        }

        public bool SetFinish(int row, int col)
        {
            if (!IsInBounds(row, col)) return false;
            Cell cell = _grid[row, col];
            if (cell.IsWall == true) return false;
            if (cell.Type == CellType.Start) return false;
            if (_finish != null)
            {
                _finish.Type = CellType.Empty;
            }
            _finish = cell;
            cell.Type = CellType.Finish;
            return true;
        }

        public bool ToggleWall(int row, int col)
        {
            if (!IsInBounds(row, col)) return false;
            Cell cell = _grid[row, col];
            if (cell.Type == CellType.Start) return false;
            if (cell.Type == CellType.Finish) return false;
            if (cell.IsWall == true)
            {
                cell.Type = CellType.Empty;
            }
            else
            {
                cell.Type = CellType.Wall;
            }
            return true;
        }

        public void ClearWalls()
        {
            _start = null;
            _finish = null;
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    _grid[r, c].Type = CellType.Empty;
                }
            }
        }

        public void ResetSearch()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    _grid[r, c].Reset();
                }
            }
        }

        public void GenerateRandom(double wallDensity)
        {
            _start = null;
            _finish = null;
            Random random = new Random();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    double p = random.NextDouble();

                    if (p < wallDensity)
                    {
                        _grid[r, c].Type = CellType.Wall;
                    }
                    else
                    {
                        _grid[r, c].Type = CellType.Empty;
                    }
                }
            }
        }

        public List<(Cell neighbor, double weight)> GetNeighbors(Cell cell)
        {
            List<(Cell, double)> result = new List<(Cell, double)>();
            int r = cell.Row;
            int c = cell.Col;
            int[] dr = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dc = { 0, 0, -1, 1, -1, 1, -1, 1 };
            double[] weights = { 1.0, 1.0, 1.0, 1.0, Math.Sqrt(2), Math.Sqrt(2), Math.Sqrt(2), Math.Sqrt(2) };

            for (int i = 0; i < 8; i++)
            {
                int nr = r + dr[i];
                int nc = c + dc[i];
                if (!IsInBounds(nr, nc)) continue;
                if (_grid[nr, nc].IsWall) continue;

                bool isDiagonal = (dr[i] != 0 && dc[i] != 0);
                if (isDiagonal)
                {
                    if (_grid[r, nc].IsWall && _grid[nr, c].IsWall)
                    {
                        continue;
                    }
                }
                result.Add((_grid[nr, nc], weights[i]));
            }
            return result;
        }
    }
}