namespace LambdaProj2
{
	internal class Program
	{


		static void Main(string[] args)
		{
			Func<float, float, float> Plus = (a, b) => a + b;
			Func<float, float, float> Minus = (a, b) => a - b;
			Func<float, float, float> Divide = (a, b) => a / b;
			Func<float, float, float> Multiply = (a, b) => a * b;

			Dictionary<string, Func<float, float, float>> Operators = new Dictionary<string, Func<float, float, float>>
			{
				{ "+",Plus },
				{ "-",Minus },
				{ "/",Divide },
				{ "*",Multiply }
			};

			Func<float, float, float> OperationGet(string s)
			{
				if (Operators.ContainsKey(s))
				{
					return Operators[s];
				}
				else
				{
					return null;
				}
			}

			float a = 10f;
			float b = 5f;
			//string operator = "+";

			Func<float, float, float> operation = OperationGet("+");
			float result = operation(a, b);
			Console.WriteLine(result);

			//string[] operations = { "+", "-", "/", "*" };

			//foreach (string op in operations)
			//{
			//	Func<float, float, float> operation = OperationGet(op);
			//	if (operation != null)
			//	{
			//		float result = operation(a, b);
			//		Console.WriteLine($"{a} {op} {b} = {result}");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Operation {op} not found.");
			//	}
			//}
		}
	}
}
