using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class MetricQuality
    {
        [JsonProperty(PropertyName = "requirementTestCoverage")]
        public decimal RequirementTestCoverage { get; set; }
        [JsonProperty(PropertyName = "averageLeadTime")]
        public decimal AverageLeadTime { get; set; }
        [JsonProperty(PropertyName = "defectLeakageQA")]
        public decimal DefectLeakageQA { get; set; }
        [JsonProperty(PropertyName = "productionDefect")]
        public decimal ProductionDefect { get; set; }
    }
}
