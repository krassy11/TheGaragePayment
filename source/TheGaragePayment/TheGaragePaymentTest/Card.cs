﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class Card
    {
        private Result results;

        public Card()
        {
            this.Results = new Result();
        }
        public string Status { get; set; }

        public Result Results { get; set; }
    }
}
