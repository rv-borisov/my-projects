using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] abcd = Console.ReadLine().Split(' ').ToArray();
            int a = Convert.ToInt32(abcd[0]);
            int b = Convert.ToInt32(abcd[1]);
            int c = Convert.ToInt32(abcd[2]);
            int d = Convert.ToInt32(abcd[3]);
            int result1 = a * b + c * d;
            int result2 = a * c + b * d;
            int result3 = a * d + c * b;
            int[] result = { result1, result2, result3 };
            Console.WriteLine(result.Max());
        }
    }
}
