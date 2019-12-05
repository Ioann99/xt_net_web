using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round();
            Ring ring = new Ring();

            Console.WriteLine("Enter x coordinate");
            int.TryParse(Console.ReadLine(), out ring.X);
            Console.WriteLine("Enter y coordinate");
            int.TryParse(Console.ReadLine(), out ring.Y);

            Console.WriteLine("Enter radius. Remember - it must be positive");
            int.TryParse(Console.ReadLine(), out int Rad);
            ring.Radius = Rad;

            Console.WriteLine("Enter inner radius. Remember - it must be positive");
            int.TryParse(Console.ReadLine(), out Rad);
            ring.InnerRadius = Rad;

            Console.WriteLine($"Ring's center = ({ring.X},{ring.Y})");
            Console.WriteLine($"Ring's area = {ring.GetArea()}");
            Console.WriteLine($"Sum of both roundse's lengthes in ring = {ring.BothLengthes()}");

            Console.ReadKey();
        }
    }

    class Round
    {
        public int X, Y;
        protected int _radius;

        public int Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Incorrect value. Radius must be positive."); ;
                    return;
                }
                _radius = value;
            }
        }
    }

    class Ring : Round
    {
        private int _innerRadius;
        public int InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value <= 0 || value >= _radius)
                {
                    Console.WriteLine("Incorrect value! It must be positive and less than outer radius.");
                    return;
                }
                _innerRadius = value;
            }
        }

        public double GetArea() => Math.PI * (Radius * Radius - InnerRadius * InnerRadius);
        public double BothLengthes() => 2 * Math.PI * (Radius + InnerRadius);
    }
}
