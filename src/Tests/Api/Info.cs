using NAvalanche;
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
        public AvalancheClient client;
        public Info(ITestOutputHelper output)
        {
            this.output = output;
            client = new AvalancheClient();
        }
        [Fact]
        public void GetNodeId()
        {

        }

        [Fact]
        public void GetNodeVersion()
        {
            var result = client.InfoGetNodeVersion();
            Assert.NotNull(result);
            output.WriteLine(result);
        }
    }
}
