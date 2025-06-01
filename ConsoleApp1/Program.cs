// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Microsoft.VisualBasic;
namespace Cryptology{
    class Program
        {

        public static void Main(string[] args)
            {
            List<char> Alphabet = new List <char>(){ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            while (true)
            {


                Console.WriteLine("Write ur messege");
                Console.WriteLine("________________");
                string source = Console.ReadLine().ToLower();
                if(source == "pisun")
                {
                    Console.WriteLine("idi ...");
                    break;
                }
                Console.Write("Chose type of opration (1 - code, 2 - decode): ");
                string choise = Console.ReadLine();
                int shift = 2;
                    if (choise == "2") shift = -shift;
                string result = ProcessText(source, Alphabet, shift);
                Console.WriteLine("Result: " + result);
                
            }
            

                    }
        static string ProcessText(string text,List<char> Alphabet, int shift)
                        {
                            string output = "";
                            int n = Alphabet.Count;
                            foreach (char ch in text)
                            {
                                if (Alphabet.Contains(ch))
                                {
                                    int index = Alphabet.IndexOf(ch);
                                    int newIndex = (index + shift + n) % n;
                                    output += Alphabet[newIndex];
                                }
                                else
                                {
                                    output += ch;
                                }
                            }
                            return output;

                        }










                    














        }



}
