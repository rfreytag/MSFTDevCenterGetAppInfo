using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MSFTDevCenterGetAppInfo
{
    /// <summary>
    /// This class is packages the appication listing functionality of the API service
    /// </summary>
    public class GetStoreAppListing
    {
        private ClientConfiguration ClientConfig;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c">An instance of ClientConfiguration that contains all parameters populated</param>
        public GetStoreAppListing( ClientConfiguration c )
        {
            this.ClientConfig = c;
        }

        /// <summary>
        /// Get a full listing of all applications in the permitting Dev Center.
        /// </summary>
        /// <return>void</return>
        /// <remarks>
        /// Relevant documentation: https://docs.microsoft.com/en-us/windows/uwp/monetize/get-all-apps
        /// </remarks>
        public void RunGetStoreAppListing()
        {
            // **********************
            //       SETTINGS
            // **********************
            var appId = this.ClientConfig.ApplicationId;
            var clientId = this.ClientConfig.ClientId;
            var clientSecret = this.ClientConfig.ClientSecret;
            var serviceEndpoint = this.ClientConfig.ServiceUrl;
            var tokenEndpoint = this.ClientConfig.TokenEndpoint;
            var resourceOrScope = this.ClientConfig.Scope;

            // Get authorization token
            Console.WriteLine("Getting authorization token ");
            var accessToken = IngestionClient.GetClientCredentialAccessToken(
                tokenEndpoint,
                clientId,
                clientSecret,
                resourceOrScope).Result;

            Console.WriteLine("Getting store app listing ");
            var client = new IngestionClient(accessToken, serviceEndpoint);
            dynamic app = client.Invoke<dynamic>(
                HttpMethod.Get,
                relativeUrl: string.Format(
                    CultureInfo.InvariantCulture,
                    IngestionClient.GetStoreAppListingUrlTemplate,
                    IngestionClient.Version,
                    IngestionClient.Tenant),
                requestContent: null).Result;
            Console.WriteLine(app.ToString());
        }

        /// <summary>
        /// Get a partial listing of applications in the permitting Dev Center.
        /// </summary>
        /// <param name="pSkip">The number of Dev Center applications to skip before returning the next application's information.</param>
        /// <param name="pTop">The number of Dev Center applications to return after the number of application entries skipped.</param>
        /// <return>void</return>
        /// <remarks>
        /// Relevant documentation: https://docs.microsoft.com/en-us/windows/uwp/monetize/get-all-apps
        /// </remarks>
        public void RunGetStoreAppListing(int pSkip, int pTop = 10)
        {
            // **********************
            //       SETTINGS
            // **********************
            var appId = this.ClientConfig.ApplicationId;
            var clientId = this.ClientConfig.ClientId;
            var clientSecret = this.ClientConfig.ClientSecret;
            var serviceEndpoint = this.ClientConfig.ServiceUrl;
            var tokenEndpoint = this.ClientConfig.TokenEndpoint;
            var resourceOrScope = this.ClientConfig.Scope;

            // Get authorization token
            Console.WriteLine("Getting authorization token ");
            var accessToken = IngestionClient.GetClientCredentialAccessToken(
                tokenEndpoint,
                clientId,
                clientSecret,
                resourceOrScope).Result;

            Console.WriteLine("Getting store app listing ");
            var client = new IngestionClient(accessToken, serviceEndpoint);
            dynamic app = client.Invoke<dynamic>(
                HttpMethod.Get,
                relativeUrl: string.Format(
                    CultureInfo.InvariantCulture,
                    IngestionClient.GetStoreAppListingRangeUrlTemplate,
                    IngestionClient.Version,
                    IngestionClient.Tenant,
                    pSkip,
                    pTop),
                requestContent: null).Result;
            Console.WriteLine(app.ToString());
        }

    }
}

