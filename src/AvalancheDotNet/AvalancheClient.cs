using AvalancheDotNet.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvalancheDotNet
{
    public class AvalancheClient
    {
        private HttpClient _http;
        private AvalancheConfig _config;
        private ILogger _logger;
        public AvalancheClient(AvalancheConfig config, HttpClient http, ILogger<AvalancheClient> logger)
        {
            _http = http;
            _config = config;
            _logger = logger;
        }

        internal async Task<T> CallMethod<T>(string method)
        {
            string trace = $"jsonrpc call - {method} - {_config.NodeUrl} ";
            var request = new ApiRequestInfo
            {
                jsonrpc = "2.0",
                id = 1,
                method = method
            };
            HttpResponseMessage? httpResult = null;
            try
            {
                httpResult = await _http.PostAsJsonAsync(_config.NodeUrl, request);
                httpResult.EnsureSuccessStatusCode();
                var result = await httpResult.Content.ReadFromJsonAsync<T>();
                _logger.LogTrace(trace + $"result : {Serialize(result)}");
                return result;
            }
            catch (Exception e)
            {
                trace += $"Exception lors de l'appel : {method} - {_config.NodeUrl}";
                if (httpResult != null)
                {
                    trace += @$"HTTP{(int)httpResult.StatusCode} {httpResult.StatusCode}";
                    trace += await httpResult.Content.ReadAsStringAsync();
                }
                _logger.LogError(trace);
                throw;
            }
        }

        private string Serialize<T>(T result)
        {
            return System.Text.Json.JsonSerializer.Serialize(result);
        }

        public string InfoGetNodeVersion()
        {
            var request = new ApiRequestInfo
            {
                jsonrpc = "2.0",
                id = 1,
                method = "info.getNodeID"
            };
            var httpResult = _http.PostAsJsonAsync(_config.NodeUrl, request);
            var stringResult = httpResult.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("string reuslt : " + stringResult);
            return stringResult;
        }
    }
}
