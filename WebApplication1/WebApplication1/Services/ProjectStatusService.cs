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
                                var programInfo = programData.Find(item => item.ProgramId.ToString() == values[0]);
                                var buInfo = businessData.Find(item => item.BuId == programInfo.BuId);
                                projectStatusList.Add(new ProjectStatus
                                {
                                    Slno = i--,
                                    BusinessUnit = buInfo.BuName,
                                    ProgramName = programInfo.ProgramName,
                                    Owner = programInfo.Owner,
                                    TeamSize = programInfo.TeamSize,
                                    Scope = CalculateScope(values),
                                    Schedule = CalculateSchedule(values),
                                    //Quality = int.Parse(values[7]),
                                    Sla = new MetricSLA
                                    {
                                        ScheduleAdherence = int.Parse(values[11]),
                                        DefectDensityNonProd = Convert.ToDecimal(values[12]),
                                        Sev1DefectLeakageNonProd = int.Parse(values[13]),
                                        DefectDensityProd = Convert.ToDecimal(values[14]),
                                        Sev1DefectLeakageProd = int.Parse(values[15]),
                                        Sev2DefectLeakageProd = int.Parse(values[16]),
                                        DefectRejectionRate = int.Parse(values[17])
                                    }
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
            var scope = commitment.Find(item => item.ProgramId.ToString() == values[0]);

            return (int.Parse(values[3]) / scope.PlannedCapacityinStoryPoints) * 100;

        }

        private decimal CalculateSchedule(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            var releaseSprint = sprintData.Find(item => item.ReleaseNumber == values[1]);
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var noOfSprints = releaseSprint.SprintNumber - currentSprint.SprintNumber;
            decimal schedule = Convert.ToDecimal((noOfSprints - 1) - (int.Parse(values[2]) / int.Parse(values[4])));
            return schedule;
        }

        private decimal CalculateQuality(string[] values)
        {
            //decimal defectLeakage = Convert.ToDecimal((0.4 * int.Parse(values[5])) + (0.6 * int.Parse(values[6])));
            //decimal productionDefect = Convert.ToDecimal(0.5 * int.Parse(values[7] + 0.3 * int.Parse(values[8]) + 0.2 * int.Parse(values[9])));
            //decimal noOfFDNDefects = int.Parse(values[10]);
            //decimal noOfSecurityDefects = 0;
            return 0;

        }
    }
}

