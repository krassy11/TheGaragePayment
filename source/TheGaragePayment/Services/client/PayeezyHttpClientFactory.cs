using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;

//package com.firstdata.payeezy.client;

//import org.apache.commons.lang.StringUtils;
//import org.apache.http.HttpHost;
//import org.apache.http.client.HttpClient
//import org.apache.http.client.config.RequestConfig;
//import org.apache.http.config.Registry;
//import org.apache.http.config.RegistryBuilder;
//import org.apache.http.conn.socket.ConnectionSocketFactory;
//import org.apache.http.conn.socket.PlainConnectionSocketFactory;
//import org.apache.http.conn.ssl.SSLConnectionSocketFactory;
//import org.apache.http.conn.ssl.SSLContextBuilder;
//import org.apache.http.impl.client.HttpClientBuilder;
//import org.apache.http.impl.conn.PoolingHttpClientConnectionManager;

//import javax.net.ssl.SSLContext;
//import java.security.KeyManagementException;
//import java.security.NoSuchAlgorithmException;
//import java.util.Properties;

public class PayeezyHttpClientFactory
{

    private const int DEFAULT_MAX_TOTAL_CONNECTIONS = 100;

    private const int DEFAULT_MAX_CONNECTIONS_PER_ROUTE = 5;

    private const int DEFAULT_READ_TIMEOUT_MILLISECONDS = (60 * 1000);

    private HttpClient httpClient;

    private NameValueCollection appSettings = WebConfigurationManager.AppSettings;


    public PayeezyHttpClientFactory(NameValueCollection appSettings)
    {
        buildHttpClient(appSettings);
    }

    public void buildHttpClient(NameValueCollection appSettings)
    {
        try
        {
            //SSLContext sslContext = new SSLContextBuilder().build();
            //String[] protocols = { "TLSv1.2" };
            //SSLConnectionSocketFactory sslConnectionSocketFactory = new SSLConnectionSocketFactory(sslContext, protocols, null, null);
            //Registry<ConnectionSocketFactory> socketFactoryRegistry = RegistryBuilder
            //        .< ConnectionSocketFactory > create()
            //        .register("https", sslConnectionSocketFactory)
            //        .register("http", new PlainConnectionSocketFactory())
            //        .build();
            //PoolingHttpClientConnectionManager cm = new PoolingHttpClientConnectionManager(
            //        socketFactoryRegistry);
            //cm.setMaxTotal(Integer.valueOf(DEFAULT_MAX_TOTAL_CONNECTIONS));
            //cm.setDefaultMaxPerRoute(Integer.valueOf(DEFAULT_MAX_CONNECTIONS_PER_ROUTE));
            //RequestConfig requestConfig = RequestConfig.custom()
            //        .setConnectionRequestTimeout(DEFAULT_READ_TIMEOUT_MILLISECONDS)
            //        .setConnectTimeout(DEFAULT_READ_TIMEOUT_MILLISECONDS)
            //        .setSocketTimeout(DEFAULT_READ_TIMEOUT_MILLISECONDS)
            //        .setExpectContinueEnabled(true)
            //        .setStaleConnectionCheckEnabled(true).build();


           // var clientBuilder = new HttpWebRequest();
           //clientBuilder.sss
                
            
           // clientBuilder.setDefaultRequestConfig(requestConfig);
            //set proxy
            string proxyUrl = appSettings["proxyHost"];
            var proxy = HttpWebRequest.Create(proxyUrl);
            //HttpHost proxy = new HttpHost(proxyUrl, Integer.parseInt(proxyPort));
            ////String proxyUrl = properties.getProperty("proxyHost");
            //bool proxyURLProvided = StringUtils.isNotEmpty(proxyUrl);
            //if (!proxyURLProvided)
            //{
            //    System.out.println("No Proxy URL Set");
            //}
            //String proxyPort = config..getProperty("proxyPort");
            //if (proxyURLProvided && StringUtils.isEmpty(proxyPort))
            //{
            //    System.out.println("Proxy Port not provided. Defaulting to port 80");
            //    proxyPort = "80";
            //}

            //if (proxyURLProvided)
            //{
            //    HttpHost proxy = new HttpHost(proxyUrl, Integer.parseInt(proxyPort));
            //    clientBuilder.setProxy(proxy);
            //}

            //httpClient = clientBuilder.build();
        }
        catch (Exception ex)
        {
            //ex.StackTrace();
            Console.WriteLine(ex.Message);
        }
        //catch (KeyManagementException ex)
        //{
        //    //ex.printStackTrace();
        //    Console.WriteLine(ex.Message);
        //}
    }

    public HttpClient getHttpClient()
    {
        return httpClient;
    }
}
