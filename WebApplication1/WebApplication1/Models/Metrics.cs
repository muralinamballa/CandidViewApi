using Newtonsoft.Json;

namespace CandidView.models
{
    public class Metrics
    {
        [JsonProperty(PropertyName = "value")]
        decimal Value { get; set; }
        [JsonProperty(PropertyName = "background")]
        string Background { get; set; }
    }
}
