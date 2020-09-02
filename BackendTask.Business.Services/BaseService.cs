using BackendTask.Business.Contracts.Messages;
using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using System;
using System.Collections.Generic;

namespace BackendTask.Business.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    public class BaseService
    {
        #region Constants

        protected const string ResponseMessageTransactionFailed = "Transaction failed!";

        protected const string ResponseMessageInvalidDob = "Invalid date of birth";

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="adviserRepository">The adviser repository.</param>
        /// <param name="uow">The uow.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public BaseService(IAdviserRepository adviserRepository, IUnitOfWork uow)
        {
        }

        /// <summary>
        /// Sets the dob.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <param name="responseMassage">The response massage.</param>
        /// <returns></returns>
        protected DateTime SetDob(string dob, ref ResponseMessage responseMassage)
        {
            if (!DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                responseMassage = SetValidationMessage(responseMassage, ResponseMessageInvalidDob);
                return default;
            }

            return dateOfBirth;
        }

        /// <summary>
        /// Sets the validation message.
        /// </summary>
        /// <param name="responseMassage">The response massage.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        protected ResponseMessage SetValidationMessage(ResponseMessage responseMassage, string message)
        {
            if (responseMassage == null)
                responseMassage = new ResponseMessage();

            responseMassage.IsSuccess = false;
            if (responseMassage.ValidationMessages == null)
                responseMassage.ValidationMessages = new List<string>();

            responseMassage.ValidationMessages.Add(message);

            return responseMassage;
        }

        /// <summary>
        /// Initilizes the response message.
        /// </summary>
        /// <returns></returns>
        protected ResponseMessage InitilizeResponseMessage()
        {
            return new ResponseMessage
            {
                IsSuccess = true
            };
        }
    }
}