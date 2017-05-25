using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class TeamMaster
    {
        [JsonProperty(PropertyName = "buid")]
        BUMaster BUId { get; set; }
        [JsonProperty(PropertyName = "programId")]
        ProgramMaster ProgramId { get; set; }
        [JsonProperty(PropertyName = "teamName")]
        int TeamName { get; set; }
    }
}