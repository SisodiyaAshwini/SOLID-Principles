using System;

namespace Scenarios
{
    //https://www.akadia.com/services/dotnet_polymorphism.html
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords 
    //this is the best link to understand this, The most important point to understand is type and value type, because this will create the initial link chart and accorfingly methods will be called.
    // if we do C c = new C()
    //iterator has knoweledge of C 
    //but if i do A a = new C()
    //menas it has link and method, from virtual to override and if new is there what will happen, this relationship is hidden.

    public static class InhertitanceScenario1
    {
        public static void Practice()
        {
            C c = new C();
            Console.WriteLine("C c = new C(); "+c.GetType());
            A a = new A();
            Console.WriteLine(" A a = new A(); " + a.GetType());
            a = c; // The most important to note here is a is type A and value type C.
            Console.WriteLine(" a = c; " + a.GetType());
            a.Show();
            c.Show();
            Console.ReadLine();
        }
    }
    class A
    {
        public virtual void Show()
        {
            Console.WriteLine("A.Show()");
        }
    }
    class B : A
    {
        public new void Show()
        {
            Console.WriteLine("B.Show()");
        }
    }
    class C : B
    {
        public new void Show()
        {
            Console.WriteLine("C.Show()");
        }
    }
}
//Output
//A.Show()
//C.Show()

/*
 * A.Show() because you have created a object of class A which is a base class, now it means the type and value type both are of class A,
 * when you are assiging a=c, now the value type is c but type is still A, and because the herachichy is A to B To C, 
 * For this object it will see virtual in A and look for override keywrod but because the override is not there and new is there(which is actually showding and hiding), 
 * it will not go to C because override keyword is not there
 * new break the herarchicy relationship
 * A.Show() will be called.
 */