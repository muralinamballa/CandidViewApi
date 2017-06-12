using System.Web.Http;
using CandidView.Models.Output;
using System.Web;
using System.Collections.Generic;
using CandidView.Services;

namespace CandidView.Controllers
{
    [Authorize]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        [HttpGet]
        public List<ProjectStatus> GetProjectInfo()
        {
            var winId = HttpContext.Current.User.Identity;
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