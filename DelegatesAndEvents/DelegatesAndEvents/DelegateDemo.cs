using System;
using System.Collections.Generic;


namespace DelegatesAndEvents
{
    class DelegateDemo
    {
        delegate bool Mydeli(int n);
        delegate void ChainDeli();
        delegate int ReturnDeli();
        static void Main()
        {
            int[] numbers = new int[] { 11, 3, 15, 6, 5, 2, 20, 8 };
            IEnumerable<int> result = GetNumbers(numbers, n => n < 10);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();

            //Delegate chaining

            ChainDeli a = Foo;
            a += Goo;
            a += Moo;
            a();
            Console.ReadLine();
            ReturnDeli deli = ReturnFive;
            deli += ReturnTen;
            deli += ReturnZero;
            //List<int> returnInts = new List<int>();
            //foreach (ReturnDeli del in deli.GetInvocationList())
            //    returnInts.Add(del());            
            foreach (int item in GetAllReturns(deli))
                Console.WriteLine(item);
            
            Console.ReadLine();
        }

        static IEnumerable<int> GetNumbers(IEnumerable<int> numbers, Mydeli deli)
        {
            foreach (int number in numbers)
            {
                if (deli(number))
                {
                    yield return number;
                }
            }
        }

        static void Foo() { Console.WriteLine("Foo()"); }
        static void Goo() { Console.WriteLine("Goo()"); }
        static void Moo() { Console.WriteLine("Moo()"); }

        static List<int> GetAllReturns(ReturnDeli d)
        {
            List<int> returnInts = new List<int>();
            foreach (ReturnDeli del in d.GetInvocationList())
                returnInts.Add(del());
            return returnInts;
        }
        static int ReturnFive() { return 5; }
        static int ReturnTen() { return 10; }
        static int ReturnZero() { return 0; }
    }
}
