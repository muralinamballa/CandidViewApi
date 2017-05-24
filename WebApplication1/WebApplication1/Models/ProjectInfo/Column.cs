using Newtonsoft.Json;

namespace CandidView.Models.ProjectInfo
{
    public class Column
    {
        [JsonProperty(PropertyName = "display")]
        string Display { get; set; }
    }
}
