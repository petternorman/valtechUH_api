using ServiceStack.ServiceInterface;
using TrafficAPI.Api.ResponseModels;

namespace TrafficAPI.Api
{
    public class StationService : Service
    {
        public object Get(Station request)
        {
            return new StationResponse {Result = "station"};
        }
    }
}