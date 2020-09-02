using BackendTask.Business.Contracts.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTask.Business.Contracts
{
    /// <summary>
    /// Definition of ClientService
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="newClient">The new client.</param>
        /// <returns>ResponseMessage</returns>
        public Task<ResponseMessage> CreateClient(Guid adviserId, ClientMessage newClient);

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// ClientMessageExtended
        /// </returns>
        public Task<ClientMessageExtended> GetClient(Guid adviserId, Guid clientId);

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns>List of ClientMessageExtended</returns>
        public Task<List<ClientMessageExtended>> GetClients(Guid adviserId);

        /// <summary>
        /// Updates the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// ResponseMessage
        /// </returns>
        public Task<ResponseMessage> UpdateClient(Guid adviserId, ClientMessageExtended client);

        /// <summary>
        /// Removes the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public Task<ResponseMessage> RemoveClient(Guid adviserId, Guid clientId);
    }
}
