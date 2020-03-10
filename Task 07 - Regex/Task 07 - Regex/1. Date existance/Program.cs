using System;
using System.Text.RegularExpressions;

namespace _1.Date_existance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text with dd-mm-yyyy data format:");
            string input = Console.ReadLine();

            string day_regex = @"((0[1-9])|(1[0-9])|(2[0-9])|(3[01]))";
            string month_regex = @"((0[1-9])|(1[012]))";
            string year_regex = @"([0-9]{4})";
            string pattern = @"\b(" + day_regex +
                                "-" + month_regex +
                                "-" + year_regex + @")\b";

            Regex regex = new Regex(pattern);

            MatchCollection dates = regex.Matches(input);
            Console.Write("In text \"" + input + "\" there are ");

            if (dates.Count == 0)
            {
                Console.WriteLine("no any dates.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine($"{dates.Count} dates:");
            }

            int counter = 1;
            foreach (Match match in dates)
            {
                Console.WriteLine(counter + $") {match.Value}");
                counter++;
            }

            Console.ReadKey();

        }
    }
}
