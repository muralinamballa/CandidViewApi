using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class ProgramMaster
    {
        [JsonProperty(PropertyName = "programId")]
        public int ProgramId { get; set; }
        [JsonProperty(PropertyName = "businessUnit")]
        public string BusinessUnit { get; set; }
        [JsonProperty(PropertyName = "programName")]
        public string ProgramName { get; set; }
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public int Scope { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        public int Schedule { get; set; }
        [JsonProperty(PropertyName = "quality")]
        public int Quality { get; set; }
        [JsonProperty(PropertyName = "sla")]
        public int Sla { get; set; }
        [JsonProperty(PropertyName = "remarks")]
        public string Remarks { get; set; }
    }
}
