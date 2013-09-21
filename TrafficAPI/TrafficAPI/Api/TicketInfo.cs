using ServiceStack.ServiceHost;

namespace TrafficAPI.Api
{
    [Route("/ticketinfo/{From}/{To}/{PriceCat}")]
	public class TicketInfo
	{
		public double Price { get; set; }
	    public string MsgText { get; set; }
	    public string MsgNumber { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string PriceCat { get; set; }
	}
}