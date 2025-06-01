using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Ariphm
{
    class Program
    {
        public static void Main(string[] args)
        {    
            while(true)
            {
                Console.WriteLine("Введіть число для перевірки: ");
                string number = Console.ReadLine();
                
                if (number == "стоп")
                {
                    Console.WriteLine("Програма зупинена... ");
                    break;

                }

                var numbers = number.ToCharArray();
                bool meaning = Palindrome(numbers);
                if (meaning == true)
                {
                    Console.WriteLine("uspih");
                }
                else
                {
                    Console.WriteLine(" ne uspih");
                }
            }  
        }  
        static bool Palindrome (char[] numbers) 
        {
            int count = numbers.Length;
            for (int i = 0; i < count / 2; ++i)
            { 
                if (numbers[i] != numbers[count - 1 - i]) return false;
                                                                            
            }
            return true;
        }
     
    }
}


