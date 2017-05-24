using Newtonsoft.Json;

namespace CandidView.Models.HighlightsStatus
{
    public class HighlightsStatus
    {
        [JsonProperty(PropertyName = "accomplishments")]
        string Accomplishments { get; set; }
        [JsonProperty(PropertyName = "inprogress")]
        string InProgress { get; set; }
        [JsonProperty(PropertyName = "upcommingmilestones")]
        string UpcommingMilestones { get; set; }
    }
}