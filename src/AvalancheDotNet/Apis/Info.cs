using AvalancheDotNet.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvalancheDotNet.Apis
{
    public class Info : AvalancheClient
    {
        public Info(AvalancheConfig config, HttpClient http, ILogger<AvalancheClient> logger) : base(config, http, logger)
        {
        }

        public async Task<string> GetNodeVersion()
        {
            return await this.CallMethod<string>("info.getNodeID");
        }            
    }
}