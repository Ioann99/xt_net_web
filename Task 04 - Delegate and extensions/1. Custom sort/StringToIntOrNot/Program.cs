using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToIntOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1";
            string str2 = "2,5";
            string str3 = "-4";
            
            str.DeterminateIsInt();
            str2.DeterminateIsInt();
            str3.DeterminateIsInt();

            Console.ReadKey();
        }
    }

    public static class StringExtension
    {
        public static void DeterminateIsInt(this string word)
        {
            bool IsInt = true;

            foreach (char element in word)
            {
                if ((element == '-') || (element == ',') || (element == '.'))
                {
                    Console.WriteLine(word + " is not integer positive");
                    IsInt = false;
                    break;
                }
            }

            {
                if (IsInt)
                {
                    Console.WriteLine(word + " is integer positive");

                }
            }
        }
    }
}
