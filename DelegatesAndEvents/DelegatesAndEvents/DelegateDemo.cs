using System;
using System.Collections.Generic;


namespace DelegatesAndEvents
{
    class DelegateDemo
    {        
        static void Main()
        {
            #region delegateParameter
            int[] numbers = new int[] { 11, 3, 15, 6, 5, 2, 20, 8 };
            IEnumerable<int> result = GetNumbers(numbers, n => n < 10);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
            #endregion

            #region DelegateChaining
            Action a = Foo;
            a += Goo;
            a += Moo;
            a();
            Console.ReadLine();
            #endregion

            #region funcAndAction
            //Func  -> delegate, can have return argument
            //Action -> delegate returns void
            Func<int> d = ReturnFive;
            d += ReturnTen;
            d += ReturnZero;

            foreach (int item in GetAllReturns(d))
                Console.WriteLine(item);
            Console.ReadLine();
            #endregion

            #region Closure
            //c will reference different action than b thus making them unique
            Action c = GiveMeAction();
            Action b = GiveMeAction();
            b(); c(); c(); c(); b(); c(); //b:i=4 j=9 c:i=8 j=13
            GiveMeAction(); // i=0 j=5
            #endregion
        }
        #region DelegateParameter
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
        #endregion

        #region DelegateChaining
        static void Foo() { Console.WriteLine("Foo()"); }
        static void Goo() { Console.WriteLine("Goo()"); }
        static void Moo() { Console.WriteLine("Moo()"); }
        #endregion

        #region FuncAndAction
        static IEnumerable<T> GetAllReturns<T>(Func<T> d)
        {            
            foreach (Func<T> del in d.GetInvocationList())
                yield return del();
        }
        static int ReturnFive() { return 5; }
        static int ReturnTen() { return 10; }
        static int ReturnZero() { return 0; }
        #endregion

        #region closures
        static Action GiveMeAction()
        {
            Action ret = null;

            int i = 0;
            int j = 5;
            ret += () => i++;
            ret += () => j++;
            ret += () => { i++; j++; };
            return ret;
            //var temp = new ThisisWhatActuallyHappens();
            //ret += temp.lambdais;
            //ret += temp.anameless;
            //ret += temp.function;
            //return ret;
        }

        class ThisisWhatActuallyHappens
        {
            int i = 0;
            int j = 5;
            public void lambdais()
            {
                i++;
            } 
            public void anameless()
            {
                j++;
            }
            public void function()
            {
                i++;j++;
            }
        }
        #endregion
    }
}
