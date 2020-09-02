using BackendTask.Business.Contracts.Messages;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts
{
    /// <summary>
    /// Adviser Message
    /// </summary>
    public class AdviserMessage : UserDetailsMessage
    {
        /// <summary>
        /// Gets or sets the nation insurance number.
        /// </summary>
        /// <value>
        /// The nation insurance number.
        /// </value>
        [JsonPropertyName("nationInsuranceNumber")]
        public string NationInsuranceNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [JsonPropertyName("company")]
        public string CompanyName { get; set; }
    }
}