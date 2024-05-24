using System;
using System.Diagnostics;

namespace MultiCastDelegateExample
{
	public delegate void SaySomethingDelegate(string s);

	internal class Program
	{
		static void Main(string[] args)
		{
			
			SaySomethingDelegate singleDelegate1;
			singleDelegate1 = Hello;
			//singleDelegate1 = Greetings;
			singleDelegate1("Hamid");

			SaySomethingDelegate singleDelegate2 = Greetings;
			singleDelegate2.Invoke("Mohammad");

			//Console.WriteLine(singleDelegate1.Method);
			//Console.WriteLine(singleDelegate2 == Goodbye);
			//Console.WriteLine(singleDelegate1 != singleDelegate2);

			#region Multi-cast Delegate
			//SaySomethingDelegate multiDelegate;
			//multiDelegate = Hello;
			//multiDelegate += Goodbye;
			//multiDelegate += Greetings;
			////simple invoke is type safe with compile time checking
			//multiDelegate("Legend");
			//foreach (Delegate a in multiDelegate.GetInvocationList())
			//{
			//	Console.WriteLine(a.Method);
			//}
			#endregion

			//int name = int.Parse(Console.ReadLine());
			////runtime checking -it is not type safe
			//multiDelegate.DynamicInvoke(name);
			//Console.WriteLine(multiDelegate.DynamicInvoke(name));

			#region Invoke vs. DynamicInvoke
			//Func<int, int> twice = x => x * 2;
			//const int LOOP = 5000000;
			//var watch = Stopwatch.StartNew();
			//for (int i = 0; i < LOOP; i++)
			//{
			//	twice.Invoke(3);
			//}
			//watch.Stop();
			//Console.WriteLine("Invoke: {0}ms", watch.ElapsedMilliseconds);
			//watch = Stopwatch.StartNew();
			//for (int i = 0; i < LOOP; i++)
			//{
			//	twice.DynamicInvoke(3);
			//}
			//watch.Stop();
			//Console.WriteLine("DynamicInvoke: {0}ms", watch.ElapsedMilliseconds);
			#endregion
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
