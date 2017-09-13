using iOps.Service.Reporting.Dtos;

namespace iOps.Service.Reporting
{
    /// <summary>
    /// Helper class for Reporting DTO's
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractResportResult<T> : IReportResult<T> where T : class
    {
        protected AbstractResportResult(T result)
        {
            Result = result;
        }

        /// <summary>
        /// Report Result
        /// </summary>
        public T Result { get; set; }
    }
}