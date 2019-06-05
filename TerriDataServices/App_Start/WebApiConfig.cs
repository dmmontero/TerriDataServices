namespace TerriDataServices
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    /// <summary>
    /// Defines the <see cref="WebApiConfig" />
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="config">The config<see cref="HttpConfiguration"/></param>
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            //Habilitar CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //Tipo de ruteo
            config.Routes.MapHttpRoute(
                name: "Home",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = RouteParameter.Optional, id = RouteParameter.Optional }
            );


        }
    }
}
