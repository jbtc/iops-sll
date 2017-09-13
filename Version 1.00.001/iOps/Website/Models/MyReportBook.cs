using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Telerik.Reporting;

namespace iOps.Website.Models
{
    [Description("A collection of my reports")]
    public class MyReportBook : Telerik.Reporting.ReportBook
    {
        public MyReportBook()
        {
            string reportsDirectory = AppDomain.CurrentDomain.BaseDirectory +@"\Reports\";
            TrdxClassHelper helper = new TrdxClassHelper();
            Report one = helper.GetReportFromTrdxFile(reportsDirectory + "SLLalarmreport.trdx");
            this.Reports.Add(one);
            Report two = helper.GetReportFromTrdxFile(reportsDirectory + "SLLwarningreport.trdx");
            this.Reports.Add(two);
            Report three = helper.GetReportFromTrdxFile(reportsDirectory + "SLLAircraftDockedTime.trdx");
            this.Reports.Add(three);
            Report four = helper.GetReportFromTrdxFile(reportsDirectory + "SLLAircraftUnDockedTime.trdx");
            this.Reports.Add(four);
            Report five = helper.GetReportFromTrdxFile(reportsDirectory + "SLLAircraft Docked.trdx");
            this.Reports.Add(five);
            Report six = helper.GetReportFromTrdxFile(reportsDirectory + "SLLNetworkMonitoring.trdx");
            this.Reports.Add(six);
        }
    }
}