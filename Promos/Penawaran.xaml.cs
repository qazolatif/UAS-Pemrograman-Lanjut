using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CashierApp.Controller;
using CashierApp.Model;

namespace CashierApp
{
    /// <summary>
    /// Interaction logic for Penawaran.xaml
    /// </summary>

    public partial class Penawaran : Window
    {
        readonly PenawaranController Penawarancontroller;
        IOnPenawaranChangedListener listener;
        public Penawaran()
        {
            InitializeComponent();

            Penawarancontroller = new PenawaranController();
            listPenawaran.ItemsSource = Penawarancontroller.GetItems();

            GenerateContentPenawaran();

        }

        public void SetOnItemSelectedListener(IOnPenawaranChangedListener listener)
        {
            this.listener = listener;
        }

        private void GenerateContentPenawaran()
        {
            Item drink1 = new Item("Coffee Late", 30000);
            Item drink2 = new Item("Black Tea", 20000);
            Item drink3 = new Item("Milk Shake", 15000);
            Item drink4 = new Item("Watermelon Juice", 25000);
            Item drink5 = new Item("Lemon Squash", 30000);
            Item food1 = new Item("Pizza", 75000);
            Item food2 = new Item("Fried Rice Special", 45000);

            Penawarancontroller.AddItem(drink1);
            Penawarancontroller.AddItem(drink2);
            Penawarancontroller.AddItem(drink3);
            Penawarancontroller.AddItem(drink4);
            Penawarancontroller.AddItem(drink5);
            Penawarancontroller.AddItem(food1);
            Penawarancontroller.AddItem(food2);

            listPenawaran.Items.Refresh();
        }

        private void ListPenawaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;

            this.listener.OnPenawaranSelected(item);
        }
    }

    public interface IOnPenawaranChangedListener
    {
        void OnPenawaranSelected(Item item);
    }
}
