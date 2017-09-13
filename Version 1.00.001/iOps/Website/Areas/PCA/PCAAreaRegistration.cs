using System.Web.Mvc;

namespace iOps.Website.Areas.PCA
{
    public class PCAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PCA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PCA_default",
                "PCA/{controller}/{action}/{id}",
                new { action = "ShowPCA", id = UrlParameter.Optional }
            );
        }
    }
}