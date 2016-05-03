using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceLib
{
    public class Invoice
    {
        public int ID { get; set; }  // int->value type, stored in stack=static memory
        public string Description { get; set; } // string->stored in heap(dynamic memory allocation), since they can be huge
        public decimal Amount { get; set; }
    }
}
