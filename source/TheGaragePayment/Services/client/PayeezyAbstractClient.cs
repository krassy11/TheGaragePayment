//package com.firstdata.payeezy.client;

//import com.firstdata.payeezy.api.APIResourceConstants;
//import com.firstdata.payeezy.api.PayeezyRequestOptions;
//import com.firstdata.payeezy.models.transaction.PayeezyResponse;
//import org.apache.commons.codec.binary.Base64;

//import javax.crypto.Mac;
//import javax.crypto.spec.SecretKeySpec;
//import java.security.NoSuchAlgorithmException;
//import java.security.SecureRandom;
//import java.util.HashMap;
//import java.util.Map;


using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TheGarage.Services.Payment.api;
using TheGarage.Services.Payment.models.transaction;
/**
* Base client class that provides helper methods to calculate
* authorization headers and request options
*/
public abstract class PayeezyAbstractClient
{

    protected Dictionary<string, string> getSecurityKeys(string payLoad, PayeezyRequestOptions requestOptions)
    {
        Dictionary<string, string> returnMap =new Dictionary<string, string>();
        if(requestOptions == null){
            throw new Exception("Payeezy Request Options not set");
}
        //try {
//            long nonce = Math.Abs(SecureRandom.getInstance("SHA1PRNG").nextLong());
//returnMap.put(APIResourceConstants.SecurityConstants.NONCE, Long.ToString(nonce));
            returnMap.Add(APIResourceConstants.SecurityConstants.APIKEY, requestOptions.getApiKey());
            //returnMap.Add(APIResourceConstants.SecurityConstants.TIMESTAMP, Long.toString(System.currentTimeMillis()));
            returnMap.Add(APIResourceConstants.SecurityConstants.TOKEN, requestOptions.getToken());
            returnMap.Add(APIResourceConstants.SecurityConstants.APISECRET, requestOptions.getSecret());
            returnMap.Add(APIResourceConstants.SecurityConstants.PAYLOAD, payLoad);
            returnMap.Add(APIResourceConstants.SecurityConstants.AUTHORIZE, getMacValue(returnMap));
            return returnMap;
        //} catch (ExecutionEngineException e) {
        //    MessageLogger.logMessage(e.getMessage());
        //    throw new RuntimeException(e.getMessage(),e);
       //}
       // catch
       // {

       // }
    }

    /**
     * Builds the authorization string that will sent as part of the Request Header
     * @param data
     * @return
     * @throws Exception
     */
    private string getMacValue(Dictionary<string, string> data)
{
    //Mac mac=Mac.getInstance("HmacSHA256");
    string apiSecret= data[APIResourceConstants.SecurityConstants.APISECRET];
    //SecretKeySpec secret_key = new SecretKeySpec(apiSecret.getBytes(), "HmacSHA256");
        byte[] secret_key = Encoding.UTF8.GetBytes(apiSecret);

        HMACSHA256 hmac = new HMACSHA256(secret_key);
        hmac.Initialize();
        //foreach (var key in data)
        //{
        //    var ss = data[key.Key]
        //}
        //byte[] bytes = Encoding.UTF8.GetBytes(data.);
        //byte[] rawHmac = hmac.ComputeHash(bytes);
        //Console.WriteLine(Convert.ToBase64String(rawHmac));

        //mac.init(secret_key);
        string apikey = data[APIResourceConstants.SecurityConstants.APIKEY];
        string nonce = data[APIResourceConstants.SecurityConstants.NONCE];
        //String timeStamp = data.get(APIResourceConstants.SecurityConstants.TIMESTAMP);
        string token = data[APIResourceConstants.SecurityConstants.TOKEN];
        string payload = data[APIResourceConstants.SecurityConstants.PAYLOAD];

    StringBuilder buff = new StringBuilder();
        buff.Append(apikey);
            //.append(nonce)
            //.append(timeStamp);
    if (token != null)
    {
        buff.Append(token);
    }
    if (payload != null)
    {
        buff.Append(payload);
    }
    string bufferData = buff.ToString();
    //MessageLogger.logMessage(String.format(bufferData));
    //byte[] macHash = mac.doFinal(bufferData.get("UTF-8"));
        var macHash = Encoding.UTF8.GetBytes(bufferData);
        //MessageLogger.logMessage(Integer.toString(macHash.length));
        //MessageLogger.logMessage(String.format("MacHAsh:{}" , macHash));
        string authorizeString = Convert.ToBase64String(macHash);
    //   MessageLogger.logMessage(String.format("Authorize:{}" , authorizeString));
    return authorizeString;


    }

    /**
     * Converts the bytes to Hex bytes
     * @param arr
     * @return
     */
//    private byte[] toHex(byte[] arr)
//{
//    string hex = byteArrayToHex(arr);
//    //return hex.getBytes();
//}

private string byteArrayToHex(byte[] a)
{
    StringBuilder sb = new StringBuilder(a.Length * 2);
    foreach(byte b in a)
        sb.Append(string.Format("%02x", b & 0xff));
    return sb.ToString();
}

    //protected abstract PayeezyResponse executePostRequest(string uri, string payload, PayeezyRequestOptions requestOptions);

    protected abstract PayeezyResponse executeGetRequest(string uri, Dictionary<string, string> queryParams);

}
