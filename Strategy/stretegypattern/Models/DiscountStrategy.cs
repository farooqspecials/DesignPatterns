using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stretegypattern.Models
{
    public abstract class DiscountStrategy
    {
        protected double discountPercentage { get; set; }

        public abstract decimal ApplyDiscount(decimal sale);
    }
}