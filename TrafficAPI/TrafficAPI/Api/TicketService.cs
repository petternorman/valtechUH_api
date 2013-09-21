using ServiceStack.ServiceInterface;
using TrafficAPI.Api.Repositories;
using TrafficAPI.Api.ResponseModels;

namespace TrafficAPI.Api
{
    public class TicketService : Service
    {
        public TicketRepository TicketRepository { get; set; }
        public object Get(TicketInfo request)
        {
            return TicketRepository.GetTicketInfo(request.From, request.To, request.PriceCat);
        }
    }
}