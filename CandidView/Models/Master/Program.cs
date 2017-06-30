using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class Program
    {
        [JsonProperty(PropertyName = "buId")]
        public int BuId { get; set; }
        [JsonProperty(PropertyName = "programId")]
        public int ProgramId { get; set; }
        [JsonProperty(PropertyName = "programName")]
        public string ProgramName { get; set; }
        [JsonProperty(PropertyName = "scrumName")]
        public string ScrumName { get; set; }
        [JsonProperty(PropertyName = "internalOwner")]
        public string InternalOwner { get; set; }
        [JsonProperty(PropertyName = "externalOwner")]
        public string ExternalOwner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
        [JsonProperty(PropertyName = "sprintCalendar")]
        public string SprintCalendar { get; set; }
    }
}

