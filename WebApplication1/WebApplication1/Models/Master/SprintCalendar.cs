using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class SprintCalendar
    {
        [JsonProperty(PropertyName = "sprintNumber")]
        public int SprintNumber { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public string StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public string EndDate { get; set; }
    }
}