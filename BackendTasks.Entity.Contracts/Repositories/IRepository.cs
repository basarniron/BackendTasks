using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTasks.Entity.Contracts
{
    /// <summary>
    /// Definition of Repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Add(TEntity obj);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetById(Guid id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();
        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Update(TEntity obj);
        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Remove(Guid id);
    }
}
