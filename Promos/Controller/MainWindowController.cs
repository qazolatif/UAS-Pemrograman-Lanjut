using System;
using System.Collections.Generic;
using System.Text;
using CashierApp.Model;

namespace CashierApp.Controller
{
    class MainWindowController 
    {
        readonly KeranjangBelanja keranjangBelanja;

        public MainWindowController(KeranjangBelanja keranjangBelanja)
        {
            this.keranjangBelanja = keranjangBelanja;
        }

        public void AddItem(Item item)
        {
            this.keranjangBelanja.AddItem(item);
        }

        public void AddCoupon(Coupon item)
        {
            this.keranjangBelanja.AddCoupon(item);
        }
        public List<Item> GetSelectedItems()
        {
            return this.keranjangBelanja.GetItems();
        }

        public List<Coupon> GetSelectedCoupons()
        {
            return this.keranjangBelanja.GetCoupons();
        }

        public void DeleteSelectedItem(Item item)
        {
            this.keranjangBelanja.RemoveItem(item);
        }

        public void DeleteSelectedCoupon(Coupon item)
        {
            this.keranjangBelanja.RemoveCoupon(item);
        }
    }
}
