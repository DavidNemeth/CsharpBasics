using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesVsEvents
{
    class Cow
    {
        private Action mooing;
        public event Action Mooing
        {
            add
            {
                mooing += value;
                mooing += value;
                mooing += value;
                Console.WriteLine("adding");
            }
            remove
            {
                mooing -= value;
                Console.WriteLine("removing");
            }
        }
        public void AnnoyTheCow()
        {
            if (mooing != null)
            {
                mooing();
            }
        }
    }
}

