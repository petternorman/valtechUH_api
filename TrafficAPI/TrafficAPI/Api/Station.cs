using ServiceStack.ServiceHost;

namespace TrafficAPI.Api
{
    [Route("/station")]
    [Route(("/station/{Name}"))]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}