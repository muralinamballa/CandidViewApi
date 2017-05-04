using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        public Info[] Get()
        {
            var dic = new Dictionary<long, Info>();
            dic.Add(1, new Info { id = 1, name = "CARE - Number of defects 10" });
            dic.Add(2, new Info { id = 2, name = "Budget Variance - 17%" });
            return dic.Values.ToArray();
        }
    }
}