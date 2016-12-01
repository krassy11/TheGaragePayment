using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGarage.Services.Payment
{
    public class HttpRequester
    {
        public static T Get<T>(string resourceUrl)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Method = "GET";
            //request.Headers.Add("Accept-Encoding: gzip, deflate, sdch, br");
            //request.Headers.Add("Accept-Language: g - BG, bg; q = 0.8,en; q = 0.6");
            //request.Headers.Add("Upgrade-Insecure-Requests: 1");
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            //  request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
           // request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30";


            var response = request.GetResponse();
            string responseString;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            int firstIndex = responseString.IndexOf("{");
            int lastIndex = responseString.LastIndexOf("}");
            string newString = responseString.Substring(firstIndex, lastIndex - firstIndex + 1);
            var responseData = JsonConvert.DeserializeObject<T>(newString);
            return responseData;
        }

        public static void Get(string resourceUrl)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            request.GetResponse();
        }

        public static void Post(string resourceUrl, object data)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";

            var jsonData = JsonConvert.SerializeObject(data);

            using (StreamWriter writer = 
                new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }

            request.GetResponse();
        }

        public static T Post<T>(string resourceUrl, object data)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";

            var jsonData = JsonConvert.SerializeObject(data);

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }

            var response = request.GetResponse();
            string responseString;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            var responseData = JsonConvert.DeserializeObject<T>(responseString);
            return responseData;
        }

        public static void Delete(string resourceUrl)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "DELETE";
            request.GetResponse();
        }
    }
}
