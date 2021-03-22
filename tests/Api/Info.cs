using FluentAssertions;

using Xunit;

namespace Tests.Api
{
    public class Info
    {
        public AvalancheDotNet.Apis.InfoApi _client;
        public Info(AvalancheDotNet.Apis.InfoApi client)
        {
            _client = client;
        }
        
        [Fact]
        public async void GetBlockchainId()
        {
            var result = await _client.GetBlochainId();
            result.ShouldBeOk();            
            result.response.result.blockchainID.Should().Be(Constants.ExpectedXBlockchainId);
        }
        [Fact]
        public async void GetNetworkId()
        {
            var result = await _client.GetNetworkId();
            result.ShouldBeOk();
            result.response.result.networkID.Should().Be(Constants.ExpectedNetworkId);
        }
        [Fact]
        public async void GetNetworkName()
        {
            var result = await _client.GetNetworkName();
            result.ShouldBeOk();
            result.response.result.networkName.Should().Be(Constants.ExpectedNetworkName);
        }
        [Fact]
        public async void GetNodeId()
        {
            var result = await _client.GetNodeId();
            result.ShouldBeOk();
            result.response.result.nodeID.Should().NotBeNull();
        }
        [Fact]
        public async void GetNodeIp()
        {
            var result = await _client.GetNodeIp();
            result.ShouldBeOk();            
            result.response.result.ip.Should().BeOneOf(Constants.ExpectedNodeIps);
        }
        [Fact]
        public async void GetNodeVersion()
        {
            var result = await _client.GetNodeVersion();
            result.ShouldBeOk();
            result.response.result.version.Should().Be(Constants.ExpectedNodeVersion);
        }

        [Fact]
        public async void GetNodeIsBootstraped()
        {
            var result = await _client.IsBootstraped();
            result.ShouldBeOk();
            result.response.result.isBootstrapped.Should().Be(Constants.ExpectedIsBootstrapped);
        }
        [Fact]
        public async void GetNodeTxFees()
        {
            var result = await _client.GetTxFees();
            result.ShouldBeOk();
            result.response.result.Should().Be(Constants.ExpectedTxFees);
        }
        [Fact]
        public async void GetNodePeers()
        {
            var result = await _client.GetPeers();
            result.ShouldBeOk();
            result.response.result.numPeers.Should().BeGreaterThan(Constants.ExpectedMinNumPeers);
        }
    }
}
