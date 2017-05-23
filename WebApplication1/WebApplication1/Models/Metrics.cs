using Newtonsoft.Json;

namespace CandidView.models
{
    public class Metrics
    {
        [JsonProperty(PropertyName = "value")]
        int Value { get; set; }
        [JsonProperty(PropertyName = "background")]
        string Background { get; set; }
    }
}
