using System;

namespace Generics
{
    class MyList<T>
    {
        T[] ints = new T[3];
        int currentIndex;
        public void Add(T i)
        {
            if (currentIndex == ints.Length)
            {
                Grow();
            }
            ints[currentIndex++] = i;
        }
        public T Get(int index)
        {
            return ints[index];
        }

        private void Grow()
        {
            T[] temp = new T[ints.Length * 2];
            Array.Copy(ints, temp, ints.Length);
            ints = temp;
        }
        public int Length { get { return currentIndex; } }
    }


    class GenericsExample
    {
        static void PrintItems<T>(MyList<T> items)
        {
            for (int i = 0; i < items.Length; i++)            
                Console.WriteLine(items.Get(i));            
        }
        static void P<T>(T item)
        {
            Console.WriteLine(item);
        }
        static void Main(string[] args)
        {
            MyList<int> myInts = new MyList<int>();
            myInts.Add(4);
            myInts.Add(1);
            myInts.Add(12);
            myInts.Add(2);

            P("Hello");
            P(5);
            PrintItems(myInts);
            for (int i = 0; i < myInts.Length; i++)            
                Console.WriteLine(myInts.Get(i));
            
            Console.Read();
        }
    }
}
