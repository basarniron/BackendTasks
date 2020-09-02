using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// Account model
    /// </summary>
    public class Account
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
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        [BsonRequired]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product type identifier.
        /// </summary>
        /// <value>
        /// The product type identifier.
        /// </value>
        [BsonRequired]
        public Guid ProductTypeId { get; set; }


        /// <summary>
        /// Gets or sets the account start date.
        /// </summary>
        /// <value>
        /// The account start date.
        /// </value>
        public DateTime AccountStartDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
