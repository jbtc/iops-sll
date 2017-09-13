using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using iOps.Infra;

namespace iOps.Website
{
    public class IocEnabledControllerFactory : IControllerActivator
    {
        protected IWindsorContainer Container { get; private set; }

        public IocEnabledControllerFactory(IWindsorContainer container)
        {
            Container = container;
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            try
            {
                return Container.Resolve(controllerType) as IController;
            }
            catch
            {
                return default(IController);
            }
        }
    }


    public class WindsorControllerFactory : DefaultControllerFactory
    {
        readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
            var controllerTypes =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(IController).IsAssignableFrom(t))
                    .Select(t => t);

            foreach (var t in controllerTypes)
                container.Register(Component.For(t).LifeStyle.Transient);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)container.Resolve(controllerType);
        }
    }

}