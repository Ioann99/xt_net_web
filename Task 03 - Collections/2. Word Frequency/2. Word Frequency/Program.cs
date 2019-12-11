using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Word_Frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "cat takes you like cat and motherfucker cat cat takes like like".ToLower();
            StringBuilder CacheStr = new StringBuilder();

            Dictionary<string, int> Words = new Dictionary<string, int>();

            foreach (char symb in str)
            {
                if (symb == ' ' || symb == '.')
                {
                    if (Words.ContainsKey(CacheStr.ToString()))
                    {
                        Words[CacheStr.ToString()] += 1;
                        CacheStr.Clear();
                    }
                    else
                    {
                        Words.Add(CacheStr.ToString(), 1);
                        CacheStr.Clear();
                    }
                }
                else
                {
                    CacheStr.Append(symb);
                }
            }

            foreach (var item in Words)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.ReadKey();
        }
    }
}
