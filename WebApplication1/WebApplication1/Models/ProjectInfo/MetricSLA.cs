using Newtonsoft.Json;


namespace CandidView.Models.ProjectStatus
{
    public class MetricSLA
    {
        [JsonProperty(PropertyName = "scheduleAdherence")]
        decimal ScheduleAdherence { get; set; }
        [JsonProperty(PropertyName = "defectDensityNonProd")]
        decimal DefectDensityNonProd { get; set; }
        [JsonProperty(PropertyName = "sev1DefectLeakageNonProd")]
        decimal Sev1DefectLeakageNonProd { get; set; }
        [JsonProperty(PropertyName = "defectDensityProd")]
        decimal SefectDensityProd { get; set; }
        [JsonProperty(PropertyName = "sev1DefectLeakageProd")]
        decimal Sev1DefectLeakageProd { get; set; }
        [JsonProperty(PropertyName = "sev2DefectLeakageProd")]
        decimal Sev2DefectLeakageProd { get; set; }
        [JsonProperty(PropertyName = "defectRejectionRate")]
        decimal DefectRejectionRate { get; set; }
    }
}