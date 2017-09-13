using iOps.Core.Security;
using iOps.Core.Service;
using iOps.Infra;
using iOps.Service;
using iOps.Service.Reporting;
using iOps.Website.Controllers;
using Omu.Encrypto;

namespace iOps.Website
{
    public class WindsorConfigurator
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IFormsAuthentication), typeof(FormAuthService));
            WindsorRegistrar.Register(typeof(IHasher), typeof(Hasher));
            WindsorRegistrar.Register(typeof(IUserService), typeof(UserService));
            WindsorRegistrar.Register(typeof(IReportService), typeof(ReportService));

            WindsorRegistrar.RegisterAllFromAssemblies("iOps.Data");
            WindsorRegistrar.RegisterAllFromAssemblies("iOps.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("iOps.Website");
        }
    }
}