using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using TapFinder.Web.Filters;

namespace TapFinder.Web
{
    public static class WebApiConfig
    {
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public static void Configure(IAppBuilder appBuilder, ILifetimeScope container)
        {
            var config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var requireHttpsAttribute = new RequireHttpsAttribute();
#if !DEBUG
            config.Filters.Add(requireHttpsAttribute);
#endif

            // return JSON instead of XML by default
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes
                .FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // use camelCase in JSON
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // standardize datetime format
            jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"
            };
            jsonFormatter.SerializerSettings.Converters.Add(dateConverter);

            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);

            appBuilder.UseFileServer(new FileServerOptions
            {
                EnableDefaultFiles = false,
                RequestPath = new PathString("/images")
            });
        }
    }
}
