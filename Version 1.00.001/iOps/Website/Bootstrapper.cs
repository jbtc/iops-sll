using iOps.Infra;
using System.Web;
using System.Web.Mvc;

namespace iOps.Website
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
            WindsorConfigurator.Configure();
            awesomeConfigurator.Configure();

            Globals.PicturesPath = HttpContext.Current.Server.MapPath("~/pictures");
        }
    }
}