using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts.Messages
{
    /// <summary>
    /// Adviser Message Extended
    /// </summary>
    /// <seealso cref="BackendTask.Business.Contracts.AdviserMessage" />
    public class AdviserMessageExtended : AdviserMessage
    {
        /// <summary>
        /// Gets or sets the adviser identifier.
        /// </summary>
        /// <value>
        /// The adviser identifier.
        /// </value>
        [JsonPropertyName("adviserId")]
        public string AdviserId { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        [JsonPropertyName("clients")]
        public List<ClientMessageExtended> Clients { get; set; }
    }
}
