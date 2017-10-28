using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stretegypattern.Models
{
   
    public class Customers
    {
        public enum Gender
        {
            Male,
            Female
        }
        private DiscountStrategy discountStrategy;

        public void SetDiscountStrategy(DiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
            
        }

        public decimal ApplyDiscount(decimal sale)
        {
            return discountStrategy.ApplyDiscount(sale);
        }
    }
}