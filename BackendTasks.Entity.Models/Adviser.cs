using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// Adviser model
    /// </summary>
    public class Adviser
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
        public AdviserUserDetails UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public List<Client> Clients { get; set; }

        /// <summary>
        /// Gets or sets the total assets under management.
        /// </summary>
        /// <value>
        /// The total assets under management.
        /// </value>
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalAssetsUnderManagement { get; set; }

        /// <summary>
        /// Gets or sets the total fees and charges.
        /// </summary>
        /// <value>
        /// The total fees and charges.
        /// </value>
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalFeesAndCharges { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
