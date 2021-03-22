using AvalancheDotNet.Common;
using AvalancheDotNet.Common.Records;
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
    /**
    * Class for interacting with a node's InfoAPI.
    *
    * @category RPCAPIs
    *
    * @remarks This extends the [[JRPCAPI]] class. This class should not be directly called. Instead, use the [[Avalanche.addAPI]] function to register this interface with Avalanche.
    */
    public class InfoApi : JRPCApi
    {
        public InfoApi(AvalancheCore config, HttpClient http, ILogger<InfoApi> logger) : base(config, http, logger)
        {
        }
        /**
   * Fetches the blockchainID from the node for a given alias.
   *
   * @param alias The blockchain alias to get the blockchainID
   *
   * @returns Returns a Promise<string> containing the base 58 string representation of the blockchainID.
   */
        public async Task<RequestResponseData<InfoBlockchainId>> GetBlochainId()
        {
            return await this.CallMethod<InfoBlockchainId>("info.getBlockchainID", new Dictionary<string, string> { { "alias", "X" } });
        }
        /**
   * Fetches the networkID from the node.
   *
   * @returns Returns a Promise<number> of the networkID.
   */
        public async Task<RequestResponseData<InfoNetworkId>> GetNetworkId()
        {
            return await this.CallMethod<InfoNetworkId>("info.getNetworkID");
        }
        /**
   * Fetches the network name this node is running on
   *
   * @returns Returns a Promise<string> containing the network name.
   */
        public async Task<RequestResponseData<InfoNetworkName>> GetNetworkName()
        {
            return await this.CallMethod<InfoNetworkName>("info.getNetworkName");
        }
        /**
   * Fetches the nodeID from the node.
   *
   * @returns Returns a Promise<string> of the nodeID.
   */
        public async Task<RequestResponseData<InfoNodeId>> GetNodeId()
        {
            return await this.CallMethod<InfoNodeId>("info.getNodeID");
        }
        /**
   * Fetches the version of Gecko this node is running
   *
   * @returns Returns a Promise<string> containing the version of Gecko.
   */
        public async Task<RequestResponseData<InfoNodeVersion>> GetNodeVersion()
        {
            return await this.CallMethod<InfoNodeVersion>("info.getNodeVersion");
        }
        /**
   * Fetches the transaction fee from the node.
   *
   * @returns Returns a Promise<object> of the transaction fee in nAVAX.
   */
        public async Task<RequestResponseData<InfoTxFee>> GetTxFees()
        {
            return await this.CallMethod<InfoTxFee>("info.getTxFee");
        }
        /**
 * Check whether a given chain is done bootstrapping
 * @param chain The ID or alias of a chain.
 *
 * @returns Returns a Promise<boolean> of whether the chain has completed bootstrapping.
 */
        public async Task<RequestResponseData<InfoIsBootstrapped>> IsBootstraped()
        {
            return await this.CallMethod<InfoIsBootstrapped>("info.isBootstrapped", new Dictionary<string, string> { { "chain", "X" } });
        }
        /**
 * Returns the peers connected to the node.
 *
 * @returns Promise for the list of connected peers in <ip>:<port> format.
 */
        public async Task<RequestResponseData<InfoPeers>> GetPeers()
        {
            return await this.CallMethod<InfoPeers>("info.peers");
        }
        /// <summary>
        /// Returns the node's ip
        /// </summary>
        public async Task<RequestResponseData<InfoNodeIp>> GetNodeIp()
        {
            return await this.CallMethod<InfoNodeIp>("info.getNodeIP");
        }

        /// <summary>
        /// Makes the jsonrpc call to the node
        /// </summary>        
        internal async Task<RequestResponseData<T>> CallMethod<T>(string method)
        {
            return await this.CallMethod<T>(method, new Dictionary<string, string>());
        }
        /// <summary>
        /// Makes the jsonrpc call to the node
        /// </summary>        
        internal async Task<RequestResponseData<T>> CallMethod<T>(string method, Dictionary<string, string> parameters)
        {
            return await this.CallMethod<T>(method, parameters, Constants.InfoApiUrl);
        }
    }
}