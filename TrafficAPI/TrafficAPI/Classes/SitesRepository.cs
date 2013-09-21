// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SitesRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The sites repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TrafficAPI.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Newtonsoft.Json;

    using TrafficAPI.Models;
    using System.Linq;
    /// <summary>
    /// The sites repository.
    /// </summary>
    public class SitesRepository
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the api client.
        /// </summary>
        public HttpClient ApiClient { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get sites.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="Hafas"/>.
        /// </returns>
        public List<SiteModel> GetSites(string locationText)
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

            var siteList = new List<SiteModel>();
            foreach (var item in siteInfo.Hafas.Sites.Site)
            {
                var site = new SiteModel { Name = item.Name, Number = item.Number };
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