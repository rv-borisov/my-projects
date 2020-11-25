using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int count;
            int c1 = 0;
            int[] intarr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] countarr = new int[a];
            for (int i = 0; i < intarr.Length; i++)
            {
                for (int j = i; j < intarr.Length; j++)
                {
                    count = intarr[i];
                    if (intarr[j] > intarr[i])
                    {
                        if (intarr[j] > c1)
                        {
                            c1 = intarr[j];
                        }
                        count = count + intarr[j];
                    }
                }
                countarr[i] = count;
            }
            Console.WriteLine(countarr.Max());
        }
    }
}
