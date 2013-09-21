namespace TrafficAPI.Api
{
    using System;
    using System.Net.Http;

    using ServiceStack.ServiceInterface;

    using TrafficAPI.Api.Repositories;
    using TrafficAPI.Classes;

    public class TicketService : Service
    {
        public object Get(TicketInfo request)
        {
            var apiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };

            var priceRepository = new PriceRepository(10, 18);

            var ticketRepository = new TicketRepository(apiClient, "0767201010", priceRepository);
            return ticketRepository.GetTicketInfo(request.From, request.To, request.PriceCat);
        }
    }
}