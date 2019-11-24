using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.X_mas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetNumber();
            
            DrawXMassTree(N);

            Console.ReadKey();
        }

        public static int GetNumber()
        {
            Console.WriteLine("Enter integer bigger then 0 and less than 100");
            int.TryParse(Console.ReadLine(), out int Number);

            while (Number <= 0 || Number > 100)
            {
                Console.WriteLine("Incorrect value! Enter integer bigger than 0 and less than 100");
                int.TryParse(Console.ReadLine(), out Number);
            }

            return Number;
        }

        public static void DrawXMassTree(int N)
        {
            for (int j = 0; j < N; j++)
            {
                int width = -1 + (2 * N);
                int middle = (width / 2) + 1;
                int i;
                int y = 0;

                while (middle > y)
                {
                    for (i = 0; i <= width; i++)
                    {
                        if (i >= (middle - y) && i <= (middle + y))
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    
                    if (y == j)
                    {
                        Console.WriteLine();
                        y++;
                        break;
                    }

                    Console.WriteLine();
                    y++;
                }
            }
        }
    }
}
