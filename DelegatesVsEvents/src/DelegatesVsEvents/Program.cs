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
            trainSignal.TrainIsGone();
            Console.WriteLine();

            //events stop you from invoking/assigning delegate directly            
            //trainSignal.TrainsAreComing();
            //trainSignal.TrainsAreComing = null;
            //so you no accident today:(           
            
            trainSignal.HereComesATrain();
            Console.ReadLine();
        }
    }
}
