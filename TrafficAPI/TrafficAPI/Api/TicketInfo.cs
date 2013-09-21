using ServiceStack.ServiceHost;

namespace TrafficAPI.Api
{
    [Route("/ticketinfo/{station.id}{station.id")]
	public class TicketInfo
	{
		public double Price { get; set; }
	    public string MsgText { get; set; }
	    public string MsgNumber { get; set; }
        public Station From { get; set; }
        public Station To { get; set; }
	}
}