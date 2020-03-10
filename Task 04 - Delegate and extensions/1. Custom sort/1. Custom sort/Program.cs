using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//4.1, 4.2, 4.3 are all over here

namespace _1.Custom_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[]{ "welding is true life", "fghij", "abcde", "cat" };

            Sort<string>(arr, StringCompare);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(arr[i]);
            }

            //Event starts

            Handler EndSortEvent = new Handler();
            onSortThread += EndSortEvent.Message;

            //thread starts
            Console.WriteLine("Thread starts");

            Thread myThread = new Thread(SortThread);
            myThread.Start();
            //myThread.Start(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadKey();
        }

        public delegate bool Del<T>(T x, T y);
        public delegate void MethodContainer();
        public static event MethodContainer onSortThread;

        static bool StringCompare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return true;
            }

            if (x.Length < y.Length)
            {
                return false;
            }

            x = x.ToUpper();
            y = y.ToUpper();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > y[i])
                {
                    return true;
                }
            }

            return false;
        }

        static void Sort<T>(T[] arr, Del<T> del)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    T previous = arr[i];
                    T current = arr[i + 1];
                    T pool;

                    if (del(previous, current))
                    {
                        pool = current;
                        current = previous;
                        previous = pool;

                        arr[i] = previous;
                        arr[i + 1] = current;
                    }
                }
            }
        }

        public static void SortThread()
        {
            string bufer;
            string[] arr = new string[] { "welding is true life", "fghij", "abcde", "cat" };

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[i].Length > arr[i + 1].Length)
                    {
                        bufer = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = bufer;
                    }
                }
                onSortThread();

                if (i == (arr.Length - 1))
                {
                    onSortThread();
                }
            }
        }
    }

    public class Handler
    {
        public void Message()
        {
            Console.WriteLine("Sort is end");
        }
    }
}
