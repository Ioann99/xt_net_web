using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace square
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetNumber();
            DrawSquare(N);
            Console.ReadKey();
        }

        public static int GetNumber()
        {
            int Number = 0;
            while (Number < 1 || Number > int.MaxValue || Number % 2 == 0)
            {
                Console.WriteLine("Enter uneven number N");
                int.TryParse(Console.ReadLine(), out Number);
            }

            return Number;
        }

        public static void DrawSquare(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j && i == N / 2)
                    {
                        Console.Write(' ');
                        continue;
                    }

                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}

