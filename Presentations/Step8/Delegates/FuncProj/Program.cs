

Func<string, string> selector = str => str.ToUpper();

Func<string> getGreeting = () => "Hello, Func delegate!";
Console.WriteLine(getGreeting());

Func<string, string> toUpper = str => str.ToUpper();
Console.WriteLine(toUpper("hello"));

Func<int, int, int> multiply = (a, b) => a * b;
Console.WriteLine(multiply(5, 3));



string[] words = { "orange", "apple", "Article", "elephant" };

IEnumerable<string> aWords = words.Select(selector);

foreach (string word in aWords)
	Console.WriteLine(word);

