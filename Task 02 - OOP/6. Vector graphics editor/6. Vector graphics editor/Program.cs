using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Vector_graphics_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure fgr = new Figure();
            Line line = new Line();
            Round round = new Round();
            Disc fullround = new Disc();
            Ring ring = new Ring();
            Rectangle rect = new Rectangle();

            line.Initialize();
            round.Initialize();
            fullround.Initialize();
            ring.Initialize();
            rect.Initialize();

            line.GetInfo();
            round.GetInfo();
            fullround.GetInfo();
            ring.GetInfo();
            ring.GetInfo();
            rect.GetInfo();

            Console.ReadKey();
        }
    }

    class Figure
    {
        public const string type = "Figure";
    }

    class Line : Figure
    {
        new const string type = "Line";

        public int X1, X2, Y1, Y2;
        public double GetLength() => Math.Sqrt(((X2 - X1) * (X2 - X1)) + ((Y2 - Y1) * (Y2 - Y1)));
        
        public void Initialize()
        {
            Random rnd = new Random();

            X1 = rnd.Next(20);
            X2 = rnd.Next(20);
            Y1 = rnd.Next(20);
            Y2 = rnd.Next(20);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Figure type: {type}" +
                              Environment.NewLine +
                              $"Parent's figure type: {Figure.type}");
            Console.WriteLine($"Coordinates: ({X1},{Y1}) ({X2},{Y2})");
            Console.WriteLine($"Length = {GetLength()}" + Environment.NewLine);
        }
    }

    class Round : Figure
    {
        new public const string type = "Round";

        public int X;
        public int Y;

        private int _radius;

        public int Radius
        {
            get => _radius;
            set
            {
                Random rnd = new Random();
                while (value <= 0)
                {
                    value = rnd.Next(20);
                }
                _radius = value;
            }
        }

        public void Initialize()
        {
            Random rnd = new Random();

            X = rnd.Next(20);
            Y = rnd.Next(20);
            Radius = rnd.Next(20);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Figure type: {type}" +
                              Environment.NewLine +
                              $"Parent's figure type: {Figure.type}");
            Console.WriteLine($"Coordinates: ({X},{Y})");
            Console.WriteLine($"Radius = {_radius}" + Environment.NewLine);
        }
    }

    class Disc : Round
    {
        new const string type = "Disc";

        public double GetArea() => Math.PI * Radius * Radius;

        public new void GetInfo()
        {
            Console.WriteLine($"Figure type: {type}" +
                              Environment.NewLine + 
                              $"Parent's figure type: {Round.type}");
            Console.WriteLine($"Coordinates: ({X},{Y})");
            Console.WriteLine($"Radius = {Radius}");
            Console.WriteLine($"Area = {GetArea()}" + Environment.NewLine);
        }
    }

    class Ring : Round
    {
        new const string type = "Ring";

        private int _innerRadius;
        public int InnerRadius
        {
            get => _innerRadius;
            set
            {
                Random rnd = new Random();

                while (value <= 0)
                {
                    value = rnd.Next(20);
                }
                _innerRadius = value;
            }
        }

        public double GetArea() => Math.PI * (Radius * Radius - _innerRadius * _innerRadius);
        public double GetBothLengthes() => 2 * Math.PI * (Radius + InnerRadius);

        public new void Initialize()
        {
            Random rnd = new Random();
            InnerRadius = rnd.Next(20);
        }

        public new void GetInfo()
        {
            Console.WriteLine($"Figure type: {type}" +
                              Environment.NewLine +
                              $"Parent's figure type: {Round.type}");
            Console.WriteLine($"Coordinates: ({X},{Y})");
            Console.WriteLine($"Radius = {Radius}");
            Console.WriteLine($"Inner radius = {InnerRadius}");
            Console.WriteLine($"Area = {GetArea()}");
            Console.WriteLine($"Both roundse's lengthes = {GetBothLengthes()}" + Environment.NewLine);
        }
    }

    class Rectangle : Figure
    {
        new const string type = "Rectangle";

        public int X1, X2, X3, X4, Y1, Y2, Y3, Y4;
        public double GetArea() => Math.Sqrt((X3 - X1) * (X3 - X1)) * Math.Sqrt((Y2 - Y1) * (Y2 - Y1));

        public void Initialize()
        {
            Random rnd = new Random();

            X1 = rnd.Next(20);
            X2 = X1;
            X3 = rnd.Next(20);
            X4 = X3;
            Y1 = rnd.Next(20);
            Y2 = rnd.Next(20);
            Y3 = Y2;
            Y4 = Y1;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Figure type: {type}" +
                              Environment.NewLine +
                              $"Parent's figure type: {Figure.type}");
            Console.WriteLine($"Coordinates: ({X1},{Y1}) ({X2},{Y2}) ({X3},{Y3}) ({X4},{Y4})");
            Console.WriteLine($"Area = {GetArea()}" + Environment.NewLine);
        }
    }
}
