using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts.Messages
{
    public class AdviserMessageExtended : AdviserMessage
    {
        [JsonPropertyName("adviserId")]
        public string AdviserId { get; set; }
    }
}
