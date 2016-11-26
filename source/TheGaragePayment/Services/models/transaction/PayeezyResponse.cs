namespace TheGarage.Services.Payment.models.transaction
{
    /**
     * Created by FA7G14Q on 3/30/2016.
     */
    public class PayeezyResponse
    {
        private int statusCode;
        private string responseBody;

        public PayeezyResponse(int statusCode, string responseBody)
        {
            this.statusCode = statusCode;
            this.responseBody = responseBody;
        }

        public int getStatusCode()
        {
            return statusCode;
        }

        public string getResponseBody()
        {
            return responseBody;
        }
    }
}

