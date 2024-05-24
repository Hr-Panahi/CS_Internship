
internal class Program
{
	public delegate bool FilterDelegate(Person p);

	private static void Main(string[] args)
	{
		#region Initializing
		Person p1 = new Person("Hamid", 29);
		Person p2 = new Person("Mohammad", 34);
		Person p3 = new Person("Mina", 25);
		Person p4 = new Person("Farzad", 30);
		Person p5 = new Person("Ali", 12);
		Person p6 = new Person("Sara", 8);

		List<Person> people = new() { p1, p2, p3, p4, p5, p6 };
		#endregion

		//DisplayPeople("Childs", people, Childs);


		#region Anonymous Method
		FilterDelegate filter = delegate (Person p)
		{
			return p.Age > 25 && p.Age < 30;
		};

		DisplayPeople("[Anonymous method] between 25 and 30:", people, filter);
		#endregion

		#region Lambda
		////statement lambda 
		//string searchKeyword = "A";
		//DisplayPeople("age > 20 with search keyword" + searchKeyword, people, p =>
		//{
		//	if (p.Name.Contains(searchKeyword) && p.Age > 20)
		//	{
		//		return true;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//});

		////expression lambda
		//DisplayPeople("People exactly 25 years old:", people, p => p.Age == 25);
		#endregion
	}
	static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
	{
		Console.WriteLine(title + ":");

		foreach (Person p in people)
		{
			if (filter(p))
			{
				Console.WriteLine("{0}, {1} years old!", p.Name, p.Age);
			}
		}
	}

	static bool Childs(Person p)
	{
		return p.Age <= 10;
	}

	static bool Teenagers(Person p)
	{
		return p.Age > 10 && p.Age < 20;
	}

	static bool Adults(Person p)
	{
		return p.Age >= 20;
	}
}

public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }

	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}
}



