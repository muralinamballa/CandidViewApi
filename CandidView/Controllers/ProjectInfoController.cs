using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using CandidView.Models.Output;
using System.IO;
using System.Web;
using System.Collections.Generic;
using CandidView.Services;

namespace CandidView.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        [HttpGet]
        public List<ProjectStatus> GetProjectInfo()
        {
            ProjectStatusService statusService = new ProjectStatusService();
            return statusService.GetProjectInfo();
        }

        [HttpGet]
        public string GetSlaDetail()
        {
            OverallStatusService statusService = new OverallStatusService();
            return statusService.GetSlaInfo();
        }
    }
}