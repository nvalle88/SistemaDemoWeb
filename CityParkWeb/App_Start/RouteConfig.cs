﻿#region Using

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace CityParkWeb
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "Agentes",
                action = "VerAgentesTiempoReal",
                id = UrlParameter.Optional
            }).RouteHandler = new DashRouteHandler();
        }
    }
}