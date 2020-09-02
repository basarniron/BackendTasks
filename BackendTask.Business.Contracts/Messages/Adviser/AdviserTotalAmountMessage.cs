using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts.Messages
{
    /// <summary>
    /// Adviser Total Amount Message
    /// </summary>
    public class AdviserTotalAmountMessage
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the amount property.
        /// </summary>
        /// <value>
        /// The amount property.
        /// </value>
        [JsonPropertyName("amountProperty")]
        public string AmountProperty { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
