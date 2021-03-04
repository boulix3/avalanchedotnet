using AvalancheDotNet;
using AvalancheDotNet.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Api
{
    public class Info
    {
        public InfoClient _client;
        public Info(InfoClient client)
        {
            _client = client;
        }
        [Fact]
        public async void GetBlockchainId()
        {
            var result = await _client.GetInfoBlochainId();
            Assert.Equal(Constants.ExpectedXBlockchainId, result.result.blockchainID);
        }
        [Fact]
        public async void GetNetworkId()
        {
            var result = await _client.GetInfoNetworkId();
            Assert.Equal(Constants.ExpectedNetworkId, result.result.networkID);
        }
        [Fact]
        public async void GetNetworkName()
        {
            var result = await _client.GetInfoNetworkName();
            Assert.Equal(Constants.ExpectedNetworkName, result.result.networkName);
        }
        [Fact]
        public async void GetNodeId()
        {
            var result = await _client.GetInfoNodeId();
            Assert.NotNull(result.result.nodeID);
        }
        [Fact]
        public async void GetNodeIp()
        {
            var result = await _client.GetInfoNodeIp();
            Assert.Equal(Constants.ExpectedNodeIp, result.result.ip);
        }
        [Fact]
        public async void GetNodeVersion()
        {
            var result = await _client.GetInfoNodeVersion();
            Assert.Equal(Constants.ExpectedNodeVersion, result.result.version);
        }

        [Fact]
        public async void GetNodeIsBootstraped()
        {
            var result = await _client.GetInfoIsBootstraped();
            Assert.Equal(Constants.ExpectedIsBootstrapped, result.result.isBootstrapped);
        }
        [Fact]
        public async void GetNodeTxFees()
        {
            var result = await _client.GetInfoTxFees();
            Assert.Equal(Constants.ExpectedTxFees, result.result);
        }
        [Fact]
        public async void GetNodePeers()
        {
            var result = await _client.GetInfoPeers();
            Assert.True(Constants.ExpectedMinNumPeers < result.result.numPeers);
        }
    }
}
