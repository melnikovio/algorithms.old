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

        private static double[] Salary { get; set; }
        private static int[] Citizens { get; set; }

        private static void HelloFromSortLand()
        {
            for (var i = 1; i < Salary.Length; i++)
            {
                var j = i - 1;
                while (j >= 0 && Salary[j] > Salary[j + 1])
                {
                    Swap(j + 1, j);
                    SwapCitizen(j + 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = Salary[i];
            Salary[i] = Salary[j];
            Salary[j] = temp;
        }

        private static void SwapCitizen(int i, int j)
        {
            var temp = Citizens[i];
            Citizens[i] = Citizens[j];
            Citizens[j] = temp;
        }

        static void Main()
        {
            Salary = ReadFromFile(out var arrayLength);
            Citizens = Enumerable.Range(1, arrayLength).ToArray();

            HelloFromSortLand();

            WriteToFile(Citizens[0] + " " + Citizens[Citizens.Length / 2] + " " + Citizens[Citizens.Length - 1]);
        }
    }
}