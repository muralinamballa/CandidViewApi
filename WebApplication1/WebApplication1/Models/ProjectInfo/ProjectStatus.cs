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
        int Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        int Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        MetricQuality Quality { get; set; }
        [JsonProperty(PropertyName = "sla")]
        MetricSLA Sla { get; set; }
        [JsonProperty(PropertyName = "remarks")]
        string Remarks { get; set; }
    }
}
