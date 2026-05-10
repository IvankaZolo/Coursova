namespace Coursova
{
    public partial class MainForm : Form
    {
        private Maze _maze;
        private MazeRenderer _renderer;
        private FileManager _fileManager;
        private PathResult? _lastResult;
        private bool _isPaused;
        private bool _isDrawing;
        private bool _isFirstSave = true;
        private Queue<Cell> _visitedQueue;
        private Queue<Cell> _pathQueue;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _maze = new Maze(20, 20);
            int cellSize = Math.Min(mazePictureBox.Width / 20, mazePictureBox.Height / 20);
            _renderer = new MazeRenderer(cellSize);
            _fileManager = new FileManager("results.txt");
            _visitedQueue = new Queue<Cell>();
            _pathQueue = new Queue<Cell>();
            _isPaused = false;
            _isDrawing = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int rows;
            int cols;
            if (!ValidateMazeSize(out rows, out cols))
            {
                return;
            }
            _maze = new Maze(rows, cols);
            int cellSize = Math.Min(mazePictureBox.Width / cols, mazePictureBox.Height / rows);
            _renderer = new MazeRenderer(cellSize);
            _lastResult = null;
            mazePictureBox.Invalidate();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (_maze == null)
            {
                ShowError("Спочатку створіть лабіринт.");
                return;
            }

            int percent;

            if (!int.TryParse(txtDensity.Text, out percent))
            {
                ShowError("Будь ласка, введіть ціле число від 1 до 60.");
                return;
            }

            if (percent < 1 || percent > 60)
            {
                ShowError("Щільність стін має бути від 1 до 60%.");
                return;
            }

            double wallDensity = percent / 100.0;
            _maze.GenerateRandom(wallDensity);
            _lastResult = null;
            mazePictureBox.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_maze == null)
            {
                return;
            }
            _maze.ClearWalls();
            _lastResult = null;
            lblAlgorithm.Text = "Алгоритм:";
            lblVisited.Text = "Переглянуто вершин:";
            lblPathLength.Text = "Довжина шляху:";
            lblTime.Text = "Час виконання:";

            mazePictureBox.Invalidate();
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            PathfinderBase pathfinder = new DijkstraPathfinder();
            RunAlgorithm(pathfinder);
        }

        private void btnAStarManhattan_Click(object sender, EventArgs e)
        {
            PathfinderBase pathfinder = new AStarPathfinder(HeuristicType.Manhattan);
            RunAlgorithm(pathfinder);
        }

        private void btnAStarEuclid_Click(object sender, EventArgs e)
        {
            PathfinderBase pathfinder = new AStarPathfinder(HeuristicType.Euclidean);
            RunAlgorithm(pathfinder);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                _isPaused = false;
                animationTimer.Start();
                btnPause.Text = "Пауза";
            }
            else
            {
                _isPaused = true;
                animationTimer.Stop();
                btnPause.Text = "Продовжити";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_lastResult == null)
            {
                ShowError("Спочатку запустіть алгоритм.");
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "results.txt";
            dialog.Filter = "Текстовий файл (*.txt)|*.txt";
            dialog.Title = "Зберегти результати пошуку";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileManager fm = new FileManager(dialog.FileName);
                    fm.SaveResult(_lastResult);
                    _isFirstSave = false;
                    MessageBox.Show("Результати збережено!", "Успіх",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        private void mazePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_maze == null) return;
            var (row, col) = _renderer.GetCellByPixel(e.X, e.Y);
            if (!_maze.IsInBounds(row, col)) return;
            if (rbStart.Checked)
            {
                Cell cell = _maze.GetCell(row, col);

                if (cell.IsWall)
                {
                    MessageBox.Show("Не можна встановити старт на стіну.");
                    return;
                }
                if (cell.Type == CellType.Finish)
                {
                    MessageBox.Show("Не можна встановити старт на фініш.");
                    return;
                }
                _maze.ResetSearch();
                _maze.SetStart(row, col);
            }
            else if (rbFinish.Checked)
            {
                Cell cell = _maze.GetCell(row, col);

                if (cell.IsWall)
                {
                    MessageBox.Show("Не можна встановити фініш на стіну.");
                    return;
                }
                if (cell.Type == CellType.Start)
                {
                    MessageBox.Show("Не можна встановити фініш на старт.");
                    return;
                }
                _maze.ResetSearch();
                _maze.SetFinish(row, col);
            }
            else if (rbWall.Checked)
            {
                _isDrawing = true;
                _maze.ResetSearch();
                _maze.ToggleWall(row, col);
            }
            mazePictureBox.Invalidate();
        }

        private void mazePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_maze == null) return;
            if (_isDrawing && rbWall.Checked && e.Button == MouseButtons.Left)
            {
                var (row, col) = _renderer.GetCellByPixel(e.X, e.Y);

                if (_maze.IsInBounds(row, col))
                {
                    _maze.ToggleWall(row, col);
                    mazePictureBox.Invalidate();
                }
            }
        }

        private void mazePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }

        private void mazePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_maze != null && _renderer != null)
            {
                _renderer.Render(e.Graphics, _maze);
            }
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (_visitedQueue.Count > 0)
            {
                Cell cell = _visitedQueue.Dequeue();

                if (cell.Type != CellType.Start && cell.Type != CellType.Finish)
                {
                    cell.Type = CellType.Visited;
                }
                mazePictureBox.Invalidate();
                return;
            }

            if (_pathQueue.Count > 0)
            {
                Cell cell = _pathQueue.Dequeue();

                if (cell.Type != CellType.Start && cell.Type != CellType.Finish)
                {
                    cell.Type = CellType.Path;
                }
                mazePictureBox.Invalidate();
                return;
            }
            animationTimer.Stop();
            if (_lastResult != null)
            {
                UpdateStats(_lastResult);
            }
        }

        private void RunAlgorithm(PathfinderBase pathfinder)
        {
            if (_maze == null)
            {
                ShowError("Спочатку створіть лабіринт.");
                return;
            }

            if (_maze.Start == null)
            {
                ShowError("Встановіть стартову точку.");
                return;
            }

            if (_maze.Finish == null)
            {
                ShowError("Встановіть фінішну точку.");
                return;
            }
            _maze.ResetSearch();
            PathResult result = pathfinder.FindPath(_maze);
            _lastResult = result;
            _fileManager.SaveResult(result);
            StartAnimation(result);
        }

        private void StartAnimation(PathResult result)
        {
            _maze.ResetSearch();
            _visitedQueue = new Queue<Cell>(result.VisitedCells);
            _pathQueue = new Queue<Cell>(result.Path);
            _isPaused = false;
            btnPause.Text = "Пауза";
            animationTimer.Start();
        }

        private void UpdateStats(PathResult result)
        {
            lblAlgorithm.Text = "Алгоритм: " + result.AlgorithmName;
            lblVisited.Text = "Переглянуто вершин: " + result.VisitedCount;
            lblTime.Text = "Час виконання: " + result.ElapsedTime.ToString("F4") + " мс";

            if (result.IsPathFound)
            {
                lblPathLength.Text = "Довжина шляху: " + result.PathLength.ToString("F2");
            }
            else
            {
                lblPathLength.Text = "Шлях не знайдено";
            }
        }

        private bool ValidateMazeSize(out int rows, out int cols)
        {
            rows = 0;
            cols = 0;

            if (!int.TryParse(txtRows.Text, out rows))
            {
                ShowError("Введіть ціле число для кількості рядків.");
                return false;
            }

            if (!int.TryParse(txtCols.Text, out cols))
            {
                ShowError("Введіть ціле число для кількості стовпців.");
                return false;
            }

            if (rows < 10 || rows > 100)
            {
                ShowError("Кількість рядків має бути від 10 до 100.");
                return false;
            }

            if (cols < 10 || cols > 100)
            {
                ShowError("Кількість стовпців має бути від 10 до 100.");
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}