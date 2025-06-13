using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace FileManager
{
    class Program
    {
        public static void Main()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string previousPath = currentPath;
            string mode = "main";
            FileItem fileManager = new FileItem(currentPath);
            DirectoryItem directoryManager = new DirectoryItem(currentPath);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Поточна директорія: {0} /n", currentPath);
                Console.WriteLine("Введіть команду: ");
                string input = Console.ReadLine().ToLower();
                mode = input;
                if (mode == "директорії")
                {
                    Console.WriteLine("Режим роботи з директоріями");
                    Console.WriteLine("Введіть команду: ");
                    string source = Console.ReadLine().ToLower();
                    if (source == "help")
                    {
                        //FileCommandHelp();
                    }
                    else if (source == "create")
                    {
                        Console.WriteLine("Введіть ім'я нової директорії");
                        string name = Console.ReadLine();
                        directoryManager.Create(name);
                        Console.WriteLine("Директорія створена");
                    }
                    else if (source == "delete")
                    {
                        Console.WriteLine("Введіть ім'я директорії для видалення");
                        string name = Console.ReadLine();
                        directoryManager.Delete(name);

                    }
                    else if (source == "change directory")
                    {
                        Console.WriteLine("Введіть директорію для переходу");
                        string name = Console.ReadLine();
                        directoryManager.ChangeCurrentDirectory(name);
                    }
                    else if (source == "go to previous")
                    {
                        directoryManager.GoToPreviousDirectory();
                    }
                    else if (source == "clear")
                    {
                        directoryManager.ClearDirectory();
                    }
                }
                else if (mode == "файли")
                {
                    Console.WriteLine("Режим роботи з файлами");
                    Console.WriteLine("Введіть команду: ");
                    string source = Console.ReadLine().ToLower();
                    if (source == "create")
                    {
                        Console.WriteLine("Введіть ім'я і тип нового файлу");
                        string name = Console.ReadLine();
                        fileManager.Create(name);
                    }
                    else if (source == "delete")
                    {
                        Console.WriteLine("Введіть ім'я файлу для видалення");
                        string name = Console.ReadLine();
                        fileManager.Delete(name);
                    }
                    else if (source == "rename")
                    {
                        Console.WriteLine("Введіть ім'я файлу який перейменовуєте");
                        string oldname = Console.ReadLine();
                        Console.WriteLine("Введіть нове ім'я");
                        string newname = Console.ReadLine();
                        fileManager.Rename(oldname, newname);
                    }
                    else if (source == "copy")
                    {
                        Console.WriteLine("Введіть ім'я файлу для копіювання");
                        string name = Console.ReadLine();
                        fileManager.Copy(name);
                        Console.WriteLine("done");
                    }
                    else if (source == "move")
                    {
                        Console.WriteLine("Ввдіть ім'я файлу");
                        string item = Console.ReadLine();
                        Console.WriteLine("Введіть нову локацію");
                        string place = Console.ReadLine();
                        fileManager.MoveFile(item, place);
                    }
                    else if (source == "read")
                    {
                        Console.WriteLine("Введіть ім'я файлу для читання");
                        string name = Console.ReadLine();
                        fileManager.ReadFile(name);
                    }
                }

            }
        }
        /*public static void FileCommandHelp()
        {
            Console.WriteLine("Створення файлу: Create(Ім'я файлу)/n Видалення файлу: Delete(Ім'я файлу)/n Переіменування файлу: Rename(Ім'я файлу)/n Копіювання файлу: Copy(Ім'я файлу)/n Переміщення файлу: Move(Ім'я файлу)/n Зчитування файлу: Read(Ім'я файлу)");
        }*/
    }
    
}
