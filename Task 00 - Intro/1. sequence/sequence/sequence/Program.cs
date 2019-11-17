using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            while (N < 1 || N > int.MaxValue)
            {
                Console.WriteLine("Enter number N");
                int.TryParse(Console.ReadLine(), out N);
            }

            StringBuilder myStringBuilder = new StringBuilder("");
            int i = 1;
            for (;  i < N; i++)
            {
                myStringBuilder.Append(Convert.ToString(i) + ",");
            }

            myStringBuilder.Append(Convert.ToString(i));

            Console.WriteLine(myStringBuilder);
            Console.ReadKey();
        }
    }
}
