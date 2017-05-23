using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using CandidView.models;
using System.IO;
using System.Web;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        public GridData Get()
        {	
            GridData data = JsonConvert.DeserializeObject<GridData>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/data.json")));
            return data;
        }
    }
}