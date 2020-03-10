using System;
using System.Text.RegularExpressions;

namespace _2.HTML_replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"<[^<>]*>");

            Console.WriteLine("Enter text with HTML-fichas:");

            string input = Console.ReadLine();

            string result = regex.Replace(input, "_");
            Console.WriteLine($"Un-HTML-ed result: {result}");

            Console.ReadKey();
        }
    }
}
