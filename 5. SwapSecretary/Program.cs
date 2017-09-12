using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _5.SwapSecretary
{
    /// <summary>
    /// Please take a seat on this couch
    /// </summary>
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

            return file.ReadLine().Split(' ').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        private static StreamWriter Writer { get; set; }

        private static void TellSecretarySexyPhrase(string line)
        {
            Writer.WriteLine(line);
        }

        private static long[] Array { get; set; }

        private static void SwapNumbersWithSexySecretary()
        {
            for (var i = 0; i < Array.Length; i++)
            {
                var minumalValueIndex = 0;
                var minimalValue = Array[i];
                for (var j = i + 1; j < Array.Length; j++)
                {
                    if (minimalValue > Array[j])
                    {
                        minimalValue = Array[j];
                        minumalValueIndex = j;
                    }
                }
                if (minumalValueIndex != 0)
                {
                    Swap(i, minumalValueIndex);

                    TellSecretarySexyPhrase("Swap elements at indices " + (i + 1) + " and " + (minumalValueIndex + 1) + ".");
                }
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }

        static void Main(string[] args)
        {
            Array = ReadFromFile();

            Writer = File.CreateText(@"output.txt");

            SwapNumbersWithSexySecretary();

            TellSecretarySexyPhrase("No more swaps needed.");
            TellSecretarySexyPhrase(string.Join(" ", Array));

            Writer.Close();
        }
    }
}
