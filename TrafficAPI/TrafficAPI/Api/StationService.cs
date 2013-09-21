using ServiceStack.ServiceInterface;
using TrafficAPI.Api.Repositories;
using TrafficAPI.Api.ResponseModels;

namespace TrafficAPI.Api
{
    public class StationService : Service
    {
        public object Get(Station request)
        {
            var stationRepository = new StationRepository();
            return new StationResponse {Result = stationRepository.GetSites(request.Name)};
        }
    }
}