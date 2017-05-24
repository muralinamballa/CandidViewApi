using Newtonsoft.Json;

namespace CandidView.Models.ProjectStatus
{
    public class ProjectStatus
    {
        [JsonProperty(PropertyName = "slno")]
        int Slno { get; set; }
        [JsonProperty(PropertyName = "businessUnit")]
        string BusinessUnit { get; set; }
        [JsonProperty(PropertyName = "programName")]
        string ProgramName { get; set; }
        [JsonProperty(PropertyName = "owner")]
        string Owner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        int TeamSize { get; set; }
        [JsonProperty(PropertyName = "scope")]
        Metrics Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        Metrics Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        Metrics Quality { get; set; }
        [JsonProperty(PropertyName = "sla")]
        Metrics Sla { get; set; }
        [JsonProperty(PropertyName = "remarks")]
        string Remarks { get; set; }
    }
}
