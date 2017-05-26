using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using CandidView.Models.Master;
using Newtonsoft.Json;
using System.Web;
using CandidView.Models.ProjectStatus;
using System;

namespace CandidView.Services
{
    public class ProjectStatusService : ApiController
    {
        public List<ProjectStatus> GetProjectInfo()
        {
            try
            {
                List<ProjectStatus> projectStatusList = new List<ProjectStatus>();
                List<Program> programData = JsonConvert.DeserializeObject<List<Program>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/program.json")));
                List<BusinessUnit> businessData = JsonConvert.DeserializeObject<List<BusinessUnit>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/businessunit.json")));
                int i = 0;

                using (var fs = File.OpenRead(@"C:\Data\projectstatus.csv"))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        i++;
                        var line = reader.ReadLine();
                        if (i > 1)
                        {
                            var values = line.Split(',');

                            var programInfo = programData.Find(item => item.ProgramId.ToString() == values[0]);
                            var buInfo = businessData.Find(item => item.BuId == programInfo.BuId);

                            projectStatusList.Add(new ProjectStatus
                            {
                                Slno = i--,
                                BusinessUnit = buInfo.BuName,
                                ProgramName = programInfo.ProgramName,
                                Owner = programInfo.Owner,
                                TeamSize = programInfo.TeamSize
                                //Scope = int.Parse(values[5]),
                                //Schedule = int.Parse(values[6]),
                                //Quality = int.Parse(values[7]),
                                //Sla = int.Parse(values[8]),
                                // Remarks = values[9]
                            });
                        }
                    }
                    return projectStatusList;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        private decimal calculateSchedule(string[] values)
        {
            return 0;  

            // Schedule = remaing # of sprints for release - # of sprint for last pass(team specific)-(values[2]/values[4])
        }
    }
}
