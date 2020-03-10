using System;
using System.Text.RegularExpressions;

namespace _4.Number_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = "([0-9])";
            string numbers = "(" + number + "+)";
            string plus_minus = "(([+-]){0,1})";
            string only_numbers = "(" + plus_minus + numbers + ")";
            string after_point_part = "(" + @"\." + numbers + ")";

            string only_numbers_with_point =
                "(" + only_numbers + after_point_part + "{0,1})";

            string with_mult =
                "(" + only_numbers_with_point + @"\*" +
                numbers + @"(\^" + only_numbers + "){0,1})";

            string exp =
                "(" + only_numbers_with_point + "e" + only_numbers + ")";

            Regex regex_numbers = new Regex("^" + only_numbers_with_point + "$");
            Regex regex_mult = new Regex("^" + with_mult + "$");
            Regex regex_exp = new Regex("^" + exp + "$");

            Console.WriteLine("Enter number");
            string input = Console.ReadLine();

            if (regex_numbers.IsMatch(input))
            {
                Console.WriteLine("It is normal number");
                Console.ReadKey();
                return;
            }

            if (regex_mult.IsMatch(input))
            {
                Console.WriteLine("It is number with mult");
                Console.ReadKey();
                return;
            }

            if (regex_exp.IsMatch(input))
            {
                Console.WriteLine("This is scientific notation number");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Input is not a number");
            Console.ReadKey();
        }
    }
}
