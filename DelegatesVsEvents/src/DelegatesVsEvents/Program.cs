﻿using System;

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

            //eventhandler

            Script s1 = new Script { Name = "Raiku" };
            s1.Interrupt += interrupt;
            Script s2 = new Script { Name = "Barburas" };
            s2.Interrupt += interrupt;
            Script caster = new Random().Next() % 2 == 0 ? s1 : s2;
            caster.CastInterrupted();

            Console.ReadLine();
                                  
        }
        static void interrupt(object sender, ScriptEventArgs e)
        {
            Script s = sender as Script;            
            switch (e.CurrentCastState)
            {
                case CastState.Casting:
                    Console.WriteLine("{0} Interrupt!", s.Name);                    
                    break;

                case CastState.Iddle:
                    Console.WriteLine("Not casting");
                    break;
            }
        }
    }    
}
