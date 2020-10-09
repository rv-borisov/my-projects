using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            int l, k, m;
            int number = 0;
            int i;
            string[] lkm = Console.ReadLine().Split(' ').ToArray();
            l = Convert.ToInt32(lkm[0]);
            k = Convert.ToInt32(lkm[1]);
            m = Convert.ToInt32(lkm[2]);
            for (i = k; i <= l; i += m)
            {
                number++;
            }
            if (i - m == l)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}
