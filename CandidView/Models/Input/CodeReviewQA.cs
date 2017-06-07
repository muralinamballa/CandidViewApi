using Newtonsoft.Json;

namespace CandidView.Models.Output
{
    public class CodeReviewQA
    {
        [JsonProperty(PropertyName = "catastrophic")]
        public decimal Catastrophic { get; set; }
        [JsonProperty(PropertyName = "majorDefectsWithoutWorkaround")]
        public decimal MajorDefectsWithoutWorkaround { get; set; }
        [JsonProperty(PropertyName = "majorDefectsWithWorkaround")]
        public decimal MajorDefectsWithWorkaround { get; set; }
        [JsonProperty(PropertyName = "minorDefects")]
        public decimal MinorDefects { get; set; }
    }
}