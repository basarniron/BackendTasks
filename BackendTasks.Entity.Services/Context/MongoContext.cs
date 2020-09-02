using BackendTasks.Entity.Contracts;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTasks.Entity.Services.Context
{
    /// <summary>
    /// Implementation of MongoContext
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Contracts.IMongoContext" />
    public class MongoContext : IMongoContext
    {
        #region Constants

        private const string MongoSetting = "MongoSettings:";
        private const string ConfigurationSetting = "Connection";
        private const string DatabaseNameSetting = "DatabaseName";

        #endregion

        #region Fields

        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        #endregion

        #region Private properties

        private IMongoDatabase Database { get; set; }
        
        #endregion

        #region Public properties

        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; } 
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();
        }

        #region Public methods
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        } 
        #endregion

        #region Private methods

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(_configuration[$"{MongoSetting}{ConfigurationSetting}"]);
            Database = MongoClient.GetDatabase(_configuration[$"{MongoSetting}{DatabaseNameSetting}"]);
        }


        #endregion
    }
}
