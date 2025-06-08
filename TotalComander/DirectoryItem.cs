using System;
using System.IO;

namespace FileManager
{
    public class DirectoryItem : BaseFileSystemItem
    {
        private string previousDirectory;
        public DirectoryItem(string path) : base(path)
        {
            previousDirectory = Directory.GetCurrentDirectory();
        }
        public override void Create(string newName)
        {
            string newPath = System.IO.Path.Combine(Path, newName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
                Console.WriteLine("Створено директорію");
            }
            else
            {
                Console.WriteLine("Директорія вже існує");
            }
        }
        public override void Delete(string newName)
        {
            string newPath = System.IO.Path.Combine(Path, newName);
            if (Directory.Exists(newPath))
            {
                Directory.Delete(newPath);
                Console.WriteLine("Директорія видалена");
            }
            else
            {
                Console.WriteLine("Директорія не знайдена");
            }
        }
        public void ChangeCurrentDirectory(String newDirectory)
        {

            if (Directory.Exists(newDirectory))
            {
                previousDirectory = Path;
                Path = newDirectory;
            }
            else
            {
                Console.WriteLine("Вказана директорія не існує");
            }
        }
        public void GoToPreviousDirectory()
        {
            if (Directory.Exists(previousDirectory))
            {
                (Path, previousDirectory) = (previousDirectory, Path);
            }
            else
            {
                Console.WriteLine("Немає директорї для повернення");
            }
        }
        public void ClearDirectory()
        {
            var directoryInfo = new DirectoryInfo(Path);
            foreach (FileSystemInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                dir.Delete(true);
                
            }
        }
    }
}