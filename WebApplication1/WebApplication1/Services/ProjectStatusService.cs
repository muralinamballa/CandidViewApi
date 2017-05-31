using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using CandidView.Models.Master;
using Newtonsoft.Json;
using System.Web;
using CandidView.Models.Output;
using System;

namespace CandidView.Services
{
    public class ProjectStatusService
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
                {
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            i++;
                            var line = reader.ReadLine();
                            if (i > 1)
                            {
                                string[] values = line.Split(',');
                                var programInfo = programData.Find(item => item.ProgramId.ToString() == values[1]);
                                var buInfo = businessData.Find(item => item.BuId == programInfo.BuId);
                                projectStatusList.Add(new ProjectStatus
                                {
                                    Slno = projectStatusList.Count + 1,
                                    BuId = buInfo.BuId,
                                    BuName = buInfo.BuName,
                                    ProgramName = programInfo.ProgramName,
                                    Owner = programInfo.Owner,
                                    TeamSize = programInfo.TeamSize,
                                    Scope = CalculateScope(values),
                                    Schedule = CalculateSchedule(values),
                                    //Quality = int.Parse(values[8])
                                });
                            }
                        }
                    }
                }
                return projectStatusList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalculateScope(string[] values)
        {
            List<Commitment> commitment = JsonConvert.DeserializeObject<List<Commitment>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/commitment.json")));
            var scope = commitment.Find(item => item.ProgramId.ToString() == values[1]);

            return (int.Parse(values[4]) / scope.PlannedCapacityinStoryPoints) * 100;

        }

        private decimal CalculateSchedule(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            int releaseSprintNumber = releaseSprint(values);
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var noOfSprints = releaseSprintNumber - currentSprint.SprintNumber;
            decimal schedule = Convert.ToDecimal((noOfSprints - 1) - (int.Parse(values[3]) / int.Parse(values[5])));
            return schedule;
        }
        private int releaseSprint(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            List<ReleaseCalendar> releaseData = JsonConvert.DeserializeObject<List<ReleaseCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/releasecalendar.json")));
            var releaseMonth = releaseData.Find(item => item.ReleaseNumber.ToString() == values[2]);
            var releaseSprint = sprintData.Find(item => (releaseMonth.CodeFreezeDate >= item.StartDate && releaseMonth.CodeFreezeDate <= item.EndDate));
            return releaseSprint.SprintNumber;
        }


        private decimal CalculateQuality(string[] values)
        {
            //decimal defectLeakage = Convert.ToDecimal((0.4 * int.Parse(values[6])) + (0.6 * int.Parse(values[7])));
            //decimal productionDefect = Convert.ToDecimal(0.5 * int.Parse(values[8] + 0.3 * int.Parse(values[9]) + 0.2 * int.Parse(values[10])));
            //decimal noOfFDNDefects = int.Parse(values[11]);
            //decimal noOfSecurityDefects = 0;
            return 0;

        }
    }
}

