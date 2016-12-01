using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class Result
    {
        private Token token;

        public Result()
        {
            this.Token = new Token();
        }
        public string Status { get; set; }

        public Token Token { get; set; }

    }
}
