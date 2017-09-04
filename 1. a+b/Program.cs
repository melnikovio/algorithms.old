using System.Linq;

namespace _1.a_b
{
    class Program
    {
        private static int[] ReadFromFile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");
       
            return file.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        private static void WriteToFile(string result)
        {
            System.IO.File.WriteAllText(@"output.txt", result);
        }

        static void Main(string[] args)
        {
            var input = ReadFromFile();
            var result = input.Sum();
            WriteToFile(result.ToString());
        }
    }
}
