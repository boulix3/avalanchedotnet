using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvalancheDotNet.Common.Records
{
    public record Request(string jsonRpc, int id, string method, [property: JsonPropertyName("params")] Dictionary<string, string> parameters)
    {
    }
}
