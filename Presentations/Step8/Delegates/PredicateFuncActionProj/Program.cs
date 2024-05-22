

#region Predicate<in T>
List<string> names = new List<string>() { "Hamid", "Reza", "Mohammad" };
names.RemoveAll(Filter);
foreach(var name in names)
{
	Console.WriteLine(name);
}
names.RemoveAll(s => s.Contains("a"));
foreach(var name in names)
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