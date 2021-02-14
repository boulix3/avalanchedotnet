using AvalancheDotNet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Constants
    {
        public const string ExpectedXBlockchainId = "2oYMBNV4eNHyqk2fjjV5nVQLDbtmNJzq5s3qs3Lo6ftnC6FByM";
        public const string ExpectedNetworkId = "1";
        public const string ExpectedNetworkName = "mainnet";
        public const string ExpectedNodeId = "";
        public const string ExpectedNodeIp = "90.87.67.72:9651";
        public const string ExpectedNodeVersion = "avalanche/1.2.0";
        public const bool ExpectedIsBootstrapped = true;
        public static InfoTxFee ExpectedTxFees = new InfoTxFee(10000000, 1000000);
        public const int ExpectedMinNumPeers = 500;
    }
}
