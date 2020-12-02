using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace test
{
    class Coordinates 
    {
        public string Address { get; set; }
        public List<string> CoordinatesList { get; set; }

        public Coordinates(IResponse response)
        {
            Address = response.Name;
            response.Polygon = InputProcessing.ToNormalize(response.Polygon);
            CoordinatesList = InputProcessing.ToList(response.Polygon);
        }
    }
}
