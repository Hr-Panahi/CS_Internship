
#region Program
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;
#nullable disable
Console.WriteLine("Select a method from the following table:\n");
Console.WriteLine("─────────────────────────────────────────────────────────");
Console.WriteLine("1. Divide              | 2. FileReader/HandledFileReader |");
Console.WriteLine("───────────────────────┼─────────────────────────────────|");
Console.WriteLine("3. Increment           | 4. CreateArray                  |");
Console.WriteLine("───────────────────────┼─────────────────────────────────|");
Console.WriteLine("5. FileReader2         | 6. ExceptionFilter              |");
Console.WriteLine("───────────────────────┼─────────────────────────────────|");
Console.WriteLine("7. NestedTryBlock      | 8. ThrowException               |");
Console.WriteLine("───────────────────────┼─────────────────────────────────");
Console.WriteLine("9. CustomException     |");
Console.WriteLine("───────────────────────┘\n");

bool running = true;
while (running)
{
	PrintInBlue("Enter name of the method:");
	string command = Console.ReadLine();

	switch (command.ToLower())
	{
		case "divide":
			Divide();
			break;
		case "filereader":
			FileReader();
			break;
		case "handledfilereader":
			HandledFileReader();
			break;
		case "incrementbyone":
			IncrementByOne();
			break;
		case "createarray":
			CreateArray();
			break;
		case "filereader2":
			FileReader2();
			break;
		case "nestedtryblock":
			NestedTryBlock();
			break;
		case "customexception":
			CustomException();
			break;
		case "exceptionfilter":
			ExceptionFilter();
			break;
		case "throwexception":
			ThrowException();
			break;
		default:
			Console.WriteLine("Invalid command. Try another command!");
			break;
	}
}
static void PrintWithColor(string message, ConsoleColor color = ConsoleColor.White)
{
	Console.ForegroundColor = color;
	Console.WriteLine(message);
	Console.ResetColor();
}

static void PrintInRed(string message)
{
	PrintWithColor(message, ConsoleColor.Red);
}

static void PrintInGreen(string message)
{
	PrintWithColor(message, ConsoleColor.Green);
}
static void PrintInBlue(string message)
{
	PrintWithColor(message, ConsoleColor.Blue);
}
static void PrintInYellow(string message)
{
	PrintWithColor(message, ConsoleColor.Yellow);
}
#endregion

#region Anatomy

try
{
	// try doing something
}
catch
{
	// catching exceptions here
}
finally
{
	// before leaving, execute codes here
}


#endregion

#region Your own code Detects an Error
void Divide()
{
	PrintInYellow(message: "Divide() is ready");
	try
	{
		PrintInGreen("Enter first number:");
		int a = int.Parse(Console.ReadLine());
		PrintInGreen("Enter second number:");
		int b = int.Parse(Console.ReadLine()) ;

		Console.WriteLine(a / b);
	}
	catch (Exception ex)
	{
		PrintInRed(ex.Message);
	}
	finally
	{
		Console.WriteLine("Finally block executed");
	}
}
#endregion

#region Failure in Class Library

void FileReader()
{
	PrintInYellow("FileReader() is ready");
	PrintInGreen("Enter file name:");
	string fileName = Console.ReadLine();

	string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	string filePath = Path.Combine(desktopPath, fileName);
	using (StreamReader reader = new StreamReader(filePath))
	{
		string line = reader.ReadLine();
		Console.WriteLine(line);
	}
}

void HandledFileReader()
{
	PrintInYellow("HandledFileReader() is ready");
	PrintInGreen("Enter file name:");
	string fileName = Console.ReadLine();

	string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	string filePath = Path.Combine(desktopPath, fileName);

	try
	{
		using (StreamReader reader = new StreamReader(filePath))
		{
			string line = reader.ReadLine();
			Console.WriteLine(line);
		}
	}
	catch (FileNotFoundException)
	{
		PrintInRed($"Couldn't find {fileName}.");
	}
}

#endregion

#region Runtime detects failure of an operation
void IncrementByOne()
{
	PrintInYellow(message: "IncrementByOne() is ready");
	PrintInGreen($"Enter number between {uint.MinValue} - {uint.MaxValue}:");
	uint userNumber = uint.Parse(Console.ReadLine());
	try
	{
		checked
		{
			uint incremented = userNumber + 1; // This will cause arithmetic overflow
			Console.WriteLine("Result: " + incremented);
		}
	}
	catch (OverflowException ex)
	{
		PrintInRed("Overflow exception: " + ex.Message);
	}
}
#endregion

#region The runtime detects a situation outside of your control
void CreateArray()
{
	PrintInYellow(message: "CreateArray() is ready");
	try
	{
		PrintInGreen($"Insert array size (insert {int.MaxValue} to have fun)");
		int size = Int32.Parse(Console.ReadLine());
		object[] array = new object[size]; // Attempting to allocate a large array
		PrintInGreen($"Array with size of {size} created successfully.");
	}
	catch (OutOfMemoryException ex)
	{
		PrintInRed("Out of memory exception: " + ex.Message);
	}
}
#endregion

#region Exception Classes
Exception x1;
SystemException x2;
ApplicationException x3;
ArgumentException x4;
ArgumentNullException x5;
NullReferenceException x6;
TimeoutException x7;
SqlAlreadyFilledException x8;
#endregion

#region Multiple Catch Blocks
void FileReader2()
{
	PrintInYellow(message: "FileReader2() is ready");
	PrintInGreen("Enter file name:");
	string fileName = Console.ReadLine();

	string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	string filePath = Path.Combine(desktopPath, fileName);

	try
	{
		using (StreamReader reader = new StreamReader(filePath))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				Console.WriteLine(line);
			}
		}
	}

	catch (FileNotFoundException x)
	{
		PrintInRed($"File '{x.FileName}' is missing");

		Console.WriteLine("Creating the file...");
		try
		{
			// Create an empty file
			using (FileStream fs = File.Create(filePath))
			{
				Console.WriteLine($"File '{fileName}' created successfully.");
			}
		}
		catch (Exception ex)
		{
			PrintInRed($"Error occurred while creating the file: {ex.Message}");
		}
	}
	catch (DirectoryNotFoundException)
	{
		PrintInRed($"The containing directory does not exist.");
	}
	catch (IOException x)
	{
		PrintInRed($"IO error: '{x.Message}'");
	}
}

#endregion

#region Exception Filters

void ExceptionFilter()
{
	PrintInYellow(message: "ExceptionFilter() is ready");
	int a, b;
	try
	{
		PrintInGreen("Enter first number");
		a = Int32.Parse(Console.ReadLine());
		PrintInGreen("Enter second number");
		b = Int32.Parse(Console.ReadLine());
		Console.WriteLine(a / b);
	}
	catch (Exception x) when (x.Message.ToLower().Contains("format"))
	{
		PrintInRed(x.Message);
	}
	catch (Exception x) when (x.Message.Contains("zero"))
	{
		PrintInRed(x.Message);
	}
}
#endregion

#region Nested try Blocks
void NestedTryBlock()
{
	PrintInYellow(message: "NestedTryBlock() is ready");
	string[] myArray = { "1", null, "2", null, "3", null };
	PrintInGreen("Array Created:");
	Console.WriteLine("myArray = { \"1\", null, \"2\", null,\"3\",null }");

	try
	{
		PrintInGreen("Give me index and I show you element's type:");
		int index = int.Parse(Console.ReadLine());
		Console.WriteLine($"Element at index {index} is: " + (myArray[index] == null ? "Null": myArray[index])) ;
		try
		{
			Console.WriteLine(myArray[index].GetType());
		}
		//finally { Console.WriteLine("Finally block executed."); }
		catch (NullReferenceException x)
		{
			PrintInRed(x.Message);
		}
	}
	catch (IndexOutOfRangeException x)
	{
		PrintInRed(x.Message);
	}
	catch
	{
		PrintInRed("I can catch almost everthing. But I swallow them right away. Yum yum...");
	}

}
#endregion

#region Throwing Exception

void ThrowException()
{
	PrintInYellow(message: "ThrowException() is ready");
	Console.WriteLine("Enter value (0 is not expected as correct argument)");
	int value = int.Parse(Console.ReadLine());
	try
	{
		if (value == 0)
		{
			// Simulate an error condition
			throw new ArgumentException("Value cannot be zero.");
		}
		else
		{
			Console.WriteLine("Value is valid: " + value);
		}
	}
	catch (ArgumentException ex)
	{
		// Log the exception or perform some specific handling
		Console.WriteLine("ArgumentException caught in ProcessData: " + ex.Message);
		throw; // throw reserves call stack while throw ex loses call stack
				  // Rethrow the exception with additional context
		//throw new ApplicationException("Error occurred while processing data.", ex);
	}
}

#endregion

#region Costum Exceptions
void CustomException()
{
	PrintInYellow(message: "CustomException() is ready");
	PrintInGreen("Enter a number! So we can show the number to you ^^");
	while (true)
	{
		try
		{
			int s = Int32.Parse(Console.ReadLine());

			if (s == 0)
			{
				throw new CantBeZeroException();
			}
			if (s == 13)
			{
				throw new UnluckyNumberException(s);
			}

			Console.WriteLine(s);
			// If a valid number is entered, break out of the loop
			break;
		}
		catch (UnluckyNumberException ex)
		{
			PrintInRed(ex.Message);
			PrintInRed("Beware of using this number " + ex.Number);
			PrintInGreen("Try another number:");
		}
		catch (CantBeZeroException ex)
		{
			PrintInRed(ex.Message);
			PrintInGreen("Try another number:");
		}
		catch (FormatException)
		{
			PrintInRed("Invalid input! Please enter a valid number.");
			PrintInGreen("Try a valid input format:");
		}
	}
}


public class UnluckyNumberException : Exception
{
	public int Number { get; }

	public UnluckyNumberException(int number) : base($"Unlucky number exception occurred!")
	{
		Number = number;
	}
}

public class CantBeZeroException : Exception
{
	public CantBeZeroException() : base("Can't use 0") { }

	//public int Number { get; private set; }
	//public CantBeZeroException(int number)
	//{
	//	Number = number;
	//}
}
#endregion

