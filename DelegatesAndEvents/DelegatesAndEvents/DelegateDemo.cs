using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class DelegateDemo
    {
        delegate bool Mydeli(int n);

        static void Main()
        {
            int[] numbers = new int[] { 11, 3, 15, 6, 5, 2, 20, 8 };
            IEnumerable<int> result = GetNumbers(numbers, n => n < 10);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            Console.Read();
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
    }
}
