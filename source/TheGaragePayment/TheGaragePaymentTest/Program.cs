﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Services.Payment;

namespace TheGaragePaymentTest
{
    class Program
    {
        static void Main()
        {
            //Dictionary<string, string> requestMap = new Dictionary<string, string>();
            //requestMap.Add("callback", "Payeezy.callback");
            //requestMap.Add("ta_token", "123");
            //requestMap.Add("auth", "false");
            //requestMap.Add("type", "FDToken");
            //requestMap.Add("credit_card.type", "visa");
            //requestMap.Add("credit_card.cardholder_name", "Kolev Iliya");
            //requestMap.Add("credit_card.card_number", "4788250000028291");
            //requestMap.Add("credit_card.exp_date", "1218");
            //requestMap.Add("credit_card.cvv", "123");
            //// billing address is optional
            //requestMap.Add("billing_address.city", "St.Louis");
            //requestMap.Add("billing_address.country", "US");
            //requestMap.Add("billing_address.email", "abc@abc.com");
            //requestMap.Add("billing_address.phone.type", "home");
            //requestMap.Add("billing_address.phone.number", "212-515-1212");
            //requestMap.Add("billing_address.street", "12115 LACKLAND");
            //requestMap.Add("billing_address.state_province", "MO");
            //requestMap.Add("billing_address.phone.number", "212-515-1212");
            //requestMap.Add("billing_address.zip_postal_code", "63146");

            // this picks the properties from the .payeezy.properties files
            // alternatively you can populate the properties and pass it to the constructor
            //PayeezyClientHelper clientHelper = new PayeezyClientHelper();
            //try
            //{
            //    PayeezyResponse payeezyResponse = clientHelper.doGetTokenCall(requestMap);
            //    Console.WriteLine(payeezyResponse.getResponseBody());
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //}
            var studentsServiceUrl = "https://api-cert.payeezy.com";

            var testUrl = "http://localhost:29863";

            //HttpRequester.Post(studentsServiceUrl + "students", newBook);

            //var card = new Card()
            //{
            //    Id = 1,
            //    Token = "465456464666",
            //    HolderName = "Ivan Ivanov"
            //};


            //var cards = HttpRequester.Get<IEnumerable<Card>>(studentsServiceUrl + "/v1/securitytokens");


            var values = HttpRequester.Get<ValuesResponse>(testUrl + "/api/values");

            //foreach (var item in values)
            //{
            //    Console.WriteLine(item);
            //}






            //var jsonHelper = new JSONHelperN<Card>();
            //var sss = jsonHelper.getJSONObject(card);
            //Console.WriteLine(sss);
            //var kkk = jsonHelper.fromJson(sss);
            //Console.WriteLine(kkk.Token);

            //var url = "http://www.abv.bg";
            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            //if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
            //    Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}",
            //                         myHttpWebResponse.StatusDescription);
            //// Releases the resources of the response.
            //Console.WriteLine(myHttpWebResponse.GetResponseStream());
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine(myHttpWebResponse.GetResponseStream());
            //myHttpWebResponse.Close();



        }
    }
}
