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
    /// Implementation of IAdviserService
    /// </summary>
    /// <seealso cref="IAdviserService" />
    public class AdviserService : BaseService, IAdviserService
    {
        #region Constants

        private const string StatusActive = "Active";
        private const string StatusInactive = "Inactive";

        #endregion

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
            var responseMassage = InitilizeResponseMessage();

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
                },
                TotalAssetsUnderManagement = newAdviser.TotalAssetsUnderManagement,
                TotalFeesAndCharges = newAdviser.TotalFeesAndCharges,
                IsActive = newAdviser.IsActive
            };

            if (!responseMassage.IsSuccess)
                return responseMassage;

            _adviserRepository.Add(adviser);
            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
            }

            return responseMassage;
        }

        /// <summary>
        /// Populates the advisers.
        /// </summary>
        /// <param name="newAdviser">The new adviser.</param>
        /// <returns></returns>
        public async Task<ResponseMessage> PopulateAdvisers()
        {
            var responseMassage = InitilizeResponseMessage();

            #region Prepopulate adviser data
            var adviser1 = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = "Testname1",
                    MiddleName = null,
                    LastName = "Testlastname1",
                    Dob = new DateTime(1983, 1, 2),
                    CompanyName = "Test 1 ltd",
                    NationInsuranceNumber = "AB12345C"
                },
                Clients = new List<Client>
                {
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname101",
                            LastName = "Testclientlastname101",
                            Dob = new DateTime(1963, 11, 2),
                        }
                    },
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname102",
                            LastName = "Testclientlastname102",
                            Dob = new DateTime(1969, 5, 23),
                        }
                    }
                },
                TotalAssetsUnderManagement = 3212.32M,
                TotalFeesAndCharges = 450.98M,
                IsActive = true
            };

            var adviser2 = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = "Testname2",
                    MiddleName = null,
                    LastName = "Testlastname2",
                    Dob = new DateTime(1981, 10, 2),
                    CompanyName = "Test 2 ltd",
                    NationInsuranceNumber = "AB12345C"
                },
                Clients = new List<Client>
                {
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname201",
                            LastName = "Testclientlastname201",
                            Dob = new DateTime(1975, 2, 12),
                        }
                    },
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname202",
                            LastName = "Testclientlastname202",
                            Dob = new DateTime(1969, 5, 23),
                        }
                    }
                },
                TotalAssetsUnderManagement = 50000M,
                TotalFeesAndCharges = 550.68M,
                IsActive = true
            };

            var adviser3 = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = "Testname3",
                    MiddleName = null,
                    LastName = "Testlastname3",
                    Dob = new DateTime(1979, 10, 2),
                    CompanyName = "Test 3 ltd",
                    NationInsuranceNumber = "AB12345C"
                },
                Clients = new List<Client>
                {
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname301",
                            LastName = "Testclientlastname301",
                            Dob = new DateTime(1975, 2, 12),
                        }
                    }
                },
                TotalAssetsUnderManagement = 24500M,
                TotalFeesAndCharges = 245.23M,
                IsActive = false
            };

            var adviser4 = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = "Testname4",
                    MiddleName = null,
                    LastName = "Testlastname4",
                    Dob = new DateTime(1945, 1, 2),
                    CompanyName = "Test 4 ltd",
                    NationInsuranceNumber = "AB12345C"
                },
                Clients = new List<Client>
                {
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        UserDetails = new UserDetails
                        {
                            Name = "Testclientname401",
                            LastName = "Testclientlastname401",
                            Dob = new DateTime(1975, 2, 12),
                        }
                    }
                },
                TotalAssetsUnderManagement = 24500M,
                TotalFeesAndCharges = 245.23M,
                IsActive = false
            };

            var adviser5 = new Adviser
            {
                Id = Guid.NewGuid(),
                UserDetails = new AdviserUserDetails
                {
                    Name = "Testname5",
                    MiddleName = null,
                    LastName = "Testlastname5",
                    Dob = new DateTime(1941, 1, 2),
                    CompanyName = "Test 5 ltd",
                    NationInsuranceNumber = "AB12345C"
                },
                TotalAssetsUnderManagement = 4566.34M,
                TotalFeesAndCharges = 45.23M,
                IsActive = true
            };
            #endregion

            _adviserRepository.Add(adviser1);
            _adviserRepository.Add(adviser2);
            _adviserRepository.Add(adviser3);
            _adviserRepository.Add(adviser4);
            _adviserRepository.Add(adviser5);

            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
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
                Clients = result.Clients != null ? (from c in result.Clients
                                                    select new ClientMessageExtended
                                                    {
                                                        ClientId = c.Id.ToString(),
                                                        Name = c.UserDetails.Name,
                                                        MiddleName = c.UserDetails.MiddleName,
                                                        LastName = c.UserDetails.LastName,
                                                        Dob = c.UserDetails.Dob.FormatDate()
                                                    }).ToList() : null,
                TotalAssetsUnderManagement = result.TotalAssetsUnderManagement,
                TotalFeesAndCharges = result.TotalFeesAndCharges,
                IsActive = result.IsActive
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
                        Clients = r.Clients != null ? (from c in r.Clients
                                                       select new ClientMessageExtended
                                                       {
                                                           ClientId = c.Id.ToString(),
                                                           Name = c.UserDetails.Name,
                                                           MiddleName = c.UserDetails.MiddleName,
                                                           LastName = c.UserDetails.LastName,
                                                           Dob = c.UserDetails.Dob.FormatDate()
                                                       }).ToList() : null,
                        TotalAssetsUnderManagement = r.TotalAssetsUnderManagement,
                        TotalFeesAndCharges = r.TotalFeesAndCharges,
                        IsActive = r.IsActive
                    })?.ToList();
        }

        /// <summary>
        /// Gets the adviser total fees and charges.
        /// </summary>
        /// <returns></returns>
        public List<AdviserTotalAmountMessage> GetAdviserTotalFeesAndCharges()
        {
            var result = _adviserRepository.AdviserTotalAmountsGroupByStatus(false);

            if (result != null)
            {
                return (from r in result
                        select new AdviserTotalAmountMessage
                        {
                            AmountProperty = "Total fees and charges",
                            Status = SetStatus(r.IsActive),
                            TotalAmount = r.TotalAmount
                        }
                        ).ToList();
            }

            return null;
        }

        /// <summary>
        /// Gets the adviser total assets under management.
        /// </summary>
        /// <returns></returns>
        public List<AdviserTotalAmountMessage> GetAdviserTotalAssetsUnderManagement()
        {
            var result = _adviserRepository.AdviserTotalAmountsGroupByStatus(true);

            if (result != null)
            {
                return (from r in result
                        select new AdviserTotalAmountMessage
                        {
                            AmountProperty = "Total assets under management",
                            Status = SetStatus(r.IsActive),
                            TotalAmount = r.TotalAmount
                        }
                        ).ToList();
            }

            return null;
        }

        /// <summary>
        /// Removes the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns>ResponseMessage</returns>
        public async Task<ResponseMessage> RemoveAdviser(Guid adviserId)
        {
            var responseMassage = InitilizeResponseMessage();

            _adviserRepository.Remove(adviserId);
            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
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
            var responseMassage = InitilizeResponseMessage();

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
                },
                TotalAssetsUnderManagement = adviser.TotalAssetsUnderManagement,
                TotalFeesAndCharges = adviser.TotalFeesAndCharges,
                IsActive = adviser.IsActive
            };

            if (!responseMassage.IsSuccess)
                return responseMassage;

            _adviserRepository.Update(adviserToUpdate);
            var result = await _uow.Commit();
            if (!result)
            {
                SetValidationMessage(responseMassage, ResponseMessageTransactionFailed);
            }

            return responseMassage;
        }

        #region Private static methods

        private static string SetStatus(bool isActive)
        {
            return isActive ? StatusActive : StatusInactive;
        }

        #endregion
    }
}