
// Lambda Expression is an unnamed method written in place of delegate instance
// (parameters) => expression-or-statement-block
SquareDelegate sqr = x => x * x;
Console.WriteLine(sqr(3)); // 9

//lambda expression with statement code block
PlusDelegate plus = (a, b) => { return a + b; };
Console.WriteLine(plus(2,9));

Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
int total = totalLength("hello", "world"); // total is 10;
Console.WriteLine(total);

delegate int SquareDelegate(int i);
delegate int PlusDelegate (int i, int j);
