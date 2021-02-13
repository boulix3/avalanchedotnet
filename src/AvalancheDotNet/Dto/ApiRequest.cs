using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvalancheDotNet.Dto
{
    public class ApiRequestInfo
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public string method { get; set; }
        [JsonPropertyName("params")]
        public Dictionary<string, string> parameters { get; set; } = new();
    }
}
