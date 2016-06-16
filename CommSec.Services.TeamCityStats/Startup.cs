using System.Configuration;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using CommSec.Services.TeamCityStats;
using CommSec.Services.TeamCityStats.Controllers;
using CommSec.Services.TeamCityStats.Core;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using Configuration = CommSec.Services.TeamCityStats.Core.Configuration;

[assembly: OwinStartup(typeof(Startup))]

namespace CommSec.Services.TeamCityStats
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(GetConfig());
            builder.RegisterType<StatisticRepository>().SingleInstance();
            builder.RegisterType<StatisticController>();
            var container = builder.Build();

            var config = new HttpConfiguration {DependencyResolver = new AutofacWebApiDependencyResolver(container)};
            config.EnableSwagger(c => c.SingleApiVersion("v1", "TeamCity Statistic Service")).EnableSwaggerUi();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{action}",
                defaults: new { action = "Index", id = UrlParameter.Optional });


            app.UseWebApi(config);
        }

        private Configuration GetConfig()
        {
            var config = WebConfigurationManager.OpenWebConfiguration("/");
            var csSection = config.ConnectionStrings;

            return new Configuration
            {
                Database = csSection.ConnectionStrings["TeamCityStats"].ConnectionString
            };
        }
    }
}
