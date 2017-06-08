using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using CandidView.Models.RiskStatus;
using CandidView.Models.HighlightsStatus;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace CandidView.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class StatusController : ApiController
    {
        [HttpGet]
        public List<RiskStatus> GetRiskStatus()
        {
            List<RiskStatus> data = JsonConvert.DeserializeObject<List<RiskStatus>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/riskstatus.json")));
            return data;
        }
        [HttpGet]
        public List<HighlightsStatus> GetHighlightsStatus()
        {
            List<HighlightsStatus> data = JsonConvert.DeserializeObject<List<HighlightsStatus>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/highlightsstatus.json")));
            return data;
        }

    }
}
