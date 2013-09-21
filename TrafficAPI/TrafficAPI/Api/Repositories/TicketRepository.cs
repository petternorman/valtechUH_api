using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace TrafficAPI.Api.Repositories
{
    public class TicketRepository
	{
		public HttpClient ApiClient { get; set; }



		public TicketInfo GetTicketInfo(int startLocation, int endLocation)
		{
			this.ApiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };
			var path = string.Format("sl/reseplanerare.json?S={0}&Z={1}Lang=sv&key=54d1713582880d4187bab3fe743ca271", startLocation, endLocation);
			var response = this.ApiClient.GetAsync(path).Result;

			if (!response.IsSuccessStatusCode)
			{
			}

			var result = response.Content.ReadAsStringAsync().Result;
			var rootObject = JsonConvert.DeserializeObject<RootObject>(result);

			var ticketInfo = new TicketInfo
				                 {
					                 MsgNumber = "0767201010",
					                 MsgText = rootObject.HafasResponse.Trip.FirstOrDefault().Summary.PriceInfo.TariffZones
				                 };

			return ticketInfo;
		}

		public class RootObject
		{
			public HafasResponse HafasResponse { get; set; }
		}

		public class HafasResponse
		{
			public int Trips { get; set; }
			public List<Trip> Trip { get; set; }
		}

		public class Trip
		{
			public Summary Summary { get; set; }
		}

		public class Summary
		{
			public string DepartureDate { get; set; }
			public string ArrivalDate { get; set; }
			public int SubTrips { get; set; }
			public int Changes { get; set; }
			public string Duration { get; set; }
			public PriceInfo PriceInfo { get; set; }
			public string CO2 { get; set; }
			public int MT6MessagesExist { get; set; }
			public int RTUMessagesExist { get; set; }
			public int RemarksExist { get; set; }
		}

		public class PriceInfo
		{
			public TariffMessages TariffMessages { get; set; }
			public string TariffZones { get; set; }
			public string TariffRemark { get; set; }
		}

		public class TariffMessages
		{
			public string TariffMessage { get; set; }
		}

		public class TicketResponse
		{
			public List<TicketInfo> Info { get; set; }
		}
	}
}