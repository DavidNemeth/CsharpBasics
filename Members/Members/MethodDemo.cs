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
        public  MethodDemo()
        {
            WriteAsBytes(32, 42, 255, Int16.MaxValue, Int32.MaxValue);
            WriteAsBytes(new double[] { 2.0, 4.4, 5.2, 7.1, 9.2 });                    
        }

        private void WriteAsBytes(params int[] values)
        {
            Debug.WriteLine("writing integers");
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
        private void WriteAsBytes(params double[] values)
        {
            Debug.WriteLine("writing doubles");
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
