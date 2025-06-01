// See https://aka.ms/new-console-template for more information
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
                int max = 0, index = 0;
                
                for(int i = 0; i < count; i++)
                {
                    if (container[i].Length > max)
                    {
                        max = container[i].Length;
                        index = i;
                    }
                }
                Console.WriteLine("Найдовше слово:  {0}", container[index] );
            }   
                
        }
    }
}
