// See https://aka.ms/new-console-template for more information
namespace Area
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Оберіть метод обрахунків:");
            Console.WriteLine("1.Визначення площі трикутника.\n2.Визначення сторони прямокутного трикутника");
            string m = Console.ReadLine();
            if(m == "1")
            {
                Console.WriteLine("Введіть висоту і довжину основи для обчислення площі через пробіл: ");
                string source1 = Console.ReadLine();
                /*if (source1.Length > 3)
                {
                    Console.WriteLine("для обчислення потрібно ввести тільки два числа");
                }
                */
                string[] container = source1.Split(' ');
                int count = 2;
                double [] numbers1 = new double[count];
                for(int i = 0; i < count; i++)
                {
                    numbers1[i] = double.Parse(container[i]);
                }
                string result1 = AreaCalculation(numbers1, count);

                Console.WriteLine("Результат: {0}",result1);
            }
            else 
            {
                Console.WriteLine("Введіть дані для обчислення Гіпотенузи: ");
                string source2 = Console.ReadLine();
                /*if (source2.Length > 3)
                {
                    Console.WriteLine("для обчислення потрібно ввести тільки два числа");
                }
                */
                string[] container2 = source2.Split(' ');
                int count2 = 2;
                double[] numbers2 = new double[count2];
                for(int i = 0; i < count2; i++)
                {
                    numbers2[i] = double.Parse(container2[i]);
                }
                string result2 = Piphagor(numbers2, count2);
                Console.WriteLine("Результат: {0}", result2 );
            }

        }
        static string AreaCalculation(double [] numbers1, int count)
        {
            double high = numbers1[0];
            double storona = numbers1[1];
            double area = (high * storona ) / 2;
            string result = area.ToString();
            return result;

        }
        static string Piphagor(double [] numbers1, int count)
        {
            double katet1 = numbers1[0];
            double katet2 = numbers1[1];
            double hypotenuse = Math.Sqrt( katet1 * katet2);
            string result = string.Format("{0:0.000}", hypotenuse);
            return result;

        }

    }
}
