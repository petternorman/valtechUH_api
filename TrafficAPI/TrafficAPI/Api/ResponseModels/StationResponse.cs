using ServiceStack.ServiceInterface.ServiceModel;

namespace TrafficAPI.Api.ResponseModels
{
    public class StationResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}