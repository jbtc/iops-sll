using iOps.Service.Reporting.Dtos;

namespace iOps.Service.Reporting
{
    /// <summary>
    /// Handles the querying of reports
    /// </summary>
    public interface IReportService
    {
        IReportResult Generate(IReportQuery query);
    }
}