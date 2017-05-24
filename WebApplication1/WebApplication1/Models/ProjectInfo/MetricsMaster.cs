using System.Collections.Generic;
using Newtonsoft.Json;

namespace CandidView.Models.ProjectStatus
{
    public class MetricsMaster
    {
        [JsonProperty(PropertyName = "metricName")]
        string MetricName { get; set; }
        [JsonProperty(PropertyName = "background")]
        string Background { get; set; }
    }
}
