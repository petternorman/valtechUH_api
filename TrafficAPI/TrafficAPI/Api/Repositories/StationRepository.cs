using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace TrafficAPI.Api.Repositories
{
    public class StationRepository
    {
        #region Public Properties

        public HttpClient ApiClient { get; set; }

        #endregion

        #region Public Methods and Operators


        public List<Station> GetSites(string locationText)
        {
            this.ApiClient = new HttpClient { BaseAddress = new Uri("https://api.trafiklab.se") };

            string path = string.Format(
                "sl/realtid/GetSite.json?stationSearch={0}&key=72c26d46c3efc6d5158d1dfc89b5f6fd", locationText);
            HttpResponseMessage response = this.ApiClient.GetAsync(path).Result;

            if (!response.IsSuccessStatusCode)
            {
            }

            string result = response.Content.ReadAsStringAsync().Result;
            var siteInfo = JsonConvert.DeserializeObject<RootObjectJsonRespone>(result);

            var siteList = new List<Station>();
            foreach (var item in siteInfo.Hafas.Sites.Site)
            {
                var site = new Station { Name = item.Name, Id = item.Number };
                siteList.Add(site);           
            }

            return siteList;
        }

        #endregion

        public class RootObjectJsonRespone
        {
            public HafasJsonRespone Hafas { get; set; }
        }

        public class HafasJsonRespone
        {
            public SitesJsonRespone Sites { get; set; }

        }

        public class SitesJsonRespone
        {
            public List<SiteJsonRespone> Site { get; set; }

        }

        public class SiteJsonRespone
        {
            public string Name { get; set; }

            public int Number { get; set; }
        }
    }
}