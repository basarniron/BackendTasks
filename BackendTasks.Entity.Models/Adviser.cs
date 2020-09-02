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
        /// Gets or sets the contact details.
        /// </summary>
        /// <value>
        /// The contact details.
        /// </value>
        public ContactDetails ContactDetails { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public List<Client> Clients { get; set; }
    }
}
