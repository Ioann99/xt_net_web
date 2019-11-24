using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Non_negative_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 20;//arr size

            int[] arr = GenerateArray(N);
            PrintArray(arr, N);
            DisplayNonNegativeSum(arr, N);

            Console.ReadKey();
        }

        public static int[] GenerateArray(int N)
        {
            Random rnd = new Random();
            int[] arr = new int[N];

            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(-20, 20);
            }

            return arr;
        }

        public static void PrintArray(int[] arr, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void DisplayNonNegativeSum(int[] arr, int N)
        {
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine(Environment.NewLine + $"Non-negative sum is {sum}");
        }
    }
}
