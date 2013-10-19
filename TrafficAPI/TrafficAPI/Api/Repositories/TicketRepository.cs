namespace TrafficAPI.Api.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class TicketRepository
	{
        public TicketRepository(HttpClient apiClinet, string phonenumber, PriceRepository priceRepository)
        {
            this.ApiClient = apiClinet;
            this.PhoneNumber = phonenumber;
            this.PriceRepository = priceRepository;
        }

		protected HttpClient ApiClient { get; set; }

        protected String PhoneNumber { get; set; }

        protected PriceRepository PriceRepository { get; set; }

		public TicketInfo GetTicketInfo(int startLocation, int endLocation, string priceCat)
		{	
			var path = string.Format("sl/reseplanerare.json?S={0}&Z={1}Lang=sv&key={2}", startLocation, endLocation, ApiSettings.ApiKeySLReseplanerare);
			var response = this.ApiClient.GetAsync(path).Result;

			if (!response.IsSuccessStatusCode)
			{
			}

			var result = response.Content.ReadAsStringAsync().Result;
			var rootObject = JsonConvert.DeserializeObject<RootObject>(result);

		    if (rootObject.HafasResponse.Trip == null)
		    {
		        return new TicketInfo();
            }
		    var firstOrDefault = rootObject.HafasResponse.Trip.FirstOrDefault(x => x.Summary.PriceInfo != null);
		    if (firstOrDefault != null)
		    {
		        var priceInfo = firstOrDefault.Summary.PriceInfo;

		        var nrTariffRemark = Convert.ToInt32(priceInfo.TariffRemark.Substring(0, 1));

		        var ticketInfo = new TicketInfo
		            {
		                MsgNumber = this.PhoneNumber,
		                MsgText = priceCat + priceInfo.TariffZones,
		                Price = this.PriceRepository.GetPrice(nrTariffRemark, priceCat)
		            };

		        return ticketInfo;
		    }

		    return new TicketInfo();
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
			public int Changes { get; set; }
			public string Duration { get; set; }
			public PriceInfo PriceInfo { get; set; }
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