using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using iOps.Infra;
using WebApiContrib.IoC.CastleWindsor;

namespace iOps.Website
{
    //TODO: Wireup the windor stuff
    public class WindsorConfiguration
    {
        public static void Configure(HttpConfiguration configuration)
        {
            var container = IoC.Container;
            //configuration.Services.Replace(typeof(IHttpControllerActivator), new IocEnabledControllerFactory(container));
            
            var resolver = new WindsorResolver(container);
            //DependencyResolver.SetResolver(resolver);
            configuration.DependencyResolver = resolver;
        }
    }
}