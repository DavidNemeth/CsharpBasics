using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public interface IConstraint
    {
        string message { get; }
    }
    public class MyConstraint : IConstraint
    {
        public string message
        {
            get
            {
                return "Hello..";
            }
        }
    }

    public static class GenericExtensions
    {
        public static void PrintConstraint<T>(this T ex) where T : IConstraint
        {
            Console.WriteLine(ex.message);
        }
        public static void Print<T>(this T message)
        {
            Console.WriteLine(message);
        }
    }
}
