using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalancheDotNet.Dto
{
    public record InfoNodeId(string nodeID);
    public record InfoNodeVersion(string version);
    public record InfoBlockchainId(string blockchainID);
    public record InfoNetworkId(string networkID);
    public record InfoNetworkName(string networkName);
    public record InfoNodeIp(string ip);
    public record InfoIsBootstrapped(bool isBootstrapped);
    public record InfoTxFee(int creationTxFee, int txFee);
    public record InfoPeers(int numPeers, InfoPeer[] peers);
    public record InfoPeer(string ip, string publicIP, string nodeID, string version, string lastSent, string lastReceived);
}
