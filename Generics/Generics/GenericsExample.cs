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
            var blabla = new int[myList.Count];
            int[] myToArray = myList.ToArray();

            myList.CopyTo(blabla);
            foreach (var item in blabla)
            {
                Console.WriteLine(item);
            }
            
            
        }
    }
}
