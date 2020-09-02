using BackendTasks.Entity.Models;
using System.Collections.Generic;

namespace BackendTasks.Entity.Contracts.Repositories
{
    /// <summary>
    /// Defition of AdviserRepository
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Contracts.IRepository{BackendTasks.Entity.Models.Adviser}" />
    public interface IAdviserRepository : IRepository<Adviser>
    {
        /// <summary>
        /// Advisers the total amounts group by status.
        /// </summary>
        /// <param name="isAssetsUnderManagement">if set to <c>true</c> [is assets under management].</param>
        /// <returns>List of AdviserTotalAmount</returns>
        public List<AdviserTotalAmount> AdviserTotalAmountsGroupByStatus(bool isAssetsUnderManagement);
    }
}
