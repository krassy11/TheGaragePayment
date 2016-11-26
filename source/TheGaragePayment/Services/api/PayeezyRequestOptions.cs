namespace TheGarage.Services.Payment.api
{
    /**
 * Use this call to pass apikey, token and secret required for making a transaction
 */
    public class PayeezyRequestOptions
    {

        private string apiKey;
        private string token;
        private string secret;

        public PayeezyRequestOptions(string apiKey, string token, string securedSecret)
        {
            this.apiKey = apiKey;
            this.token = token;
            this.secret = securedSecret;
        }

        public string getApiKey()
        {
            return apiKey;
        }

        public string getToken()
        {
            return token;
        }

        public string getSecret()
        {
            return secret;
        }
    }
}


