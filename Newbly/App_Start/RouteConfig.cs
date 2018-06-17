using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Newbly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
             * Example of using Attribute Routing
             * First set routes.MapMvcAttributeRoutes()
             * then in the controller. [Route("movies/released/{year}/{month:regex()}")]
             * Notice contraits are now set in the controller
             **/
            routes.MapMvcAttributeRoutes();

            /*
             * Exmaple of using Convention Base Routing
             * Updating an action or route requires you to update here and in controller
             * 
             * */
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month})",
            //    new { controller ="Movies", action = "ByReleaseDate"},
            //    new { year = @"\d{4}", month = @"\d{2}"} // or @"2015|2016" to set specific constraits
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
