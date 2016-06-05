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
            var myList = new MyList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var microsoftList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(microsoftList.Exists(i => i >= 10));
            Console.WriteLine(myList.Exists(i => i >= 10));
        }
    }
}
