using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts.Messages
{
    public class UserDetailsMessage
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("firstname")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>
        /// The dob.
        /// </value>
        [JsonPropertyName("dateOfBirth")]
        public string Dob { get; set; }
    }
}
