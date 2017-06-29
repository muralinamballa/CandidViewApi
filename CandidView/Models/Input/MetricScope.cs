using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class MetricScope
    {
        [JsonProperty(PropertyName = "backlogPresent")]
        public string BacklogPresent { get; set; }
        [JsonProperty(PropertyName = "stories")]
        public string Stories { get; set; }
        [JsonProperty(PropertyName = "developmentDependencies")]
        public string DevelopmentDependencies { get; set; }
        [JsonProperty(PropertyName = "tgoDesign")]
        public string TgoDesign { get; set; }
        [JsonProperty(PropertyName = "tgoConstruction")]
        public string TgoConstruction { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public string StartDate { get; set; }
    }
}