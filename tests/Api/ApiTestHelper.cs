using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using AvalancheDotNet.Common;
using AvalancheDotNet.Common.Records;

using FluentAssertions;
using FluentAssertions.Equivalency;

using Xunit;

namespace Tests.Api
{
    public static class ApiTestHelper
    {
        public static void ShouldBeOk<T>(this RequestResponseData<T> response)
        {
            response.status.Should().Be(HttpStatusCode.OK);
            response.response.jsonRpc.Should().Be(JRPCApi.jrpcVersion);
            response.response.Should().NotBeNull();
        }        
    }
}
