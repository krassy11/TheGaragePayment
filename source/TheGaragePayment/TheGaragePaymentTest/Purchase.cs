using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class Purchase
    {
        private Token token;

        public Purchase()
        {
            this.token = new Token();
        }

        [JsonProperty(PropertyName = "merchant_ref")]
        public string MerchantRef { get; set; }

        [JsonProperty(PropertyName = "transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "token")]
        public Token Token { get; set; }
    }
}
