using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.No_positive
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;//arr size

            int[,,] mass = GenerateArr(N);
            PrintArr(mass);

            int[,,] editedArr = ReplaceNumbers(mass, N);
            Console.WriteLine(Environment.NewLine + "--------------" +
                                                    "Edited Array:+" +
                                                    "--------------" +
                                                    Environment.NewLine);
            PrintArr(editedArr);

            Console.ReadKey();
        }

        public static int[,,] GenerateArr(int N)
        {
            Random rnd = new Random();
            int[,,] arr = new int[N,N,N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        arr[i, j, k] = rnd.Next(-10, 10);
                    }
                }
            }

            return arr;
        }

        public static void PrintArr(int[,,] mass)
        {
            int N = 5;//mass size
            int[,,] arr = new int[N, N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        //Console.WriteLine($"mass[{i},{j},{k}] = {mass[i, j, k]}");    //вывод с подписью каждого эл-та
                        Console.Write(String.Format("{0,3}", mass[i, j, k]));         //вывод последовательностью двумерных массивов
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        public static int[,,] ReplaceNumbers(int [,,] mass, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if (mass[i, j, k] > 0)
                        {
                            mass[i, j, k] = 0;
                        }
                    }
                }
            }

            return mass;
        }
    }
}
