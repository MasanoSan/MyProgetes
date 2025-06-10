using System;
using System.IO;

namespace FileManager
{
    public class FileItem : BaseFileSystemItem
    {
        public FileItem(string path) : base(path) { }
        public override void Create(string newName)
        {
            string newFile = System.IO.Path.Combine(Path, newName);
            File.Create(newFile);
            Console.WriteLine("Файл створено");
        }
        public override void Delete(string newName)
        {
            string delFile = System.IO.Path.Combine(Path, newName);
            File.Delete(delFile);
            Console.WriteLine("Файл видалено");
        }
        public void Rename(string fileToRename, string newName)
        {
            string newRename = System.IO.Path.Combine(Path, fileToRename);
            if (!File.Exists(newRename))
            {
                Console.WriteLine("В директорії не існує файлів");
                return;
            }
            string newPath = System.IO.Path.Combine(Path, newName);
            File.Move(newRename, newPath);
            
            Console.WriteLine("Файл перейменовано ");
        }
        public void Copy(string newName)
        {
            string newPath = System.IO.Path.Combine(Path, newName);
            File.Copy(Path, newPath);
        }
        public void MoveFile(string movableFile, string newDirectory)
        {
            string fileName = System.IO.Path.Combine(Path, movableFile);
            if (File.Exists(fileName))
            {
                string newPath = System.IO.Path.Combine(newDirectory, movableFile);
                File.Move(fileName, newPath);
            }
            else
            {
                Console.WriteLine("Файл не знайдено!");
            }
        }
        public void ReadFile(string newName)
        {
            string newPath = System.IO.Path.Combine(Path, newName);
            if (File.Exists(newPath))
            {
                Console.WriteLine(File.ReadAllText(newPath));
            }
            else
            {
                Console.WriteLine("Файл не знайдено!");
            }
        }
    }
}