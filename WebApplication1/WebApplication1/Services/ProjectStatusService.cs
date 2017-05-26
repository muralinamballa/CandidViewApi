﻿using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using CandidView.Models.Master;
namespace CandidView.Services
{

    public class ProjectStatusService : ApiController
    {

        public List<Program> GetProjectInfo()
        {

            List<Program> programData = new List<Program>();

            using (var fs = File.OpenRead(@"C:\Data\csvprojectdata.csv"))
            using (var reader = new StreamReader(fs))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');
                    //programData.Add(new Program
                    //{
                    //    ProgramId = int.Parse(values[0]),
                    //    BusinessUnit = values[1],
                    //    ProgramName = values[2],
                    //    Owner = values[3],
                    //    TeamSize = int.Parse(values[4]),
                    //    Scope = int.Parse(values[5]),
                    //    Schedule = int.Parse(values[6]),
                    //    Quality = int.Parse(values[7]),
                    //    Sla = int.Parse(values[8]),
                    //    Remarks = values[9]
                    //});

                }

                return programData;

            }
        }
    }
}