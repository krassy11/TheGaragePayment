using Newtonsoft.Json;

namespace TheGaragePaymentTest
{
    public class TokenData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "cardholder_name")]
        public string CardholderName { get; set; }

        [JsonProperty(PropertyName = "exp_date")]
        public string ExpDate { get; set; }
    }
}