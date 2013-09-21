using ServiceStack.ServiceInterface.ServiceModel;

namespace TrafficAPI.Api.ResponseModels
{
    public class TicketInfoResponse
    {
        public TicketInfo Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}