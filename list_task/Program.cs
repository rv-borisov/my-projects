using System.Collections.Generic;

namespace list_task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> {1, 2, 23, 1, 23, 11, 32, 12, 0, 5, 3, 1, 2 };
            int value = 1;
            Method(list, value);
        }
        static void Method(List<int> list, int value)
        {
            foreach (var item in list.ToArray())
            {
                if (item == value)
                {
                    list.Remove(item);
                }
            }
        }
    }
}
