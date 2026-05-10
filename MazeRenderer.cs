namespace Coursova
{
    public class MazeRenderer
    {
        private int _cellSize;
        public int CellSize
        {
            get { return _cellSize; }
            set { _cellSize = value; }
        }

        public MazeRenderer(int cellSize)
        {
            _cellSize = cellSize;
        }

        public void Render(Graphics g, Maze maze)
        {
            for (int r = 0; r < maze.Rows; r++)
            {
                for (int c = 0; c < maze.Cols; c++)
                {
                    Cell cell = maze.GetCell(r, c);
                    int pixelX = c * _cellSize;
                    int pixelY = r * _cellSize;
                    DrawCell(g, cell, pixelX, pixelY);
                }
            }
        }

        public void RenderCell(Graphics g, Maze maze, Cell cell)
        {
            int pixelX = cell.Col * _cellSize;
            int pixelY = cell.Row * _cellSize;
            DrawCell(g, cell, pixelX, pixelY);
        }

        public (int row, int col) GetCellByPixel(int pixelX, int pixelY)
        {
            int row = pixelY / _cellSize;
            int col = pixelX / _cellSize;
            return (row, col);
        }

        public Color GetCellColor(CellType type)
        {
            if (type == CellType.Wall)
                return Color.FromArgb(40, 40, 40); // темно-сірий

            if (type == CellType.Start)
                return Color.FromArgb(0, 200, 100); // зелений

            if (type == CellType.Finish)
                return Color.FromArgb(220, 50, 50); // червоний

            if (type == CellType.Visited)
                return Color.FromArgb(100, 160, 220); // блакитний

            if (type == CellType.Path)
                return Color.FromArgb(255, 200, 0); // жовтий

            return Color.White;// Empty - білий
        }

        private void DrawCell(Graphics g, Cell cell, int pixelX, int pixelY)
        {
            Color cellColor = GetCellColor(cell.Type);
            using (SolidBrush brush = new SolidBrush(cellColor))
            {
                g.FillRectangle(brush, pixelX, pixelY, _cellSize, _cellSize);
            }
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                g.DrawRectangle(pen, pixelX, pixelY, _cellSize, _cellSize);
            }
        }
    }
}
