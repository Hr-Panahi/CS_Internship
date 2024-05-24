
// Predicate delegate to check if a number is even
//Predicate<int> isEven = number => number % 2 == 0;
//Console.WriteLine(isEven(4)); 
//Console.WriteLine(isEven(5)); 

//List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
//int firstEven = numbers.Find(isEven);
//Console.WriteLine($"First even number: {firstEven}");


#region Predicate<in T>
List<string> names = new List<string>() { "Hamid", "Reza", "Mohammad", "Sina" };
//names.RemoveAll(Filter);
//foreach (var name in names)
//{
//	Console.WriteLine(name);
//}
names.RemoveAll(s => s.Contains("a"));
foreach (var name in names)
{
	Console.WriteLine(name);
}
static bool Filter(string s)
{
	return s.Contains("i");
}
static bool Filter2(string s)
{
	return s.Contains("a");
}
#endregion