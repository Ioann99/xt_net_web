using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle trn = new Triangle();
            Console.WriteLine("Enter a");
            trn.A = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b");
            trn.B = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c");
            trn.C = Convert.ToDouble(Console.ReadLine());

            trn.GetInfo();
            Console.ReadKey();
        }
    }

    class Triangle
    {
        private double _a, _b, _c;
        private double area, perimeter;

        public double A
        {
            get => _a;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect value! This number must be positive!");
                    double.TryParse(Console.ReadLine(), out value);
                }

                _a = value;
            }
        }

        public double B
        {
            get => _b;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect value! This number must be positive!");
                    double.TryParse(Console.ReadLine(), out value);
                }

                _b = value;
            }
        }

        public double C
        {
            get => _c;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect value! This number must be positive!");
                    double.TryParse(Console.ReadLine(), out value);
                }

                _c = value;
            }
        }

        public void GetInfo()
        {
            perimeter = _a + _b + _c;
            double p = perimeter / 2;
            area = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            if (area == 0)
            {
                Console.WriteLine("Triangle with these sides does not exist");
                return;
            }
            Console.WriteLine($"A = {_a}" + 
                              Environment.NewLine +
                              $"B = {_b}" +
                              Environment.NewLine +
                              $"C = {_c}" +
                              Environment.NewLine +
                              $"Perimeter = {perimeter}" +
                              Environment.NewLine +
                              $"Area = {area}");
        }
    }
}
