using System;
using System.Collections;
using System.Collections.Generic;
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
            var ageList = new MyList<int>(5) { 10, 12, 41, 21, 52 };
            ageList.InsertRange(2, new[] { 50, 51, 52, 50, 51, 52, 50, 51, 52, 50, 51, 52, 50, 51, 52 });  
            P(ageList);               
        }
    }
}
