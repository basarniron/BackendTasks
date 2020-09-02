using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using BackendTasks.Entity.Models;
using BackendTasks.Entity.Services.Repository;

namespace BackendTasks.Entity.Services.Repositories
{
    /// <summary>
    /// Implemention of IAdviserRepository
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Services.Repository.BaseRepository{BackendTasks.Entity.Models.Adviser}" />
    /// <seealso cref="BackendTasks.Entity.Contracts.Repositories.IAdviserRepository" />
    public class AdviserRepository : BaseRepository<Adviser>, IAdviserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdviserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AdviserRepository(IMongoContext context) : base(context)
        {
        }
    }
}
