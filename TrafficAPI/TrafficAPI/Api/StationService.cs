using ServiceStack.ServiceInterface;
using TrafficAPI.Api.Repositories;
using TrafficAPI.Api.ResponseModels;

namespace TrafficAPI.Api
{
    public class StationService : Service
    {
        public StationRepository StationRepository { get; set; }
        public object Get(Station request)
        {
            return new StationResponse {Result = StationRepository.GetSites(request.Name)};
        }
    }
}