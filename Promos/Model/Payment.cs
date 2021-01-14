using System;
using System.Collections.Generic;
using System.Text;

namespace CashierApp.Model
{
    class Payment
    {
        //private double promo = 0;
        //private double balance = 0;
        private readonly IOnPaymentChangedListener paymentCallback;

        public Payment(IOnPaymentChangedListener paymentCallback)
        {
            this.paymentCallback = paymentCallback;
        }

        public void UpdateTotal(double subtotal, double potongan)
        {
            double total = subtotal + potongan;
            this.paymentCallback.OnPriceUpdated(subtotal,  total, potongan);
        }

    }

    interface IOnPaymentChangedListener
    {
        void OnPriceUpdated(double subtotal, double grantTotal, double potongan);
    }
}
