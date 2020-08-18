using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleApplication1
{
    

    public partial class CreateEmpResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
