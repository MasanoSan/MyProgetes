// See https://aka.ms/new-console-template for more information
namespace ClassCreation
{
    public class Trikutnik
    {

        public int A;
        public int B;
        public int C;
        public int H;
        public Trikutnik(int a, int b, int c, int h)
        {
            A = a;
            B = b;
            C = c;
            H = h;
        }

        public int Perimeter()
        {
            return A + B + C;
        }
        public int Area()
        {
            return (A * H) / 2;
        }
        public static Trikutnik operator *(Trikutnik triang1, int f)
        {

            var newTriangle = new Trikutnik(triang1.A * f, triang1.B * f, triang1.C * f, triang1.H * f);
            return newTriangle;
        }
        public override string ToString()
        {
            return string.Format("Triangle side A: {0} Triangle side B: {1} Triangle side C: {2} Triangle side H: {3}", A, B, C, H);
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Trikutnik T1 = new Trikutnik(3, 5, 14, 6);
            int area = T1.Area();
            Console.WriteLine("Площа трикутника за висотою і стороню = {0}", area);
            Trikutnik bigsize = T1 * 3;
            Console.WriteLine("розміри трикутника = {0}", bigsize.ToString());
            area = bigsize.Area();
            Console.WriteLine("Площа трикутника за висотою і стороню = {0}", area);
            int num = 0;
            num++;




        }


    }
}