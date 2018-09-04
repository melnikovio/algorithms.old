using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _5.SwapSecretary
{
    class Program
    {
        private static long[] ReadFromFile(out int arrayLength)
        {
            var file = new StreamReader(@"input.txt");

            arrayLength = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());

            return file.ReadLine()?.Split(' ').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray();
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

        static void Main()
        {
            Array = ReadFromFile(out _);

            Writer = File.CreateText(@"output.txt");

            SwapNumbersWithSexySecretary();

            TellSecretarySexyPhrase("No more swaps needed.");
            TellSecretarySexyPhrase(string.Join(" ", Array));

            Writer.Close();
        }
    }
}
