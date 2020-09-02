using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using BackendTasks.Entity.Models;
using BackendTasks.Entity.Services.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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
            ConfigDbSet();
            CreateIndex();
        }

        /// <summary>
        /// Advisers the total amounts group by status.
        /// </summary>
        /// <param name="isAssetsUnderManagement">if set to <c>true</c> [is assets under management].</param>
        /// <returns>
        /// List of AdviserTotalAmount
        /// </returns>
        public List<AdviserTotalAmount> AdviserTotalAmountsGroupByStatus(bool isAssetsUnderManagement)
        {
            List<AdviserTotalAmount> result = null;

            if (isAssetsUnderManagement)
            {
                result = DbSet.Aggregate<Adviser>()
                         .Group(
                                 x => x.IsActive,
                                 group => new AdviserTotalAmount
                                 {
                                     IsActive = group.Key,
                                     TotalAmount = group.Sum(y => y.TotalAssetsUnderManagement)
                                 }
                         ).ToList();
            }
            else
            {
                result = DbSet.Aggregate<Adviser>()
                         .Group(
                                 x => x.IsActive,
                                 group => new AdviserTotalAmount
                                 {
                                     IsActive = group.Key,
                                     TotalAmount = group.Sum(y => y.TotalFeesAndCharges)
                                 }
                         ).ToList();
            }

            if (result == null || !result.Any())
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Creates the index.
        /// </summary>
        private void CreateIndex()
        {
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<Adviser>.IndexKeys.Ascending(adviser => adviser.UserDetails.Name);
            var indexModelName = new CreateIndexModel<Adviser>(indexKeys, indexOptions);
            DbSet.Indexes.CreateOne(indexModelName);
        }
    }
}
