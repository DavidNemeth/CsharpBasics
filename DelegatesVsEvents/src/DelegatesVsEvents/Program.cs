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

            //events are delegate references that you cant invoke/assign directly
            //trainSignal.TrainsAreComing();
            //trainSignal.TrainsAreComing = null;
            //so no accident today:(    
            trainSignal.HereComesATrain();
            Console.ReadLine();

            //adding and removing 

            Cow charlie = new Cow();
            charlie.Mooing += () => Console.WriteLine("Moo!");            
            charlie.AnnoyTheCow();
            Console.ReadLine();
        }
    }    
}
