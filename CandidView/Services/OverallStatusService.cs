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
    public class OverallStatusService
    {
        public string GetSlaInfo()
        {
            try
            {
                int i = 0;
                string slaStatus=null;
                using (var fs = File.OpenRead(@"C:\Data\projectstatus.csv"))
                {
                    //ToDo need to revisit this logic for SLA calculation
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            i++;
                            var line = reader.ReadLine();
                            if (i > 1)
                            {
                                string[] values = line.Split(',');
                                slaStatus = "Green"; // CalculateColor(values)
                            }
                        }
                    }
                }
                return slaStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

