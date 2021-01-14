using System;
using System.Collections.Generic;
using System.Text;

namespace CashierApp.Model
{
    public class Coupon
    {
        public string Title { get; set; }
        public double Disc { get; set; }

        public double DiscInPercent { get; set; }

        public Coupon(string title, double disc = 0, double discInPercent = 0)
        {
            this.Title = title;
            this.Disc = disc;
            this.DiscInPercent = discInPercent;
        }
    }
}
