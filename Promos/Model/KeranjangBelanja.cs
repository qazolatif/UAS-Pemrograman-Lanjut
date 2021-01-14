using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows;

namespace CashierApp.Model
{
    class KeranjangBelanja
    {
        readonly List<Item> itemBelanja;
        readonly List<Coupon> itemCoupon;
        int capacity = 1;
        readonly Payment payment;
        readonly IOnKeranjangBelanjaChangedListener callback;

        public KeranjangBelanja(Payment payment, IOnKeranjangBelanjaChangedListener callback)
        {
            this.payment = payment;
            this.itemBelanja = new List<Item>();
            this.itemCoupon = new List<Coupon>();
            this.callback = callback;
        }
        public List<Item> GetItems()
        {
            return this.itemBelanja;
        }

        public List<Coupon> GetCoupons()
        {
            return this.itemCoupon;
        }


        public void AddItem(Item item)
        {
            this.itemBelanja.Add(item);
            this.callback.AddItemSucceed();
            CalculateSubTotal();
        }

        public void AddCoupon(Coupon item)
        {
            if (capacity == 1)
            {
                this.itemCoupon.Add(item);
                this.callback.AddCouponSucceed();
                capacity = 0;
                CalculateSubTotal();
            } else
            {
                MessageBox.Show("Maaf. Anda hanya dapat menggunakan salah satu kupon", "Konfirmasi Kupon", MessageBoxButton.OK);
            }
        }

        public void RemoveCoupon(Coupon item)
        {
            this.itemCoupon.Remove(item);
            this.callback.RemoveCouponSucceed();
            capacity = 1;
            CalculateSubTotal();
        }

        public void RemoveItem(Item item)
        {
            this.itemBelanja.Remove(item);
            this.callback.RemoveItemSucceed();
            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {
            double subtotal = 0;
            double potongan = 0;
            foreach (Item item in itemBelanja)
            {
                subtotal += item.Price;
            }

            foreach (Coupon coupon in itemCoupon)
            {
                if (coupon.DiscInPercent != 0)
                {

                    if(coupon.DiscInPercent == 30)
                    {
                        if(subtotal >= 100000)
                        {
                            potongan -= 30000;
                        } else {
                            potongan -= subtotal * (coupon.DiscInPercent / 100);
                        }
                    } else { 
                        potongan -= subtotal * (coupon.DiscInPercent/100);
                    }
                }

                if(coupon.Disc != 0)
                {
                    potongan -= coupon.Disc;
                }
            }
            payment.UpdateTotal(subtotal, potongan); 
        }
    }

    interface IOnKeranjangBelanjaChangedListener
    {
        void RemoveItemSucceed();
        void AddItemSucceed();

        void RemoveCouponSucceed();
        void AddCouponSucceed();
    }
}
