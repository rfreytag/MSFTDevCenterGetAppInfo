# MSFTDevCenterGetAppInfo - Experiments with the MSFT Store API.  

The API documentation starts here: https://docs.microsoft.com/en-us/windows/uwp/monetize/using-windows-store-services

## Problem ##

This repository exposes a bug in the ['get all' or 'get specific range' MSFT Dev Center Store API](https://docs.microsoft.com/en-us/windows/uwp/monetize/get-all-apps) as documented.  Neither the 'get all' or 'get specific range' will return more than the first 10 store apps.  

### Required values
* Azure AD Tenant (Directory ID)
* Client ID of the Azure AD registered program permitted access through the Dev Center
* Client Secret (write it down!) of the Azure AD registered program permitted access through the Dev Center

Grant Dev Center access to an Azure AD registered program by going to: 'Partner Center'=>(gear icon)=>'Developer Settings'=>'Users'=>'Add Azure AD applictions' button.

## Get Application Listing Details ##

NOTE: This example should be understood by reading Program.cs.  

### Relevant Documentation  ###

* [Access analytics data using Store servies - UWP app developer](https://docs.microsoft.com/en-us/windows/uwp/monetize/access-analytics-data-using-windows-store-services)
    * [Prerequisites : Access analytics data using Store servies - UWP app developer](https://docs.microsoft.com/en-us/windows/uwp/monetize/access-analytics-data-using-windows-store-services#prerequisites)
	* [Add users, groups, and Azure AD applications to your Dev Center account - UWP app developer](https://docs.microsoft.com/en-us/windows/uwp/publish/add-users-groups-and-azure-ad-applications#add-azure-ad-applications-to-your-dev-center-account)

* [Create and manage submissions](https://docs.microsoft.com/en-us/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)
	* [Get app data](https://docs.microsoft.com/en-us/windows/uwp/monetize/get-app-data)

## Process and Lessons Learned ##

### Prerequisites ###
1. Open * [Create and manage submissions](https://docs.microsoft.com/en-us/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)
2. Skip down to [Step 1: Complete prerequisites for using the Microsoft Store submission API](https://docs.microsoft.com/en-us/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services#step-1-complete-prerequisites-for-using-the-microsoft-store-submission-api)
3. In this section it first asks that you "first have an Azure AD".  If you have an Azure account, near as I can tell, you have a free Azure AD.
4. But whatyou haven't done, probably, is associate your AD with your Windows Dev Center (Partner Dashboard) account.  You need to dig down into the section [Connect your organization to your Dev Center account - Add or associate Azure Active Directory](https://partner.microsoft.com/en-us/dashboard/account/TenantSetup).  By the way, this is found through the ["partner dashboard"](https://partner.microsoft.com/en-us/dashboard/windows/overview).  Then one clicks the "gear" icon in the upper right.  Then one selects "Developer settings" from the drop-down menu.  This takes you to a page called ["Account settings"](https://partner.microsoft.com/en-us/dashboard/account/management).  In the left margin there is the menu option [Tenants](https://partner.microsoft.com/en-us/dashboard/account/TenantSetup).  On *this* page there is a button ["Associate Azure AD with your Dev Center account"](https://partner.microsoft.com/en-us/dashboard/Account/TenantAdd).

### Associate an Azure AD Registered App ###
* [Broadly, here are the instructions to associate an Azure AD registered app.](https://docs.microsoft.com/en-us/windows/uwp/publish/add-users-groups-and-azure-ad-applications#add-azure-ad-applications-to-your-dev-center-account)

1. I had already registered in my associated Azure AD Tenant the app 'StoreAppInfoAPI'.  
2. When I added this app with 'Manager' priviledges (required by above MSFT docs), I was able to access the following information:

3. Name: StoreAppInfoAPI info accessed by: https://partner.microsoft.com/en-us/dashboard/Account/App => (upper-right gear icon dropdown) => Developer settings => Settings:Users => (click StoreAppInfoAPI)
3. OR you 'Add Azure AD application' as a 'Manager'

* Instructions gotten from: https://docs.microsoft.com/en-us/windows/uwp/monetize/access-analytics-data-using-windows-store-services (Step 1: Complete prerequisites for using the Microsoft Store analytics API)

Which allowed me to see: 
* Tenant ID: <your Azure AD Tenant (directory) ID here.>
* Client ID:  <your Azure AD registered program Dev Center ID>
* Reply URL: <defined on your Azure AD registered program>
* App ID URI: <defined on your Azure AD registered program>
* Keys: &lt;you only get to see this once so write it down&gt;

### Get the Azure Access Token for your Azure AD Registered App ###
* [Instructions on how exactly to use an HTTP Post request to get your Azure AD access token for getting to the Dev Center API](https://docs.microsoft.com/en-us/azure/active-directory/develop/v1-oauth2-client-creds-grant-flow#service-to-service-access-token-request)
    * If you need an easy way to test your HTTP/S POST request use Google Chrome and the Chrome Web Store application 'Postman'.  You have to download that from the Google Chrome Store.

### Get Dev Center Info for All Apps and Some Apps ###

 * [Create and Manage Submissions Using Windows Store Services](https://docs.microsoft.com/en-us/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)
	* [Get All App Data](https://docs.microsoft.com/en-us/windows/uwp/monetize/get-all-apps)
	* [Get Specific App's Data](https://docs.microsoft.com/en-us/windows/uwp/monetize/get-an-app)

### MSFT Code Examples ###

I modified this [example of code to pull down an Azure Token and query the Dev Center API for an app](https://docs.microsoft.com/en-us/windows/uwp/monetize/csharp-code-examples-for-the-windows-store-submission-api) so that it would attempt to get a listing for all and a specific range of apps.

