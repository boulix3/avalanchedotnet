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
    public partial class AvalancheClient
    {
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
    }
}