using System;

namespace Scenarios
{
    //How to Implement Multiple Interfaces Having Same Method Name

    //For a class: Internal is the default if no access modifier is specified.
    //For a method: Private is the default if no access modifier is specified.
    class InterfaceScenario1
    {
        public static void Practice()
        {
            Math obj = new Math();
            obj.Add(); //This will not throw error, if single method is there

            IA obj1 = new Math();
            obj1.Add();

            IB obj2 = new Math();
            obj2.Add();
        }        
    }
    public interface IA
    {
        public void Add();
    }

    public interface IB
    {
        public void Add();
    }

    public class Math : IA, IB
    {
        public void Add()
        {
            Console.WriteLine("I am addition method");
        }

        //Class methods are private and sealed by default in .NET.This means the method is only visible within the class and cannot be overridden by the inherited class.
        //Not sure about the access modifier of this method
        void IA.Add() // Real scanerio when you want to provide different implementation, access modefier is making big sense here.
        {
            Console.WriteLine("I am Addition IA method");
        }

        void IB.Add()
        {
            Console.WriteLine("I am Addition IB method");
        }
    }
}
