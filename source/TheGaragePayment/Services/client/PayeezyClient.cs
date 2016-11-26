//package com.firstdata.payeezy.client;

//import com.firstdata.payeezy.api.APIResourceConstants;
//import com.firstdata.payeezy.api.PayeezyRequestOptions;
//import com.firstdata.payeezy.api.RequestMethod;
//import com.firstdata.payeezy.models.transaction.PayeezyResponse;
//import org.apache.http.HttpEntity;
//import org.apache.http.HttpHeaders;
//import org.apache.http.HttpResponse;
//import org.apache.http.client.HttpClient;
//import org.apache.http.client.ResponseHandler;
//import org.apache.http.client.methods.HttpEntityEnclosingRequestBase;
//import org.apache.http.client.methods.HttpGet;
//import org.apache.http.client.methods.HttpPost;
//import org.apache.http.client.methods.HttpPut;
//import org.apache.http.client.utils.URIBuilder;
//import org.apache.http.entity.ContentType;
//import org.apache.http.entity.stringEntity;
//import org.apache.http.util.EntityUtils;
//import org.json.simple.JSONArray;
//import org.json.simple.JSONObject;
//import org.json.simple.parser.JSONParser;
//import org.json.simple.parser.ParseException;

//import java.io.IOException;
//import java.net.URI;
//import java.net.URISyntaxException;
//import java.util.Iterator;
//import java.util.Map;
//import java.util.Properties;
//import java.util.Set;

using System.Collections.Specialized;
using System.Web.Query.Dynamic;
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
        string envstring = System.getenv("VCAP_SERVICES");
        string apikey = null;
        string token = null;
        string secret = null;
        string url = null;
        JSONParser jsonParser = new JSONParser();
        try{
            JSONObject vcapServiceObject = (JSONObject)jsonParser.parse(envstring);
        JSONArray payeezyJsonArray = (JSONArray)vcapServiceObject.get("payeezy-service");
        JSONObject payeezyObject = (JSONObject)payeezyJsonArray.get(0);
            if(payeezyObject != null){
                JSONObject credentialsObject = (JSONObject)payeezyObject.get("credentials");
        apikey = (string) credentialsObject.get("apikey");
                token = (string) credentialsObject.get("token");
                secret = (string) credentialsObject.get("secret");
                url = (string) credentialsObject.get("uri");
                if(url != null && !url.contains("https")){
                    url = "https://"+url;
                }
}
        }catch (ParseException ex){
            //ex.printStackTrace();
        }
        PayeezyRequestOptions requestOptions = new PayeezyRequestOptions(apikey, token, secret);
        return  execute(url, method, requestOptions, payload);
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
        switch (method){
            case GET:
        return executeGetRequest(URL, (Dictionary<string, string>)payload);
            case POST:
        return executePostRequest(URL, (string)payload, requestOptions);
            case PUT:
        return executePostRequest(URL, (string)payload, requestOptions);
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
protected PayeezyResponse executePostRequest(string uri, string payload, PayeezyRequestOptions requestOptions)
{
    HttpClient httpClient = payeezyHttpClient.getHttpClient();
    HttpPost httpPost =  createPostConnection(uri,payload,requestOptions);
    stringEntity entity = new stringEntity(payload);
httpPost.setEntity(entity);
        // Create a custom response handler
        ResponseHandler<PayeezyResponse> responseHandler = new ResponseHandler<PayeezyResponse>()
        {

           public PayeezyResponse handleResponse(final HttpResponse response) throws IOException
{
               return getResponse(response);
}

        };
        return httpClient.execute(httpPost, responseHandler);
    }

    /**
     * Execute a PUT Request
     * @param uri
     * @param payload
     * @param requestOptions
     * @return
     * @throws Exception
     */
    protected PayeezyResponse executePutRequest(string uri, string payload, PayeezyRequestOptions requestOptions)
{
    HttpClient httpClient = payeezyHttpClient.getHttpClient();
    HttpPut httpPost = createPutConnection(uri,payload,requestOptions);
    stringEntity entity = new stringEntity(payload);
httpPost.setEntity(entity);
        // Create a custom response handler
        ResponseHandler<PayeezyResponse> responseHandler = new ResponseHandler<PayeezyResponse>()
        {

            public PayeezyResponse handleResponse(final HttpResponse response) throws IOException
{
                return getResponse(response);
}

        };
        return httpClient.execute(httpPost, responseHandler);
    }

    /**
     * Execute a Get Request
     * @param uri
     * @param queryParams
     * @return
     * @throws Exception
     */
    protected PayeezyResponse executeGetRequest(string uri, Dictionary<string, string> queryParams)
{
    URI buildURI =  buildGetURI(uri, queryParams);
    HttpGet httpGet = new HttpGet(buildURI);
HttpClient httpClient = payeezyHttpClient.getHttpClient();
ResponseHandler<PayeezyResponse> responseHandler = new ResponseHandler<PayeezyResponse>()
{
                public PayeezyResponse handleResponse(final HttpResponse response) throws IOException
{
                    return getResponse(response);
}
            };
        return httpClient.execute(httpGet, responseHandler);
    }

    private PayeezyResponse getResponse(HttpResponse response) throws IOException
{
        int status = response.getStatusLine().getStatusCode();
    HttpEntity entity = response.getEntity();
    string responseBody = entity != null ? EntityUtils.tostring(entity) : null;
        return new PayeezyResponse(status, responseBody);
    }

    /**
     * Build GET URI
     * @param uri
     * @param queryParams
     * @return
     * @throws URISyntaxException
     */
    private URI buildGetURI(string uri, Dictionary<string, string> queryParams)
{
        if(uri.contains("https://")){
        uri = uri.replace("https://", "");
    }
    URIBuilder uriBuilder = new URIBuilder();
uriBuilder.setHost(uri);
        uriBuilder.setScheme("https");
        Set<string> keySet = queryParams.keySet();
Iterator<string> iterator = keySet.iterator();
        while (iterator.hasNext()){
            string key = iterator.next();
uriBuilder.setParameter(key, queryParams.get(key));
        }
        return uriBuilder.build();
    }

    /**
     * Create Post Connection
     * @param uri
     * @param payload
     * @param requestOptions
     * @return
     * @throws Exception
     */
    private HttpPost createPostConnection(string uri, string payload, PayeezyRequestOptions requestOptions)
{
    HttpPost post = new HttpPost(uri);
        setHttpHeaders(post, payload, requestOptions );
        return post;
    }

    /**
     * Create PUT Connection
     * @param uri
     * @param payload
     * @param requestOptions
     * @return
     * @throws Exception
     */
    private HttpPut createPutConnection(string uri, string payload, PayeezyRequestOptions requestOptions)
{
    HttpPut put = new HttpPut(uri);
        setHttpHeaders(put, payload, requestOptions );
        return put;
    }

    /**
     * Set the HTTP Headers required for the request
     * @param httpPost
     * @param payload
     * @param requestOptions
     * @throws Exception
     */

    private void setHttpHeaders(HttpEntityEnclosingRequestBase httpPost, string payload, PayeezyRequestOptions requestOptions)
{
    Dictionary<string, string> keyMap = getSecurityKeys( payload, requestOptions);
    Iterator<string> iter=keyMap.keySet().iterator();
        while(iter.hasNext()) {
        string key = iter.next();
        if (APIResourceConstants.SecurityConstants.PAYLOAD.equals(key))
            continue;
        httpPost.setHeader(key, keyMap.get(key));
    }
    httpPost.setHeader("User-Agent", "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
    httpPost.setHeader(HttpHeaders.CONTENT_TYPE, ContentType.APPLICATION_JSON.getMimeType());
}

}
    }


