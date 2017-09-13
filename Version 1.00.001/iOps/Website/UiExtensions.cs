using Elmah;
using System;
using System.Web;

namespace iOps.Website
{
    public static class UiExtensions
    {
        public static void Raize(this Exception ex)
        {
            if (HttpContext.Current == null)
                ErrorLog.GetDefault(null).Log(new Error(ex));
            else
                ErrorSignal.FromCurrentContext().Raise(ex);
        }
    }
}