using System;

namespace simple
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetNumber();
            bool result = IsNumberPrimitive(N);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int GetNumber()
        {
            int Number = 0;
            while (Number < 1 || Number > int.MaxValue)
            {
                Console.WriteLine("Enter number N");
                int.TryParse(Console.ReadLine(), out Number);
            }

            return Number;
        }

        public static bool IsNumberPrimitive(int N)
        {
            int i = 2;
            for (; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
