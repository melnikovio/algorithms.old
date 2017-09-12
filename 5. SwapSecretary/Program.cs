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

        private static void WriteToFile(string line)
        {
            Writer.WriteLine(line);
        }

        private static long[] Array { get; set; }

        private static void SwapNumbersWithSexySecretary()
        {
            for (var i = 1; i < Array.Length; i++)
            {
                string pleaseTellMeAboutYourself = null;
                var j = i - 1;
                while (j >= 0 && Array[j] > Array[j + 1])
                {
                    Swap(j + 1, j);
                    //pleaseTellMeAboutYourself = "Swap elements at indices " + (j+1) + " and " + (i+1) + ".";
                    j--;
                }
                if (!string.IsNullOrEmpty(pleaseTellMeAboutYourself))
                    WriteToFile(pleaseTellMeAboutYourself);
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;

            WriteToFile("Swap elements at indices " + (j + 1) + " and " + (i + 1) + ".");
        }

        static void Main(string[] args)
        {
            Array = ReadFromFile();

            Writer = File.CreateText(@"output.txt");

            SwapNumbersWithSexySecretary();

            WriteToFile("No more swaps needed.");
            WriteToFile(string.Join(" ", Array));

            Writer.Close();
        }
    }
}
