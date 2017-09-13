using System.Web.Mvc;

namespace iOps.Website
{
    /// <summary>
    /// FilterConfig: Class for managing the Filter Collection
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters: Register items to the Filter Collection
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}