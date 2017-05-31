﻿using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using CandidView.Models.ProjectStatus;
using System.IO;
using System.Web;
using System.Collections.Generic;
using CandidView.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProjectInfoController : ApiController
    {
        // GET api/projectinfo
        [HttpGet]
        public List<ProjectStatus> GetProjectInfo()
        {
            // List<ProjectStatus> data = JsonConvert.DeserializeObject<List<ProjectStatus>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/projectstatus.json")));
            ProjectStatusService statusService = new ProjectStatusService();
            return statusService.GetProjectInfo();
        }

        [HttpGet]
        public List<Metrics> GetMetricsMasterInfo()
        {
            List<Metrics> data = JsonConvert.DeserializeObject<List<Metrics>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/metrics.json")));
            return data;
        }
    }
}