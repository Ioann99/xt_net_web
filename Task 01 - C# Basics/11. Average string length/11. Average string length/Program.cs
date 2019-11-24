using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Average_string_length
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string");
            string str = Console.ReadLine();
            char[] charsToTrim = { ' ', ',', '.', ':', ':', '!', '?', '/' };
            double middleLength = 0;
            int space = 0;

            str = str.Trim(charsToTrim);
            foreach (char symb in str)
            {
                if (symb == ' ')
                {
                    space++;
                }
            }

            middleLength = str.Length;
            middleLength = (middleLength - space) / (space + 1);
            Console.WriteLine($"Trimmed string:{str}");
            Console.WriteLine($"Middle length of word in this string is {middleLength}");
            Console.ReadKey();
        }
    }
}
