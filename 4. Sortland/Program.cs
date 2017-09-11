using System.Globalization;
using System.Linq;

namespace _4.Sortland
{
    class Program
    {
        /// <summary>
        /// We are sure that file is exist and filled with correct values
        /// </summary>
        /// <returns></returns>
        private static double[] ReadFromFile()
        {
            var file = new System.IO.StreamReader(@"input.txt");

            var arrayLength = long.Parse(file.ReadLine()); //still don't know for what reason I need this

            return file.ReadLine().Split(' ').Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        private static void WriteToFile(string result)
        {
            System.IO.File.WriteAllText(@"output.txt", $"{result}");
        }

        private static double[] Array { get; set; }
        private static int[] PNumbers { get; set; }

        private static void HelloFromSortland()
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

        static void Main(string[] args)
        {
            Array = ReadFromFile();
            PNumbers = Enumerable.Range(1, Array.Length).ToArray();

            HelloFromSortland();

            WriteToFile(string.Join(" ", $"{PNumbers[0]} {PNumbers[PNumbers.Length/2]} {PNumbers[PNumbers.Length-1]}"));
        }
    }
}
