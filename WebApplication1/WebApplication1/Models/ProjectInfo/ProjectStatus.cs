using Newtonsoft.Json;

namespace CandidView.Models.ProjectStatus
{
    public class ProjectStatus
    {
        [JsonProperty(PropertyName = "slno")]
        public int Slno { get; set; }
        [JsonProperty(PropertyName = "businessUnit")]
        public string BusinessUnit { get; set; }
        [JsonProperty(PropertyName = "programName")]
        public string ProgramName { get; set; }
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public int Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        public int Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        public MetricQuality Quality { get; set; }
        [JsonProperty(PropertyName = "sla")]
        public MetricSLA Sla { get; set; }
        [JsonProperty(PropertyName = "remarks")]
        string Remarks { get; set; }
    }
}
