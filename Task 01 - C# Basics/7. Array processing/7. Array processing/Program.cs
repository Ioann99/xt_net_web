using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Array_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 20;//arr size

            int[] arr = GenerateArray(N);
            Console.WriteLine("Unsorted array:");
            PrintArray(arr, N);

            int[] sortedArr = SortArray(arr, N);
            Console.WriteLine(Environment.NewLine + "Sorted array:");
            PrintArray(sortedArr, N);
            PrintMaxMin(sortedArr, N);

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

        public static int[] SortArray(int[] arr, int N)
        {
            int container = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < (N - 1); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        container = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = container;
                    }
                }
            }
            return arr;
        }

        public static void PrintMaxMin(int[] sortedArr, int N)
        {
            Console.WriteLine(Environment.NewLine + $"Min = {sortedArr[0]}");
            Console.WriteLine($"Max = {sortedArr[N - 1]}");
        }
    }
}
