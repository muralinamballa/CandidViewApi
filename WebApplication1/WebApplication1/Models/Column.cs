using Newtonsoft.Json;

namespace CandidView.models
{
    public class Column
    {
        [JsonProperty(PropertyName = "display")]
        string Display { get; set; }
    }
}
