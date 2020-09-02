using BackendTasks.Entity.Contracts;
using System.Threading.Tasks;

namespace BackendTasks.Entity.Services
{
    /// <summary>
    /// Implementation of UnitOfWork
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
