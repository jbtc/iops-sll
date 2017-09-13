using System;

namespace iOps.Service.Reporting.Dtos
{
    /// <summary>
    /// Used to determine the output of the report
    /// </summary>
    public enum ReportKind
    {
        Pdf,
        Json = 0, // Default to JSON to render on page
        Csv
    }


    /// <summary>
    /// The data used to build the report
    /// </summary>
    public interface IReportQuery
    {
        /// <summary>
        /// [Optional]
        /// The starting date/time of the period to generate report
        /// </summary>
        DateTime? StartTime { get; set; }

        /// <summary>
        /// [Required]
        /// The end date/time of the period to generate the report
        /// Defaults to current date/time
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// [Optional]
        /// The output type of the report
        /// Defaults to JSON
        /// </summary>
        ReportKind Type { get; set; }
    }
}