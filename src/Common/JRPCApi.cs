using AvalancheDotNet.Common.Records;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvalancheDotNet.Common
{
    public abstract class JRPCApi
    {
        private const string jrpcVersion = "2.0";
        private static int rpcid = 0;

        private HttpClient _http;
        private AvalancheCore _config;
        private ILogger _logger;
        internal JRPCApi(AvalancheCore config, HttpClient http, ILogger logger)
        {
            _http = http;
            _config = config;
            _logger = logger;
        }

        public async Task<RequestResponseData<T>> CallMethod<T>(string method, Dictionary<string, string> parameters, string apiUrl)
        {
            var url = $"{_config.NodeUrl}/{apiUrl}";
            string trace = $"jsonrpc call - {method} - {url} ";
            var callId = Interlocked.Increment(ref rpcid);
            var request = new Request(jrpcVersion, callId, method, parameters);
            HttpResponseMessage? httpResult = null;
            try
            {
                httpResult = await _http.PostAsJsonAsync(_config.NodeUrl, request);
                ResponseData<T>? apiResponse = null;
                if (httpResult.IsSuccessStatusCode)
                {
                    apiResponse = await httpResult.Content.ReadFromJsonAsync<ResponseData<T>>();
                }
                var result = new RequestResponseData<T>(apiResponse, httpResult.StatusCode,
                    httpResult.ReasonPhrase ?? httpResult.StatusCode.ToString(), request);
                _logger.LogTrace(trace + $"result : {Serialize(result)}");
                return result;
            }
            catch (Exception e)
            {
                trace += $"Exception lors de l'appel : {method} - {url} - " + e.Message;
                if (httpResult != null)
                {
                    trace += @$"HTTP{(int)httpResult.StatusCode} {httpResult.StatusCode}";
                    trace += await httpResult.Content.ReadAsStringAsync();
                }
                _logger.LogError(trace);
                throw;
            }
        }
#warning move method to util class.
        private string Serialize<T>(T result)
        {
            return System.Text.Json.JsonSerializer.Serialize(result);
        }
    }
}
