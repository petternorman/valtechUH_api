using ServiceStack.ServiceInterface;
using TrafficAPI.Api.Repositories;

namespace TrafficAPI.Api
{
    public class StationService : Service
    {
        public object Get(Station request)
        {
            var stationRepository = new StationRepository();
            return stationRepository.GetSites(request.Name);
        }
    }
}