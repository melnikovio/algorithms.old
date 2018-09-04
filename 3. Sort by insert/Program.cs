using System;
using System.Linq;

namespace _3.Sort_by_insert
{
    class Program
    {
        #region File operations
        private static long[] ReadFromFile(out int arrayLength)
        {
            var file = new System.IO.StreamReader(@"input.txt");

            arrayLength = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());

            return file.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
        }

        private static void WriteToFile(string result, string evidence)
        {
            System.IO.File.WriteAllText(@"output.txt", result + Environment.NewLine + evidence);
        }
        #endregion

        private static long[] Array { get; set; }

        private static void SortArrayByInsertMethod(out long[] evidence)
        {
            evidence = new long[Array.Length];
            evidence[0] = 1;

            for (var i = 1; i < Array.Length; i++)
            {
                var j = i - 1;
                while (j >= 0 && Array[j] > Array[j+1])
                {
                    Swap(j+1, j);
                    j--;
                }
                evidence[i] = j+2;
            }
        }

        private static void Swap(long i, long j)
        {
            var temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }

        static void Main()
        {
            Array = ReadFromFile(out _);

            SortArrayByInsertMethod(out var evidence);

            WriteToFile(string.Join(" ", evidence), string.Join(" ", Array));
        }
    }
}
