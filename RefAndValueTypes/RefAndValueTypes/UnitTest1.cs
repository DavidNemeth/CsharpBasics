﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefAndValueTypes
{
    public class Invoice
    {
        public int ID { get; set; }  // int->value type, stored in stack=static memory
        public string Description { get; set; } // string->stored in heap(dynamic memory allocation), since they can be huge
        public decimal Amount { get; set; }
    }

    /*
     *  This Unit test shows the difference between value and reference types.
     *  Reference types holds a pointer to a nother area of the heap that contains the value for our object.
     *  Value types got their space reserved on the stack that holds the actual value.
     */
    [TestClass]
    public class RefAndValueTypes
    {
        /*
        * The test gives a simple example how reference type behave,
        * and all new instace points to different objects 
        */
        [TestMethod]
        public void IdentityTest()
        {
            Invoice firstInvoice = new Invoice();
            firstInvoice.ID = 1;  // pointer!
            firstInvoice.Description = "Test";
            firstInvoice.Amount = 0.0M;

            Invoice secondInvoice = new Invoice();
            secondInvoice.ID = 1;
            secondInvoice.Description = "Test";
            secondInvoice.Amount = 0.0M;

            Assert.IsFalse(object.ReferenceEquals(secondInvoice, firstInvoice));
            Assert.IsTrue(firstInvoice.ID == 1);

            secondInvoice.ID = 2;

            Assert.IsTrue(firstInvoice.ID == 1);
            Assert.IsTrue(secondInvoice.ID == 2);


            /*
             * Since we make both instance equal to each other
             * from now on they are pointed to the same object,
             * therefore if we make changes both instance will change.
             * (well there is really only one now)
             */
            secondInvoice = firstInvoice;
            Assert.IsTrue(object.ReferenceEquals(secondInvoice, firstInvoice));

            secondInvoice.ID = 5;
            Assert.IsTrue(firstInvoice.ID == 5);

            firstInvoice.Description = "test2";
            Assert.IsTrue(secondInvoice.Description == "test2");
        }
        /*
         * This test shows how value types behave differently
         * compared to reference type, as they actually hold the value and not a pointer. 
         */
        [TestMethod]
        public void ValueTypeTest()
        { 
            int x = 5;
            int y = x;

            y = 10;

            Assert.IsTrue(x == 5);
            Assert.IsTrue(y == 10);
        }
        /*
         * Parameters pass "by value" on default
         * Reference types pass a COPY of the reference(copy of the pointer)
         * Value Types pass a COPY of the value         
         * CHANGES TO VALUE DONT PROPAGATE TO CALLER!
         * 
         * ref and out keywords allow pass "by reference"
         * ref parameters requires initialized variable
         * out must be assigned in the method
         */
        [TestMethod]
        public void MethodParameters()
        {
            Invoice invoice = new Invoice();
            invoice.ID = 1;
            int value;
            int refvalue = 1;

            DoWork(ref invoice,out value, ref refvalue);

            Assert.IsTrue(invoice.ID == 5);
            Assert.IsTrue(value == 2);
            Assert.IsTrue(refvalue == 3);            
        }

        void DoWork(ref Invoice invoice,out int value,ref int refvalue)
        {
            invoice = new Invoice();      
            invoice.ID = 5;
            refvalue = 3;
            value = 2;
        }
    }
}