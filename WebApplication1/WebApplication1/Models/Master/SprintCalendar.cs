using Newtonsoft.Json;
using System;

namespace CandidView.Models.Master
{
    public class SprintCalendar
    {
        [JsonProperty(PropertyName = "sprintNumber")]
        public int SprintNumber { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "releaseNumber")]
        public string ReleaseNumber { get; set; }
    }
}