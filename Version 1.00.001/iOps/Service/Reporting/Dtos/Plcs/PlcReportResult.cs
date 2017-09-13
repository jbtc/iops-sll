using System.Collections.Generic;
using iOps.Service.Reporting.Dtos.Gates;

namespace iOps.Service.Reporting.Dtos.Plcs
{
    public class PlcReportResult : AbstractResportResult<IEnumerable<PlcReportRow>>
    {
        public PlcReportResult()
            : this(new List<PlcReportRow>())
        {

        }

        public PlcReportResult(IEnumerable<PlcReportRow> result)
            : base(result)
        {
        }
    }
}