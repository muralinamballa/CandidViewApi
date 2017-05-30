using Newtonsoft.Json;


namespace CandidView.Models.ProjectStatus
{
    public class MetricSLA
    {
        [JsonProperty(PropertyName = "scheduleAdherence")]
        public decimal ScheduleAdherence { get; set; }
        [JsonProperty(PropertyName = "defectDensityNonProd")]
        public decimal DefectDensityNonProd { get; set; }
        [JsonProperty(PropertyName = "sev1DefectLeakageNonProd")]
        public decimal Sev1DefectLeakageNonProd { get; set; }
        [JsonProperty(PropertyName = "defectDensityProd")]
        public decimal DefectDensityProd { get; set; }
        [JsonProperty(PropertyName = "sev1DefectLeakageProd")]
        public decimal Sev1DefectLeakageProd { get; set; }
        [JsonProperty(PropertyName = "sev2DefectLeakageProd")]
        public decimal Sev2DefectLeakageProd { get; set; }
        [JsonProperty(PropertyName = "defectRejectionRate")]
        public decimal DefectRejectionRate { get; set; }
    }
}