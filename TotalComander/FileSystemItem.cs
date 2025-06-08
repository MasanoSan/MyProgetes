using System;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace FileManager
{
    // Same as FileItem, rename the class
    // Naming tip: This class is base for other system managers
    public abstract class BaseFileSystemItem
    {
        // Path should not be public
        // Also can be renamed to something like "CurrentPath", to avoid System.IO.Path namespace conflicts
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