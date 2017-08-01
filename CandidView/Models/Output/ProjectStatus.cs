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
        [JsonProperty(PropertyName = "externalOwner")]
        public string ExternalOwner { get; set; }
        [JsonProperty(PropertyName = "internalOwner")]
        public string InternalOwner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public MetricScope Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        public decimal Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        public MetricQuality Quality { get; set; }
        [JsonProperty(PropertyName = "qualityEngineeringPractice")]
        public MetricQualityEngineeringPractice QualityEngineeringPractice { get; set; }
        [JsonProperty(PropertyName = "resource")]
        public MetricResource Resource { get; set; }
        [JsonProperty(PropertyName = "release")]
        public decimal Release { get; set; }
    }
}
