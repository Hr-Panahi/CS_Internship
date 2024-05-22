
Predicate<int> p1 = value => value > 0;
Predicate<int> p2 = (value) => value > 0;
Predicate<int> p3 = (int value) => value > 0;
Predicate<int> p4 = value => { return value > 0; };
Predicate<int> p5 = (value) => { return value > 0; };
Predicate<int> p6 = (int value) => { return value > 0; };
Predicate<int> p7 = bool (value) => value > 0;
Predicate<int> p8 = bool (int value) => value > 0;
Predicate<int> p9 = bool (value) => { return value > 0; };
Predicate<int> pA = bool (int value) => { return value > 0; };


/*Lambda Expression is an unnamed method written in place of delegate instance
 * (parameters) => expression-or-statement-block
*/

SquareDelegate sqr = x => x * x;
Console.WriteLine(sqr(3)); // 9

PlusDelegate plus = (a, b) => { return a + b; };
Console.WriteLine(plus(2,9));

Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
int total = totalLength("hello", "world"); // total is 10;
Console.WriteLine(total);

//lambda expression with statement code block
delegate int SquareDelegate(int i);
delegate int PlusDelegate (int i, int j);
