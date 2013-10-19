using System.Configuration;

namespace TrafficAPI.Api
{
    /// <summary>
    /// Set/Change values in AppSettings.config
    /// </summary>
    public class ApiSettings
    {
        public static string PhoneNumberSL
        {
            get { return ConfigurationManager.AppSettings["PhoneNumberSL"]; }
        }

        public static int PriceSLRed 
        { 
            get { return int.Parse(ConfigurationManager.AppSettings["PriceSLRed"]); }
        }

        public static int PriceSLRegular
        {
            get { return int.Parse(ConfigurationManager.AppSettings["PriceSLRegular"]); }
        }

        public static string ApiKeySLRealtid
        {
            get { return ConfigurationManager.AppSettings["ApiKeySLRealtid"]; }
        }

        public static string ApiKeySLReseplanerare
        {
            get { return ConfigurationManager.AppSettings["ApiKeySLReseplanerare"]; }
        }
    }
}