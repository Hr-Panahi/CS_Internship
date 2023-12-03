using System;
using System.Diagnostics;

namespace BubbleSort_vs_BogoSort
{
    class Program
    {
        #region BogoSort
        private static bool IsSorted(ref int[] data)
		{
			int count = data.Length;

			while (--count >= 1)
				if (data[count] < data[count - 1]) return false;

			return true;
		}

		private static void Shuffle(ref int[] data)
		{
			int temp, rnd;
			Random rand = new Random();

			for (int i = 0; i < data.Length; ++i)
			{
				rnd = rand.Next(data.Length);
				temp = data[i];
				data[i] = data[rnd];
				data[rnd] = temp;
            }
        }

        public static void BogoSort(ref int[] data)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!IsSorted(ref data))
                Shuffle(ref data);

            stopwatch.Stop();
            Console.WriteLine($"BogoSort took {stopwatch.Elapsed.TotalMilliseconds} milliseconds.");
        }
        #endregion BogoSort

        #region BubbleSort
        public static void BubbleSort(int[] data)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j <= data.Length - 2; j++)
            {
                for (int i = 0; i <= data.Length - 2; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        int storage = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = storage;
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"BubbleSort took {stopwatch.Elapsed.TotalMilliseconds} milliseconds.");
        }
        #endregion BubbleSort

        public static void Main()
        {

            int[] dataArr = { -1, 25, -58964, 8547, -119, 0, 78596, 277, 5789 };
            BubbleSort(dataArr);
            foreach (var item in dataArr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            int[] dataArr2 = { -1, 25, -58964, 8547, -119, 0, 78596 , 277 , 5789};
            BogoSort(ref dataArr2);
            foreach (var item in dataArr2)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
