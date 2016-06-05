using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var myList = new MyList<int> { 10, 20, 30, 40, 50 };
            var microsoftList = new List<int> { 1, 2, 3, 4, 5 };
            microsoftList.RemoveAt(1);
            myList.RemoveAt(0);
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
