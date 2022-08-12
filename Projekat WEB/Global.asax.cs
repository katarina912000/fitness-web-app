using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Projekat_WEB.Models;
namespace Projekat_WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpContext.Current.Application["fitnesCentri"] = new List<FitnesCentar>();
            HttpContext.Current.Application["grupniTreninzi"] = new List<GrupniTrening>();
            HttpContext.Current.Application["korisnici"] = new List<Korisnik>();

        }
    }
}
