using BackendTask.Business.Contracts;
using BackendTask.Business.Contracts.Messages;
using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using BackendTasks.Entity.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.Business.Services
{
    /// <summary>
    /// Implementation of IAdviserService
    /// </summary>
    /// <seealso cref="IAdviserService" />
    public class AdviserService : BaseService, IAdviserService
    {

        #region Dependency Injected Fields

        private readonly IAdviserRepository _adviserRepository;
        private readonly IUnitOfWork _uow;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AdviserService"/> class.
        /// </summary>
        /// <param name="adviserRepository">The adviser repository.</param>
        /// <param name="uow">The uow.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public AdviserService(IAdviserRepository adviserRepository, IUnitOfWork uow) : base(adviserRepository, uow)
        {
            _adviserRepository = adviserRepository ?? throw new ArgumentNullException();
            _uow = uow ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Creates the adviser.
        /// </summary>
        /// <param name="newAdviser">The new adviser.</param>
        /// <returns></returns>
        public async Task<ResponseMessage> CreateAdviser(AdviserMessage newAdviser)
        {
            var responseMassage = new ResponseMessage
            {
                IsSuccess = true
            };

            var adviser = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = newAdviser.Name,
                    MiddleName = newAdviser.MiddleName ?? null,
                    LastName = newAdviser.LastName,
                    Dob = SetDob(newAdviser.Dob, ref responseMassage),
                    CompanyName = newAdviser.CompanyName,
                    NationInsuranceNumber = newAdviser.NationInsuranceNumber
                }
            };

            if (!responseMassage.IsSuccess)
                return responseMassage;

            _adviserRepository.Add(adviser);
            var result = await _uow.Commit();
            if (!result)
            {
                responseMassage.IsSuccess = false;
                responseMassage.ValidationMessages = new List<string>
                {
                    "Transaction failed!"
                };
            }

            return responseMassage;
        }

        /// <summary>
        /// Gets the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns>ResponseAdviserMessage</returns>
        public async Task<AdviserMessageExtended> GetAdviser(Guid adviserId)
        {
            var result = await _adviserRepository.GetById(adviserId);

            if (result == null)
                return null;

            return new AdviserMessageExtended
            {
                AdviserId = result.Id.ToString(),
                Name = result.UserDetails.Name,
                MiddleName = result.UserDetails.MiddleName,
                LastName = result.UserDetails.LastName,
                CompanyName = result.UserDetails.CompanyName,
                NationInsuranceNumber = result.UserDetails.NationInsuranceNumber,
                Dob = result.UserDetails.Dob.FormatDate(),
                Clients = (from c in result.Clients
                          select new ClientMessageExtended 
                          {
                              ClientId = c.Id.ToString(),
                              Name = c.UserDetails.Name,
                              MiddleName = c.UserDetails.MiddleName,
                              LastName = c.UserDetails.LastName,
                              Dob = c.UserDetails.Dob.FormatDate()
                          }).ToList()
            };
        }

        /// <summary>
        /// Gets the advisers.
        /// </summary>
        /// <returns>ResponseAdviserMessage</returns>
        public async Task<List<AdviserMessageExtended>> GetAdvisers()
        {
            var result = await _adviserRepository.GetAll();

            if (result == null || !result.Any())
                return null;

           return (from r in result
                    select new AdviserMessageExtended
                    {
                        AdviserId = r.Id.ToString(),
                        Name = r.UserDetails.Name,
                        MiddleName = r.UserDetails.MiddleName,
                        LastName = r.UserDetails.LastName,
                        CompanyName = r.UserDetails.CompanyName,
                        NationInsuranceNumber = r.UserDetails.NationInsuranceNumber,
                        Dob = r.UserDetails.Dob.FormatDate(),
                        Clients = (from c in r.Clients
                                   select new ClientMessageExtended
                                   {
                                       ClientId = c.Id.ToString(),
                                       Name = c.UserDetails.Name,
                                       MiddleName = c.UserDetails.MiddleName,
                                       LastName = c.UserDetails.LastName,
                                       Dob = c.UserDetails.Dob.FormatDate()
                                   }).ToList()
                    }).ToList();
        }

        /// <summary>
        /// Removes the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns>ResponseMessage</returns>
        public async Task<ResponseMessage> RemoveAdviser(Guid adviserId)
        {
            var responseMassage = new ResponseMessage
            {
                IsSuccess = true
            };

            _adviserRepository.Remove(adviserId);
            var result = await _uow.Commit();
            if (!result)
            {
                responseMassage.IsSuccess = false;
                responseMassage.ValidationMessages = new List<string>
                {
                    "Transaction failed!"
                };
            }

            return responseMassage;
        }

        /// <summary>
        /// Updates the adviser.
        /// </summary>
        /// <param name="adviser">The adviser.</param>
        /// <returns></returns>
        public async Task<ResponseMessage> UpdateAdviser(AdviserMessageExtended adviser)
        {
            var responseMassage = new ResponseMessage
            {
                IsSuccess = true
            };

            var adviserToUpdate = new Adviser
            {
                Id = new Guid(adviser.AdviserId),
                UserDetails = new AdviserUserDetails
                {
                    Name = adviser.Name,
                    MiddleName = adviser.MiddleName ?? null,
                    LastName = adviser.LastName,
                    Dob = SetDob(adviser.Dob, ref responseMassage),
                    CompanyName = adviser.CompanyName,
                    NationInsuranceNumber = adviser.NationInsuranceNumber
                }
            };

            if (!responseMassage.IsSuccess)
                return responseMassage;

            _adviserRepository.Update(adviserToUpdate);
            var result = await _uow.Commit();
            if (!result)
            {
                responseMassage.IsSuccess = false;
                responseMassage.ValidationMessages = new List<string>
                {
                    "Transaction failed!"
                };
            }

            return responseMassage;
        }
    }
}
