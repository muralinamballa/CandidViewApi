using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class ProjectStatus
    {
        [JsonProperty(PropertyName = "slno")]
        public int Slno { get; set; }
        [JsonProperty(PropertyName = "buId")]
        public int BuId { get; set; }
        [JsonProperty(PropertyName = "buName")]
        public string BuName { get; set; }
        [JsonProperty(PropertyName = "programName")]
        public string ProgramName { get; set; }
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public decimal Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        public decimal Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        public MetricQuality Quality { get; set; }
        [JsonProperty(PropertyName = "qualityEngineeringPractice")]
        public MetricQualityEngineeringPractice QualityEngineeringPractice { get; set; }

    }
}
