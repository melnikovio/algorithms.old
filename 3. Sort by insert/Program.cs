using System;
using System.Linq;
using System.Net.Sockets;

namespace _3.Sort_by_insert
{
    class Program
    {
        /// <summary>
        /// We are sure that file is exist and filled with correct values
        /// </summary>
        /// <returns></returns>
        private static long[] ReadFromFile()
        {
            var file = new System.IO.StreamReader(@"input.txt");

            var arrayLength = long.Parse(file.ReadLine()); //still don't know for what reason I need this

            return file.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        private static void WriteToFile(string result, string evidence)
        {
            System.IO.File.WriteAllText(@"output.txt", result + Environment.NewLine + evidence);
        }

        private static long[] Array { get; set; }
        private static long[] Evidence { get; set; }

        private static void SortArrayByInsertMethod()
        {
            Evidence[0] = 1;
            for (var i = 1; i < Array.Length; i++)
            {
                var j = i - 1;
                while (j >= 0 && Array[j] > Array[j+1])
                {
                    Swap(j+1, j);
                    j--;
                }
                Evidence[i] = j+2;
            }
        }

        private static void Swap(long i, long j)
        {
            var temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }

        static void Main(string[] args)
        {
            Array = ReadFromFile();
            Evidence = new long[Array.Length];

            SortArrayByInsertMethod();

            WriteToFile(string.Join(" ", Evidence), string.Join(" ", Array));
        }
    }
}
