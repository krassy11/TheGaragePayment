using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class Card
    {
        private Result result;

        public Card()
        {
            this.result = new Result();
        }

        public string Status { get; set; }

        [JsonProperty(PropertyName = "Results")]
        public Result Result { get; set; }
    }
}
