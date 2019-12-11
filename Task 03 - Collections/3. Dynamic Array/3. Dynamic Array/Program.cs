using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class DynamicArray<T>
    {
        private T[] store;
        private int CurrentIndex = 0;
        private int _length;
        private int _capasity;

        public DynamicArray()
        {
            store = new T[8];
        }

        public DynamicArray(int Length)
        {
            store = new T[Length];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (store.Length <= CurrentIndex)
            {
                var newStore = new T[CurrentIndex * 2];
                store = newStore;
            }

            store[++CurrentIndex] = item;

        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (store.Length <= collection.Count())
            {
                var newStore = new T[collection.Count() * 2];
                store = newStore;
            }

            foreach (T item in collection)
            {
                Add(item);
            }
        }
        
        public bool Remove (T item)
        {
            int i = 0;
            int indexOfElement = 0;

            if (store.Contains(item))
            {
                foreach (T element in store)
                {
                    //только вот как сравнить два дженерика?(element == item). их же нельзя сравнить. надо think 'bout it...
                    if (element == item)
                    {
                        indexOfElement = i;
                    }

                    i++;
                }

                for (i = 0; i < store.Length; i++)
                {
                    if (i == indexOfElement)
                    {
                        store[i] = default;
                    }
                }

                return true;
            }

            return false;
        }

        public bool Insert (T item, int position)
        {
            if (position > store.Length)
            {
                var newStore = new T[(position - store.Length) * 2];
                store = newStore;
                store[position] = item;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Length
        {
            get
            {
                _length = store.Length;
                return _length;
            }
        }

        public int Capasity
        {
            get
            {
                return _capasity;
            }
        }


    }
}
