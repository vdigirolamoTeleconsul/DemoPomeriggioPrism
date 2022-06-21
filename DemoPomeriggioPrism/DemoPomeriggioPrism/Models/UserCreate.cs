using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DemoPomeriggioPrism.Models
{
    public class UserCreate 
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
