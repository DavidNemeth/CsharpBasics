using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlphAndNumTest
{
    class Recurseive
    {
        class Counting
        {
            static int counter = 0;
            public int id;            
            public char c;
            public Counting()
            {
                id = counter;
                c = (char)(((int)'a') + counter);
                counter++;
            }
        }
        static void Recurse(int i)
        {
            var c1 = new Counting();            
            Console.Write("{0}\t{1}\n" ,c1.c,c1.id);  
            if (i == 0)
            {
                return;
            }
            Recurse(i - 1);
        }

        static void Main(string[] args)
        {
            Recurse(100);
            Console.Read();
        }        
    }
}
