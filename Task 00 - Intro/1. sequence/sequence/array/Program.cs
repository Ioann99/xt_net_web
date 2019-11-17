using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetArrayDimension();
            int[][] FilledArray = FillArray(N);
            PrintFilledArray(N, FilledArray);

            int[][] SortedArray = SortArray(N, FilledArray);
            PrintSortedArray(N, SortedArray);

            int[][] GlobalSortedArray = GlobalSortArray(N, FilledArray);
            PrintGlobalSortedArray(N, GlobalSortedArray);

            Console.ReadKey();
        }

        public static int GetArrayDimension()
        {
            int Number = 0;
            while (Number < 1 || Number > int.MaxValue || Number > 10)
            {
                Console.WriteLine("Enter array dimension N, not bigger than 10");
                int.TryParse(Console.ReadLine(), out Number);
            }

            return Number;
        }

        public static int[][] FillArray(int N)
        {
            int[][] myArray = new int[N][];
            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Enter dimension for " + i + " sub-array");
                int.TryParse(Console.ReadLine(), out int D);
                myArray[i] = new int[D];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < myArray[i].Length; j++)
                {
                    myArray[i][j] = rnd.Next(0, 100);
                }
            }

            return myArray;
        }

        public static void PrintFilledArray(int N, int[][] FilledArray)
        {
            Console.WriteLine();
            Console.WriteLine("Unsorted array:");
            Console.Write("{");
            for (int i = 0; i < N; i++)
            {
                Console.Write("{");
                for (int j = 0; j < FilledArray[i].Length; j++)
                {
                    Console.Write(FilledArray[i][j] + ",");
                }

                Console.Write("},");
            }

            Console.Write("\b");
            Console.Write("}");
            Console.WriteLine();
        }

        public static int[][] SortArray(int N, int[][] FilledArray)
        {
            int container;
            for (int i = 0; i < N; i++)
            {
                for (int k = 0; k < FilledArray[i].Length; k++)
                {
                    for (int j = 0; j < (FilledArray[i].Length - 1); j++)
                    {
                        if (FilledArray[i][j] > FilledArray[i][j + 1])
                        {
                            container = FilledArray[i][j + 1];
                            FilledArray[i][j + 1] = FilledArray[i][j];
                            FilledArray[i][j] = container;
                        }
                    }
                }
            }

            return FilledArray;
        }

        public static void PrintSortedArray(int N, int[][] SortedArray)
        {
            Console.WriteLine();
            Console.WriteLine("Sorted array:");
            Console.Write("{");
            for (int i = 0; i < N; i++)
            {
                Console.Write("{");
                for (int j = 0; j < SortedArray[i].Length; j++)
                {
                    Console.Write(SortedArray[i][j] + ",");
                }

                Console.Write("\b");
                Console.Write("},");
            }

            Console.Write("\b");
            Console.Write("}");
            Console.WriteLine();
        }

        public static int[][] GlobalSortArray(int N, int[][] FilledArray)
        {
            // устанавливаем длину одномерного глобального массива для глобальной сортировки
            int GlobalArrayCounter = 0, GlobalArraySize = 0;
            for (int i = 0; i < N; i++)
            {
                GlobalArraySize += FilledArray[i].Length;
            }

            // заполняем его
            int[] GlobalArray = new int[GlobalArraySize];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < FilledArray[i].Length; j++)
                {
                    GlobalArray[GlobalArrayCounter] = FilledArray[i][j];
                    GlobalArrayCounter++;
                }
            }

            // сортируем
            int container;
            for (int i = 0; i < GlobalArray.Length; i++)
            {
                for (int j = 0; j < (GlobalArray.Length - 1); j++)
                {
                    if (GlobalArray[j] > GlobalArray[j + 1])
                    {
                        container = GlobalArray[j + 1];
                        GlobalArray[j + 1] = GlobalArray[j];
                        GlobalArray[j] = container;
                    }
                }
            }

            // передаём в FilledArray, чтобы затем в основном теле программы это записалось в GlobalSortedArray
            GlobalArrayCounter = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < FilledArray[i].Length; j++)
                {
                    FilledArray[i][j] = GlobalArray[GlobalArrayCounter];
                    GlobalArrayCounter++;
                }
            }

            return FilledArray;
        }

        public static void PrintGlobalSortedArray(int N, int[][] GlobalSortedArray)
        {
            Console.WriteLine();
            Console.WriteLine("Global-Sorted array:");
            Console.Write("{");
            for (int i = 0; i < N; i++)
            {
                Console.Write("{");
                for (int j = 0; j < GlobalSortedArray[i].Length; j++)
                {
                    Console.Write(GlobalSortedArray[i][j] + ",");
                }

                Console.Write("\b");
                Console.Write("},");
            }

            Console.Write("\b");
            Console.Write("}");
            Console.WriteLine();
        }
    }
}
