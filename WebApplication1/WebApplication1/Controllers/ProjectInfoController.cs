using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using CandidView.Models.ProjectStatus;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        [HttpGet]
        public List<ProjectStatus> GetProjectInfo()
        {	
            List<ProjectStatus> data = JsonConvert.DeserializeObject<List<ProjectStatus>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/projectstatus.json")));
            return data;
        }

        [HttpGet]
        public List<MetricsMaster> GetMetricsMasterInfo()
        {
            List<MetricsMaster> data = JsonConvert.DeserializeObject<List<MetricsMaster>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/metrics.json")));
            return data;
        }
    }
}