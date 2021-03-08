using AvalancheDotNet.Common;
using AvalancheDotNet.Common.Records;
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
    public class Api : JRPCApi
    {
        public Api(AvalancheCore config, HttpClient http, ILogger<Api> logger) : base(config, http, logger)
        {
        }
        public async Task<RequestResponseData<InfoBlockchainId>> GetInfoBlochainId()
        {
            return await this.CallMethod<InfoBlockchainId>("info.getBlockchainID", new Dictionary<string, string> { { "alias", "X" } });
        }
        public async Task<RequestResponseData<InfoNetworkId>> GetInfoNetworkId()
        {
            return await this.CallMethod<InfoNetworkId>("info.getNetworkID");
        }

        public async Task<RequestResponseData<InfoNetworkName>> GetInfoNetworkName()
        {
            return await this.CallMethod<InfoNetworkName>("info.getNetworkName");
        }
        public async Task<RequestResponseData<InfoNodeId>> GetInfoNodeId()
        {
            return await this.CallMethod<InfoNodeId>("info.getNodeID");
        }

        public async Task<RequestResponseData<InfoNodeIp>> GetInfoNodeIp()
        {
            return await this.CallMethod<InfoNodeIp>("info.getNodeIP");
        }
        public async Task<RequestResponseData<InfoNodeVersion>> GetInfoNodeVersion()
        {
            return await this.CallMethod<InfoNodeVersion>("info.getNodeVersion");
        }
        public async Task<RequestResponseData<InfoIsBootstrapped>> GetInfoIsBootstraped()
        {
            return await this.CallMethod<InfoIsBootstrapped>("info.isBootstrapped", new Dictionary<string, string> { { "chain", "X" } });
        }
        public async Task<RequestResponseData<InfoTxFee>> GetInfoTxFees()
        {
            return await this.CallMethod<InfoTxFee>("info.getTxFee");
        }
        public async Task<RequestResponseData<InfoPeers>> GetInfoPeers()
        {
            return await this.CallMethod<InfoPeers>("info.peers");
        }

        internal async Task<RequestResponseData<T>> CallMethod<T>(string method)
        {
            return await this.CallMethod<T>(method, new Dictionary<string, string>());
        }

        internal async Task<RequestResponseData<T>> CallMethod<T>(string method, Dictionary<string, string> parameters)
        {
            return await this.CallMethod<T>(method, parameters, Constants.InfoApiUrl);
        }
    }
}