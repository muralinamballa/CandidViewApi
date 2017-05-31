using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class MetricQuality
    {
        [JsonProperty(PropertyName = "defectLeakage")]
        decimal DefectLeakage { get; set; }
        [JsonProperty(PropertyName = "productionDefect")]
        decimal ProductionDefect { get; set; }
        [JsonProperty(PropertyName = "fdnDefects")]
        decimal FDNDefects { get; set; }
        [JsonProperty(PropertyName = "securityDefects")]
        decimal SecurityDefects { get; set; }
    }
}
