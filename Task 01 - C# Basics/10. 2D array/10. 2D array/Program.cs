using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2D_array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x");
            int.TryParse(Console.ReadLine(), out int x);
            Console.WriteLine("Enter y");
            int.TryParse(Console.ReadLine(), out int y);

            int[,] arr = GenerateArray(x, y);

            PrintArray(arr, x, y);

            PrintEvenSum(arr, x, y);

            Console.ReadKey();
        }

        public static int[,] GenerateArray(int x, int y)
        {
            Random rnd = new Random();
            int[,] arr = new int[x, y];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arr[i, j] = rnd.Next(-20, 20);
                }
            }

            return arr;
        }

        public static void PrintArray(int[,] arr, int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(String.Format("{0,3}", arr[i, j]) + " ");
                }

                Console.WriteLine();
            }
        }

        public static void PrintEvenSum(int[,] arr, int x, int y)
        {
            int sum = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine(Environment.NewLine + $"Sum of even elements is {sum}");
        }
    }
}
