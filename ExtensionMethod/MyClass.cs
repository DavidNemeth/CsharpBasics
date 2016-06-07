using ExtensionMethod;
using System;
using System.Collections.Generic;

namespace ExtensionMethod
{
    public class MyClass
    {
        public void DoStuff()
        {
            "Example One.Print".Print();
            string message = "Hello, my name is David";
            string name = message.GetStringsAfter("Hello, my name is ");
            name.Print();
            Console.WriteLine();

            "Example Two".Print();
            var myList = new List<string>() { "hello", "hi", "dave", "whats up", "hey" };
            var messageStartsWith = myList.StartsWith("h");           
            foreach (var item in messageStartsWith)
            {
                item.Print();
            }
            Console.WriteLine();

            "Example Three".Print();
            int i = 12;
            i.Print();

            Console.WriteLine();
            "Example Four".Print();
            var myConstrait = new MyConstraint();
            myConstrait.PrintConstraint();
        }
    }
}