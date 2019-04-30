using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace tecAirlinesServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Configuración y servicios de API web
            ////Evito las referencias circulares al trabajar con Entity FrameWork         
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ////Elimino que el sistema devuelva en XML, sólo trabajaremos con JSON
            //config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            var enableCorsAttribute = new EnableCorsAttribute("*","*","*");
            config.EnableCors(enableCorsAttribute);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
