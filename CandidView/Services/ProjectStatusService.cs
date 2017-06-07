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

                using (var fs = File.OpenRead(@"C:\Data\ProjectStatus2.csv"))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            i++;
                            var line = reader.ReadLine();
                            if (i > 2)
                            {
                                string[] values = line.Split(',');
                                decimal[] quality = CalculateQuality(values);
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
                                    Quality = new MetricQuality
                                    {
                                        RequirementTestCoverage = quality[0],
                                        AverageLeadTime = quality[1],
                                        DefectLeakageQA = quality[2],
                                        ProductionDefect = quality[3]
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
            var scope = commitment.Find(item => item.ProgramId.ToString() == values[1]);

            return Math.Round((Convert.ToDecimal(values[4]) / scope.PlannedCapacityinStoryPoints * 100), 2);

        }

        private decimal CalculateSchedule(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            int releaseSprintNumber = ReleaseSprint(values);
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var noOfSprints = releaseSprintNumber - currentSprint.SprintNumber;
            decimal schedule = Convert.ToDecimal((noOfSprints - 1) - (int.Parse(values[3]) / int.Parse(values[5])));
            return schedule;
        }

        private int ReleaseSprint(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            List<ReleaseCalendar> releaseData = JsonConvert.DeserializeObject<List<ReleaseCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/releasecalendar.json")));
            var releaseMonth = releaseData.Find(item => item.ReleaseNumber.ToString() == values[2]);
            var releaseSprint = sprintData.Find(item => (releaseMonth.CodeFreezeDate >= item.StartDate && releaseMonth.CodeFreezeDate <= item.EndDate));
            return releaseSprint.SprintNumber;
        }


        private decimal[] CalculateQuality(string[] values)
        {
            decimal[] qualityCalculation = new decimal[4];
            decimal requirementTestCoverage = Math.Round((Convert.ToDecimal(values[12] + values[14]) / Convert.ToDecimal(values[11] + values[13])),2);
            decimal averageLeadTime = Convert.ToDecimal(values[25]);
            decimal defectLeakageQA = Convert.ToDecimal(0.4 + Convert.ToInt32(values[6]) + 0.6 + Convert.ToInt32(values[7]));
            decimal productionDefect = Convert.ToDecimal(0.5 + Convert.ToInt32(values[8]) + 0.3 + Convert.ToInt32(values[9]) + 0.3 + Convert.ToInt32(values[10]));
            qualityCalculation[0] = requirementTestCoverage;
            qualityCalculation[1] = averageLeadTime;
            qualityCalculation[2] = defectLeakageQA;
            qualityCalculation[3] = productionDefect;
            return qualityCalculation;

        }
    }
}

