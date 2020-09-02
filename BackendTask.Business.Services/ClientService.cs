using BackendTask.Business.Contracts;
using BackendTask.Business.Contracts.Messages;
using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using BackendTasks.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.Business.Services
{
    /// <summary>
    /// Implementation of IClientService
    /// </summary>
    /// <seealso cref="BackendTask.Business.Contracts.IClientService" />
    public class ClientService : BaseService, IClientService
    {
        #region Dependency Injected Fields

        private readonly IAdviserRepository _adviserRepository;
        private readonly IAdviserService _adviserService;
        private readonly IUnitOfWork _uow;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="adviserRepository">The adviser repository.</param>
        /// <param name="uow">The uow.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public ClientService(IAdviserRepository adviserRepository,
                             IAdviserService adviserService,
                             IUnitOfWork uow) : base(adviserRepository, uow)
        {
            _adviserRepository = adviserRepository ?? throw new ArgumentNullException();
            _adviserService = adviserService ?? throw new ArgumentNullException();
            _uow = uow ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="newClient">The new client.</param>
        /// <returns>
        /// ResponseMessage
        /// </returns>
        public async Task<ResponseMessage> CreateClient(Guid adviserId, ClientMessage newClient)
        {
            var responseMassage = InitilizeResponseMessage();

            var adviser = await _adviserRepository.GetById(adviserId);
            if (adviser == null)
            {
                return SetValidationMessage(responseMassage, "Adviser not found");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                UserDetails = new UserDetails
                {
                    Name = newClient.Name,
                    MiddleName = newClient.MiddleName ?? null,
                    LastName = newClient.LastName,
                    Dob = SetDob(newClient.Dob, ref responseMassage)
                }
            };

            if (!responseMassage.IsSuccess)
                return responseMassage;

            if (adviser.Clients == null || !adviser.Clients.Any())
            {
                adviser.Clients = new List<Client>();
            }

            adviser.Clients.Add(client);

            _adviserRepository.Update(adviser);
            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
            }

            return responseMassage;
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// ClientMessageExtended
        /// </returns>
        public async Task<ClientMessageExtended> GetClient(Guid adviserId, Guid clientId)
        {
            var adviser = await _adviserRepository.GetById(adviserId);
            if (adviser == null)
            {
                return null;
            }

            var client = adviser.Clients.FirstOrDefault(p => p.Id.Equals(clientId));
            if (client == null)
            {
                return null;
            }

            return new ClientMessageExtended
            {
                ClientId = client.Id.ToString(),
                Name = client.UserDetails.Name,
                MiddleName = client.UserDetails.MiddleName,
                LastName = client.UserDetails.LastName,
                Dob = client.UserDetails.Dob.FormatDate()
            };
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns>
        /// List of ClientMessageExtended
        /// </returns>
        public async Task<List<ClientMessageExtended>> GetClients(Guid adviserId)
        {
            var result = await _adviserService.GetAdviser(adviserId);
            if (result == null)
            {
                return null;
            }

            return result.Clients;
        }

        /// <summary>
        /// Removes the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public async Task<ResponseMessage> RemoveClient(Guid adviserId, Guid clientId)
        {
            var responseMassage = InitilizeResponseMessage();

            var adviser = await _adviserRepository.GetById(adviserId);
            if (adviser == null)
            {
                return SetValidationMessage(responseMassage, "Adviser not found");
            }

            var adviserClient = adviser.Clients?.FirstOrDefault(p => p.Id.Equals(clientId));
            if (adviserClient != null)
            {
                adviser.Clients.Remove(adviserClient);
                _adviserRepository.Update(adviser);
                var result = await _uow.Commit();

                if (!result)
                {
                    SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
                }
            }

            return responseMassage;
        }

        /// <summary>
        /// Updates the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// ResponseMessage
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResponseMessage> UpdateClient(Guid adviserId, ClientMessageExtended client)
        {
            var responseMassage = InitilizeResponseMessage();

            var adviser = await _adviserRepository.GetById(adviserId);
            if (adviser == null)
            {
                return SetValidationMessage(responseMassage, "Adviser not found");
            }

            var clientIdGuid = new Guid(client.ClientId);
            var adviserClient = adviser.Clients?.FirstOrDefault(p => p.Id.Equals(clientIdGuid));
            if (adviserClient == null)
            {
                return SetValidationMessage(responseMassage, "Client not found");
            }

            adviserClient.UserDetails.Name = client.Name;
            adviserClient.UserDetails.MiddleName = client.MiddleName ?? null;
            adviserClient.UserDetails.LastName = client.LastName;
            adviserClient.UserDetails.Dob = SetDob(client.Dob, ref responseMassage);

            if (!responseMassage.IsSuccess)
                return responseMassage;

            _adviserRepository.Update(adviser);
            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
            }

            return responseMassage;
        }
    }
}
