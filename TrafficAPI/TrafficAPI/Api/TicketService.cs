using ServiceStack.ServiceInterface;
using TrafficAPI.Api.Repositories;

namespace TrafficAPI.Api
{
    public class TicketService : Service
    {
        public object Get(TicketInfo request)
        {
            var ticketRepository = new TicketRepository();
            return ticketRepository.GetTicketInfo(request.From, request.To, request.PriceCat);
        }
    }
}