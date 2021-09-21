using System;
using System.Collections.Generic;
using System.Text;

namespace Scenarios
{
    public class InheritanceScenario2
    {
        public static void Practice()
        {
            Bb b = new Bb();
            b.abc(new Q());
            Console.ReadLine();
        }
    }

    public class P
    { }
    public class Q : P
    { }

    public class Aa
    {
        public void abc(Q q)
        {
            Console.WriteLine("abc from Aa"); 
        }
    }

    public class Bb : Aa
    {
        public void abc(P p)
        {
            Console.WriteLine("abc from Bb");// I answered this
        }
    }
}
