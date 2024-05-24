

static void CheckEven(int i)
{
	if (i % 2 == 0) 
		Console.WriteLine(i + " is Even");
	else
        Console.WriteLine(i + " is not even");    
}

Action<int> printActionDel = CheckEven;
CheckEven(10);

// Action delegate with no parameters
Action greet = () => Console.WriteLine("Hello, World!");
greet();

// Action delegate with one parameter
Action<string> printMessage = message => Console.WriteLine(message);
printMessage("Hello, Action delegate!");

// Action delegate with two parameters
Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");
add(5, 3);


//Example 2

List<string> names = new List<string>();
names.Add("Hamid");
names.Add("Ali");
names.Add("Hosein");
names.Add("Mohammad");

//names.ForEach(Print);

names.ForEach(delegate (string name)
{
	Console.WriteLine(name);
});

//void Print(string s)
//{
//	Console.WriteLine(s);
//}