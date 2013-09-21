namespace TrafficAPI.Classes
{
    using System;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class SitesRepository
    {
        public HttpClient ApiClient { get; set; }


        public SiteJsonResponse GetSites(string location)
        {
            this.ApiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };

            var path = string.Format("sl/realtid/GetSite.json?stationSearch={0}&key=72c26d46c3efc6d5158d1dfc89b5f6fd", location);
            var response = this.ApiClient.GetAsync(path).Result;

            if (!response.IsSuccessStatusCode)
            {
            }

            var result = response.Content.ReadAsStringAsync().Result;
            var siteInfo = JsonConvert.DeserializeObject<SiteJsonResponse>(result);

            return siteInfo; 
        }

        public class SiteJsonResponse
        {
            public int NUmber { get; set; }

            public int Name { get; set; }
        }
    }
}