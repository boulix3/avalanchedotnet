using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace NAvalanche
{
    public class AvalancheClient
    {
        private HttpClient _http;
        public AvalancheClient()
        {
            _http = new HttpClient();
        }

        public string InfoGetNodeVersion()
        {
            var request = new ApiRequestInfo
            {
                jsonrpc = "2.0",
                id = 1,
                method = "info.getNodeID"
            };
            var httpResult = _http.PostAsJsonAsync("http://box:9650/ext/info", request);
            var stringResult = httpResult.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("string reuslt : " + stringResult);
            return stringResult;            
        }
    }
    public class ApiRequestInfo
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public string method { get; set;}
        [JsonPropertyName("params")]
        public Dictionary<string, string> parameters { get; set; } = new();
}
}
