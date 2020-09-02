using System;
using System.Threading.Tasks;

namespace BackendTasks.Entity.Contracts
{
    /// <summary>
    /// Definition of UnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        Task<bool> Commit();
    }
}
