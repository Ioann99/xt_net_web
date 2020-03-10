using System;
using System.Text.RegularExpressions;


namespace _5.Time_counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string hour = "(([0-9])|(0[0-9])|(1[0-9])|(2[0-3]))";
            string minute = "([0-5][0-9])";
            string pattern = "(" + hour + @"\:" + minute + ")";

            Regex regex = new Regex(pattern);

            Console.WriteLine("Enter text with time:");

            string input = Console.ReadLine();
            MatchCollection collection = regex.Matches(input);


            Console.WriteLine($"Time appears {collection.Count} times in text:");

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
