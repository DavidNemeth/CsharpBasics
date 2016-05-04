using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members
{
    public class DelegateDemo
    {
        /*
         * delegate can invoke multiple method across multiple object
         * events makes them safe to expose from a class
         * events allow you to add or remove yourself from invocation list
        */
        public DelegateDemo()
        {
            DebugWindowLogger log1 = new DebugWindowLogger();
            BetterDebugWindowLogger log2 = new BetterDebugWindowLogger();
                     
            _writer = new DelegateMessage(log2.SendMessage);
            _writer += log1.SendMessage;
            _writer += log2.SendMessage;
            _writer += log1.SendMessage;
        }

        public void DoWork()
        {
            _writer("Doing some work");
        }

        public DelegateMessage _writer;
    }

    public delegate void DelegateMessage(String message);

    public class DebugWindowLogger
    {
        public void SendMessage(string message)
        {
            Debug.WriteLine(message + " first");
        }
    }

    public class BetterDebugWindowLogger
    {
        public void SendMessage(string message)
        {
            Debug.WriteLine(message + " better!");
        }
    }
}
