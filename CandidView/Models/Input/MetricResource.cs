using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class MetricResource
    {
        [JsonProperty(PropertyName = "attrition")]
        public decimal Attrition { get; set; }
        [JsonProperty(PropertyName = "availabilityofResource")]
        public string AvailabilityofResource { get; set; }
    }
}