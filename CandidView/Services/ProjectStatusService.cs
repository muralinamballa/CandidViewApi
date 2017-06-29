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

                using (var fs = File.OpenRead(@"C:\Data\ProjectStatus.csv"))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            i++;
                            var line = reader.ReadLine();
                            if (i > 4)
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
                                    Quality = CalculateQuality(values),
                                    QualityEngineeringPractice = CalculateQualityEngineeringPractice(values),
                                    Resource = CalculateResource(values)
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
        private MetricScope CalculateScope(string[] values)
        {
            MetricScope scopeData = new MetricScope
            {
                BacklogPresent = values[39],
                Stories = values[40],
                DevelopmentDependencies = values[41],
                TgoDesign = values[42],
                TgoConstruction = values[43],
                StartDate = values[44]
            };
            return scopeData;
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
        private MetricQuality CalculateQuality(string[] values)
        {
            List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/sprintcalendar.json")));
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var daysLeftIndex = Convert.ToInt32((currentSprint.EndDate - DateTime.Today).TotalDays / 10);
            decimal pendingTestCoverage = Math.Round((Convert.ToDecimal(values[19] + values[21]) / Convert.ToDecimal(values[18] + values[20])), 2);
            MetricQuality Quality = new MetricQuality
            {
                RequirementTestCoverage = daysLeftIndex - pendingTestCoverage,
                AverageLeadTime = Convert.ToDecimal(values[32]),
                DefectLeakageQA = Convert.ToDecimal(0.4 + Convert.ToInt32(values[6]) + 0.6 + Convert.ToInt32(values[7])),
                ProductionDefect = Convert.ToDecimal(0.5 + Convert.ToInt32(values[8]) + 0.3 + Convert.ToInt32(values[9]) + 0.3 + Convert.ToInt32(values[10]))
            };
            return Quality;
        }
        private MetricQualityEngineeringPractice CalculateQualityEngineeringPractice(string[] values)
        {
            MetricQualityEngineeringPractice QualityEngineeringPractice = new MetricQualityEngineeringPractice
            {
                TDDCoverage = Convert.ToDecimal(values[38]),
                BDDCoverage = Math.Round((Convert.ToDecimal(values[19]) / Convert.ToDecimal(values[18])) * 100, 2),
                MVPAdoption = Convert.ToDecimal(values[38]),
                CodeReviewDev = new CodeReviewDev
                {
                    Catastrophic = Convert.ToDecimal(values[22]),
                    MajorDefectsWithoutWorkaround = Convert.ToDecimal(values[23]),
                    MajorDefectsWithWorkaround = Convert.ToDecimal(values[24]),
                    MinorDefects = Convert.ToDecimal(values[25]),
                },
                CodeReviewQA = new CodeReviewQA
                {
                    Catastrophic = Convert.ToDecimal(values[26]),
                    MajorDefectsWithoutWorkaround = Convert.ToDecimal(values[27]),
                    MajorDefectsWithWorkaround = Convert.ToDecimal(values[28]),
                    MinorDefects = Convert.ToDecimal(values[29]),
                },
                MaintainabilityIndex = Convert.ToDecimal(values[30]),
                CyclomaticComplexity = Convert.ToDecimal(values[31])
            };
            return QualityEngineeringPractice;
        }
        private MetricResource CalculateResource(string[] values)
        {
            MetricResource Resource = new MetricResource
            {
                Attrition = Convert.ToDecimal(values[33]),
                AvailabilityofResource = values[34]
            };
            return Resource;
        }
    }
}

