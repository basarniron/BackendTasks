using BackendTasks.Entity.Models;

namespace BackendTasks.Entity.Contracts.Repositories
{
    /// <summary>
    /// Defition of AdviserRepository
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Contracts.IRepository{BackendTasks.Entity.Models.Adviser}" />
    public interface IAdviserRepository : IRepository<Adviser>
    {
    }
}
