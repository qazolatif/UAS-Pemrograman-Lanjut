using System;
using System.Collections.Generic;
using System.Text;
using CashierApp.Model;

namespace CashierApp.Controller
{
    class PenawaranController
    {
        private readonly List<Item> items;

        public PenawaranController()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public List<Item> GetItems()
        {
            return this.items;
        }
    }
}
