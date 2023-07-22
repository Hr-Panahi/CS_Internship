using System;
namespace BubbleSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements you want to add to the array: ");
            int numberOfElements = int.Parse(Console.ReadLine());

            int[] numberArray= new int[numberOfElements];
            Console.WriteLine("Enter the Array Elements: ");
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }
            for (int j = 0; j <= numberArray.Length - 2; j++)
            {
                for (int i = 0; i <= numberArray.Length - 2; i++)
                {
                    if (numberArray[i] > numberArray[i+1])
                    {
                        int storage = numberArray[i + 1];
                        numberArray[i + 1] = numberArray[i];
                        numberArray[i] = storage;
                    }
                }
            }
            Console.WriteLine("Sorted Array:");
            foreach (int item in numberArray)
            {
                Console.Write(item + " ");
            }

        }
    }
}
