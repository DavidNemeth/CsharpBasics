using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members
{
    public class MethodDemo
    {
        public MethodDemo()
        {
            WriteAsBytes(32, 42, 255, Int16.MaxValue, Int32.MaxValue);
            WriteAsBytes(new int[] { 2, 4, 5, 7, 9 });                    
        }

        private void WriteAsBytes(params int[] values)
        {
            foreach (var value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                foreach (byte b in bytes)
                {
                    string message = String.Format("0x{0:X2} ", b);
                    Debug.Write(message);
                }

                Debug.WriteLine("");
            }
        }
    }
}
