using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CashierApp
{
    /// <summary>
    /// Interaction logic for PilihCoupon.xaml
    /// </summary>
    public partial class PilihCoupon : Window
    {
        readonly Controller.CouponController couponController;
        IOnPilihCouponChangedListener listener;

        public PilihCoupon()
        {
            InitializeComponent();

            couponController = new Controller.CouponController();
            DaftarCoupon.ItemsSource = couponController.GetItems();

            GenerateListCoupon();
        }

        private void GenerateListCoupon()
        {
            Model.Coupon awalTahun = new Model.Coupon(title: "Promo Awal Tahun, Diskon 25%", discInPercent: 25);
            Model.Coupon tebusMurah = new Model.Coupon(title: "Promo Tebus Murah, Diskon 30% atau max. 30.000", discInPercent: 30);
            Model.Coupon promoNatal = new Model.Coupon(title: "Promo Natal, Potongan 10000", disc: 10000);

            couponController.AddItem(awalTahun);
            couponController.AddItem(tebusMurah);
            couponController.AddItem(promoNatal);

            DaftarCoupon.Items.Refresh();
        }

        public void SetOnItemSelectedListener(IOnPilihCouponChangedListener listener)
        {
            this.listener = listener;
        }

        public interface IOnPilihCouponChangedListener
        {
            void OnPilihCouponChangedListener(Model.Coupon item);
        }

        private void DaftarCouponSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Model.Coupon item = listbox.SelectedItem as Model.Coupon;

            this.listener.OnPilihCouponChangedListener(item);
        }
    }
}
