// Code is generated by TTelerik Data Access Service Wizard
// using Global.asax.Routes.tt template

using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;

namespace LawAppWeb
{
    public partial class Global
    {
        public void ConfigureWebApi()
        {
			//useful when serializing graph of objects
            //GlobalConfiguration.Configuration.Formatters.Clear();

            //var jsonSerializerSettings = new JsonSerializerSettings
            //{
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //};
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter() { SerializerSettings = jsonSerializerSettings });
			//

            RouteTable.Routes.MapHttpRoute(name: "DefaultApi",
                                           routeTemplate: "api/{controller}/{id}",
                                           defaults: new { id = RouteParameter.Optional });

            RouteTable.Routes.MapHttpRoute(name: "IPN",
                                           routeTemplate: "api/IPN/{action}");

            ApplyCustomConfiguration();
        }

        partial void ApplyCustomConfiguration();
    }
}
