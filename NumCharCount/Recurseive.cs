using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NumCharCount
{
    class Recurseive
    {
        class Counting
        {
            static int Id;
            public int id
            {
                get { return Id; }
                set { Id = value; }
            }
            public char c;
            public Counting()
            {
                c = (char)(((int)'a') + Id);
                Id++;
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
            Recurse(10);
            Console.Read();
        }        
    }
}
