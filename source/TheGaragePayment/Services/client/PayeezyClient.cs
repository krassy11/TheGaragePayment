using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using TheGarage.Services.Payment.api;
using TheGarage.Services.Payment.models.transaction;

namespace TheGarage.Services.Payment.client
{
    /**
 * Client class that provides convenience methods to execute GET and POST requests
 */
    public class PayeezyClient : PayeezyAbstractClient
    {

        private PayeezyHttpClientFactory payeezyHttpClient;
        //private NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public PayeezyClient(NameValueCollection appSettings)
        {
            payeezyHttpClient = new PayeezyHttpClientFactory(appSettings);
        }

        /**
         * Reads the required credentials and the host information from VCAP_SERVICES variables
         * making it cloudfoundry aware
         * @param method
         * @param payload
         * @return
         * @throws Exception
         */
        public PayeezyResponse execute(RequestMethod method, Object payload)
        {
            //string envstring = System.getenv("VCAP_SERVICES");
            string apikey = null;
            string token = null;
            string secret = null;
            string url = null;
            //JSONParser jsonParser = new JSONParser();
            var jsonParser = new JSONHelper<Object>();
            apikey = (string)jsonParser.fromJson("apikey");
            token = (string)jsonParser.fromJson("token");
            secret = (string)jsonParser.fromJson("secret");
            url = (string)jsonParser.fromJson("uri");
            if (url != null && !url.Contains("https"))
            {
                url = "https://" + url;
            }

            //try
            //{
            //    //JSONObject vcapServiceObject = (JSONObject)jsonParser.parse(envstring);
            //    //JSONArray payeezyJsonArray = (JSONArray)vcapServiceObject.get("payeezy-service");
            //    //JSONObject payeezyObject = (JSONObject)payeezyJsonArray.get(0);
            //    if (payeezyObject != null)
            //    {
            //        JSONObject credentialsObject = (JSONObject)payeezyObject.get("credentials");
            //        apikey = (string)credentialsObject.get("apikey");
            //        token = (string)credentialsObject.get("token");
            //        secret = (string)credentialsObject.get("secret");
            //        url = (string)credentialsObject.get("uri");
            //        if (url != null && !url.Contains("https"))
            //        {
            //            url = "https://" + url;
            //        }
            //    }
            //}
            //catch (ParseException ex)
            //{
            //    //ex.printStackTrace();
            //}
            PayeezyRequestOptions requestOptions = new PayeezyRequestOptions(apikey, token, secret);
            return execute(url, method, requestOptions, payload);
        }

        /**
         * Method that executes a GET and POST for the provided payload
         * @param URL
         * @param method
         * @param requestOptions
         * @param payload
         * @return
         * @throws Exception
         */
        public PayeezyResponse execute(string URL, RequestMethod method, PayeezyRequestOptions requestOptions, Object payload)
        {
            switch ((int)method)
            {
                case 1:
                    return executeGetRequest(URL, (Dictionary<string, string>)payload);
                case 2:
                    //return executePostRequest(URL, (string)payload, requestOptions);
                    return null;
                case 3:
                    return null;
                    //return executePostRequest(URL, (string)payload, requestOptions);
                default:
                    throw new Exception("Unsupported Request Method");
            }
        }

        /**
         * Execute a POST Request
         * @param uri
         * @param payload
         * @param requestOptions
         * @return
         * @throws Exception
         */
        //    protected PayeezyResponse executePostRequest(string uri, string payload, PayeezyRequestOptions requestOptions)
        //    {
        //        HttpClient httpClient = payeezyHttpClient.getHttpClient();
        //        HttpPost httpPost = createPostConnection(uri, payload, requestOptions);
        //        stringEntity entity = new stringEntity(payload);
        //        httpPost.setEntity(entity);
        //        // Create a custom response handler
        //        ResponseHandler<PayeezyResponse> responseHandler = new ResponseHandler<PayeezyResponse>()
        //        {

        //       public PayeezyResponse handleResponse(HttpResponse response)
        //    {
        //        return getResponse(response);
        //    }

        //};
        //    return HttpClient.execute(httpPost, responseHandler);
        //}

        /**
         * Execute a PUT Request
         * @param uri
         * @param payload
         * @param requestOptions
         * @return
         * @throws Exception
         */
        //protected PayeezyResponse executePutRequest(string uri, string payload, PayeezyRequestOptions requestOptions)
        //{
        //    HttpClient httpClient = payeezyHttpClient.getHttpClient();
        //    HttpPut httpPost = createPutConnection(uri, payload, requestOptions);
        //    stringEntity entity = new stringEntity(payload);
        //    httpPost.setEntity(entity);
        //    // Create a custom response handler
        //    ResponseHandler<PayeezyResponse> responseHandler = new ResponseHandler<PayeezyResponse>()
        //    {

        //            public PayeezyResponse handleResponse(final HttpResponse response)
        //{
        //                return getResponse(response);
        //}

        //        };
        //        return httpClient.execute(httpPost, responseHandler);
        //    }

        /**
         * Execute a Get Request
         * @param uri
         * @param queryParams
         * @return
         * @throws Exception
         */
        protected override PayeezyResponse executeGetRequest(string uri, Dictionary<string, string> queryParams)
        {
            //        URI buildURI = buildGetURI(uri, queryParams);
            ////        HttpGet httpGet = new HttpGet(buildURI);
            //var httpClient = payeezyHttpClient.getHttpClient();
            ////        ResponseHandler<PayeezyResponse> responseHandler = new HttpWebRequest<PayeezyResponse>()
            ////        {
            ////            public PayeezyResponse handleResponse(HttpResponse response)
            ////    {
            ////        return getResponse(response);
            ////    }
            ////};
            //return httpClient.(httpGet, responseHandler);
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(uri);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            var httpClient = payeezyHttpClient.getHttpClient();

            var sss = new PayeezyResponse();

            response.Close();
            return sss;
        }

private PayeezyResponse getResponse(HttpWebResponse response)
{
    var status = (int)response.StatusCode;




            var reader = new StreamReader(response.GetResponseStream());
            string responseBody = reader.ReadToEnd();


    //        var entity = response.GetResponseStream();
    //string responseBody = entity != null ? EntityUtils.tostring(entity) : null;
    return new PayeezyResponse(status, responseBody);
}

/**
 * Build GET URI
 * @param uri
 * @param queryParams
 * @return
 * @throws URISyntaxException
 */
//private Uri buildGetURI(string uri, Dictionary<string, string> queryParams)
//{
//    if (uri.Contains("https://"))
//    {
//        uri = uri.Replace("https://", "");
//    }
//    URIBuilder uriBuilder = new URIBuilder();
//    uriBuilder.setHost(uri);
//    uriBuilder.setScheme("https");
//    Set<string> keySet = queryParams.keySet();
//    Iterator<string> iterator = keySet.iterator();
//    while (iterator.hasNext())
//    {
//        string key = iterator.next();
//        uriBuilder.setParameter(key, queryParams.get(key));
//    }
//    return uriBuilder.build();
//}

/**
 * Create Post Connection
 * @param uri
 * @param payload
 * @param requestOptions
 * @return
 * @throws Exception
 */
//private HttpPost createPostConnection(string uri, string payload, PayeezyRequestOptions requestOptions)
//{
//    //var sss = new HttpWeb
//    //HttpPost post = new HttpPost(uri);
//    //setHttpHeaders(post, payload, requestOptions);


//    byte[] buffer = Encoding.UTF8.GetBytes(payload);
//    HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(uri);
//    hwr.Method = "POST";
//    hwr.ContentType = "application/x-www-form-urlencoded";
//    hwr.ContentLength = buffer.Length;
//    Stream PostStream = hwr.GetRequestStream();
//    PostStream.Write(buffer, 0, buffer.Length);
//    PostStream.Close();

//    return post;
//}

/**
 * Create PUT Connection
 * @param uri
 * @param payload
 * @param requestOptions
 * @return
 * @throws Exception
 */
//private HttpPut createPutConnection(string uri, string payload, PayeezyRequestOptions requestOptions)
//{
//    HttpPut put = new HttpPut(uri);
//    setHttpHeaders(put, payload, requestOptions);
//    return put;
//}

/**
 * Set the HTTP Headers required for the request
 * @param httpPost
 * @param payload
 * @param requestOptions
 * @throws Exception
 */

//private void setHttpHeaders(HttpEntityEnclosingRequestBase httpPost, string payload, PayeezyRequestOptions requestOptions)
//{
//    Dictionary<string, string> keyMap = getSecurityKeys(payload, requestOptions);
//    Iterator<string> iter = keyMap.keySet().iterator();
//    while (iter.hasNext())
//    {
//        string key = iter.next();
//        if (APIResourceConstants.SecurityConstants.PAYLOAD.equals(key))
//            continue;
//        httpPost.setHeader(key, keyMap.TryGetValue(key, val));
//    }
//    httpPost.setHeader("User-Agent", "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
//    httpPost.setHeader(HttpHeaders.CONTENT_TYPE, ContentType.APPLICATION_JSON.getMimeType());
//}

}
    }


