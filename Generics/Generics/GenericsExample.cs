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
            P("Not sure why i would do this");
            var ageList = new MyList<int>(5) { 1, 2, 3, 4, 5 };
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 50000; i++)
            {
                ageList.InsertRange(2, new[] { 10, 20, 30, });
            }            
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks / (float)Stopwatch.Frequency);
        }
    }
}
