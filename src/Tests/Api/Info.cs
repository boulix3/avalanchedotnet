using AvalancheDotNet;
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
        private readonly ITestOutputHelper output;
        public AvalancheClient _client;
        public Info(AvalancheClient client)
        {
            _client = client;
        }
        [Fact]
        public void GetNodeId()
        {
            
        }

        [Fact]
        public void GetNodeVersion()
        {
            var result = _client.InfoGetNodeVersion();
            Assert.Equal("1.2.3", result);
        }
    }
}
