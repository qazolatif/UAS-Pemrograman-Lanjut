using System;
using System.Collections.Generic;
using System.Text;
using CashierApp.Model;

namespace CashierApp.Controller
{
    class CouponController
    {
        private readonly List<Coupon> items;

        public CouponController()
        {
            items = new List<Coupon>();
        }

        public void AddItem(Coupon item)
        {
            this.items.Add(item);
        }

        public List<Coupon> GetItems()
        {
            return this.items;
        }

    }
}
