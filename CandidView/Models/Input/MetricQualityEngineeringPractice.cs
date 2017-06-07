using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class MetricQualityEngineeringPractice
    {
        [JsonProperty(PropertyName = "tddCoverage")]
        public decimal TDDCoverage { get; set; }
        [JsonProperty(PropertyName = "bddCoverage")]
        public decimal BDDCoverage { get; set; }
        [JsonProperty(PropertyName = "mvpAdoption")]
        public decimal MVPAdoption { get; set; }
        [JsonProperty(PropertyName = "codeReviewDev")]
        public CodeReviewDev CodeReviewDev { get; set; }
        [JsonProperty(PropertyName = "codeReviewQA")]
        public CodeReviewQA CodeReviewQA { get; set; }
        [JsonProperty(PropertyName = "maintainabilityIndex")]
        public decimal MaintainabilityIndex { get; set; }
        [JsonProperty(PropertyName = "cyclomaticComplexity")]
        public decimal CyclomaticComplexity { get; set; }

    }
}