using AvalancheDotNet.Common.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Constants
    {
        public const string ExpectedXBlockchainId = "2JVSBoinj9C2J33VntvzYtVJNZdN2NKiwwKjcumHUWEb5DbBrm";
        public const string ExpectedNetworkId = "5";
        public const string ExpectedNetworkName = "fuji";
        public const string ExpectedNodeId = "NodeID-Df9KjvQZnNR4GP2PreArxmbdEas1TuxTM";
        public static string[] ExpectedNodeIps = new string[]{"13.59.217.63:21001", "18.191.245.5:21001" };
        public const string ExpectedNodeVersion = "avalanche/1.2.5";
        public const bool ExpectedIsBootstrapped = true;
        public static InfoTxFee ExpectedTxFees = new InfoTxFee(10000000, 1000000);
        public const int ExpectedMinNumPeers = 50;
    }
}
