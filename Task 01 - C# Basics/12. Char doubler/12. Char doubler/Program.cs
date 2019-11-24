using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Char_doubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string");
            string strInput = Console.ReadLine();
            Console.WriteLine("Enter basis string");
            string strBasis = Console.ReadLine();

            string strCharList = TransformStr(strBasis).ToString();
            Console.WriteLine("Changed string:" +
                              Environment.NewLine +
                              strCharList);

            string strOutput = DoubleCharsInStr(strCharList, strInput).ToString();
            Console.WriteLine("Output string:" +
                              Environment.NewLine +
                              strOutput);

            Console.ReadKey();
        }

        public static StringBuilder TransformStr(string strBasis)
        {
            StringBuilder str = new StringBuilder();
            bool IsSymbPlacedFlag = false;

            foreach (char symb in strBasis)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (symb == str[i])
                    {
                        IsSymbPlacedFlag = true;
                        continue;
                    }
                }

                if (IsSymbPlacedFlag == false)
                {
                    str.Append(symb);
                    IsSymbPlacedFlag = false;
                }

                IsSymbPlacedFlag = false;
            }
            return str;
        }

        public static StringBuilder DoubleCharsInStr(string strCharList, string strInput)
        {
            StringBuilder str = new StringBuilder();

            foreach (char symb in strInput)
            {
                str.Append(symb);
                for (int i = 0; i < strCharList.Length; i++)
                {
                    if (symb == strCharList[i])
                    {
                        str.Append(symb);
                    }
                }
            }
            return str;
        }
    }
}
