namespace TrafficAPI.Api.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class DistanceRepository
    {
        public HttpClient ApiClient { get; set; }

        public int Direction(string a, int b)
        {
            this.ApiClient = new HttpClient { BaseAddress = new Uri("http://maps.googleapis.com") };

            string path = string.Format(
                "/maps/api/directions/json?origin={0},IL&destination={1}", a, b);
            HttpResponseMessage response = this.ApiClient.GetAsync(path).Result;

            if (!response.IsSuccessStatusCode)
            {
            }

            string result = response.Content.ReadAsStringAsync().Result;
            //var siteInfo = JsonConvert.DeserializeObject<RootObjectJsonRespone>(result);

            return 0;

        }
    }
}