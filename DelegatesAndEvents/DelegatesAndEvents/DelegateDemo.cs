using System;
using System.Collections.Generic;


namespace DelegatesAndEvents
{
    class DelegateDemo
    {
        //delegate bool Mydeli(int n);
        //delegate void ChainDeli();
        //delegate T ReturnDeli<T>();
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

            Action a = Foo;
            a += Goo;
            a += Moo;
            a();
            Console.ReadLine();

            //Func  -> delegate, can have return argument
            //Action -> delegate returns void

            Func<int> d = ReturnFive;
            d += ReturnTen;
            d += ReturnZero;
                        
            foreach (int item in GetAllReturns(d))
                Console.WriteLine(item);
            
            Console.ReadLine();
        }
        #region mydeli
        static IEnumerable<int> GetNumbers(IEnumerable<int> numbers, Func<int, bool> deli)
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
        #endregion

        #region returndeli
        static IEnumerable<T> GetAllReturns<T>(Func<T> d)
        {            
            foreach (Func<T> del in d.GetInvocationList())
                yield return del();
        }
        static int ReturnFive() { return 5; }
        static int ReturnTen() { return 10; }
        static int ReturnZero() { return 0; }
        #endregion  
    }
}
