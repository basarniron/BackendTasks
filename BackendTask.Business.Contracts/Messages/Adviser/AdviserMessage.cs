using BackendTask.Business.Contracts.Messages;
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

        /// <summary>
        /// Gets or sets the total assets under management.
        /// </summary>
        /// <value>
        /// The total assets under management.
        /// </value>
        [JsonPropertyName("totalAssetsUnderManagement")]
        public decimal TotalAssetsUnderManagement { get; set; }

        /// <summary>
        /// Gets or sets the total fees and charges.
        /// </summary>
        /// <value>
        /// The total fees and charges.
        /// </value>
        [JsonPropertyName("totalFeesAndCharges")]
        public decimal TotalFeesAndCharges { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}