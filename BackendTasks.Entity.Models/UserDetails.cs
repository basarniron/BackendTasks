using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// UserDetails model
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [BsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [BsonRequired]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>
        /// The dob.
        /// </value>
        [BsonRequired]
        public DateTime Dob { get; set; }
    }
}
