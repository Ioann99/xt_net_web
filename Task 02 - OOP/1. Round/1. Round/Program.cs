using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Round
{
    class Program
    {
        static void Main(string[] args)
        {
            Round circle = new Round();

            circle.center_x = circle.Get_center_x();
            circle.center_y = circle.Get_center_y();
            Console.WriteLine("Enter radius");
            //double.TryParse(Console.ReadLine(), out double rad);
            //circle.Radius = rad;
            circle.Radius = Convert.ToDouble(Console.ReadLine());

            circle.GetInfo();
            Console.ReadKey();
        }
    }

    public class Round
    {
        public int center_x, center_y;
        public double length, area;
        private double _radius;

        public int Get_center_x()
        {
            Console.WriteLine("Enter x coordinate");
            int.TryParse(Console.ReadLine(), out int coordinate);
            return coordinate;
        }

        public int Get_center_y()
        {
            Console.WriteLine("Enter y coordinate");
            int.TryParse(Console.ReadLine(), out int coordinate);
            return coordinate;
        }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    while (value <= 0)
                    {
                        Console.WriteLine("Incorrect value! Radius must be positive");
                        double.TryParse(Console.ReadLine(), out value);
                    }
                }
                _radius = value;
            }
        }

        public void GetInfo()
        {
            length = 2 * Math.PI * _radius;
            area = Math.PI * _radius * _radius;
            Console.WriteLine($"Centre is ({center_x},{center_y})" +
                              Environment.NewLine +
                              $"Radius = {_radius}" +
                              Environment.NewLine +
                              $"Length = {length}" +
                              Environment.NewLine +
                              $"Area = {area}");
        }
    }
}
