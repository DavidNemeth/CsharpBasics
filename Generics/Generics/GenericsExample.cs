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
            Random randy = new Random();
            var myList = new MyList<int> { };
            var microsoftList = new List<int> { };
            for (int i = 0; i < 20; i++)
            {
                myList.Add(randy.Next(100));
                microsoftList.Add(randy.Next(100));
            }
            microsoftList.Sort();
            foreach (var item in microsoftList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            myList.Sort();
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
