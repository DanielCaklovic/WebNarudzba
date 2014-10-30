using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DAL;
using System.Data.Entity;
using WebNarudzbe.Mappings;

namespace WebNarudzbe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ///<c>
            ///DELETE db
            ///var dbContext = new WebNarudzbaContext().Database;
            ///dbContext.Delete();
            ///</c>
             
            ///<remarks>
            ///Kreiraj bazu ako ne postoji - po shemi iz WebNarudzbaContext
            ///</remarks>
            Database.SetInitializer(new CreateDatabaseIfNotExists<WebNarudzbaContext>());
            AutoMapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
