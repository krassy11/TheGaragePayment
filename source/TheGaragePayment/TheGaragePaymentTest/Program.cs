using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Services.Payment;
using TheGarage.Services.Payment.models.transaction;

namespace TheGaragePaymentTest
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> requestMap = new Dictionary<string, string>();
            requestMap.Add("callback", "Payeezy.callback");
            requestMap.Add("ta_token", "123");
            requestMap.Add("auth", "false");
            requestMap.Add("type", "FDToken");
            requestMap.Add("credit_card.type", "visa");
            requestMap.Add("credit_card.cardholder_name", "Kolev Iliya");
            requestMap.Add("credit_card.card_number", "4788250000028291");
            requestMap.Add("credit_card.exp_date", "1218");
            requestMap.Add("credit_card.cvv", "123");
            // billing address is optional
            requestMap.Add("billing_address.city", "St.Louis");
            requestMap.Add("billing_address.country", "US");
            requestMap.Add("billing_address.email", "abc@abc.com");
            requestMap.Add("billing_address.phone.type", "home");
            requestMap.Add("billing_address.phone.number", "212-515-1212");
            requestMap.Add("billing_address.street", "12115 LACKLAND");
            requestMap.Add("billing_address.state_province", "MO");
            requestMap.Add("billing_address.phone.number", "212-515-1212");
            requestMap.Add("billing_address.zip_postal_code", "63146");

            // this picks the properties from the .payeezy.properties files
            // alternatively you can populate the properties and pass it to the constructor
            PayeezyClientHelper clientHelper = new PayeezyClientHelper();
            try
            {
                PayeezyResponse payeezyResponse = clientHelper.doGetTokenCall(requestMap);
                Console.WriteLine(payeezyResponse.getResponseBody());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
