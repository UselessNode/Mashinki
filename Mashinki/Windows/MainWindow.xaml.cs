using Mashinki.EF;
using Mashinki.Seed;
using Mashinki.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Mashinki
{
    public partial class MainWindow : Window
    {
        public RadaEntities Entities { get; set; }

        // 📛 Permition
        public MainWindow(bool admin)
        {
            InitializeComponent();
            TabControl_Tables.SelectedIndex = 0;
            ReadData(1);
            bool AllowEdit = admin;
            if(!AllowEdit)
            {
                Button_CreateRow.IsEnabled = AllowEdit;
                DeleteRowAuto.Visibility = Visibility.Collapsed;
                DeleteRowClient.Visibility = Visibility.Collapsed;
                DeleteRowPurchase.Visibility = Visibility.Collapsed;
                DeleteRowAutoType.Visibility = Visibility.Collapsed;

                EditRowAuto.Visibility = Visibility.Collapsed;
                EditRowClient.Visibility = Visibility.Collapsed;
                EditRowPurchase.Visibility = Visibility.Collapsed;
                EditRowAutoType.Visibility = Visibility.Collapsed;
            }
        }

        // 📝 Creating new rows
        private void Button_CreateRow_Click(object sender, RoutedEventArgs e)
        {
            switch (TabControl_Tables.SelectedIndex)
            {   case 0:
                    AutosForm autosForm = new AutosForm(this);
                    autosForm.ShowDialog();
                    break;
                case 1:
                    ClientsForm clientsForm = new ClientsForm(this);
                    clientsForm.ShowDialog();
                    break;
                case 2:
                    PurchasesForm purchasesForm = new PurchasesForm(this);
                    purchasesForm.ShowDialog();
                    break;
                case 3:
                    AutoTypesForm autoTypesForm = new AutoTypesForm(this);
                    autoTypesForm.ShowDialog();
                    break;
                default:
                    break;
            }


        }

        // 📖 Read data from DB

        private void ReadData(int nothing)
        {
            AutoSeeder autoSeeder = new AutoSeeder();
            AutoTypesSeeder autoTypeSeeder = new AutoTypesSeeder();
            ClientSeeder clientSeeder = new ClientSeeder();
            PurchaseSeeder purchaseSeeder = new PurchaseSeeder();

            Generator gen = new Generator();

            List<Auto> autos = autoSeeder.GetAutos(3);
            List<Client> clients = clientSeeder.GetClients(3);
            List<Purchase> purchases = purchaseSeeder.GetPurchases(autos,clients,3);
            List<AutoTypes> autoTypes = autoTypeSeeder.GetAutoTypes(autos);

            DataGrid_Autos.ItemsSource = autos;
            DataGrid_Clients.ItemsSource = clients;
            DataGrid_Purchases.ItemsSource = purchases;
            DataGrid_AutoTypes.ItemsSource = autoTypes;
            ComboBox_SelectSortType.ItemsSource = autoTypes;
            //List<AutoTypes> autoTypes = gen.GetAutoTypes(5);
        }

        public RadaEntities ReadData()
        {
            Entities = new RadaEntities();
            DataGrid_Autos.ItemsSource = Entities.Auto.ToList();
            DataGrid_Clients.ItemsSource = Entities.Client.ToList();
            DataGrid_Purchases.ItemsSource = Entities.Purchase.ToList();
            DataGrid_AutoTypes.ItemsSource = Entities.AutoTypes.ToList();
            ComboBox_SelectSortType.ItemsSource = Entities.AutoTypes.ToList();
            return Entities;
        }

        // 🔄 Updating row
        private void RowButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (TabControl_Tables.SelectedIndex)
            {
                case 0:
                    Auto rowAuto = (sender as Button).DataContext as Auto;
                    AutosForm autos = new AutosForm(this, rowAuto);
                    autos.ShowDialog();
                    break;
                case 1:
                    Client rowClient = (sender as Button).DataContext as Client;
                    ClientsForm clients = new ClientsForm(this, rowClient);
                    clients.ShowDialog();
                    break;
                case 2:
                    Purchase rowPurchase = (sender as Button).DataContext as Purchase;
                    PurchasesForm purchases = new PurchasesForm(this, rowPurchase);
                    purchases.ShowDialog();
                    break;
                case 3:
                    AutoTypes rowAutoTypes = (sender as Button).DataContext as AutoTypes;
                    AutoTypesForm autoTypesForm = new AutoTypesForm(this, rowAutoTypes);
                    autoTypesForm.ShowDialog();
                    break;
                default:
                    break;
            }
            
        }

        // 🗑 Deleting rows
        private void RowButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            switch (TabControl_Tables.SelectedIndex)
            {
                case 0:
                    Auto rowAuto = (sender as Button).DataContext as Auto;
                    index = rowAuto.Id;
                    Entities.Auto.Remove(rowAuto);
                    break;
                case 1:
                    Client rowClient = (sender as Button).DataContext as Client;
                    index = rowClient.Id;
                    Entities.Client.Remove(rowClient);
                    break;
                case 2:
                    Purchase rowPurchase = (sender as Button).DataContext as Purchase;
                    index = rowPurchase.Id;
                    Entities.Purchase.Remove(rowPurchase);
                    break;
                case 3:
                    AutoTypes autoTypes = (sender as Button).DataContext as AutoTypes;
                    index = autoTypes.Id;
                    Entities.AutoTypes.Remove(autoTypes);
                    break;
                default:
                    break;
            }

            if (MessageBox.Show(
                $"Вы уверены, что хотите удалить запись №{index}",
                "Удаление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Entities.SaveChanges();
            }
            ReadData();

        }

        // 🔎 Search               
        private void TextBox_SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text.ToLower();
            if (String.IsNullOrEmpty(text))
            {
                ReadData();
                return;
            }
            else
                DataGrid_Autos.ItemsSource = Entities.Auto.Where(x=>x.Name.Contains(text)).ToList();

        }

        // 🏷️ Filter
        private void ComboBox_SelectSortType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = ComboBox_SelectSortType.SelectedIndex + 1;
            DataGrid_Autos.ItemsSource = Entities.Auto.Where(x => x.TypeID == filter).ToList();
        }

        private void TabControl_Tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TabControl_Tables.SelectedIndex != 0)
            {
                Label_Search.Visibility = Visibility.Collapsed;
                TextBox_SearchBar.Visibility = Visibility.Collapsed;
                Label_Filter.Visibility = Visibility.Collapsed;
                Button_ResetFilter.Visibility = Visibility.Collapsed;
                ComboBox_SelectSortType.Visibility = Visibility.Collapsed;

            }
            else
            {
                Label_Search.Visibility = Visibility.Visible;
                TextBox_SearchBar.Visibility = Visibility.Visible;
                Label_Filter.Visibility = Visibility.Visible;
                Button_ResetFilter.Visibility = Visibility.Visible;
                ComboBox_SelectSortType.Visibility = Visibility.Visible;
            }

        }

        private void Button_ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectSortType.SelectedIndex = -1;
            ReadData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            WindowAuth auth = new();
            auth.Show();
            Hide();
        }
    }
}
