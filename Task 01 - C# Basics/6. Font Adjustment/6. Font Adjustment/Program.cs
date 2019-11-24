using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Font_Adjustment
{

    enum FontTypes
    {
        bold,
        italic,
        underline
    }


    class Program
    {

        private const string noItemsMessage = "None";

        static void Main(string[] args)
        {
            List<FontTypes> ft = new List<FontTypes>(3);
            int n = 0;
            while (n < 3 && n >= 0)
            {
                PrintParams(ft);
                Console.WriteLine("Введите:");
                foreach (FontTypes item in Enum.GetValues(typeof(FontTypes)))
                {
                    Console.WriteLine($"{(int)item + 1}. {item}");
                }
                int.TryParse(Console.ReadLine(), out n);
                n--;

                if (n < 3 && n >= 0)
                {
                    if (ft.Contains((FontTypes)n))
                    {
                        ft.Remove((FontTypes)n);
                    }
                    else
                    {
                        ft.Add((FontTypes)n);
                    }
                }
            }
        }

        private static void PrintParams<T>(List<T> ft)
        {
            Console.WriteLine("Параметры надписи: ");
            if (ft.Count == 0)
            {
                Console.WriteLine(noItemsMessage);
            } else
            {
                Console.WriteLine(string.Join(", ", ft));
            }
            Console.WriteLine();
        }
    }
}
