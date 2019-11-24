using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong a = GetFirstValue();

            ulong b = GetSecondValue();

            ReturnAreaValue(a, b);

            Console.ReadKey();
        }

        public static ulong GetFirstValue()
        {
            Console.WriteLine("Enter first integer");
            ulong.TryParse(Console.ReadLine(), out ulong FirstValue);

            while (FirstValue <= 0 || FirstValue > ulong.MaxValue || (FirstValue % 1) != 0)
            {
                Console.WriteLine("Enter integer bigger than 0");
                ulong.TryParse(Console.ReadLine(), out FirstValue);
            }

            return FirstValue;
        }

        public static ulong GetSecondValue()
        {
            Console.WriteLine("Enter second integer");
            ulong.TryParse(Console.ReadLine(), out ulong SecondValue);

            while (SecondValue <= 0 || SecondValue > ulong.MaxValue || (SecondValue % 1) != 0)
            {
                Console.WriteLine("Enter integer bigger than 0");
                ulong.TryParse(Console.ReadLine(), out SecondValue);
            }

            return SecondValue;
        }

        public static void ReturnAreaValue(ulong a, ulong b)
        {
            Console.WriteLine("Area is " + a * b);
        }
    }
}
