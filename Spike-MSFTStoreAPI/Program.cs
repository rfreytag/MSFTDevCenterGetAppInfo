using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MSFTDevCenterGetAppInfo
{
    //Copied from a MSFT Example found here: https://docs.microsoft.com/en-us/windows/uwp/monetize/csharp-code-examples-for-the-windows-store-submission-api
    class Program
    {
        /// <summary>
        /// Program entry
        /// </summary>
        /// <param name="args">A string array of arguments provided from the command-line.</param>
        static void Main( string[] args )
        {
            string TenantId = ""; // ... or just replace this text with the TenantId.

            if ( TenantId == "")
            {
                Console.WriteLine("Type in the authorizing Azure AD Tenant ID");
                TenantId = Console.ReadLine();
            }

            var config = new ClientConfiguration()
            {
                ApplicationId = "...Not needed for testing yet...",
                InAppProductId = "...Not needed for testing yet...",
                FlightId = "...Not needed for testing yet...",

                // Azure AD registered program client ID granted access to the Dev Center - found in: 'Partner Center'=>(gear icon)=>'Developer Settings'=>'Users'=>'Add Azure AD applictions' button
                ClientId = "", // ...or just replace this text with the registered application's Dev Center Client ID.  
                // Azure AD registered program client secret to gain access to the Dev Center.  
                ClientSecret = "", // ...or just replace this text with the registered application's Dev Center Client Secret.  

                ServiceUrl = "https://manage.devcenter.microsoft.com",
                TokenEndpoint = "https://login.microsoftonline.com/" + TenantId + "/oauth2/token",
                Scope = "https://manage.devcenter.microsoft.com",
            };


            if ( config.ClientId == "" || config.ClientSecret == "")
            {
                Console.WriteLine("What is the Dev Center 'client ID' for this application?");
                config.ClientId = Console.ReadLine();

                Console.WriteLine("What is the Dev Center 'client secret' for this application?");
                config.ClientSecret = Console.ReadLine();
            }

            // below from original MSFT Example (see reference at top)
            //new FlightSubmissionUpdateSample(config).RunFlightSubmissionUpdateSample();
            //new InAppProductSubmissionUpdateSample(config).RunInAppProductSubmissionUpdateSample();
            //new InAppProductSubmissionCreateSample(config).RunInAppProductSubmissionCreateSample();
            //new AppSubmissionUpdateSample(config).RunAppSubmissionUpdateSample();

            // new test calls following model provided by MSFT example.
            new GetStoreAppListing(config).RunGetStoreAppListing();
            new GetStoreAppListing(config).RunGetStoreAppListing(2, 3);
        }
    }
}
