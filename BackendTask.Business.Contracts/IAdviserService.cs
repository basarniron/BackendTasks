using BackendTask.Business.Contracts.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTask.Business.Contracts
{
    /// <summary>
    /// Definition of AdviserService
    /// </summary>
    public interface IAdviserService
    {
        /// <summary>
        /// Gets the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns></returns>
        public Task<AdviserMessageExtended> GetAdviser(Guid adviserId);

        /// <summary>
        /// Gets the advisers.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns></returns>
        public Task<List<AdviserMessageExtended>> GetAdvisers();

        /// <summary>
        /// Creates the adviser.
        /// </summary>
        /// <param name="newAdviser">The new adviser.</param>
        /// <returns></returns>
        public Task<ResponseMessage> CreateAdviser(AdviserMessage newAdviser);

        /// <summary>
        /// Updates the adviser.
        /// </summary>
        /// <param name="adviser">The adviser.</param>
        /// <returns></returns>
        public Task<ResponseMessage> UpdateAdviser(AdviserMessageExtended adviser);
        
        /// <summary>
        /// Removes the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns></returns>
        public Task<ResponseMessage> RemoveAdviser(Guid adviserId);
    }
}
