// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

namespace Multiplying
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Введіть масив 1: ");
                string source1 = Console.ReadLine();
                if(source1 == "stop")
                {
                    Console.WriteLine("зупинка програми");
                    break;
                }
                string[] container = source1.Split(' ', '.', ',', ':', ';', '!', '?', '-');
                int count = container.Length;
                int[] numbers1 = new int[count];
                Console.WriteLine("Введіть масив 2: ");
                string source2 = Console.ReadLine();
                string[] container2 = source2.Split(' ', '.', ',', ':', ';', '!', '?', '-');
                if (container.Length != container2.Length)
                {
                    Console.WriteLine("Масиви мають бути однакової довжини");
                    return;
                }
                int[] numbers2 = new int[count];
                for(int i = 0; i < count; i++)
                {
                    numbers2[i] = int.Parse(container2[i]);
                    numbers1[i] = int.Parse(container[i]);
                }
                string result = MultiplyingMethod(numbers1,numbers2);
                Console.WriteLine("Отриманий результат: {0}", result);
            }
        }
         static string MultiplyingMethod(int[] numbers1, int[] numbers2 )
        {
            //int count = numbers1.Length;
            
            List<int> source = new List<int>();
            for(int i = 0; i <=numbers1.Length - 1; i++)
            {
                source.Add(numbers1[i] * numbers2[i]);
            }
            List<string> result = new List<string>();
            foreach(int num in source)
            {
                result.Add(num.ToString());
            }
            string result1 = string.Join(" ", result);
            return result1;
        }
    }
}
