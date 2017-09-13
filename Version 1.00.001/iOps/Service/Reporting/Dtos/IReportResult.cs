namespace iOps.Service.Reporting.Dtos
{

    /// <summary>
    /// Basic Report Result
    /// </summary>
    public interface IReportResult
    {

    }

    /// <summary>
    /// The result of the Report Query
    /// </summary>
    public interface IReportResult<T> : IReportResult where T : class
    {
        /// <summary>
        /// The result of the report
        /// </summary>
        T Result { get; set; }
    }
}