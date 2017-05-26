using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class ReleaseCalendar
    {
        [JsonProperty(PropertyName = "releaseNumber")]
        public int ReleaseNumber { get; set; }
        [JsonProperty(PropertyName = "codeFreezDate")]
        public int CodeFreezeDate { get; set; }
    }
}