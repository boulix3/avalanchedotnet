using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AvalancheDotNet.Common.Records
{
    public record RequestResponseData<T>(ResponseData<T>? response, HttpStatusCode status, string statusText, Request request);
    public record ResponseData<T>(string jsonRpc, int id, T result);
}
