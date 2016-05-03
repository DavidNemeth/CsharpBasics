using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefAndValueTypes
{
    public class Invoice
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IdentityTest()
        {
            Invoice firstInvoice = new Invoice();
            firstInvoice.ID = 1;
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

            secondInvoice = firstInvoice;
            Assert.IsTrue(object.ReferenceEquals(secondInvoice, firstInvoice));

            secondInvoice.ID = 5;
            Assert.IsTrue(firstInvoice.ID == 5);

            firstInvoice.Description = "test2";
            Assert.IsTrue(secondInvoice.Description == "test2");
        }        
    }
}
