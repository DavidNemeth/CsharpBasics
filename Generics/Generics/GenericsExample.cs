using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Generics
{
    class GenericsExample
    {
        static void P<T>(MyList<T> items)
        {
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(items[i]);
        }
        static void P<T>(T items)
        {
            Console.WriteLine(items);
        }
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            int[] items = Enumerable.Range(0, 100000000).ToArray();
            
            var myList = new MyList<int>(5) { 1, 2, 3, 4, 5 };            
            timer.Restart();
            myList.AddRange(items);
            myList.InsertRange(2, items);
            timer.Stop();
            Console.WriteLine("MyList speed: " + timer.ElapsedTicks / (float)Stopwatch.Frequency);

            var microsoftList = new List<int>(5) { 1, 2, 3, 4, 5 };
            timer.Restart();
            microsoftList.AddRange(items);
            microsoftList.InsertRange(2, items);
            timer.Stop();
            Console.WriteLine("microsoftList speed: " + timer.ElapsedTicks / (float)Stopwatch.Frequency);



        }
    }
}
