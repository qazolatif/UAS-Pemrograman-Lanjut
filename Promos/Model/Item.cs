using System;
using System.Collections.Generic;
using System.Text;

namespace CashierApp.Model
{
    public class Item
    {
        public string Title { get; set; }
        public double Price { get; set; }

        public Item(string title, double price)
        {
            this.Title = title;
            this.Price = price;
        }
    }
}
