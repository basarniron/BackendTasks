using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// Contact Details model
    /// </summary>
    public class ContactDetails
    {
        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public List<Phone> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [BsonRequired]
        public string Email { get; set; }
    }
}
