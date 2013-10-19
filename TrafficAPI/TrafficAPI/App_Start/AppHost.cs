using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using TrafficAPI.Api;
using TrafficAPI.Api.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TrafficAPI.App_Start.AppHost), "Start")]

//IMPORTANT: Add the line below to MvcApplication.RegisterRoutes(RouteCollection) in the Global.asax:
//routes.IgnoreRoute("api/{*pathInfo}"); 

namespace TrafficAPI.App_Start
{
    using System;
    using System.Net.Http;

    public class CustomUserSession : AuthUserSession
	{
		public string CustomProperty { get; set; }
	}

	public class AppHost
		: AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("Team Valtech @Uppsala Hackathon", typeof(StationService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            var apiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };
            var stationRepository = new StationRepository(apiClient);
            container.Register(stationRepository);


            var priceRepository = new PriceRepository(ApiSettings.PriceSLRed, ApiSettings.PriceSLRegular);
            var ticketRepository = new TicketRepository(apiClient, ApiSettings.PhoneNumberSL, priceRepository);
            container.Register(ticketRepository);

			ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}