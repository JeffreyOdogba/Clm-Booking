using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Clm_Booking
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ClmWorld",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Clm_Booking", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Bookings",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdminManage", action = "Bookings", id = UrlParameter.Optional }
            );
        }
    }
}
