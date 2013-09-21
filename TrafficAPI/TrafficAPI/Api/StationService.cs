namespace TrafficAPI.Api
{
    using System;
    using System.Net.Http;

    using ServiceStack.ServiceInterface;

    using TrafficAPI.Api.Repositories;
    using TrafficAPI.Api.ResponseModels;

    public class StationService : Service
    {
        public object Get(Station request)
        {
            var apiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };

            var stationRepository = new StationRepository(apiClient);
            return new StationResponse { Result = stationRepository.GetSites(request.Name) };
        }
    }
}