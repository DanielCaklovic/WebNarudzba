using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DAL;
using System.Data.Entity;

namespace WebNarudzbe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
             //var dbContext = new WebNarudzbaContext().Database;
            //dbContext.Delete();

            //Kreiraj bazu ako ne postoji - po shemi iz WebNarudzbaContext
            Database.SetInitializer(new CreateDatabaseIfNotExists<WebNarudzbaContext>());
            //Database.SetInitializer<WebNarudzbaContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
