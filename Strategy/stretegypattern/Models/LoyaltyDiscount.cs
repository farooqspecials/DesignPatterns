using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stretegypattern.Models
{
    public class LoyaltyDiscount:DiscountStrategy
    {
        public LoyaltyDiscount()
        {
            discountPercentage = 15;
        }

        public override decimal ApplyDiscount(decimal sale)
        {
            return (decimal)(100 - discountPercentage) * sale / 100;
        }

    }
}