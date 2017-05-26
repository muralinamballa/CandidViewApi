using Newtonsoft.Json;

namespace CandidView.Models.Master
{
    public class BusinessUnit
    {
        [JsonProperty(PropertyName = "buId")]
        public int BuId { get; set; }
        [JsonProperty(PropertyName = "buName")]
        public string BuName { get; set; }
    }
}