// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Strings
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введіть ваш текст: ");
                Console.WriteLine("________________");
                string source = Console.ReadLine().ToLower();
                if(source == "stop the program")
                {
                    Console.WriteLine("зупинка програми");
                    break;
                }
                string[] container = source.Split(' ', '.', ',', ':', ';', '!', '?', '-');
                int count = container.Length;
                string result11 = ReverseMethod(container);
                string result22 = ListMethod(container);
                Console.WriteLine("Результати методу аррейреверс: {0}", result11);
                Console.WriteLine("Результати методу ліст: {0}", result22);
            }
        }
         static string ReverseMethod(string[] container)
        {
            string[] reversed = new string[container.Length];
            Array.Copy(container, reversed, container.Length);
            Array.Reverse(reversed);
            string result = string.Join(" ", reversed);
            return result;
        }
        static string ListMethod(string[] container)
        {
            int count = container.Length;
            List<string> source = new List<string>();
            for (int i = count-1; i >= 0; i--)
            {
                source.Add(container[i]);
            }
            string result = string.Join(" ", source);
            return result;
        }
    }
}
