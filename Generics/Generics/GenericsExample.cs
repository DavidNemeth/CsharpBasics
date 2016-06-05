using System;
using System.Collections.Generic;

namespace Generics
{
    class GenericsExample
    {
        static void P<T>(MyList<T> items)
        {
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(items[i]);
        }
        static void P<T>(T items)
        {
            Console.WriteLine(items);
        }
        static void Main(string[] args)
        {
            var myList = new MyList<int> { 18, 28, 38, 40 };
            var microsoftList = new List<int> { 18, 28, 38, 40 };
            Console.WriteLine(microsoftList.TrueForAll(i => i >= 18));
            Console.WriteLine(myList.TrueForAll(i => i >= 18));

            microsoftList.ForEach(Console.WriteLine);
            Console.WriteLine();
            myList.ConvertAll(i => i.ToString());
            myList.ForEach(Console.WriteLine);
        }
    }
}
