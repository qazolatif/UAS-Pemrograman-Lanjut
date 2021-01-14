using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CashierApp.Controller;
using CashierApp.Model;
using static CashierApp.PilihCoupon;

namespace CashierApp
{
    public partial class MainWindow : Window,
        IOnPenawaranChangedListener,
        IOnPilihCouponChangedListener,
        IOnPaymentChangedListener, 
        IOnKeranjangBelanjaChangedListener
    {
        readonly MainWindowController controller;
        readonly Payment payment;

        public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.GetSelectedItems();
            listBoxPakaiCoupon.ItemsSource = controller.GetSelectedCoupons();

            InitializeView();

        }

        private void InitializeView()
        {
            labelSubtotal.Content = "Rp 0";
            labelGrantTotal.Content = "Rp 0";
            labelPromoFee.Content = "Rp 0";
        }

        public void OnPenawaranSelected(Item item)
        {
            controller.AddItem(item);
        }

        private void OnButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
        }

        private void ListBoxPesanan_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Anda ingin menghapus item ini?",
                    "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.DeleteSelectedItem(item);
            }
        }

        private void ListBoxPakaiCoupon_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Anda ingin menghapus kupon ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Coupon item = listBox.SelectedItem as Coupon;
                controller.DeleteSelectedCoupon(item);
            }
        }

        public void OnPriceUpdated(double subtotal,  double grantTotal, double potongan)
        {
            labelSubtotal.Content = "Rp " + subtotal;
            labelGrantTotal.Content = "Rp " + grantTotal;
            labelPromoFee.Content = "Rp " + potongan;
        }

        public void RemoveItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void AddItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void RemoveCouponSucceed()
        {
            listBoxPakaiCoupon.Items.Refresh();
        }

        public void AddCouponSucceed()
        {
            listBoxPakaiCoupon.Items.Refresh();
        }

        private void OnPilihCouponClicked(object sender, RoutedEventArgs e)
        {
            PilihCoupon pilihCouponWindow = new PilihCoupon();
            pilihCouponWindow.SetOnItemSelectedListener(this);
            pilihCouponWindow.Show();
        }

        public void OnPilihCouponChangedListener(Coupon item)
        {
            controller.AddCoupon(item);
        }
    }
}
