using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    static class InputProcessing
    {
        public static string ToNormalize(string input)
        {
            input = input.Replace("M", "").Replace("Z", "").Replace("L", "");
            input = input.Substring(1).Substring(0, input.Length - 1).Replace(" -", ",").Replace("  ", ";").Replace(" ", ";");
            input = input.Substring(0, input.Length - 2);
            return input;
        }

        public static List<string> ToList(string input)
        {
            List<string> result = input.Split(';').ToList();
            result.RemoveAll(string.IsNullOrWhiteSpace);
            return result;
        }
    }
}
