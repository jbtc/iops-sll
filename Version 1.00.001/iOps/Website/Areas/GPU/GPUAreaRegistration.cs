using System.Web.Mvc;

namespace iOps.Website.Areas.GPU
{
    public class GPUAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GPU";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GPU_default",
                "GPU/{controller}/{action}/{id}",
                new { action = "ShowGPU", id = UrlParameter.Optional }
            );
        }
    }
}