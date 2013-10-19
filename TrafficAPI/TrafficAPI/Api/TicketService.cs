namespace TrafficAPI.Api
{
    using ServiceStack.ServiceInterface;
    using Repositories;

    public class TicketService : Service
    {
        public TicketRepository TicketRepository { get; set; }
        public object Get(TicketInfo request)
        {
            return TicketRepository.GetTicketInfo(request.From, request.To, request.PriceCat);
        }
    }
}