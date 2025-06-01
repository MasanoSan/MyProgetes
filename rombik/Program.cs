// See https://aka.ms/new-console-template for more information

namespace Rombik
{
    class Program
    {
        public static void Main(string[] args)
        {
            string n = "*";
            char m = ' ';
            int count = 13;
            int F = count-1;
            for (int i=0; i<(count * 2) - 1; i++)
            {
                //(m,(count-1)/ 2 + n);
                Console.WriteLine("{0}{1}", new string(m,F),n);
                
                if (i >= count - 1)
                {
                    F++;
                    n = n.Remove(0, 2);
                }
                else
                {
                    F--;
                    n = n + "**";
                }
                        //n.Remove()
            }
        }
    }
}