using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeekYou
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, -10, -5, 6, -12, 144 };

            Console.WriteLine("Original array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();


            PrimitiveSort(arr);


            DelegateSort(arr, IntCompare);


            AnonymMethod AnonymSort = delegate (int[] AnonymArr)
            {
                int primitive_size = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        primitive_size++;
                    }
                }

                int[] stack_arr = new int[primitive_size];
                int j = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        stack_arr[j] = arr[i];
                        j++;
                    }
                }

                Console.WriteLine(Environment.NewLine + "Anonym sorted array:");

                for (int i = 0; i < stack_arr.Length; i++)
                {
                    Console.Write(stack_arr[i] + " ");
                }

                Console.WriteLine();
            };
            AnonymSort(arr);


            LambdaSort LOneSort = (x) => x > 0;
            LSort(arr, LOneSort);

            Console.ReadKey();
        }

        //primitive sort block
        public static void PrimitiveSort(int[] arr)
        {

            int primitive_size = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    primitive_size++;
                }
            }

            int[] stack_arr = new int[primitive_size];
            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    stack_arr[j] = arr[i];
                    j++;
                }
            }

            Console.WriteLine(Environment.NewLine + "Sorted array:");

            for (int i = 0; i < stack_arr.Length; i++)
            {
                Console.Write(stack_arr[i] + " ");
            }

            Console.WriteLine();
        }


        //delegate sort block
        public delegate bool Del(int x);

        static bool IntCompare(int x)
        {
            if (x > 0)
            {
                return true;
            }
            else return false;
        }

        static void DelegateSort(int[] arr, Del del)
        {
            int[] Sorted = new int[5];//ficha-chicha
            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];

                if (del(current))
                {
                    Sorted[j] = current;
                    j++;
                }
            }

            Console.WriteLine(Environment.NewLine + "Sorted by delegate array:");

            for (int i = 0; i < Sorted.Length; i++)
            {
                Console.Write(Sorted[i] + " ");
            }

            Console.WriteLine();
        }


        //anonymous method sort block
        delegate void AnonymMethod(int[] arr);


        //lamb(a)da method sort block
        delegate bool LambdaSort(int x);
        static void LSort(int[] arr, LambdaSort LOneSort = (x) => x > 0)
        {

        }
    }
}
