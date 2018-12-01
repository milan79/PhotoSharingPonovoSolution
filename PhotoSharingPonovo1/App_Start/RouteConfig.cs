using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharingPonovo1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PhotoRoute",
                url: "zoran/{id}",
                defaults: new { controller = "Photo", action = "Details" },
                //constraints: new { id = "[0 - 9] +" }  SA OVAKVIM REDOM NE RADI JER SVE STO JE POD ZNAKOVIMA NAVODE NE SME DA IMA RAZMAKE     !!!!!!!!!!!!!!!!!
                constraints: new { id = "[0-9]+" }
            );

            routes.MapRoute(
                name: "rade",
                url: "rade/{ime}",
                defaults: new { controller = "PrikazListe", action = "Prikaz"}
            );

            routes.MapRoute(
                name: "PhotoTitleRoute",
                url: "photo/title/{name}",
                defaults: new { controller = "Photo", action = "DisplayByName"}  //ovde isto nije htelo da radi zato sto je pisalo Dislay umesto Display
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
