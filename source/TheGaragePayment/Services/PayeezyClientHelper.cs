using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web.Configuration;
using TheGarage.Services.Payment.api;
using TheGarage.Services.Payment.client;
using TheGarage.Services.Payment.models.transaction;

namespace TheGarage.Services.Payment
{
    /**
     * Helper class that provides convenient methods to execute primary, secondary, getToken and dynamic pricing API's
     * the URL should always point to the host.
     * when making the GetToken call do not pass the protocol as the helper sets up the protocol
     */
    public class PayeezyClientHelper
    {

        private PayeezyClient payeezyClient;
        private NameValueCollection appSettings = WebConfigurationManager.AppSettings;
        //private JSONHelper jsonHelper;

        /**
         * Loads the Configuration properties from ~HOME/.payeez.properties
         * throws ApplicationRuntimeException if Configuration file is not found
         * @throws ApplicationRuntimeException
         */
        public PayeezyClientHelper()
        {
            //jsonHelper = new JSONHelper();
            try
            {
                //properties = new Properties();
                //properties.load(new FileInputStream(new PayeezyConfiguration().load()));
            }
            catch (FileNotFoundException e)
            {
                throw new ApplicationException("Configuration file not found." +
                        " If you are not using the .payeezt.properties file," +
                        //" please use the " + PayeezyClientHelper.class.getSimpleName() + "(Properties) constructor." +
                    " If you are using .payeezy.properties, you can generate one using java -jar payeezy-sdk-for-java-x.xx.jar", e);
        } catch (IOException e) {
            throw new ApplicationException("Configuration file could not be loaded.  Check to see if the user running this has permission to access the file", e);
}
payeezyClient = new PayeezyClient(appSettings);
    }


    /**
     * Construct a PayeezyClientHelper specifying the configuration.
     * Properties that must be set are:
     * url
     * apikey
     * secret
     * token
     * proxyHost --> if behind a proxy
     * proxyPort --> proxy port, defaults to 80 if the proxyHost is provided, but no proxyPort set      *
     */
    public PayeezyClientHelper(NameValueCollection appSettings)
{
    jsonHelper = new JSONHelper();
    if (appSettings == null || appSettings.isEmpty())
    {
        throw new ApplicationRuntimeException("SDK Properties should be configured to use the Client. Please provide the required properties based on the type of transaction.");
    }
    this.appSettings = appSettings;
    payeezyClient = new PayeezyClient(appSettings);
}

/**
 * Use this for primary transactions like Authorize, Purchase
 * @param transactionRequest
 * @return
 * @throws Exception
 */
public PayeezyResponse doPrimaryTransaction(TransactionRequest transactionRequest)
{
    string payload = jsonHelper.getJSONObject(transactionRequest);
    
    string URL = appSettings["url"];
    URL = URL+ APIResourceConstants.PRIMARY_TRANSACTIONS;
    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(), payload );
        return payeezyResponse;
}

/**
 *Use this for Secondary transactions like void, refund, capture etc
 */

public PayeezyResponse doSecondaryTransaction(string id, TransactionRequest transactionRequest)
{
    string URL = properties.getProperty("url");
    URL = URL+ APIResourceConstants.PRIMARY_TRANSACTIONS+ "/"+id;
    string payload = jsonHelper.getJSONObject(transactionRequest);
    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(),payload );
        return payeezyResponse;
}

/**
 * Get Token Call to tokenize a credit card
 * @param queryMap
 * @return
 * @throws Exception
 */
public PayeezyResponse doGetTokenCall(Dictionary<string, string> queryMap)
{
    string URL = properties.getProperty("url")+ APIResourceConstants.SECURE_TOKEN_URL;
        if(URL.contains("http://")){
        URL.replace("https://", "");
    }
        if(!queryMap.containsKey(APIResourceConstants.SecurityConstants.APIKEY)){
        String apikey = properties.getProperty(APIResourceConstants.SecurityConstants.APIKEY);
        queryMap.put(APIResourceConstants.SecurityConstants.APIKEY, apikey);
    }

        if(!queryMap.containsKey(APIResourceConstants.SecurityConstants.JS_SECURITY_KEY)){
        String jsSecurityKey = properties.getProperty(APIResourceConstants.SecurityConstants.JS_SECURITY_KEY);
        queryMap.put(APIResourceConstants.SecurityConstants.JS_SECURITY_KEY, jsSecurityKey);
    }
    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.GET, null, queryMap);
        return payeezyResponse;
}

/**
 * Dynamic Pricing look up
 * @param transactionRequest
 * @return
 * @throws Exception
 */
public PayeezyResponse doExchangeRate(TransactionRequest transactionRequest)
{
    string URL = appSettings["url"]+ APIResourceConstants.EXCHANGE_RATE;
    string payload = jsonHelper.getJSONObject(transactionRequest);
    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(),payload );
        return payeezyResponse;
}


/**
 * API Call to search for events
 * @param URL
 * @param queryMap
 * @param requestOptions
 * @return
 * @throws Exception
 */
public PayeezyResponse getEvents(string URL, Dictionary<string, string> queryMap, PayeezyRequestOptions requestOptions)
{
    URL = URL+ APIResourceConstants.SECURE_TOKEN_URL;
    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.GET,requestOptions,queryMap);
        return payeezyResponse;
}


private PayeezyRequestOptions getRequestOptions()
{
    string apikey = appSettings[APIResourceConstants.SecurityConstants.APIKEY];
    string secret = appSettings[APIResourceConstants.SecurityConstants.APISECRET];
    string token = appSettings[APIResourceConstants.SecurityConstants.TOKEN];
    return new PayeezyRequestOptions(apikey, token, secret);
}

/**
 * Enrollment call for ACH Pay
 * @param enrollmentRequest
 * @return
 * @throws Exception
 */
//public PayeezyResponse enrollInACH(EnrollmentRequest enrollmentRequest) throws Exception
//{
//    String payload = jsonHelper.getJSONObject(enrollmentRequest);
//    String URL = properties.getProperty("url");
//    URL = URL+ APIResourceConstants.ACH_URL;
//    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(), payload );
//        return payeezyResponse;
//}

/**
 * Validate ach micro deposit
 * @param microDeposit
 * @return
 * @throws Exception
 */
//public PayeezyResponse validateMicroDeposit(BAARequest microDeposit) throws Exception
//{
//    String payload = jsonHelper.getJSONObject(microDeposit);
//    String URL = properties.getProperty("url");
//    URL = URL+ APIResourceConstants.ACH_MICRO_DEPOSIT;
//    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(), payload );
//        return payeezyResponse;
//}

/**
 * Update ACH Enrollment info
 * @param enrollmentRequest
 * @return
 * @throws Exception
 */
//public PayeezyResponse updateACHEnrollment(EnrollmentRequest enrollmentRequest) throws Exception
//{
//    String payload = jsonHelper.getJSONObject(enrollmentRequest);
//    String URL = properties.getProperty("url");
//    URL = URL+ APIResourceConstants.ACH_URL;
//    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.PUT, getRequestOptions(), payload );
//        return payeezyResponse;
//}

/**
 * Close Enrollment call for ACH Pay
 * @param enrollmentRequest
 * @return
 * @throws Exception
 */
//public PayeezyResponse closeACHEnrollment(EnrollmentRequest enrollmentRequest) throws Exception
//{
//    String payload = jsonHelper.getJSONObject(enrollmentRequest);
//    String URL = properties.getProperty("url");
//    URL = URL+ APIResourceConstants.ACH_CLOSE;
//    PayeezyResponse payeezyResponse = payeezyClient.execute(URL, RequestMethod.POST, getRequestOptions(), payload );
//        return payeezyResponse;
//}

}
}
