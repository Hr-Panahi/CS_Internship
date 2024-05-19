using System;

namespace MultiCastDelegateExample
{
	public delegate void SaySomethingDelegate(string s);
	internal class Program
	{
		static void Main(string[] args)
		{
			// Multi-cast delegate combining Hello and Goodbye methods
			SaySomethingDelegate singleDelegate1 = Hello;
			singleDelegate1 = Goodbye;
			singleDelegate1("Charlie");

			// Multi-cast delegate combining Hello, Goodbye, and Greetings methods
			SaySomethingDelegate singleDelegate2 = Greetings;
			//singleDelegate = Greetings;
			singleDelegate2.Invoke("Dave");

			Console.WriteLine(singleDelegate1.Method);
			Console.WriteLine(singleDelegate2 == Goodbye);
			Console.WriteLine(singleDelegate1 != singleDelegate2);
		}

		public static void Hello(string name)
		{
			Console.WriteLine($"Hello, {name}!");
		}

		public static void Goodbye(string name)
		{
			Console.WriteLine($"Goodbye, {name}!");
		}

		public static void Greetings(string name)
		{
			Console.WriteLine($"Greetings, {name}!");
		}
	}
}
