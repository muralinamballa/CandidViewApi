using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidView.Models.Master
{
    public class Commitment
    {
        [JsonProperty(PropertyName = "programId")]
        public int ProgramId { get; set; }
        [JsonProperty(PropertyName = "releasenumber")]
        public decimal Releasenumber { get; set; }
        [JsonProperty(PropertyName = "plannedCapacityinStoryPoints")]
        public int PlannedCapacityinStoryPoints { get; set; }

    }
}