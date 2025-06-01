// See https://aka.ms/new-console-template for more information
namespace Ejecting
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введіть інформацію для обробки: ");
            string source = Console.ReadLine();
            int m = source.Length;
            char[] symbols = source.ToCharArray(0, m);
            List<char> sourceList = new List<char>();
            for(int i = 0; i < m; i++)
            {
                bool n = char.IsLetter(symbols[i]);
                if(n == true)
                {
                    sourceList.Add(symbols[i]);
                }
            }
            string result = string.Join("", sourceList);
            Console.WriteLine("Результат: {0}", result);
            string mm = new string (sourceList.ToArray());
        }   
    }
}
