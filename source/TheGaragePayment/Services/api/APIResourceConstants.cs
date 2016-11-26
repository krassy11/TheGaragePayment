namespace TheGarage.Services.Payment.api
{
    /**
 * Contains all the resource constants and security constants
 * LIVE_URL is the production URL
 *
 */
    public class APIResourceConstants
    {
        public const string SANDBOX_URL = "https://api-cert.payeezy.com";
        public const string LIVE_URL = "https://api-cert.payeezy.com";
        public const string PRIMARY_TRANSACTIONS = "/v1/transactions";
        public const string EXCHANGE_RATE = "/v1/transactions/exchange_rate";
        public const string SECURE_TOKEN_URL = "/v1/securitytokens";
        public const string CONNECT_PAY_URL = "v1/connectpay/consumer/enrollment";
        public const string CONNECT_PAY_CLOSE = "v1/connectpay/consumer/enrollment/close";
        public const string CONNECT_PAY_MICRO_DEPOSIT = "v1/connectpay/consumer/enrollment/baa";

        public class SecurityConstants
        {
            public const string NONCE = "nonce";
            public const string APIKEY = "apikey";
            public const string APISECRET = "pzsecret";
            public const string TOKEN = "token";
            public const string TIMESTAMP = "timestamp";
            public const string AUTHORIZE = "Authorization";
            public const string PAYLOAD = "payload";
            public const string JS_SECURITY_KEY = "js_security_key";
        }
    }
}