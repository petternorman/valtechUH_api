﻿namespace TrafficAPI.Api.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class StationRepository
    {
        #region Public Properties

        public StationRepository(HttpClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        protected HttpClient ApiClient { get; set; }
        #endregion

        #region Public Methods and Operators

        public List<Station> GetSites(string locationText)
        {
            var path = string.Format(
                "sl/realtid/GetSite.json?stationSearch={0}&key={1}", locationText, ApiSettings.ApiKeySLRealtid);
            var response = this.ApiClient.GetAsync(path).Result;                                

            if (!response.IsSuccessStatusCode)
            {
                return new List<Station>();
            }

            var result = response.Content.ReadAsStringAsync().Result;

            dynamic test = JsonConvert.DeserializeObject(result);
            var siteList = new List<Station>();

            var siteTest = test.Hafas.Sites.Site;
            if (siteTest.GetType().ToString() == "Newtonsoft.Json.Linq.JObject")
            {
                var site = new Station { Name = siteTest.Name, Id = siteTest.Number };
                siteList.Add(site);
            }
            else
            {
                foreach (var item in siteTest)
                {
                    var site = new Station { Name = item.Name, Id = item.Number };
                    siteList.Add(site);
                }
            }
        
            return siteList;
        }

        #endregion
    }
}