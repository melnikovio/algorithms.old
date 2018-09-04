using System;
using System.Globalization;
using System.Linq;

namespace _4.Sortland
{
    class Program
    {
        #region file operations
        private static double[] ReadFromFile(out int arrayLength)
        {
            var file = new System.IO.StreamReader(@"input.txt");

            arrayLength = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
            
            return file.ReadLine()?.Split(' ').Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        private static void WriteToFile(string result)
        {
            System.IO.File.WriteAllText(@"output.txt", result);
        }
        #endregion

        private static double[] Array { get; set; }
        private static int[] PNumbers { get; set; }

        private static void HelloFromSortLand()
        {
            for (var i = 1; i < Array.Length; i++)
            {
                var j = i - 1;
                while (j >= 0 && Array[j] > Array[j + 1])
                {
                    Swap(j + 1, j);
                    SwapPerson(j + 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }

        private static void SwapPerson(int i, int j)
        {
            var temp = PNumbers[i];
            PNumbers[i] = PNumbers[j];
            PNumbers[j] = temp;
        }

        static void Main()
        {
            Array = ReadFromFile(out var arrayLength);
            PNumbers = Enumerable.Range(1, arrayLength).ToArray();

            HelloFromSortLand();

            WriteToFile(PNumbers[0] + " " + PNumbers[PNumbers.Length / 2] + " " + PNumbers[PNumbers.Length - 1]);
        }
    }
}