using Newtonsoft.Json;

namespace CandidView.Models.ProjectStatus
{
    public class Metrics
    {
        [JsonProperty(PropertyName = "metricName")]
        string MetricName { get; set; }
        [JsonProperty(PropertyName = "background")]
        string Background { get; set; }
    }
}
