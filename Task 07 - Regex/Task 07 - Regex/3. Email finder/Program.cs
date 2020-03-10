using System;
using System.Text.RegularExpressions;

namespace _3.Email_finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = "([a-z])";
            string numbers = "([0-9])";
            string letter_or_number = "(" + letters + "|" + numbers + ")";
            string other_name_simvols = "([.-_])";
            string user_name = "(" + letter_or_number +
                               "|(" + letter_or_number +
                               "(" + letter_or_number + "|"+                                   other_name_simvols + ")*" +     
                                     letter_or_number + "))";
            string poddomen = "((" + letter_or_number
                + "|(" + letter_or_number +
                "(" + letter_or_number + "|[.-])*" + letter_or_number + @"))\.)";
            string domen = "((" + letter_or_number
                + "|(" + letter_or_number +
                "(" + letter_or_number + "|[.-]){0,4}" + letter_or_number + @"))\.)";
            string end = "((ru)|(com)|(net))";

            string patterm = user_name + "@" + "(" + poddomen + ")*" + domen + end;

            Regex regex = new Regex(patterm, RegexOptions.IgnoreCase);

            Console.WriteLine(Environment.NewLine + "Enter text:");
            string input = Console.ReadLine();

            MatchCollection collection = regex.Matches(input);
            Console.WriteLine("Next emails are founded:");

            int counter = 1;
            foreach (Match match in collection)
            {
                Console.WriteLine(counter + ")" + match.Value);
                counter++;
            }

            Console.ReadKey();
        }
    }
}
