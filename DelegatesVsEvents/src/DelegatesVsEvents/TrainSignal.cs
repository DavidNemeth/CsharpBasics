using System;


namespace DelegatesVsEvents
{
    class TrainSignal
    {
        public event Action TrainsAreComing; //void delegate reference
        public event Action GoodToGo;

        public void HereComesATrain()
        {
            //logix
            if (TrainsAreComing != null)
            {
                TrainsAreComing.Invoke();
            }
            
        }
        public void TrainIsGone()
        {
            //more logix
            if (GoodToGo != null)
            {
                GoodToGo.Invoke();
            }
            
        }
    }

    class Car
    {
        public Car(TrainSignal trainSignal)
        {
            trainSignal.TrainsAreComing += StopTheCar; //add to list(subscribe)
            trainSignal.GoodToGo += () => Console.WriteLine("Get movin' boy!"); //same stuff with Lambda
        }

        private void MoveOn()
        {
            Console.WriteLine("Good to go!");
        }

        private void StopTheCar()
        {
            Console.WriteLine("STAPHH!");
        }
    }
}
