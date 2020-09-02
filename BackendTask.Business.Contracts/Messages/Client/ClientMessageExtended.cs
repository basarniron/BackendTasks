using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts.Messages
{
    /// <summary>
    /// Client Message Extended
    /// </summary>
    public class ClientMessageExtended: ClientMessage
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }
}
