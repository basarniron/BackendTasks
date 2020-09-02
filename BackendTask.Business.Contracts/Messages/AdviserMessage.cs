using System.Text.Json.Serialization;

namespace BackendTask.Business.Contracts
{
    /// <summary>
    /// Adviser Message
    /// </summary>
    public class AdviserMessage
    {
        [JsonPropertyName("nino")]
        public string NationInsuranceNumber { get; set; }

        [JsonPropertyName("company")]
        public string CompanyName { get; set; }

        [JsonPropertyName("firstname")]
        public string Name { get; set; }

        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string Dob { get; set; }
    }
}