using AvalancheDotNet.Common;
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
    public class InfoClient
    {
        private AvalancheClient _client;
        public InfoClient(AvalancheClient client)
        {
            this._client = client;
        }
        public async Task<ApiResult<InfoBlockchainId>> GetInfoBlochainId()
        {
            return await this.CallMethod<ApiResult<InfoBlockchainId>>("info.getBlockchainID", new Dictionary<string, string> { { "alias", "X" } });
        }
        public async Task<ApiResult<InfoNetworkId>> GetInfoNetworkId()
        {
            return await this.CallMethod<ApiResult<InfoNetworkId>>("info.getNetworkID");
        }
        
        public async Task<ApiResult<InfoNetworkName>> GetInfoNetworkName()
        {
            return await this.CallMethod<ApiResult<InfoNetworkName>>("info.getNetworkName");
        }
        public async Task<ApiResult<InfoNodeId>> GetInfoNodeId()
        {
            return await this.CallMethod<ApiResult<InfoNodeId>>("info.getNodeID");
        }

        public async Task<ApiResult<InfoNodeIp>> GetInfoNodeIp()
        {
            return await this.CallMethod<ApiResult<InfoNodeIp>>("info.getNodeIP");
        }
        public async Task<ApiResult<InfoNodeVersion>> GetInfoNodeVersion()
        {
            return await this.CallMethod<ApiResult<InfoNodeVersion>>("info.getNodeVersion");
        }
        public async Task<ApiResult<InfoIsBootstrapped>> GetInfoIsBootstraped()
        {
            return await this.CallMethod<ApiResult<InfoIsBootstrapped>>("info.isBootstrapped", new Dictionary<string, string> { { "chain", "X" } });
        }
        public async Task<ApiResult<InfoTxFee>> GetInfoTxFees()
        {
            return await this.CallMethod<ApiResult<InfoTxFee>>("info.getTxFee");
        }
        public async Task<ApiResult<InfoPeers>> GetInfoPeers()
        {
            return await this.CallMethod<ApiResult<InfoPeers>>("info.peers");
        }

        internal async Task<T> CallMethod<T>(string method)
        {
            return await this.CallMethod<T>(method, new Dictionary<string, string>());
        }

        internal async Task<T> CallMethod<T>(string method, Dictionary<string, string> parameters)
        {
            return await this._client.CallMethod<T>(Constants.InfoApiUrl, method, parameters);
        }
        }
    }