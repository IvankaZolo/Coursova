using System.Text;

namespace Coursova
{
    public class FileManager
    {
        private string _filePath;
        private bool _overwrite;
        public FileManager(string filePath)
        {
            _filePath = filePath;
        }
        public void SaveResult(PathResult result)
        {
            try
            {
                string text = FormatResult(result);
                if (_overwrite)
                {
                    File.WriteAllText(_filePath, text);
                    _overwrite = false;
                }
                else
                {
                    File.AppendAllText(_filePath, text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка збереження файлу: " + ex.Message);
            }
        }
        private string FormatResult(PathResult result)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----");
            sb.AppendLine($"Дата та час: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine($"Алгоритм: {result.AlgorithmName}");
            sb.AppendLine($"Розмір сітки: {result.MazeRows} x {result.MazeCols}");
            sb.AppendLine($"Старт: ({result.StartCell.Row}, {result.StartCell.Col})");
            sb.AppendLine($"Фініш: ({result.FinishCell.Row}, {result.FinishCell.Col})");
            sb.AppendLine($"Переглянуто вершин: {result.VisitedCount}");
            sb.AppendLine($"Час виконання: {result.ElapsedTime} мс");

            if (result.IsPathFound)
                sb.AppendLine($"Довжина шляху: {result.PathLength:F2}");
            else
                sb.AppendLine("Шлях не знайдено");

            sb.AppendLine(); 
            return sb.ToString();
        }
    }
}
