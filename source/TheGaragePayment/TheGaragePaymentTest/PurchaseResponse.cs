using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class PurchaseResponse
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }
    }
}
