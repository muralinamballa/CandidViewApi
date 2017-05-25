using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class BUMaster
    {
        [JsonProperty(PropertyName = "buid")]
        int BUId { get; set; }
    }
}