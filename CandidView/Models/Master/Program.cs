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
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [JsonProperty(PropertyName = "teamSize")]
        public int TeamSize { get; set; }
    }
}

