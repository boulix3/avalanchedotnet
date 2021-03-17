using AvalancheDotNet;
using AvalancheDotNet.Apis;
using AvalancheDotNet.Common;
using AvalancheDotNet.Common.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Api
{
    public class Info
    {
        public AvalancheDotNet.Apis.Api _client;
        public Info(AvalancheDotNet.Apis.Api client)
        {
            _client = client;
        }
        private void AssertResultOk<T>(RequestResponseData<T> response)
        {
            Assert.Equal(HttpStatusCode.OK, response.status);
            Assert.Equal(JRPCApi.jrpcVersion, response.response.jsonRpc);
            Assert.NotNull(response.response);
        }
        [Fact]
        public async void GetBlockchainId()
        {
            var result = await _client.GetInfoBlochainId();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedXBlockchainId, result.response.result.blockchainID);
        }
        [Fact]
        public async void GetNetworkId()
        {
            var result = await _client.GetInfoNetworkId();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedNetworkId, result.response.result.networkID);
        }
        [Fact]
        public async void GetNetworkName()
        {
            var result = await _client.GetInfoNetworkName();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedNetworkName, result.response.result.networkName);
        }
        [Fact]
        public async void GetNodeId()
        {
            var result = await _client.GetInfoNodeId();
            AssertResultOk(result);
            Assert.NotNull(result.response.result.nodeID);
        }
        [Fact]
        public async void GetNodeIp()
        {
            var result = await _client.GetInfoNodeIp();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedNodeIp, result.response.result.ip);
        }
        [Fact]
        public async void GetNodeVersion()
        {
            var result = await _client.GetInfoNodeVersion();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedNodeVersion, result.response.result.version);
        }

        [Fact]
        public async void GetNodeIsBootstraped()
        {
            var result = await _client.GetInfoIsBootstraped();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedIsBootstrapped, result.response.result.isBootstrapped);
        }
        [Fact]
        public async void GetNodeTxFees()
        {
            var result = await _client.GetInfoTxFees();
            AssertResultOk(result);
            Assert.Equal(Constants.ExpectedTxFees, result.response.result);
        }
        [Fact]
        public async void GetNodePeers()
        {
            var result = await _client.GetInfoPeers();
            AssertResultOk(result);
            Assert.True(Constants.ExpectedMinNumPeers < result.response.result.numPeers);
        }
    }
}
