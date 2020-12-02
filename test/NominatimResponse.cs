using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace test
{
    public class NominatimResponse : IResponse
    {

        [JsonPropertyName("display_name")]
        public string Name { get; set; }

        [JsonPropertyName("svg")]
        public string Polygon { get; set; }
    }
}
