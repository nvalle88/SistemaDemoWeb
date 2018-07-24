using CityParkWeb.Utiles;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CityParkWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected  void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //IdentityConfig.RegisterIdentities();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Constantes.ServerReportUrl = System.Configuration.ConfigurationManager.AppSettings["ServerReportUrl"];
            Constantes.ReporteCuelloPath = System.Configuration.ConfigurationManager.AppSettings["ReporteCuelloPath"];
            Constantes.UsuarioReport = System.Configuration.ConfigurationManager.AppSettings["UsuarioReport"];
            Constantes.Contrasena = System.Configuration.ConfigurationManager.AppSettings["Contrasena"];

        }

       
    }
}
