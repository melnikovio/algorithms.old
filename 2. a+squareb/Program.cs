using System;
using System.Linq;

namespace _2.a_squareb
{
    class Program
    {
        private static long[] ReadFromFile()
        {
            var file = new System.IO.StreamReader(@"input.txt");

            return file.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        private static void WriteToFile(string result)
        {
            System.IO.File.WriteAllText(@"output.txt", result);
        }

        static void Main(string[] args)
        {
            var input = ReadFromFile();
            var result = input[0] + input[1] * input[1];
            WriteToFile(result.ToString());
        }
    }
}
