using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using iOps.Infra;
using iOps.Service.Reporting;

namespace iOps.Service
{
    public static class WindsorWireup
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IReportService), typeof(ReportService));
            WindsorRegistrar.Register(typeof(IReportService), typeof(ReportService));
        }
    }
}
