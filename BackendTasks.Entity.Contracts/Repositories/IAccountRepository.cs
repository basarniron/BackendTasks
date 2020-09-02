using BackendTasks.Entity.Models;

namespace BackendTasks.Entity.Contracts.Repositories
{
    /// <summary>
    /// Definition of AccountRepository
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Contracts.IRepository{BackendTasks.Entity.Models.Account}" />
    public interface IAccountRepository : IRepository<Account>
    {
    }
}
