using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// Client model
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        /// <value>
        /// The user details.
        /// </value>
        [BsonRequired]
        public UserDetails UserDetails { get; set; }
    }
}
