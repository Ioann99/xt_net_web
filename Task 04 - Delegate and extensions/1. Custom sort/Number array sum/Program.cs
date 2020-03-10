using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_array_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] IntArr = new int[] { 1, 2, 3, 4, 5 };

            int sum = IntArr.ArraySum();

            Console.WriteLine(sum);

            Console.ReadKey();
        }
        
    }

    public static class ArrayExtension
    {
        public static int ArraySum(this int[] arr)
        {
            int sum = 0;
            foreach (int number in arr)
            {
                sum += number;
            }

            return sum;
        }
    }
}
