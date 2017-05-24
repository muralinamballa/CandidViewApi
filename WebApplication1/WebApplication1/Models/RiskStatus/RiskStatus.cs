using Newtonsoft.Json;

namespace CandidView.Models.RiskStatus
{
    public class RiskStatus
    {
        [JsonProperty(PropertyName = "slno")]
        int Slno { get; set; }
        [JsonProperty(PropertyName = "type")]
        string Type { get; set; }
        [JsonProperty(PropertyName = "description")]
        string Description { get; set; }
        [JsonProperty(PropertyName = "owner")]
        string Owner { get; set; }
        [JsonProperty(PropertyName = "exposure")]
        string Exposure { get; set; }
        [JsonProperty(PropertyName = "status")]
        string Status { get; set; }
    }
}