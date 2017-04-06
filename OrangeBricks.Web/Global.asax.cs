using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OrangeBricks.Web.Models;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.Web.Mvc;
using OrangeBricks.Web.Infrastructure;
using OrangeBricks.Web.Controllers.GenericBuilder;

namespace OrangeBricks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            // DB Context
            container.Register<IOrangeBricksContext, ApplicationDbContext>();
            
            // Auth
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.Register<IAuthenticationManager>(() => HttpContext.Current.GetOwinContext().Authentication);
            
            // MVC
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            //Register all viewmodel builders
            var typeviewmodel = typeof(IViewModel);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeviewmodel.IsAssignableFrom(p));

            foreach (var reg in types)
            {
                container.Register(reg);
            }
            // register Iviewmodel factoru
            container.Register<IViewModelFactory, GenericViewModelFactory>();


            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
