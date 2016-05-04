using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class Bus
    {
        public static int busNo = 0;
        public static string _name;

        static Bus()
        {
            Console.WriteLine("Woey, it's a new day! Drivers are starting to work.");
        }

        public Bus(string name)
        {            
            busNo++;
            _name = name;
            Console.WriteLine("Bus #{0} goes from the depot. Driver name: {1}", busNo, _name);
        }

        public Bus()
            : this("Anonimous")
        { 
        }
             
    }

    class constructorDemo
    {
        static void Main(string[] args)
        {
            Bus busOne = new Bus();
            Bus busTwo = new Bus("Dave");            
            Console.ReadLine();
        }
    }
}
