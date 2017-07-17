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

                                List<SprintCalendar> sprintData = JsonConvert.DeserializeObject<List<SprintCalendar>>
                                    (File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/" + programInfo.SprintCalendar + ".json")));
                                projectStatusList.Add(new ProjectStatus
                                {
                                    Slno = projectStatusList.Count + 1,
                                    BuId = buInfo.BuId,
                                    BuName = buInfo.BuName,
                                    ProgramName = programInfo.ProgramName,
                                    InternalOwner = programInfo.InternalOwner,
                                    ExternalOwner = programInfo.ExternalOwner,
                                    TeamSize = programInfo.TeamSize,
                                    Scope = CalculateScope(values,sprintData),
                                    Schedule = CalculateSchedule(values, sprintData),
                                    Quality = CalculateQuality(values,sprintData),
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
        private MetricScope CalculateScope(string[] values, List<SprintCalendar> sprintData)
        {
            MetricScope scopeData = new MetricScope
            {
                BacklogPresent = values[39],
                Stories = values[40],
                DevelopmentDependencies = values[41],
                TgoDesign = values[42],
                TgoConstruction = values[43],
                NoOfDaysFromStartDate = 35,
                NoOfDaysFromCodeFreezeDate = 35
        };
            return scopeData;
        }
        private decimal CalculateSchedule(string[] values, List<SprintCalendar> sprintData)
        {
            int releaseSprintNumber = ReleaseSprint(values, sprintData);
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var noOfSprints = releaseSprintNumber - currentSprint.SprintNumber;
            decimal schedule = Convert.ToDecimal((noOfSprints - 1) - (int.Parse(values[3]) / int.Parse(values[5])));
            return schedule;
        }
        private int ReleaseSprint(string[] values, List<SprintCalendar> sprintData)
        {
            List<ReleaseCalendar> releaseData = JsonConvert.DeserializeObject<List<ReleaseCalendar>>(File.ReadAllText(HttpContext.Current.Server.MapPath("/data/masters/releasecalendar.json")));
            var releaseMonth = releaseData.Find(item => item.ReleaseNumber.ToString() == values[2]);
            var releaseSprint = sprintData.Find(item => (releaseMonth.CodeFreezeDate >= item.StartDate && releaseMonth.CodeFreezeDate <= item.EndDate));
            return releaseSprint.SprintNumber;
        }
        private MetricQuality CalculateQuality(string[] values,List<SprintCalendar> sprintData)
        {
            var currentSprint = sprintData.Find(item => (DateTime.Today >= item.StartDate && DateTime.Today <= item.EndDate));
            var daysLeftIndex = ((currentSprint.EndDate - DateTime.Today).TotalDays / 10);           
            decimal pendingTestCoverage = (1 - (Convert.ToDecimal(values[21]) / Convert.ToDecimal(values[18])));
            MetricQuality Quality = new MetricQuality
            {
                RequirementTestCoverage = Math.Round((Convert.ToDecimal(daysLeftIndex) - pendingTestCoverage),2),
                AverageLeadTime = Convert.ToDecimal(values[32]),
                DefectLeakageQA = (0.4M*Convert.ToDecimal(values[6])) + (0.6M* Convert.ToDecimal(values[7])),
                ProductionDefect = (0.5M * Convert.ToDecimal(values[8]))+(0.3M * Convert.ToDecimal(values[9]))+(0.2M * Convert.ToDecimal(values[10]))
            };
            return Quality;
        }
        private MetricQualityEngineeringPractice CalculateQualityEngineeringPractice(string[] values)
        {
            MetricQualityEngineeringPractice QualityEngineeringPractice = new MetricQualityEngineeringPractice
            {
                TDDCoverage = (values[38] != "N/A") ? Convert.ToDecimal(values[38]) : 0,
                BDDCoverage = Math.Round(((Convert.ToDecimal(values[19])) / (Convert.ToDecimal(values[19]) + Convert.ToDecimal(values[20]))) * 100, 2),
                MVPAdoption = (values[37] != "N/A") ? Convert.ToDecimal(values[37]) : 0,
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
                MaintainabilityIndex = (values[30] != "N/A") ? Convert.ToDecimal(values[30]) : 0,
                CyclomaticComplexity = (values[31] != "N/A") ? Convert.ToDecimal(values[31]) : 0
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

