using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    static class FileProcessing
    {
        public static void CreateRecord(string fileName, Coordinates coordinates, int step)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(path, fileName);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(coordinates.Address);
                for (int i = 0; i < coordinates.CoordinatesList.Count; i += step)
                {
                    writer.WriteLine(coordinates.CoordinatesList[i]);
                }
                writer.WriteLine();
            }
        }
    }
}
