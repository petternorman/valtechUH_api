using ServiceStack.ServiceHost;

namespace TrafficAPI.Api
{
    [Route("/station")]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}