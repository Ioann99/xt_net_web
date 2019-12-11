using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = RequestN();

            int[] Array = CreateArray(N);

            LinkedList<int> People = new LinkedList<int>(Array);

            foreach (byte num in People)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
            
            var Node = People.First;
            var NextNode = Node.Next;
            var current = NextNode;

            while (People.Count > 1)
            {
                if (current == null)
                {
                    Node = People.First;
                    NextNode = Node.Next;
                    current = NextNode;
                }

                Node = NextNode;
                NextNode = NextNode.Next;
                People.Remove(current);
                if (NextNode == null)
                {
                    NextNode = Node;
                }
                current = NextNode.Next;
                NextNode = NextNode.Next;

                foreach (byte num in People)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

            //while (People.Count > 1)
            //{
            //    int z = People.Count;
            //    for (int i = 1; i < z; i = i + 2)
            //    {
            //        People.Remove(i);
            //    }

            //    foreach (byte num in People)
            //    {
            //        Console.Write(num + " ");
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine();

            foreach (byte num in People)
            {
                Console.Write(num + " ");
            }

            Console.ReadKey();
        }

        public static byte RequestN()
        {
            Console.WriteLine("Enter integer N");
            byte.TryParse(Console.ReadLine(), out byte n);
            return n;
        }

        public static int[] CreateArray(int N)
        {
            int z = 1;
            int[] mass = new int[N];

            for (int i = 0; i < N; i++)
            {
                mass[i] = z;
                z-=-1;
            }

            return mass;
        }
    }
}
