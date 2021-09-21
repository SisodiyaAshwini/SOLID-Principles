using System;

namespace Scenarios
{
    class Program
    {
        private static int y = x;
        private static int x = 5;
        static void Main(string[] args)
        {
            //InterfaceScenario1.Practice();
            //InhertitanceScenario1.Practice();
            //InheritanceScenario2.Practice();
            //InheritanceScanerio3.Practice();

            //Scenario
            Console.WriteLine(y);
            Console.ReadLine();

            //Scenario
            string nullString = (string)null;
            Console.WriteLine(nullString is string);
            Console.ReadLine();

            //Palindrom 
            string str = "madam";
            string reverseStr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseStr = reverseStr + str[i];
            }
            Console.WriteLine(str);
            Console.WriteLine(reverseStr);
            if (reverseStr == str)
            {
                Console.WriteLine("This is orignal string: " + str);
                Console.WriteLine("This is orignal reverse string: " + reverseStr);
            }
            Console.ReadLine();
        }
    }
}
