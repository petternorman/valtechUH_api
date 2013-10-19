namespace TrafficAPI.Api
{
    using ServiceStack.ServiceInterface;
    using Repositories;
    using ResponseModels;

    public class StationService : Service
    {
        public StationRepository StationRepository { get; set; }
        public object Get(Station request)
        {
         
            return new StationResponse { Result = StationRepository.GetSites(request.Name) };
        }
    }
}