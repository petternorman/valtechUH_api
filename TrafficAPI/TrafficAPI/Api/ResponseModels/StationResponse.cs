using System.Collections.Generic;
using ServiceStack.ServiceInterface.ServiceModel;

namespace TrafficAPI.Api.ResponseModels
{
    public class StationResponse
    {
        public List<Station> Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}