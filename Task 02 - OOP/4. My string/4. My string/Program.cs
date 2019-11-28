using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.My_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st string");
            MyString str1 = new MyString(Console.ReadLine().ToCharArray());
            Console.WriteLine("Enter 2nd string");
            MyString str2 = new MyString(Console.ReadLine().ToCharArray());

            str1.Compare(str2);
            str1.Concat(str2);
            foreach (char symb in str1.ToCharArray())
            {
                Console.Write(symb + " ");
            }

            Console.WriteLine(Environment.NewLine + "Enter char to seek in first string");
            char ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Is char " + ch + " placed in string:" + str1.Find(ch));

            Console.WriteLine("Char array to string is:" + str1.ToString());

            Console.Write("String to char array is:");
            foreach (char symb in str1.ToCharArray())
            {
                Console.Write(symb + " ");
            }

            Console.ReadKey();
        }
    }

    class MyString
    {
        public MyString(char[] value)
        {
            this.value = value;
        }

        private char[] value;

        public void Compare(MyString str)
        {
            Console.WriteLine("Is these string are equal: " + this.value.SequenceEqual(str.value));
        }

        public void Concat(MyString str)
        {
            this.value = this.value.Concat(str.value).ToArray<char>();
        }

        public bool Find(char ch)
        {
            return this.value.First(x => x == ch) == ch;
        }

        public override string ToString()
        {
            return string.Join(" ", this.value);
        }

        public char[] ToCharArray()
        {
            return this.value;
        }
    }
}

