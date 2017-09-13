using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Telerik.Reporting;
using Telerik.Reporting.Processing;
using Telerik.Reporting.XmlSerialization;

namespace iOps.Website.Models
{
    public class TrdxClassHelper
    {
        public Telerik.Reporting.Report GetReportFromTrdxFile(string path)
        {
            Telerik.Reporting.Report report = null;
            XmlReaderSettings settings = new XmlReaderSettings(); settings.IgnoreWhitespace = true;
            //read the .trdx file contents
            using (XmlReader xmlReader = XmlReader.Create(path, settings))
            {
                ReportXmlSerializer xmlSerializer = new ReportXmlSerializer();

                //deserialize the .trdx report XML contents
                report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
            }
            return report;
        }
    }
}
