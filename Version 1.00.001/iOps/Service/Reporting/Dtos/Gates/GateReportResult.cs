using System.Collections.Generic;

namespace iOps.Service.Reporting.Dtos.Gates
{
    public class GateReportResult : AbstractResportResult<IEnumerable<GateReportRow>>
    {
        public GateReportResult()
            : this(new List<GateReportRow>())
        {
        }

        public GateReportResult(IEnumerable<GateReportRow> result)
            : base(result)
        {
        }

    }
}
