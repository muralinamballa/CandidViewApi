using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class ReleaseCalendar
    {
        [JsonProperty(PropertyName = "releaseNumber")]
        public int ReleaseNumber { get; set; }
        [JsonProperty(PropertyName = "lastPassSprintCount")]
        public int LastPassSprintCount { get; set; }
    }
}