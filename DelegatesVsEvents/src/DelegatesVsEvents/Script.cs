using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesVsEvents
{
    class Script
    {
        public string Name { get; set; }
        public event EventHandler Interrupt;
        public void Casting()
        {
            Interrupt?.Invoke(this, EventArgs.Empty);
        }
    }
}
