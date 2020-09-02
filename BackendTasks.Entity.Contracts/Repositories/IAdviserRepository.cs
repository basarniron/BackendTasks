using BackendTasks.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTasks.Entity.Contracts.Repositories
{
    /// <summary>
    /// Defition of AdviserRepository
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Contracts.IRepository{BackendTasks.Entity.Models.Adviser}" />
    public interface IAdviserRepository : IRepository<Adviser>
    {
        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>List of Advisers</returns>
        public Task<List<Adviser>> GetByName(string name);

        /// <summary>
        /// Advisers the total amounts group by status.
        /// </summary>
        /// <param name="isAssetsUnderManagement">if set to <c>true</c> [is assets under management].</param>
        /// <returns>List of AdviserTotalAmount</returns>
        public List<AdviserTotalAmount> AdviserTotalAmountsGroupByStatus(bool isAssetsUnderManagement);
    }
}
