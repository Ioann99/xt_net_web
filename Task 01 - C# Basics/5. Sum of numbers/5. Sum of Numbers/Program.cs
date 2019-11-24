using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Sum_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort[] massOfDividings = new ushort[1000];// code with piece
            ushort sum = 0;
            int counter = 0;

            for (ushort i = 1; i < 1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    massOfDividings[counter] = i;
                    Console.WriteLine($"[{counter}] = {massOfDividings[counter]}");
                    counter++;
                }
            }

            for (ushort i = 0; i < counter; i++)
            {
                sum += massOfDividings[i];
            }

            Console.WriteLine("Sum of number between 1 and 1000, which are divides by 3 or 5 is " + sum);
            Console.ReadKey();
        }
    }
}
