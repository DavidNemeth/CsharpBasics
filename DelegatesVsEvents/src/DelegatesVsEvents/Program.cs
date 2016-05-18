using System;

namespace DelegatesVsEvents
{
    public class Program
    {       
        public static void Main(string[] args)
        {
            TrainSignal trainSignal = new TrainSignal();
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            trainSignal.HereComesATrain();
            Console.WriteLine();
            trainSignal.GoodToGo();
        }
    }
}
