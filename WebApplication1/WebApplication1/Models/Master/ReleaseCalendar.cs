using Newtonsoft.Json;
using System;

namespace CandidView.Models.Master
{
    public class ReleaseCalendar
    {
        [JsonProperty(PropertyName = "releaseNumber")]
        public decimal ReleaseNumber { get; set; }
        [JsonProperty(PropertyName = "codeFreezDate")]
        public DateTime CodeFreezeDate { get; set; }
    }
}