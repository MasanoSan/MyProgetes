using System;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace FileManager
{
    public abstract class BaseFileSystemItem
    {
        public string Path { get; set; }
        protected BaseFileSystemItem(string path)
        {
            Path = path;
        }
        public abstract void Create(string newName);
        public abstract void Delete(string newName);
        public void DisplayAllUnits()
        {
            string[] dir = Directory.GetDirectories(Path);
            foreach (var dirs in dir)
            {
                Console.WriteLine(System.IO.Path.GetDirectoryName(dirs));
            }
            string[] files = Directory.GetFiles(Path);
            foreach (var file in files)
            {
                Console.WriteLine(System.IO.Path.GetFileName(file));
            }
        }
    }
}