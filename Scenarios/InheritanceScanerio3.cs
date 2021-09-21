using System;

namespace Scenarios
{
    public class InheritanceScanerio3
    {
		public static void Practice()
		{
			MyClassB b = new MyClassB();
			MyClassA a = b;
			a.abc();
			Console.ReadLine();
		}
	}


	class MyClassA
	{
		public MyClassA()
		{
			Console.WriteLine("constructor A");
		}

		public void abc()
		{
			Console.WriteLine("A");
		}
	}



	class MyClassB : MyClassA
	{
		public MyClassB()
		{
			Console.WriteLine("constructor B");
		}

		public void abc()
		{
			Console.WriteLine("B");
		}
	}
}
