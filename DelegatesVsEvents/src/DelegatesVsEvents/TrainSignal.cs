using System;


namespace DelegatesVsEvents
{
    class TrainSignal
    {
        public Action TrainsAreComing; //void delegate reference
        public Action GoodToGo;

        public void HereComesATrain()
        {
            //logix
            TrainsAreComing();
        }
        public void TrainIsGone()
        {
            //more logix
            GoodToGo();
        }
    }

    class Car
    {
        public Car(TrainSignal trainSignal)
        {
            trainSignal.TrainsAreComing += StopTheCar; //add to list(subscribe)
            trainSignal.GoodToGo += MoveOn;
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
