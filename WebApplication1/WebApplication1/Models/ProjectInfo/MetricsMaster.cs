using System.Collections.Generic;
using Newtonsoft.Json;

namespace CandidView.Models.ProjectInfo
{
    public class MetricsMaster
    {
        [JsonProperty(PropertyName = "metricName")]
        string MetricName { get; set; }
        [JsonProperty(PropertyName = "background")]
        string Background { get; set; }
    }

    public class MetricsRoot
    {
        [JsonProperty(PropertyName = "metricsData")]
        public MetricsMaster[] MetricsData { get; set; }
    }

}
