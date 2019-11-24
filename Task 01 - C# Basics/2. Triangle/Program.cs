using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetNumber();

            DrawTriangle(N);

            Console.ReadKey();
        }

        public static int GetNumber()
        {
            Console.WriteLine("Enter integer bigger then 0 and less than 100");
            int.TryParse(Console.ReadLine(), out int Number);

            while (Number < 0 || Number > 100)
            {
                Console.WriteLine("Incorrect value! Enter integer bigger than 0 and less than 100");
                int.TryParse(Console.ReadLine(), out Number);
            }

            return Number;
        }

        public static void DrawTriangle(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
